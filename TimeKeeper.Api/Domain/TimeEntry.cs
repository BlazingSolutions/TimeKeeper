using System;

#nullable disable

namespace TimeKeeper.Api.Domain
{
    public partial class TimeEntry
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Client { get; set; }
        public int Category { get; set; }
        public decimal Hours { get; set; }
        public string Notes { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsAuthorised { get; set; }
        public int? AuthorisedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }

        public virtual Category CategoryNavigation { get; set; }
    }
}
