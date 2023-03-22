using System.ComponentModel.DataAnnotations;

namespace CNN.Core.Business.Models.ProductModel;

public class ProductInModel: BaseProduct
{
    [Required]
    public override string CaseSize { get => base.CaseSize; set => base.CaseSize = value; }
    [Required]
    public override string Name { get => base.Name; set => base.Name = value; }
    public ICollection<Guid>? CategoriesIds { get; set; }


    [Required, Range(1.0, float.MaxValue)]
    public float InitialUnitPrice { get; set; }
    [Required, Range(1, int.MaxValue)]
    public int InitialQuantity { get; set; }
}
