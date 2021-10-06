using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }

        // // [Column("Created_at")]
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // public DateTime CreateAt { get; set; }
        //
        // // [Column("Updated_at")]
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // public DateTime UpdatedAt { get; set; }

    }
}
