using Domain.BaseDto;
using Domain.BaseResponse;

namespace infrastructure.cqrs
{
    public interface Queriable<ResponseType, RequestType>
    {

        Response<ResponseType> Execute(Request<RequestType> request);
    }
}
