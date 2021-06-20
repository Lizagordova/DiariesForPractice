using DiariesForPractice.DiaryGenerator.Helpers;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiaryGenerator.Builders.Pages
{
    public static class StudentCharactectiristicPage
    {
        public static void AddStudentCharactectiristicPage(this IWTable table, PracticeData data)
        {
        }
        
        private static void AddStudentCharacteristic(IWTable table, PracticeData data)
        {
            var studentCharacteristicTitleParagraph = table[0, 1].AddParagraph();
            studentCharacteristicTitleParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            studentCharacteristicTitleParagraph.AppendText("Характеристика профессиональной деятельности обучающегося в период прохождения практики");
            var studentCharacteristicParagraph = table[0, 1].AddParagraph();
            studentCharacteristicParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            studentCharacteristicParagraph.ApplyStyle("commonData");
            studentCharacteristicParagraph.AddLineBreaks(2);
            studentCharacteristicParagraph.AppendText($"{data.Student.FullName}");
            studentCharacteristicParagraph.AddLineBreaks(2);
            studentCharacteristicParagraph.AppendText(data.PracticeDetails.StudentCharacteristic.DescriptionByHead);
            var studentCharacteristicFooter = table[0, 1].AddParagraph();
            studentCharacteristicFooter.AppendText("Число пропущенных дней за время практики:");
            studentCharacteristicFooter.AddLineBreaks(2);
            studentCharacteristicFooter.AppendText($"а) по уважительной причине: {data.PracticeDetails.StudentCharacteristic.MissedDaysWithReason}");
            studentCharacteristicFooter.AddLineBreaks(2);
            studentCharacteristicFooter.AppendText($"б) без уважительной причины. {data.PracticeDetails.StudentCharacteristic.MissedDaysWithoutReason}");
        }
        
        
    }
}