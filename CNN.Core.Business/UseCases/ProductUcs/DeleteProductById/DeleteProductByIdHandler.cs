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

namespace CNN.Core.Business.UseCases.ProductUcs.DeleteProductById;

public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdCommand, ProductOutModel>
{
    private readonly IProductRepository _repo;

    public DeleteProductByIdHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ProductOutModel> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var product = await _repo.GetByIdAsync(request.Id) ?? throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", "This product not exist !"} });
        await _repo.DeleteAsync(product);
        return product.ToModel();
    }
}
