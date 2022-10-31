using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LibraryManagement.Book.Domain
{
    [Table("Book"), MessagePackObject(keyAsPropertyName: true)]
    public class Book
    {
        [Column("id"), System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Column("name"), MaxLength(64)]
        public string Name { get; set; } = default!;
        [Column("stock")] 
        public int Stock { get; set; }
        [Column ("price")] 
        public float Price { get; set; }

        [Column("category")] 
        public string Category { get; set; } = default!;
        [Column("year")] 
        public int Year { get; set; }
        [Column("Author_Id")]
        public int AuthorId { get; set; }

    }

}
