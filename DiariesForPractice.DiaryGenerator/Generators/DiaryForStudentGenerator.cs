﻿using System.IO;
using DiariesForPractice.DiariesGenerator.Builders;
using DiariesForPractice.DiaryGenerator.Builders;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;
using DiariesForPractice.Domain.Services.Diaries;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiaryGenerator.Generators
{
    public class DiaryForStudentGenerator
    {
        private readonly IDiaryBuilder _builder;
        private readonly IDiariesEditorService _diariesEditor;
        private readonly IDiariesReaderService _diariesReader;
        
        public DiaryForStudentGenerator(
            IDiaryBuilder builder,
            IDiariesEditorService diariesEditor,
            IDiariesReaderService diariesReader)
        {
            _builder = builder;
            _diariesEditor = diariesEditor;
            _diariesReader = diariesReader;
        }

        public void Generate(PracticeData practiceData)
        {
            var diaryDocument = _builder.BuildDiary(practiceData);
            AddOrUpdateDiary(practiceData, diaryDocument);
        }

        private void AddOrUpdateDiary(PracticeData practiceData, WordDocument document)
        {
            var diary = practiceData.Diary;
            //todo: дополнить
            diary.Generated = true;
            _diariesEditor.AddOrUpdateDiary(diary);
            var path = GenerateDocumentPath(practiceData);
            SaveDocument(document, path);
        }

        private void SaveDocument(WordDocument document, string path)
        {
            var memoryStream = new MemoryStream();
            document.Save(memoryStream, FormatType.Docx);
            document.Close();
            memoryStream.Position = 0;
            using (var file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var bytes = new byte[memoryStream.Length];
                memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                file.Write(bytes, 0, bytes.Length);
                memoryStream.Close();
            }
        }

        private string GenerateDocumentPath(PracticeData practiceData)
        {
           var path = @$"c:\diaries\";
           path += $@"{practiceData.Institute.Name}";
           AddIfNotExistsDirectory(path);
           path += @$"\{practiceData.Cafedra.Name}";
           AddIfNotExistsDirectory(path);
           path += @$"\{practiceData.Direction.Name}";
           AddIfNotExistsDirectory(path);
           path += @$"\{practiceData.Group.Name}";
           AddIfNotExistsDirectory(path);
           path += @$"\{practiceData.Student.FullName}.docx";

           return path;
        }

        private void AddIfNotExistsDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}