using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.CategoryModel;

public class CategoryBaseModel
{
    public virtual string Name { get; set; } = string.Empty;
    public virtual string Description { get; set; } = string.Empty;

    public CategoryBaseModel(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public CategoryBaseModel()
    {
    }
}
