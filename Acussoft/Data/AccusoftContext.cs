using Accusoft.Models;
using Microsoft.EntityFrameworkCore;


namespace Accusoft.Data
{
    public class AccusoftContext(DbContextOptions<AccusoftContext> options) : DbContext(options)
    {
        public DbSet<Credor> Credor { get; set; } = default!;
        public DbSet<StatusNota> StatusNota { get; set; } = default!;
        public DbSet<NotaEmitida> NotaEmitida { get; set; } = default!;
    }
}