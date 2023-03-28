using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Business.Models.ProductModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.CategoryUcs.AddCategory;

public class AddCategoryCommand: IRequest<CategoryOutModel>
{
    public CategoryInModel Model { get; set; } = null!;

    public AddCategoryCommand(CategoryInModel categoryInModel)
    {
        Model = categoryInModel;
    }

    public AddCategoryCommand()
    {
    }
}
