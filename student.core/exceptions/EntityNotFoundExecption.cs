using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.core.exceptions
{
    public class EntityNotFoundExecption : Exception
    {
        public EntityNotFoundExecption(): base("Item Not Found") { }
    }
}
