using CNN.Core.Business.Models.RoleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.UserModels;

public class UserOutModel: BaseUserModel
{
    public Guid Id { get; set; }

    public ICollection<RoleOutModel> Roles { get; set; } = null!;
    public virtual string? Picture { get; set; }

    public UserOutModel()
    {
    }

    public UserOutModel(string userName, DateTime birthDate, string firstName, string lastName, string? phoneNumber, Guid id, ICollection<RoleOutModel> roles, string? picture): base(userName, birthDate, firstName, lastName, phoneNumber)
    {
        Id = id;
        Roles = roles;
        Picture = picture;
    }
}
