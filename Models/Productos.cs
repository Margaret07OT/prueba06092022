using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba06092022.Models
{

      [Table("t-productos")]
    public class Productos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Descripcion { get; set; }

        public Decimal Precio { get; set; }

        public Decimal PorcentajeDescuento { get; set; }

        public string? ImageName { get; set; }

        public string? Status { get; set; }

    }
}