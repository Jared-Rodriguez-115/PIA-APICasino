using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.Entidades;

namespace WebApiCasino
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RifaParticipante>()
                .HasKey(al => new { al.RifaId, al.ParticipanteId });
        }

        public DbSet<Rifa> Rifas { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Premios> Premios { get; set; }

        public DbSet<Cartas> Cartas { get; set; }
        public DbSet<RifaParticipante> RifasParticipantes { get; set; }

       
    }
}
