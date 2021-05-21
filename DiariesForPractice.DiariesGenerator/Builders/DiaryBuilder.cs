using System;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;
using Word = Microsoft.Office.Interop.Word;
using Document =  Microsoft.Office.Interop.Word.Document;

namespace DiariesForPractice.DiariesGenerator.Builders
{
    public class DiaryBuilder : IDiaryBuilder
    {
        Word._Application application;
        Word._Document document;
        Object missingObj = System.Reflection.Missing.Value;
        private Object trueObj = true;
        private Object falseObj = false;
        Object templatePathObj = @"C:\d";
        public DiaryBuilder()
        {
            application = new Word.Application();
            
        }
        public Document BuildDiary(PracticeData practiceData)
        {
            
            throw new System.NotImplementedException();
        }

        public void BuildFirstPage(Document document)
        {
            
        }

        public void BuildSecondPage(Document document)
        {
            
        }
        
        public void BuildThirdPage(Document document)
        {
            
        }
        
        public void BuildFourthPage(Document document)
        {
            
        }
        
        public void BuildFifthPage(Document document)
        {
            
        }
        
        public void BuildSixthPage(Document document)
        {
            
        }
        
        public void BuildEighthPage(Document document)
        {
            
        }
    }
}