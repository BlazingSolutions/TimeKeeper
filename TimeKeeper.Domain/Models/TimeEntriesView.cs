using System;

#nullable disable

namespace TimeKeeper.Domain.Models
{
    public partial class TimeEntriesView
    {
        public int Id { get; set; }
        public int User { get; set; }
        public decimal Hours { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreated { get; set; }
        public string ClientName { get; set; }
        public string CategoryName { get; set; }
    }
}
