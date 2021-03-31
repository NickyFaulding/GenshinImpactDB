using Microsoft.EntityFrameworkCore;

namespace WadApplication.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> AllCharacters { get; set; }
        public DbSet<Weapon> AllWeapons { get; set; }
        public DbSet<Artifact> AllArtifacts { get; set; }
        public DbSet<ArtifactSet> ArtifactSets { get; set; }
    }
}