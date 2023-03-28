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

namespace CNN.Core.Business.UseCases.CategoryUcs.AddCategory;

public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, CategoryOutModel>
{
    private readonly ICategoryRepository _repo;

    public AddCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<CategoryOutModel> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        ValidatorBehavior<CategoryInModel>.Validate(request.Model);
        var model = request.Model;
        Category? exist = await _repo.GetAsync(model.Name);
        if (exist is not null) throw new BadRequestException(new Dictionary<string, List<string>> { { "Name", new List<string> { "This category already exist !" } } });

        var category = new Category
        {
            Description = model.Description,
            Name = model.Name,
        };
        await _repo.AddAsync(category);
        category.Products = new List<Product>();

        return category.ToCategoryModel();
    }
}
