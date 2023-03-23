using CNN.Core.Business.Models.ProductModel;
using CNN.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.PathProduct;

public class PathProductCommand: IRequest<ProductOutModel>
{
    public JsonPatchDocument<Product> PatchDocument { get; set; }
    public Guid Id { get; set; }

    public PathProductCommand(Guid id, JsonPatchDocument<Product> patchDocument)
    {
        PatchDocument = patchDocument;
        Id = id;
    }
}
