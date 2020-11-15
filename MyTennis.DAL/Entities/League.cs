using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTennis.DAL.Entities
{
    public class League
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}

