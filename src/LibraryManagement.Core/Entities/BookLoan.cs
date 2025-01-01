using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Core.Entities
{
    public class BookLoan : BaseEntity
    {
        [Required(ErrorMessage = "Kitap seçimi zorunludur.")]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [Required(ErrorMessage = "Üye seçimi zorunludur.")]
        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [Required(ErrorMessage = "Alış tarihi zorunludur.")]
        [Display(Name = "Alış Tarihi")]
        [DataType(DataType.Date)]
        public DateTime LoanDate { get; set; }

        [Required(ErrorMessage = "Son teslim tarihi zorunludur.")]
        [Display(Name = "Son Teslim Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }
        public int ExtensionCount { get; set; }
    }
}