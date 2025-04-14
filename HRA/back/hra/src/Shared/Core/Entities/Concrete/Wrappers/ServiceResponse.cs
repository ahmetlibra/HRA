using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete.Wrappers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
