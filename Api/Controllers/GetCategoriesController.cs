using Application.CategoryService.GetCategories;
using Domain.BaseDto;
using Domain.BaseResponse;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetCategoriesController : ControllerBase
    {
 
        private readonly ILogger<GetCategoriesController> _logger;
        private readonly IGetCategoriesService<GetCategoriesResponse, GetCategoriesRequest> service;

        public GetCategoriesController(ILogger<GetCategoriesController> logger , IGetCategoriesService<GetCategoriesResponse, GetCategoriesRequest> service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet]
        public PaginatedResponse<GetCategoriesResponse> Get()
        {
            return service.Execute(new X { Data = new GetCategoriesRequest { PageIndex = 2, PageSize = 3 } });
        }

        class X : Request<GetCategoriesRequest>
        {
            public GetCategoriesRequest Data { get; set ; }
        }
    }


}