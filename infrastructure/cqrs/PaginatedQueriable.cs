using Domain.BaseDto;
using Domain.BaseResponse;

namespace infrastructure.cqrs
{
    public interface PaginatedQueriable<ResponseType, RequestType>
    { 
         PaginatedResponse<ResponseType> Execute(Request<RequestType> request);
    }
}
