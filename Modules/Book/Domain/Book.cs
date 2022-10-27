using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LibraryManagement.Book.Domain
{
    [Table("Book"), MessagePackObject(keyAsPropertyName: true)]
    public class Book
    {
        [Column("Id"), System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Column("Name"), MaxLength(64)]
        public string Name { get; set; } = default!;
        [Column("Author_Id")]
        public int AuthorId { get; set; }
    }
}
