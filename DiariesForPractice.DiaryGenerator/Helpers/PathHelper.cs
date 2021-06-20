using System.IO;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO;

namespace DiariesForPractice.DiaryGenerator.Helpers
{
    public static class PathHelper
    {
        public static string GenerateDocumentPath(PracticeData practiceData, FormatType type)
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
            path += @$"\{practiceData.Student.FullName}.{GetExtensions(type)}";

            return path;
        }

        private static void AddIfNotExistsDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static string GetExtensions(FormatType type)
        {
            var extension = "";
            if (type == FormatType.Docx)
            {
                extension = "docx";
            }

            if (type == FormatType.Html)
            {
                extension = "html";
            }

            return extension;
        }
    }
}