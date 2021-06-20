using System;
using System.IO;
using DiariesForPractice.DiaryGenerator.Builders;
using DiariesForPractice.DiaryGenerator.Helpers;
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
            diary.Generated = true;
            diary.GeneratedDate = DateTime.Now;
            diary.Comment = CommentHelper.GenerateComment(practiceData);
            var wordPath = PathHelper.GenerateDocumentPath(practiceData, FormatType.Docx);
            var htmlPath = PathHelper.GenerateDocumentPath(practiceData, FormatType.Html);
            diary.Path = wordPath;
            _diariesEditor.AddOrUpdateDiary(diary);
            SaveDocument(document, wordPath, FormatType.Docx);
            SaveDocument(document, htmlPath, FormatType.Html);
        }

        private void SaveDocument(WordDocument document, string path, FormatType type)
        {
            var memoryStream = new MemoryStream();
            document.Save(memoryStream, type);
            document.Close();
            memoryStream.Position = 0;
            if (type == FormatType.Html)
            {
                var export = new HTMLExport();
                document.SaveOptions.HtmlExportHeadersFooters = true;
                using (var file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    var bytes = new byte[memoryStream.Length];
                    memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                    file.Write(bytes, 0, bytes.Length);
                    export.SaveAsXhtml(document, file);
                }
                
            }
            else
            {
                using (var file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    var bytes = new byte[memoryStream.Length];
                    memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                    file.Write(bytes, 0, bytes.Length);
                }
            }
            memoryStream.Close();
        }
    }
}