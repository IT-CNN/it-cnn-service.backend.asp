using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.ProductModel;

public class ProductCategoryOutModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ProductCategoryOutModel(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public ProductCategoryOutModel()
    {
    }
}
