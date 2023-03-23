using CNN.Core.Business.Models.ProductModel;
using MediatR;

namespace CNN.Core.Business.UseCases.ProductUcs.GetAllProducts;

public record GetAllProductsQuery: IRequest<ICollection<ProductOutModel>>;