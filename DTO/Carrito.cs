using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prueba06092022.Models;
namespace prueba06092022.DTO
{
    public class Carrito
    {
        public  decimal  total { get; set;}
        public List<Proforma> itemsCarrito {get; set;}  
 
 
    }
}