using System;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;

namespace DiariesForPractice.DiariesGenerator.Builders
{
    public class DiaryBuilder : IDiaryBuilder
    {
        
        public DiaryBuilder()
        {
        }
        
        public WordDocument BuildDiary(PracticeData practiceData)
        {
            var document = new WordDocument();
            BuildFirstPage(document);
            BuildSecondPage(document);
            BuildThirdPage(document);
            BuildFourthPage(document);
            BuildFifthPage(document);
            BuildSixthPage(document);
            BuildSeventhPage(document);
            BuildEighthPage(document);

            return document;
        }

        public void BuildFirstPage(WordDocument document)
        {
            var section = document.AddSection();
            section.PageSetup.Margins.All = 72;
            section.PageSetup.PageSize = new Syncfusion.Drawing.Size(691, 792);
            var style = document.AddParagraphStyle("normal");
            style.CharacterFormat.FontSize = 12f;
            style.CharacterFormat.FontName = "Times New Roman";
            var paragraph = section.HeadersFooters.Header.AddParagraph();
            paragraph.AppendText("МИНИСТЕРСТВО НАУКИ И ВЫСШЕГО ОБРАЗОВАНИЯ РОССИЙСКОЙ ФЕДЕРАЦИИ");
            var imageStream = new FileStream("images/MISIS_logo.PNG", FileMode.Open, FileAccess.Read);
            var picture = paragraph.AppendPicture(imageStream);
            picture.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
            picture.VerticalOrigin = VerticalOrigin.Margin;
            picture.VerticalPosition = -45;
            picture.HorizontalOrigin = HorizontalOrigin.Column;
            picture.HorizontalPosition = 263.5f;
            picture.WidthScale = 20;
            picture.HeightScale = 15;
            
        }

        public void BuildSecondPage(WordDocument document)
        {
            
        }
        
        public void BuildThirdPage(WordDocument document)
        {
            
        }
        
        public void BuildFourthPage(WordDocument document)
        {
            
        }
        
        public void BuildFifthPage(WordDocument document)
        {
            
        }
        
        public void BuildSixthPage(WordDocument document)
        {
            
        }
        
        public void BuildSeventhPage(WordDocument document)
        {
            
        }
        
        public void BuildEighthPage(WordDocument document)
        {
            
        }

        private void AddSectionSettings(WordDocument document)
        {
            
            
        }

        private void AddStyleSettings(WordDocument document)
        {
            var style = document.AddParagraphStyle("normal");
            style.CharacterFormat.FontSize = 12f;
            style.CharacterFormat.FontName = "Times New Roman";
        }
    }
}