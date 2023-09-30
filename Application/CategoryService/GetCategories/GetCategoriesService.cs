using Domain.BaseDto;
using Domain.BaseResponse;

namespace Application.CategoryService.GetCategories
{
    public class GetCategoriesService : IGetCategoriesService<GetCategoriesResponse, GetCategoriesRequest>
    {
        public PaginatedResponse<GetCategoriesResponse> Execute(Request<GetCategoriesRequest> request)
        {
            var requestData = request.Data;

            return new PaginatedResponse<GetCategoriesResponse>
            {
                ItemCountInPage = requestData.PageSize,
                MaxItemsPerPage = 300,
                PageIndex = requestData.PageIndex,
                Data = new List<GetCategoriesResponse> {
                    new GetCategoriesResponse {Name = "A"},
                    new GetCategoriesResponse {Name = "B"},
                }
            };
        }
    }



}
