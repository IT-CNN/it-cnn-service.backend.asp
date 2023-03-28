using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.CategoryUcs.GetCategory;

public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryOutModel>
{
    private readonly ICategoryRepository _repo;

    public GetCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<CategoryOutModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        Category? category = await _repo.GetAsync(id: request.Id) ?? throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", "This category not exist !"} });
        category.Products = new List<Product>();
        return category.ToCategoryModel();
    }
}
