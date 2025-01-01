using System;
using System.Collections.Generic;

namespace LibraryManagement.Core.Entities
{
    public class Book : BaseEntity
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string Category { get; set; }
        public int CopyCount { get; set; }
        public int AvailableCopies { get; set; }
        public string Description { get; set; }
        public ICollection<BookLoan> BookLoans { get; set; }
    }
}