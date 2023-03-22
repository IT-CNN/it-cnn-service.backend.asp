using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.RoleModel;

public class RoleOutModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LongName { get; set; } = string.Empty;

    public RoleOutModel()
    {
    }

    public RoleOutModel(Guid id, string shortName, string longName)
    {
        Id = id;
        Name = shortName;
        LongName = longName;
    }
}
