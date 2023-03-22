using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Domain.Entities;

public class Product: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = null!;
    public string CaseSize { get; set; } = string.Empty;

    public virtual ICollection<UnitPrice> Prices { get; set; } = new List<UnitPrice>();
    public virtual ICollection<Quantity> Quantities { get; set; } = new List<Quantity>();
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
