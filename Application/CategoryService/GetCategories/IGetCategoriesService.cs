using Domain.Entities;
using infrastructure.cqrs;

namespace Application.CategoryService.GetCategories
{
    public interface IGetCategoriesService<Rs, Rq> : PaginatedQueriable<Rs, Rq> { } 

}
