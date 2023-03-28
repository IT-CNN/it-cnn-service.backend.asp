using CNN.Core.Business.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.CategoryModel;

public class CategoryInModel : CategoryBaseModel
{
    [Required]
    public override string Name { get => base.Name; set => base.Name = value; }
    [Required]
    public override string Description { get => base.Description; set => base.Description = value; }

    public CategoryInModel()
    {
    }

    public CategoryInModel(string name, string description) : base(name, description)
    {
    }

}
