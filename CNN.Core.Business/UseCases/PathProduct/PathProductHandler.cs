using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.PathProduct;

public class PathProductHandler : IRequestHandler<PathProductCommand, ProductOutModel>
{
    private readonly IProductRepository _repo;

    public PathProductHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ProductOutModel> Handle(PathProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repo.GetByIdAsync(request.Id);
        if (product is null) throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", "This user not exist !"} });
        request.PatchDocument.ApplyTo(product);
        await _repo.UpdateAsync(product);

        return product.ToModel();
    }
}
