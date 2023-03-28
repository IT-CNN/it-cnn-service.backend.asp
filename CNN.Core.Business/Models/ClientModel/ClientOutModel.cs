using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.ClientModel;

public class ClientOutModel: ClientInModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public bool IsActive { get; set; }

    public ClientOutModel(Guid id, string name, string phoneNumber, DateTime createdAt, DateTime? updateAt, bool isActive)
        : base(name, phoneNumber)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdateAt = updateAt;
        IsActive = isActive;
    }
}
