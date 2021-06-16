using DiariesForPractice.DiaryGenerator.Helpers;
using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiaryGenerator.Builders.Pages
{
    public static class OrganizationDirectionPage
    {
        public static void AddOrganizationDirectionPage(this IWTable table, PracticeData data)
        {
            table.ResetCells(1, 2);
            AddTravelPermitCertificate(table, data);
            AddOrganizationMark(table, data);
        }
        
        private static void AddOrganizationMark(IWTable table, PracticeData data)
        {
            AddOrganizationMarkTitle(table);
            AddOrganizationMarkBody(table, data);
        }

        private static void AddOrganizationMarkTitle(IWTable table)
        {
            var organizationMarkParagraph = table[0, 0].AddParagraph();
            organizationMarkParagraph.ApplyStyle("boldStyle");
            organizationMarkParagraph.AddLineBreaks(1);
            organizationMarkParagraph.AppendText("ОТМЕТКА ОРГАНИЗАЦИИ");
        }

        private static void AddOrganizationMarkBody(IWTable table, PracticeData data)
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
        
        private static void AddTravelPermitCertificate(IWTable table, PracticeData data)
        {
            AddTravelPermitCertificateTitle(table);
            AddTravelPermitCertificateBody(table, data);
        }
        
        private static  void AddTravelPermitCertificateTitle(IWTable table)
        {
            var titleParagraph = table[0, 0].AddParagraph(); 
            titleParagraph.ApplyStyle("boldStyle");
            titleParagraph.AppendText("ПУТЕВКА-УДОСТОВЕРЕНИЕ");
        }
        
        private static void AddTravelPermitCertificateBody(IWTable table, PracticeData data)
        {
            var bodyParagraph = table[0, 0].AddParagraph();
            bodyParagraph.ApplyStyle("normalStyle");
            bodyParagraph.AppendText($"{data.Student.FullName}");
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText($"Направление подготовки (специльность) {data.Direction.Number} {data.Direction.Name}");
            bodyParagraph.AddLineBreaks(1); 
            bodyParagraph.AppendText($"направляется на практику {data.PracticeDetails.Organization.Name}, юридический адрес: {data.PracticeDetails.Organization.LegalAddress}"); 
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText(@$"с {data.PracticeDetails.StartDate.ToString()} по {data.PracticeDetails.EndDate.ToString()}");
            bodyParagraph.AddLineBreaks(1);
            bodyParagraph.AppendText($"приказ по НИТУ МИСиС от {data.Order.OrderDate} № {data.Order.Number}");
            bodyParagraph.AppendText($"Директор института: {data.Diary.Signatures.DirectorTravelPermitSigned}");
            bodyParagraph.AppendText($"Рук. практики от кафедры: {data.Diary.Signatures.CafedraHeadTravelPermitSigned}");
        }
    }
}