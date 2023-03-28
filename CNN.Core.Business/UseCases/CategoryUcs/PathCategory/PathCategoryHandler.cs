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

namespace CNN.Core.Business.UseCases.CategoryUcs.PathCategory;

public class PathCategoryHandler : IRequestHandler<PathCategoryCommand, CategoryOutModel>
{
    private readonly ICategoryRepository _repo;

    public PathCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<CategoryOutModel> Handle(PathCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repo.GetAsync(request.Id) ?? throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", "This category not exist !"} });
        request.PatchDocument.ApplyTo(category);
        await _repo.UpdateAsync(category);

        category.Products = new List<Product>();
        return category.ToCategoryModel();
    }
}
