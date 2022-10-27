using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LibraryManagement.Author.Domain
{
    [Table("Author"), MessagePackObject(keyAsPropertyName: true)]
    public class Author
    {
        [Column("Id"), System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Column("Name"), MaxLength(64)]
        public string Name { get; set; }
    }
}