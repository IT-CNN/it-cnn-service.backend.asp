using CNN.Core.Business.Models.CategoryModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.CategoryUcs.GetCategories;

public record GetCategoriesQuery(): IRequest<ICollection<CategoryOutModel>>;
