using System;
using System.Collections.Generic;
using System.Text;
using ErtanSahin.Web.Data.Core;

namespace ErtanSahin.Web.Data
{
    public class Member : BaseEntityWithIntIdentity
    {
        public string Email { get; set; }
        public State State { get; set; }
    }
}
