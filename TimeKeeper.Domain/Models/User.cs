using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeper.Domain.Models
{
    public partial class User
    {
        public User()
        {
            TimeEntries = new HashSet<TimeEntry>();
        }

        public int Id { get; set; }
        public int RegionalOffice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public bool IsManager { get; set; }
        public bool IsExecutive { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }

        public virtual RegionalOffice RegionalOfficeNavigation { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
