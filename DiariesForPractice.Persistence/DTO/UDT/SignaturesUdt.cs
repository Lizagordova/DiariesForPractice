namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class SignaturesUdt
    {
        public int Id { get; set; }
        public int DiaryId { get; set; }
        public bool DirectorTravelPermitSigned { get; set; }
        public bool CafedraHeadTravelPermitSigned { get; set; }
        public bool ResponsibleForPracticeOrganizationMarkSigned { get; set; }
        public bool CafedraHeadIndividualTaskSigned { get; set; }
        public bool CafedraHeadCalendarPlanSigned { get; set; }
        public bool ResponsibleForPracticeCalendarPlanSigned { get; set; }
        public bool StudentCharacteristicResponsibleForPracticeSigned { get; set; }
    }
}