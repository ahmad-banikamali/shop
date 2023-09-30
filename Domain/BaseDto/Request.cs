using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseDto
{
    public interface Request<T>
    {
        T Data { get; set; }  
    }
}
