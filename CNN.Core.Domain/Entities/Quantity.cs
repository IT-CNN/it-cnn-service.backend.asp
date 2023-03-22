using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Domain.Entities;

public class Quantity: BaseEntity
{
    public int Value { get; set; }
    public virtual Product Product { get; set; } = null!; 
}
