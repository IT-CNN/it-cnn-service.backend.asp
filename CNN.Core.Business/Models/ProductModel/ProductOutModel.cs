using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.ProductModel;

public class ProductOutModel: BaseProduct, IBaseOutModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsActive { get; set; }

    public string Code { get; set; }
    public ICollection<ProductUnitPriceOutModel> Prices { get; set; }
    public ICollection<ProductQuantityOutModel> Quantities { get; set; }
    public ICollection<ProductCategoryOutModel> Categories { get; set; }

    public ProductOutModel(
        Guid id, 
        string name,
        string caseSize,
        DateTime createdAt, 
        DateTime? updateAt, 
        DateTime? deletedAt, 
        bool isActive, 
        string code, 
        ICollection<ProductUnitPriceOutModel> prices,
        ICollection<ProductQuantityOutModel> quantities, 
        ICollection<ProductCategoryOutModel> categories): base(name, caseSize)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdateAt = updateAt;
        DeletedAt = deletedAt;
        IsActive = isActive;
        Code = code;
        Prices = prices;
        Quantities = quantities;
        Categories = categories;
    }
}
