using System;
using System.Collections.Generic;

#nullable disable

namespace TimeKeeper.Domain.Models
{
    public partial class RegionalOffice
    {
        public RegionalOffice()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
