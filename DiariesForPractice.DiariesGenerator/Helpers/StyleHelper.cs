using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;

namespace DiariesForPractice.DiariesGenerator.Helpers
{
    public static class StyleHelper
    {
        public static void AddNormalStyle(this WordDocument document)
        {
            var style = document.AddParagraphStyle("normal");
            style.CharacterFormat.FontSize = 10f; 
            style.CharacterFormat.FontName = "Times New Roman";
        }
        
        public static void AddTitleStyle(this WordDocument document)
        {
            var style = document.AddParagraphStyle("title");
            style.CharacterFormat.FontSize = 8f;
        }
        
        public static void AddInstituteNameStyle(this WordDocument document)
        {
            var style = document.AddParagraphStyle("instituteName");
            style.CharacterFormat.FontSize = 7f;
            style.CharacterFormat.Bold = true;
        }
        
        public static void AddBoldStyle(this WordDocument document)
        {
            var style = document.AddParagraphStyle("boldStyle");
            style.CharacterFormat.FontSize = 12f;
            style.CharacterFormat.Bold = true;
        }

        public static void AddCommonDataStyle(this WordDocument document)
        {
            var style = document.AddParagraphStyle("commonData");
            style.CharacterFormat.FontSize = 12f;
            style.CharacterFormat.UnderlineStyle = UnderlineStyle.Single;
        }
        
        public static void AddUniversityAddress(this WordDocument document)
        {
            var style = document.AddParagraphStyle("universityAddress");
            style.CharacterFormat.FontSize = 11f;
        }
        
        public static void AddParagraphAlignment(this IWParagraph paragraph, HorizontalAlignment alignment)
        {
            paragraph.ParagraphFormat.HorizontalAlignment = alignment;
        }
        
        
        public static void AddEmptyParagraphs(this IWTable table, int numberParagraphs, int fontSize)
        {
            for (int i = 0; i < numberParagraphs; i++)
            {
                var paragraph = table[0, 0].AddParagraph();
                paragraph.BreakCharacterFormat.FontSize = fontSize;
            }
            
        }
        
        public static void AddLineBreaks(this IWParagraph paragraph, int numberBreaks)
        {
            for (int i = 0; i < numberBreaks; i++)
            {
                paragraph.AppendBreak(BreakType.LineBreak);
            }
        }
    }
}