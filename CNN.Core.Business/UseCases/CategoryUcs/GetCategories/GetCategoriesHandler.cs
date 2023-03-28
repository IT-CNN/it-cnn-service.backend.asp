using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using MediatR;

namespace CNN.Core.Business.UseCases.CategoryUcs.GetCategories;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, ICollection<CategoryOutModel>>
{
    private readonly ICategoryRepository _repo;

    public GetCategoriesHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<ICollection<CategoryOutModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        ICollection<Category> category = await _repo.GetAsync();
        return category.Select(c =>
        {
            c.Products = new List<Product>();
            return c.ToCategoryModel();
        }).ToList();
    }
}
