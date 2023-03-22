using CNN.Core.Business.Models.RoleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.UserModels;

public class UserAuthOutModel: UserOutModel
{
    public string Token { get; set; } = string.Empty;

    public UserAuthOutModel()
    {
    }

    public UserAuthOutModel(Guid id, string userName, DateTime birthDate, string firstName, string lastName, string? phoneNumber, ICollection<RoleOutModel> roles, string? picture, string token, bool isActive)
        : base(userName, birthDate, firstName, lastName, phoneNumber, id, roles, picture, isActive)
    {
        Token = token;
    }
}
