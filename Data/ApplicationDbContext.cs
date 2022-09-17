using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using prueba06092022.Models;

namespace prueba06092022.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contacto> DataContactos {get;set;}
    public DbSet<Productos> DataProductos { get; set; }

    public DbSet<Proforma> DataProforma { get; set; }
}
