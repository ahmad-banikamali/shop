using Domain.BaseDto;
using Domain.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.cqrs
{
    public interface Executable<Req>
    {
        Response Execute(Request<Req> request);
    }
}
