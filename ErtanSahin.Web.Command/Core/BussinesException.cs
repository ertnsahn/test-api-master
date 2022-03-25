using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ErtanSahin.Web.Command.Core
{
    public class BussinesException:Exception
    {
        protected BussinesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BussinesException(string message) : base(message)
        {
        }

        public BussinesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
