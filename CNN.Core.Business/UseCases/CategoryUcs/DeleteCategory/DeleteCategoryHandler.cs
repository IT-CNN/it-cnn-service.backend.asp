using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.CategoryUcs.DeleteCategory;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, CategoryOutModel>
{
    private readonly ICategoryRepository _repo;

    public DeleteCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<CategoryOutModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? exist = await _repo.GetAsync(request.Id);
        if (exist is null) throw new BadRequestException(new Dictionary<string, List<string>> { { "Id", new List<string> { "This category don't exist !" } } });
        await _repo.DeleteAsync(exist);

        exist.Products = new List<Product>();
        return exist.ToCategoryModel();
    }
}
