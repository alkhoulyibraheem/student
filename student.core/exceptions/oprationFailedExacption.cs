using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.core.exceptions
{
    public class oprationFailedExacption : Exception
    {
        public oprationFailedExacption() : base("opration Failed") { }
    }
}
