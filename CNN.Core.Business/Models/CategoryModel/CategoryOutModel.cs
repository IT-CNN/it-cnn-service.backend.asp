using CNN.Core.Business.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.CategoryModel;

public class CategoryOutModel: CategoryBaseModel
{

    public Guid Id { get; set; }
    public ICollection<ProductOutModel>? Products { get; set; }

    public CategoryOutModel(Guid id, string name, string description, ICollection<ProductOutModel>? products) : base(name, description)
    {
        Id = id;
        Products = products;
    }
}
