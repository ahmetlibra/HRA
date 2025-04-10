using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidatorException :Exception
    {
        public ValidatorException() : this("Validation error")
        {
        }
        public ValidatorException(string message) : base(message)
        {
        }
        public ValidatorException(Exception ex) : this(ex.Message)
        {
        }
    }
}
