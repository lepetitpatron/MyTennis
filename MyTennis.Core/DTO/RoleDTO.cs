namespace MyTennis.Core.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
