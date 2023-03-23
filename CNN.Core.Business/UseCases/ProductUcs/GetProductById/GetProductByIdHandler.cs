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

namespace CNN.Core.Business.UseCases.ProductUcs.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductOutModel>
{
    private readonly IProductRepository _repo;

    public GetProductByIdHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ProductOutModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product? product = await _repo.GetByIdAsync(request.Id);
        return product is null
            ? throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", "This user not exist !"} })
            : product.ToModel();
    }
}
