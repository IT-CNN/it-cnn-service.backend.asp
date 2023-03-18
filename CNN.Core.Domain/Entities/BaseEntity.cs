using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Domain.Entities;

public class BaseEntity
{
    virtual public Guid Id { get; set; }
    virtual public DateTime CreatedAt { get; set; } = DateTime.Now;
    virtual public DateTime? UpdateAt { get; set; }
    virtual public DateTime? DeletedAt { get; set; }
    virtual public bool IsActivated { get; set; } = true;

    public BaseEntity()
    {
    }
}
