using System;
using System.Collections.Generic;

namespace MyTennis.DAL.Entities
{
    class Member
    {
        public Member()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}