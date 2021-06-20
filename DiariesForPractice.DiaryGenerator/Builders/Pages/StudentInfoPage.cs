using DiariesForPractice.DiaryGenerator.Helpers;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiaryGenerator.Builders.Pages
{
    public static class DiaryGeneratorStudentInfoPage
    {
        public static void AddStudentInfoPage(this IWTable table, PracticeData data)
        {
            AddMainStudentInfo(table, data);
            AddUniversityAddress(table);
        }
        
        private static void AddMainStudentInfo(IWTable table, PracticeData data)
        {
            var studentInfoParagraph = table[0, 1].AddParagraph();
            studentInfoParagraph.ParagraphFormat.LeftIndent = 15;
            studentInfoParagraph.ApplyStyle("commonData");
            studentInfoParagraph.AddLineBreaks(2);
            studentInfoParagraph.AppendText($"Фамилия {data.Student.FirstName}");
            studentInfoParagraph.AddLineBreaks(2);
            studentInfoParagraph.AppendText($"Имя, Отчество {data.Student.SecondName} {data.Student.LastName}");
            studentInfoParagraph.AddLineBreaks(2);
            studentInfoParagraph.AppendText($"Курс {data.Course.Name} Группа {data.Course.Name}");
            studentInfoParagraph.AddLineBreaks(2);
            studentInfoParagraph.AppendText($"Кафедра {data.Cafedra.Name }");
            studentInfoParagraph.AddLineBreaks(2);
            studentInfoParagraph.AppendText($"Институт {data.Institute.Name}");
            studentInfoParagraph.AddLineBreaks(2);
            studentInfoParagraph.AppendText($"Направление подготовки(специальность) { data.Direction.Name}");
            studentInfoParagraph.AddLineBreaks(2);
            studentInfoParagraph.AppendText($"Наименование ОПОП ВО {data.Direction.Number}- {data.Direction.Name} (профиль/специализация");
            studentInfoParagraph.AddLineBreaks(6);
        }
        
        private static void AddUniversityAddress(IWTable table)
        {
            var universityAddressParagraph = table[0, 1].AddParagraph();
            universityAddressParagraph.ParagraphFormat.LeftIndent = 15;
            universityAddressParagraph.AppendText("Адрес НИТУ \"МИСИС\":");
            universityAddressParagraph.ApplyStyle("universityAddress");
            universityAddressParagraph.AppendBreak(BreakType.LineBreak);
            universityAddressParagraph.AppendText("Россия, 119049, г.Москва, Ленинский проспект, д.4");
        }
    }
}