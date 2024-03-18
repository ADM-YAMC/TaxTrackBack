using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class TaxTrackContext : DbContext
    {
        public TaxTrackContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ComprobanteFiscal> comprobanteFiscales { get; set; }
        public DbSet<ContribuyenteFiscal> contribuyentesFiscales { get; set; }
        public DbSet<TipoContribuyente> TipoContribuyentes { get; set; }
        public DbSet<Erros> Erros { get; set; }
    }
}
