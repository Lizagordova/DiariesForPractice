using System.IO;
using DiariesForPractice.DiariesGenerator.Helpers;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiariesGenerator.Builders.Pages
{
    public static class TitlePage
    {
        public static void AddTitlePage(this IWTable table, PracticeData data)
        {
            table.AddEmptyParagraphs(1, 12);
            AddHeader(table);
            table.AddEmptyParagraphs(5, 12);
            AddDiaryName(table);
            table.AddEmptyParagraphs(8, 12);
            AddFooter(table);
        }
        
        private static void AddHeader(IWTable table)
        {
            AddMinObrParagraph(table);
            table.AddEmptyParagraphs(1, 10);
            AddFedUchrParagraph(table);
            AddInstituteNameParagraph(table);
            AddInstituteShortnameParagraph(table);
        }
        
        private static void AddMinObrParagraph(IWTable table)
        {
            var minObrParagraph = table[0, 0].AddParagraph();
            minObrParagraph.AppendText("МИНИСТЕРСТВО НАУКИ И ВЫСШЕГО ОБРАЗОВАНИЯ РОССИЙСКОЙ ФЕДЕРАЦИИ");
            minObrParagraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            minObrParagraph.ApplyStyle("normal");
        }
        private static void AddFedUchrParagraph(IWTable table)
        {
            var fedUchrParagraph = table[0, 0].AddParagraph();
            fedUchrParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            fedUchrParagraph.ApplyStyle("title");
            fedUchrParagraph.AppendText("ФЕДЕРАЛЬНОЕ ГОСУДАРСТВЕННОЕ АВТОНОМНОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ ВЫСШЕГО ОБРАЗОВАНИЯ ");
            var imageStream = new FileStream("images/MISIS_logo.PNG", FileMode.Open, FileAccess.Read);
            var picture = fedUchrParagraph.AppendPicture(imageStream);
            picture.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
            picture.VerticalOrigin = VerticalOrigin.Margin;
            picture.VerticalPosition = 25f;
            // picture.HorizontalOrigin = HorizontalOrigin.Column;
            // picture.HorizontalPosition = 263.5f;
            // picture.WidthScale = 20;
            // picture.HeightScale = 15;
        }

        private static void AddInstituteNameParagraph(IWTable table)
        {
            var instituteNameParagraph = table[0, 0].AddParagraph();
            instituteNameParagraph.ApplyStyle("instituteName");
            instituteNameParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            instituteNameParagraph.AppendText("«НАЦИОНАЛЬНЫЙ ИССЛЕДОВАТЕЛЬСКИЙ ТЕХНОЛОГИЧЕСКИЙ УНИВЕРСИТЕТ «МИСиС»");
        }
        
        private static void AddInstituteShortnameParagraph(IWTable table)
        {
            var instituteShortnameParagraph = table[0, 0].AddParagraph();
            instituteShortnameParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            instituteShortnameParagraph.ApplyStyle("instituteName");
            instituteShortnameParagraph.AppendText("(НИТУ «МИСиС»)");
        }
        
        private static void AddDiaryName(IWTable table)
        {
            var diaryNameParagraph = table[0, 0].AddParagraph();
            diaryNameParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            diaryNameParagraph.ApplyStyle("boldStyle");
            diaryNameParagraph.AppendText("ДНЕВНИК ПО ПРАКТИКЕ");
            diaryNameParagraph.AppendBreak(BreakType.LineBreak);
            var diaryTypeParagraph = table[0, 0].AddParagraph();
            diaryTypeParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            diaryTypeParagraph.ApplyStyle("commonData");
            diaryTypeParagraph.AppendText("Производственная");//todo: сюда нужен вид практики
            var endnote = diaryTypeParagraph.AppendFootnote(FootnoteType.Footnote);
            endnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;
            endnote.TextBody.AddParagraph().AppendText("(вид практики)");
        }
        
        private static void AddFooter(IWTable table)
        {
            var paragraph = table[0, 0].AddParagraph();
            paragraph.AddParagraphAlignment(HorizontalAlignment.Center);
            paragraph.BreakCharacterFormat.FontSize = 11f;
            paragraph.AppendText("МОСКВА");
            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.AppendText("2021 г.");
        }
        
        
    }
}