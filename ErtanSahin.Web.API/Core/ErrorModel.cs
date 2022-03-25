using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ErtanSahin.Web.API.Core
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
