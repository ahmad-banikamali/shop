using infrastructure.BaseDto;
using infrastructure.BaseResponse;

namespace infrastructure.cqrs
{
    public interface Queriable<ResponseType, RequestType>
    {
         
        Response<ResponseType> Execute(Request<RequestType> request);
    }
}
