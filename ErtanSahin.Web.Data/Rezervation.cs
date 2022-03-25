using System;
using System.Collections.Generic;
using ErtanSahin.Web.Data.Core;

namespace ErtanSahin.Web.Data
{
    public class Rezervation : BaseEntityWithIntIdentity
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime RezervationStart { get; set; }
        public DateTime RezervationEnd { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
    }
}
