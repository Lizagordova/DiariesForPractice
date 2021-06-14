﻿using DiariesForPractice.DiariesGenerator.Helpers;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiariesGenerator.Builders.Pages
{
    public static class CalendarPlanPage
    {
        public static void AddCalendarPlanPage(this IWTable table, PracticeData data)
        {
        }
        
        private static void AddCalendarPlanForPractice(IWTable table, CalendarPlan calendarPlan)
        {
            var internalTable = table[0, 0].AddTable();
            internalTable.ResetCells(21, 3);
            internalTable[0, 0].AddParagraph().AppendText("Сроки работы");
            internalTable[0, 1].AddParagraph().AppendText("Наименование видов работ");
            internalTable[0, 2].AddParagraph().AppendText("Отметка о выполнении");
            var counter = 1;
            foreach (var calendarPlanWeek in calendarPlan.CalendarPlanWeeks)
            {
                internalTable[counter, 0].AddParagraph().AppendText($"{calendarPlanWeek.StartDate}-{calendarPlanWeek.EndDate}");
                internalTable[counter, 1].AddParagraph().AppendText($"{calendarPlanWeek.NameOfTheWork}");
                internalTable[counter, 2].AddParagraph().AppendText($"{calendarPlanWeek.Mark}");
            }
        }
        
        private static void AddSignatures(IWTable table, PracticeData data)
        {
            var signatureParagraph = table[0, 0].AddParagraph();
            signatureParagraph.ApplyStyle("normalStyle");
            signatureParagraph.AddLineBreaks(1);
            signatureParagraph.AppendText("Подпись руководителей практики:");
            signatureParagraph.AddLineBreaks(1);
            signatureParagraph.AppendText("от кафедры:");
            signatureParagraph.AddLineBreaks(1);
            signatureParagraph.AppendText("от профильной организации:");
        }
    }
}