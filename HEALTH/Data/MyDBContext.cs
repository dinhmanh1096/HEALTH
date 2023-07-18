using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<User>()
                .HasOne(e=>e.Workout)
                .WithOne(x=>x.User)
                .HasForeignKey<Workout>(x=>x.WorkoutID);

            modelBuilder.Entity<Workout>(w => 
            {
                w.ToTable("Workout");
                w.HasKey(wo => wo.WorkoutID);
                w.HasOne(wo => wo.sport)
                .WithMany(wo => wo.Workouts)
                .HasForeignKey(wo => wo.SportID)
                .HasConstraintName("FK_Sport_Workout");
            });
        }
    }
}
