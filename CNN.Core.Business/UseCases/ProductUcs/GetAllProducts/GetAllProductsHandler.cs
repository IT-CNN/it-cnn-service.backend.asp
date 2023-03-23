using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ProductUcs.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ICollection<ProductOutModel>>
{
    private readonly IProductRepository _repo;

    public GetAllProductsHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ICollection<ProductOutModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var p = await _repo.GetAllAsync();
        return p.Select(pr => pr.ToModel()).ToList();
    }
}
