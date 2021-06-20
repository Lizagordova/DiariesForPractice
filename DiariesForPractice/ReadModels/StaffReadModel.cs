﻿using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class StaffReadModel
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PracticeDetailsId { get; set; }
        public StaffRole Role { get; set; }
    }
}