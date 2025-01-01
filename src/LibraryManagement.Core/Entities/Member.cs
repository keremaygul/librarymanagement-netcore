using System;
using System.Collections.Generic;

namespace LibraryManagement.Core.Entities
{
    public class Member : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime MembershipDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BookLoan> BookLoans { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}