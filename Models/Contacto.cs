using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba06092022.Models
{
    [Table("t-contacto")]

    public class Contacto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name {get;set;}

        [Column("email")]
        public string? Email {get;set;}

        [Column("subject")]
        public string? Subject {get; set; } 

        [Column("comment")]
        public string? Comment {get; set; }
        

    }
}