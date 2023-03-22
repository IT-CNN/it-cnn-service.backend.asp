using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ProductUcs.AddProduct;

public class AddProductHandler : IRequestHandler<AddProductCommand, ProductOutModel>
{
    private readonly IProductRepository _repo;
    private readonly ICategoryRepository _categoryRepo;

    public AddProductHandler(IProductRepository repo, ICategoryRepository categoryRepo)
    {
        _repo = repo;
        _categoryRepo = categoryRepo;
    }

    public async Task<ProductOutModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Product? existing = await _repo.GetByNameAsync(request.Model.Name);
        if (existing is not null) throw new BadRequestException(new Dictionary<string, List<string>> { { "Name", new List<string> { "This product already exist !"} } });

        var categoryIds = request.Model.CategoriesIds;
        ICollection<Category>? categories = null;

        if (categoryIds is not null && categoryIds.Count != 0)
        {
            categories = await _categoryRepo.GetManyAsync(categoryIds);
            if (categoryIds.Count != categories.Count) throw new NotFoundEntityException(new Dictionary<string, string> { { "CategoriesIds", "Some of these categories are non-existent" } });
        }

        var product = new Product
        {
            Name = request.Model.Name,
            CaseSize = request.Model.CaseSize,
        };

        var firstPrice = new UnitPrice
        {
            Value = request.Model.InitialUnitPrice
        };

        var firstQuantity = new Quantity
        {
            Value = request.Model.InitialQuantity
        };

        product.Quantities.Add(firstQuantity);
        product.Prices.Add(firstPrice);
        if (categories is not null) product.Categories = categories;

        Product p = await _repo.CreateAsync(product);

        return p.ToModel();
    }
}
