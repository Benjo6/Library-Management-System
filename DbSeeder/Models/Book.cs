using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSeeder.Models
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

        public Book(string name, int authorId)
        {
            Name = name;
            AuthorId = authorId;
        }

        [IgnoreMember]
        public Author Author { get; set; } = null!;
    }
}
