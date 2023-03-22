using CNN.Core.Business.Models.ProductModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ProductUcs.AddProduct;

public class AddProductCommand: IRequest<ProductOutModel>
{
    public ProductInModel Model { get; set; }

    public AddProductCommand(ProductInModel model)
    {
        Model = model;
    }
}
