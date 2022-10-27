using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace DatabaseSeeder.Models
{
    [Table("Author"), MessagePackObject(keyAsPropertyName: true)]
    public class Author
    {
        public Author(string name)
        {
            Name = name;
        }

        [Column("Id"), System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Column("Name"), MaxLength(64)]
        public string Name { get; set; }

        [IgnoreMember]
        public List<Book> Books { get; set; } = new();
    }
}
