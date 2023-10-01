using Application.CategoryService.GetCategories;
using infrastructure.BaseResponse;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetCategoriesController : ControllerBase
    {

        private readonly ILogger<GetCategoriesController> _logger;
        private readonly IGetCategoriesService<GetCategoryItemResponse, GetCategoriesRequest> service;

        public GetCategoriesController(ILogger<GetCategoriesController> logger, IGetCategoriesService<GetCategoryItemResponse, GetCategoriesRequest> service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpPost]
        public PaginatedResponse<GetCategoryItemResponse> Get(GetCategoriesRequest x)
        {
            return service.Execute(() => new GetCategoriesRequest
            {
                PageSize = x.PageSize,
                PageIndex = x.PageIndex,
            });
        }


    }


}