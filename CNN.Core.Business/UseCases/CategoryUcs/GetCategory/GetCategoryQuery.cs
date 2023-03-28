using CNN.Core.Business.Models.CategoryModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.CategoryUcs.GetCategory;

public record GetCategoryQuery(Guid Id): IRequest<CategoryOutModel>;
