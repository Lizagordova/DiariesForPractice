using System;
using System.Collections.Generic;
using System.IO;
using DiariesForPractice.Domain.Handlers;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.GoogleDetail;
using DiariesForPractice.Domain.Services.Students;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace DiariesForPractice.Worker.Services
{
	public class GoogleLoaderService : ILoaderService
	{
		private readonly IGoogleDetailsReaderService _googleDetailsReader;
		private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
		private static readonly string ApplicationName = "DiariesForPractice";
		private static readonly string SpreadSheetId = "1F2uJN_7F6sMse3qD4zhrNZj1Ae_J754Oj_eaj0Wvrqk";
		private static readonly string sheet = "List";
		private static SheetsService _service;
		private readonly IGoogleDataHandler _googleDataHandler;

		public GoogleLoaderService(
			IGoogleDetailsReaderService googleDetailsReaderService,
			IGoogleDataHandler googleDataHandler
			)
		{
			_googleDetailsReader = googleDetailsReaderService;
			_googleDataHandler = googleDataHandler;
			GoogleCredential credential;
			using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
			{
				credential = GoogleCredential.FromStream(stream)
					.CreateScoped(Scopes);
			}
			_service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName
			});
		}

		public IReadOnlyCollection<string> GetData()
		{
			var credentials = _googleDetailsReader.GetGoogleDetails(new GoogleDetailsQuery());
			foreach (var credential in credentials)
			{
				HandleData(credential);
			}

			return new List<string>();
		}

		private void HandleData(GoogleDetails googleDetails)
		{
			var googleData = ReadGoogleData(googleDetails);
			_googleDataHandler.HandlerGoogleData(googleData, googleDetails.GroupId);
		}

		private IReadOnlyCollection<GoogleStudentPracticeData> ReadGoogleData(GoogleDetails googleDetails)
		{
			var range = $"{googleDetails.SheetName}!{googleDetails.FirstCell}:{googleDetails.LastCell}";
			var request = _service.Spreadsheets.Values.Get(googleDetails.SpreadSheetId, range);

			var response = request.Execute();
			var values = response.Values;
			
			var studentPracticeDataList = new List<GoogleStudentPracticeData>();
			if (values != null && values.Count > 0)
			{
				foreach (var row in values)
				{
					var studentPracticeData = new GoogleStudentPracticeData
					{
						FullName = row[1].ToString(),
					};
					studentPracticeDataList.Add(studentPracticeData);
				}
			}
			else
			{
				Console.WriteLine("No data was found");
			}

			return studentPracticeDataList;
		}

		private void CreateEntry()
		{
			var range = $"{sheet}A:F";
			var valueRange = new ValueRange();

			var objectList = new List<object>() {"Hello!", "This", "Was", "inserted", "via", "C# "};
			valueRange.Values = new List<IList<object>>() { objectList };

			var appendRequest = _service.Spreadsheets.Values.Append(valueRange, SpreadSheetId, range);
			appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
			var appendResponse = appendRequest.Execute();
		}

		private void UpdateEntry()
		{
			var range = $"{sheet}!D543";
			var valueRange = new ValueRange();

			var objectList = new List<object>() {"updated"};
			valueRange.Values = new List<IList<object>>() { objectList };

			var updateRequest = _service.Spreadsheets.Values.Update(valueRange, SpreadSheetId, range);
			//updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
			var updateResponse = updateRequest.Execute();
		}
	}
}