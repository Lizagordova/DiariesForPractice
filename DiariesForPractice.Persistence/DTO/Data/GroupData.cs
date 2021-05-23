﻿using System.Collections.Generic;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.DTO.Data
{
    public class GroupData
    {
        public IReadOnlyCollection<GroupUdt> Groups { get; set; }
        public IReadOnlyCollection<GroupDetailsUdt> GroupsDetails { get; set; }
        public IReadOnlyCollection<StudentGroupUdt> StudentGroups { get; set; }
        public IReadOnlyCollection<UserUdt> Students { get; set; }
    }
}