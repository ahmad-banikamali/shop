using infrastructure.BaseDto;
using infrastructure.BaseResponse;

namespace infrastructure.cqrs
{
    public interface PaginatedQueriable<ResT, ReqT>
    { 
         PaginatedResponse<ResT> Execute(Request<ReqT> request);
    }
}
