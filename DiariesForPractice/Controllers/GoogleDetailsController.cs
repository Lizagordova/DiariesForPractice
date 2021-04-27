using System;
using System.Linq;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.GoogleDetail;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiariesForPractice.Controllers
{
	public class GoogleDetailsController : Controller
	{
		private readonly IGoogleDetailsEditorService _googleDetailsEditor;
		private readonly IGoogleDetailsReaderService _googleDetailsReader;
		private readonly MapperService _mapper;
		
		public GoogleDetailsController(
			IGoogleDetailsEditorService googleDetailsEditor,
			IGoogleDetailsReaderService googleDetailsReader,
			MapperService mapper)
		{
			_googleDetailsEditor = googleDetailsEditor;
			_googleDetailsReader = googleDetailsReader;
			_mapper = mapper;
		}

		[HttpPost]
		[Route("/addorupdategoogledetails")]
		public ActionResult AddOrUpdateGoogleDetails([FromBody]GoogleDetailsReadModel googleDetailsReadModel)
		{
			try
			{
				var googleDetails = _mapper.Map<GoogleDetailsReadModel, GoogleDetails>(googleDetailsReadModel);
				googleDetails.Id = _googleDetailsEditor.AddOrUpdateGoogleDetails(googleDetails);

				return new OkResult();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);//todo: СЮДА

				return new StatusCodeResult(500);
			}
		}

		[HttpPost]
		[Route("/getgoogledetailsbygroup")]
		public ActionResult GetGoogleDetails([FromBody]GoogleDetailsReadModel googleDetailsReadModel)
		{
			try
			{
				var query = new GoogleDetailsQuery()
				{
					GroupId = googleDetailsReadModel.GroupId
				};
				var googleDetails = _googleDetailsReader.GetGoogleDetails(query);
				var googleDetailsViewModels = googleDetails.Select(_mapper.Map<GoogleDetails, GoogleDetailsViewModel>).ToList();

				return new JsonResult(googleDetailsViewModels);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);//todo: СЮДА

				return new StatusCodeResult(500);
			}
		}
	}
}