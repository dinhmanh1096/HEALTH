using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HEALTH.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        #region Dbset   
        public DbSet<Role>? Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>(e =>
            {
                e.ToTable("Sport");
                e.HasKey(sp => sp.SportID);
            });

            modelBuilder.Entity<Role>(r => 
            {
                r.ToTable("Role");
                r.HasKey(rl => rl.RoleID);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.UserID);
                entity.HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleID)
                .HasConstraintName("FK_role_user");

                
                
            });
            

            modelBuilder.Entity<Workout>(w => 
            {
                w.ToTable("Workout");
                w.HasKey(e => e.WorkoutID);

                w.HasOne(e => e.sport)
                .WithMany(e => e.Workouts)
                .HasForeignKey(e => e.SportID)
                .HasConstraintName("FK_Sport_Workout");

                w.HasOne(e => e.user)
                .WithMany(e => e.Workouts)
                .HasForeignKey(e => e.UserID)
                .HasConstraintName("Fk_user_workout");
            });
        }
    }
}
