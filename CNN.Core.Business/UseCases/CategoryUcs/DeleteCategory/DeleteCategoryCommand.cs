﻿using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Business.Models.ProductModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.CategoryUcs.DeleteCategory;

public record DeleteCategoryCommand(Guid Id): IRequest<CategoryOutModel>;
