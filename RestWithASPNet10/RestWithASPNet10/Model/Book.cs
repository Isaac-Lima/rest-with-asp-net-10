using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestWithASPNet10.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RestWithASPNet10.Model
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        [Column("title", TypeName = "varchar(MAX)")]
        public string Title { get; set; } 

        [Column("author", TypeName = "varchar(MAX)")]
        public string Author { get; set; }

        [Required()]
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required()]
        [Column("launch_date", TypeName = "datetime2(6)")]
        public DateTime LaunchDate { get; set; }

    }
}
