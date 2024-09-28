using DarKnightAndJoker.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DarKnightAndJoker.Server.Data
{
    public class DarKnightDbContext : DbContext
    {
        public DarKnightDbContext(DbContextOptions<DarKnightDbContext> options) : base(options) { }
        public DbSet<UsuarioRegistroInicio> UsuariosRegistrosInicios { get; set; }
    }
}
