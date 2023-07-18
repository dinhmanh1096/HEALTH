namespace HEALTH.Data
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set;}
    }
}
