using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.ProductModel;

public class ProductQuantityOutModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public float Value { get; set; }

    public ProductQuantityOutModel(
        Guid id, 
        DateTime createdAt, 
        DateTime? updateAt, 
        DateTime? deletedAt, 
        float value)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdateAt = updateAt;
        DeletedAt = deletedAt;
        Value = value;
    }
}
