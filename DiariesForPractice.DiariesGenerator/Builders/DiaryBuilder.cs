using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;
using System.IO;
using DiariesForPractice.DiariesGenerator.Helpers;
using Syncfusion.DocIO;
using Syncfusion.Drawing;

namespace DiariesForPractice.DiariesGenerator.Builders
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
            BuildFirstCellFirstPage(table);
            BuildSecondCellFirstPage(table, data);
        }

        private void BuildSecondPage(WordDocument document, PracticeData data)
        {
            var section = CreateSection(document);
            var table = CreateTable(section, 1, 2);
            BuildFirstCellSecondPage(table, data);
            BuildSecondCellSecondPage(table, data);
        }

        private void BuildThirdPage(WordDocument document, PracticeData data)
        {
            var section = CreateSection(document);
            var table = CreateTable(section, 1, 2);
            BuildFirstCellThirdPage(table, data);
            BuildSecondCellThirdPage(table, data);
        }

        private void BuildFirstCellFirstPage(IWTable table)
        {
            table.AddEmptyParagraphs(1, 12);
            AddHeader(table);
            table.AddEmptyParagraphs(5, 12);
            AddDiaryName(table);
            table.AddEmptyParagraphs(8, 12);
            AddFooter(table);
        }

        private void BuildSecondCellFirstPage(IWTable table, PracticeData data)
        {
            var paragraph = table[0, 1].AddParagraph();
            paragraph.AddParagraphAlignment(HorizontalAlignment.Center);
            AddMainStudentInfo(table, data);
            paragraph.AddLineBreaks(5);
            AddUniversityAddress(table);
        }

        public void BuildFirstCellSecondPage(IWTable table, PracticeData data)
        {
            table.ResetCells(1, 2);
            AddTravelPermitCertificate(table, data);
            AddOrganizationMark(table, data);
        }

        public void BuildSecondCellSecondPage(IWTable table, PracticeData data)
        {
            var paragraph = table[0, 1].AddParagraph();
            AddIndividualPracticeTask(table, data);
        }

        public void BuildFirstCellThirdPage(IWTable table, PracticeData data)
        {
            AddCalendarPlanForPractice(table, data);
        }

        public void BuildSecondCellThirdPage(IWTable table, PracticeData data)
        {
            var paragraph = table[0, 1].AddParagraph();
            AddStudentCharacteristic(table, data);
        }

        private void AddHeader(IWTable table)
        {
            AddMinObrParagraph(table);
            table.AddEmptyParagraphs(1, 10);
            AddFedUchrParagraph(table);
            AddInstituteNameParagraph(table);
            AddInstituteShortnameParagraph(table);
        }

        private void AddMinObrParagraph(IWTable table)
        {
            var minObrParagraph = table[0, 0].AddParagraph();
            minObrParagraph.AppendText("МИНИСТЕРСТВО НАУКИ И ВЫСШЕГО ОБРАЗОВАНИЯ РОССИЙСКОЙ ФЕДЕРАЦИИ");
            minObrParagraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            minObrParagraph.ApplyStyle("normal");
        }
        private void AddFedUchrParagraph(IWTable table)
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

        private void AddInstituteNameParagraph(IWTable table)
        {
            var instituteNameParagraph = table[0, 0].AddParagraph();
            instituteNameParagraph.ApplyStyle("instituteName");
            instituteNameParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            instituteNameParagraph.AppendText("«НАЦИОНАЛЬНЫЙ ИССЛЕДОВАТЕЛЬСКИЙ ТЕХНОЛОГИЧЕСКИЙ УНИВЕРСИТЕТ «МИСиС»");
        }
        
        private void AddInstituteShortnameParagraph(IWTable table)
        {
            var instituteShortnameParagraph = table[0, 0].AddParagraph();
            instituteShortnameParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            instituteShortnameParagraph.ApplyStyle("instituteName");
            instituteShortnameParagraph.AppendText("(НИТУ «МИСиС»)");
        }
        
        private void AddDiaryName(IWTable table)
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

        private void AddFooter(IWTable table)
        {
            var paragraph = table[0, 0].AddParagraph();
            paragraph.AddParagraphAlignment(HorizontalAlignment.Center);
            paragraph.BreakCharacterFormat.FontSize = 11f;
            paragraph.AppendText("МОСКВА");
            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.AppendText("2021 г.");
        }

        private void AddMainStudentInfo(IWTable table, PracticeData data)
        {
            var studentInfoParagraph = table[0, 1].AddParagraph();
            studentInfoParagraph.ApplyStyle("commonData");
            studentInfoParagraph.AddLineBreaks(1);
            studentInfoParagraph.AppendText($"Фамилия {data.Student.FirstName}");
            studentInfoParagraph.AddLineBreaks(1);
            studentInfoParagraph.AppendText($"Имя, Отчество {data.Student.SecondName} {data.Student.LastName}");
            studentInfoParagraph.AddLineBreaks(1);
            studentInfoParagraph.AppendText($"Курс {data.Course.Name} Группа {data.Course.Name}");
            studentInfoParagraph.AddLineBreaks(1);
            studentInfoParagraph.AppendText($"Кафедра {data.Cafedra.Name }");
            studentInfoParagraph.AddLineBreaks(1);
            studentInfoParagraph.AppendText($"Институт {data.Institute.Name}");
            studentInfoParagraph.AddLineBreaks(1);
            studentInfoParagraph.AppendText($"Направление подготовки(специальность) { data.Direction.Name}");
            studentInfoParagraph.AddLineBreaks(1);
            studentInfoParagraph.AppendText($"Наименование ОПОП ВО {data.Direction.Number}- {data.Direction.Name} (профиль/специализация");
            studentInfoParagraph.AddLineBreaks(6);
        }
        
        private void AddTravelPermitCertificate(IWTable table, PracticeData data)
        {
            AddTravelPermitCertificateTitle(table);
            AddTravelPermitCertificateBody(table, data);
        }

        private void AddTravelPermitCertificateTitle(IWTable table)
        {
            var titleParagraph = table[0, 0].AddParagraph();
            titleParagraph.ApplyStyle("boldStyle");
            titleParagraph.AppendText("ПУТЕВКА-УДОСТОВЕРЕНИЕ");
        }

        private void AddTravelPermitCertificateBody(IWTable table, PracticeData data)
        {
            var bodyParagraph = table[0, 0].AddParagraph();
            bodyParagraph.ApplyStyle("normalStyle");
            bodyParagraph.AppendText($"Обучающийся {data.Course.Name}-го курса, группы {data.Group.Name}, института {data.Institute.Name}");
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText($"{data.Student.FullName}");
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText($"Направление подготовки (специльность) {data.Direction.Number} {data.Direction.Name}");
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText($"направляется на практику {data.PracticeDetails.Organization.Name}, юридический адрес: {data.PracticeDetails.Organization.LegalAddress}");
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText(@$"с {data.PracticeDetails.StartDate.ToString()} по {data.PracticeDetails.EndDate.ToString()}");
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText($"приказ по НИТУ МИСиС от {data.Order.OrderDate} № {data.Order.Number}");
            bodyParagraph.AppendText("Директор института: ПОДПИСЬ");
            bodyParagraph.AppendText("Рук. практики от кафедры: ПОДПИСЬ");
        }
        private void AddUniversityAddress(IWTable table)
        {
            var universityAddressParagraph = table[0, 1].AddParagraph();
            universityAddressParagraph.AppendText("Адрес НИТУ \"МИСИС\":");
            universityAddressParagraph.ApplyStyle("universityAddress");
            universityAddressParagraph.AppendBreak(BreakType.LineBreak);
            universityAddressParagraph.AppendText("Россия, 119049, г.Москва, Ленинский проспект, д.4");
        }

        private void AddStudentCharacteristic(IWTable table, PracticeData data)
        {
            var studentCharacteristicTitleParagraph = table[0, 1].AddParagraph();
            studentCharacteristicTitleParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            studentCharacteristicTitleParagraph.AppendText("Характеристика профессиональной деятельности обучающегося в период прохождения практики");
            var studentCharacteristicParagraph = table[0, 1].AddParagraph();
            studentCharacteristicParagraph.AddParagraphAlignment(HorizontalAlignment.Center);
            studentCharacteristicParagraph.ApplyStyle("commonData");
            studentCharacteristicParagraph.AddLineBreaks(1);
            studentCharacteristicParagraph.AppendText($"{data.Student.FullName}");
            studentCharacteristicParagraph.AddLineBreaks(2);
            studentCharacteristicParagraph.AppendText(data.PracticeDetails.StudentCharacteristic.DescriptionByHead);
            var studentCharacteristicFooter = table[0, 1].AddParagraph();
            studentCharacteristicFooter.AppendText("Число пропущенных дней за время практики:");
            studentCharacteristicFooter.AddLineBreaks(1);
            studentCharacteristicFooter.AppendText($"а) по уважительной причине: {data.PracticeDetails.StudentCharacteristic.MissedDaysWithReason}");
            studentCharacteristicFooter.AddLineBreaks(1);
            studentCharacteristicFooter.AppendText($"б) без уважительной причины. {data.PracticeDetails.StudentCharacteristic.MissedDaysWithoutReason}");
        }

        
        
        private void AddOrganizationMark(IWTable table, PracticeData data)
        {
            AddOrganizationMarkTitle(table);
            AddOrganizationMarkBody(table, data);
        }

        private void AddOrganizationMarkTitle(IWTable table)
        {
            var organizationMarkParagraph = table[0, 0].AddParagraph();
            organizationMarkParagraph.ApplyStyle("boldStyle");
            organizationMarkParagraph.AddLineBreaks(1);
            organizationMarkParagraph.AppendText("ОТМЕТКА ОРГАНИЗАЦИИ");
        }

        private void AddOrganizationMarkBody(IWTable table, PracticeData data)
        {
            var organizationMarkBodyParagraph = table[0, 0].AddParagraph();
            organizationMarkBodyParagraph.ApplyStyle("normalStyle");
            organizationMarkBodyParagraph.AppendText($"Дата прибытия обучающегося в организацию {data.PracticeDetails.StartDate.ToString()}");
            organizationMarkBodyParagraph.AddLineBreaks(1);
            organizationMarkBodyParagraph.AppendText($"Направлен(а) в структурное подразделение {data.PracticeDetails.StructuralDivision}.");
            organizationMarkBodyParagraph.AddLineBreaks(1);
            organizationMarkBodyParagraph.AppendText("Приказ о прохождении практики в профильной организации от ... диюля 2020 ш. №1223");
            organizationMarkBodyParagraph.AddLineBreaks(1);
            organizationMarkBodyParagraph.AppendText($"Дата окончания практики {data.PracticeDetails.EndDate}");
            organizationMarkBodyParagraph.AddLineBreaks(1);
            organizationMarkBodyParagraph.AppendText("Руководитель от профильной организации");
            organizationMarkBodyParagraph.AddLineBreaks(1);
            organizationMarkBodyParagraph.AppendText($"{data.PracticeDetails.ResponsibleForStudent.Job}");
            organizationMarkBodyParagraph.AddLineBreaks(1);
            organizationMarkBodyParagraph.AppendText($"Подпись {data.PracticeDetails.ResponsibleForStudent.FullName}");
        }
        
        private void AddIndividualPracticeTask(IWTable table, PracticeData data)
        {
            var individualPracticeTaskTitleParagraph = table[0, 1].AddParagraph();
            individualPracticeTaskTitleParagraph.ApplyStyle("boldStyle");
            individualPracticeTaskTitleParagraph.AppendText("ИНДИВИДУАЛЬНОЕ ЗАДАНИЕ НА ПРАКТИКУ");
            var individualPracticeTaskParagraph = table[0, 1].AddParagraph();
            individualPracticeTaskParagraph.ApplyStyle("commonData");//todo: другой, потому что шрифт 10
            individualPracticeTaskParagraph.AppendText($"Содержание индивидуального задания {data.StudentTask.Task}");
            individualPracticeTaskParagraph.AddLineBreaks(2);
            individualPracticeTaskParagraph.AppendText($"Отзыв руководителя практики от кафедры {data.StudentCharacteristic.DescriptionByCafedraHead}");
            individualPracticeTaskParagraph.AddLineBreaks(2);
            individualPracticeTaskParagraph.AppendText($"Оценка выполнения индивидуального задания {data.StudentTask.Mark}");
            individualPracticeTaskParagraph.AddLineBreaks(2);
            individualPracticeTaskParagraph.AppendText("подпись");
        }
        
        private void AddCalendarPlanForPractice(IWTable table, PracticeData data)
        {
           /* var section = CreateSection(document);
            var table = CreateTable(section, 17, 3);
            table[0, 0].AddParagraph().AppendText("Сроки работы");
            table[0, 1].AddParagraph().AppendText("Наименование видов работ");
            table[0, 2].AddParagraph().AppendText("Отметка о выполнении");*/
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