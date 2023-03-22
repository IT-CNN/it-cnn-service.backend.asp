using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Domain.Entities;

public class UnitPrice: BaseEntity
{
    public float Value { get; set; }

    public virtual Product Product { get; set; } = null!;
}
