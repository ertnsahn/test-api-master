using System;
using System.Collections.Generic;
using System.Text;

namespace ErtanSahin.Web.Data.Core
{
    public class BaseEntityWithIntIdentity : BaseEntity<int>
    {

    }
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreateOn { get; set; }=DateTime.Now;
    }
}
