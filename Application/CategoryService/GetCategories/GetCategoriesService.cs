using Application.Database;
using AutoMapper;
using Domain.Entities;
using infrastructure;
using infrastructure.BaseDto;
using infrastructure.BaseResponse;

namespace Application.CategoryService.GetCategories
{
    public class GetCategoriesService : IGetCategoriesService<GetCategoryItemResponse, GetCategoriesRequest>
    {
        private readonly DatabaseContext database;
        private readonly IMapper mapper;

        public GetCategoriesService(DatabaseContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public PaginatedResponse<GetCategoryItemResponse> Execute(Request<GetCategoriesRequest> request)
        {
            GetCategoriesRequest requestData = request();
            int x = 0;
            var data = database.Categories.AsQueryable();

            return new PaginatedResponse<GetCategoryItemResponse>
            {
                ItemCountInPage = x,
                MaxItemsPerPage = 300,
                PageIndex = requestData.PageIndex,
                Data = data.Select(x => mapper.Map<GetCategoryItemResponse>(x)).ToList(),
            };
        }
    }



}
