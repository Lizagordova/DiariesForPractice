using DiariesForPractice.DiaryGenerator.Helpers;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiaryGenerator.Builders.Pages
{
    public static class IndividualTaskPage
    {
        public static void AddIndividualTaskPage(this IWTable table, PracticeData data)
        {
            AddIndividualPracticeTaskTitle(table);
            AddIndividualPracticeTaskBody(table, data);
            AddIndividualTasksSignatures(table, data);
        }
        
        private static void AddIndividualPracticeTaskTitle(IWTable table)
        {
            var individualPracticeTaskTitleParagraph = table[0, 1].AddParagraph();
            individualPracticeTaskTitleParagraph.ApplyStyle("boldStyle");
            individualPracticeTaskTitleParagraph.AppendText("ИНДИВИДУАЛЬНОЕ ЗАДАНИЕ НА ПРАКТИКУ");
        }
        
        private static void AddIndividualPracticeTaskBody(IWTable table, PracticeData data)
        {
            var individualPracticeTaskParagraph = table[0, 1].AddParagraph();
            individualPracticeTaskParagraph.ApplyStyle("commonData");//todo: другой, потому что шрифт 10
            individualPracticeTaskParagraph.AppendText($"Содержание индивидуального задания {data.StudentTask.Task}");
            individualPracticeTaskParagraph.AddLineBreaks(2);
            individualPracticeTaskParagraph.AppendText($"Отзыв руководителя практики от кафедры {data.StudentCharacteristic.DescriptionByCafedraHead}");
            individualPracticeTaskParagraph.AddLineBreaks(2);
            individualPracticeTaskParagraph.AppendText($"Оценка выполнения индивидуального задания {data.StudentTask.Mark}");
            individualPracticeTaskParagraph.AddLineBreaks(2);
            individualPracticeTaskParagraph.AppendText("Руководитель практики от кафедры");
            individualPracticeTaskParagraph.AddLineBreaks(2);
        }
        
        private static void AddIndividualTasksSignatures(IWTable table, PracticeData data)
        {
            
        }
    }
}