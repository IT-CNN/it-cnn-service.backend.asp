﻿using CNN.Core.Business.Models.ProductModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ProductUcs.GetProductById;

public class GetProductByIdQuery: IRequest<ProductOutModel>
{
    public Guid Id { get; set; }
}
