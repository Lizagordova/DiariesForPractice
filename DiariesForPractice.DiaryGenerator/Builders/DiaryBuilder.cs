using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;
using System.IO;
using DiariesForPractice.DiariesGenerator.Builders.Pages;
using DiariesForPractice.DiaryGenerator.Builders.Pages;
using DiariesForPractice.DiaryGenerator.Helpers;
using Syncfusion.DocIO;

namespace DiariesForPractice.DiaryGenerator.Builders
{
    public class DiaryBuilder : IDiaryBuilder
    {
        public DiaryBuilder()
        {
        }

        public WordDocument BuildDiary(PracticeData data)
        {
            var document = new WordDocument();
            AddStyles(document);
            BuildFirstPage(document, data);
            BuildSecondPage(document, data);
            BuildThirdPage(document, data);
            MemoryStream memoryStream = new MemoryStream();
            document.Save(memoryStream, FormatType.Docx);
            document.Close();
            memoryStream.Position = 0;
            using (FileStream file = new FileStream(@"c:\d\tests\test.docx", FileMode.Create, System.IO.FileAccess.Write))
            {
                byte[] bytes = new byte[memoryStream.Length];
                memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                file.Write(bytes, 0, bytes.Length);
                memoryStream.Close();
            }

            return document;
        }

        private void BuildFirstPage(WordDocument document, PracticeData data)
        {
            var section = CreateSection(document);
            var table = CreateTable(section, 1, 2);
            table.AddTitlePage(data);
            table.AddStudentInfoPage(data);
        }

        private void BuildSecondPage(WordDocument document, PracticeData data)
        {
            var section = CreateSection(document);
            var table = CreateTable(section, 1, 2);
            table.AddOrganizationDirectionPage(data);
            table.AddIndividualTaskPage(data);
        }

        private void BuildThirdPage(WordDocument document, PracticeData data)
        {
            var section = CreateSection(document);
            var table = CreateTable(section, 1, 2);
            table.AddCalendarPlanPage(data);
            table.AddStudentCharactectiristicPage(data);
        }
        
        private IWTable CreateTable(IWSection section, int rows, int columns)
        {
            var table = section.AddTable();
            table.ResetCells(rows, columns);
            table.TableFormat.Borders.BorderType = BorderStyle.Thick;
            table.TableFormat.IsAutoResized = true;

            return table;
        }

        private IWSection CreateSection(WordDocument document)
        {
            var section = document.AddSection();
            section.PageSetup.Orientation = PageOrientation.Landscape;

            return section;
        }

        private void AddStyles(WordDocument document)
        {
            StyleHelper.AddNormalStyle(document);
            StyleHelper.AddTitleStyle(document);
            StyleHelper.AddInstituteNameStyle(document);
            StyleHelper.AddBoldStyle(document);
            StyleHelper.AddCommonDataStyle(document);
            StyleHelper.AddUniversityAddress(document);
        }
    }
}