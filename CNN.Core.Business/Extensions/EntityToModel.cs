using CNN.Core.Business.Models.RoleModel;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Extensions;

public static class EntityToModel
{
    public static UserOutModel ToModel(this User user)
    {
        return new UserOutModel
        {
            Id = user.Id,
            UserName = user.UserName!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            BirthDate = user.BirthDate,
            Picture = user.Picture,
            Roles = user.UserRoles.Select(ur => ur.ToRoleMode()).ToList()
        };
    }

    public static UserAuthOutModel ToAuthModel(this User user, string token)
    {
        return new UserAuthOutModel(
            user.Id,
            user.UserName ?? string.Empty,
            user.BirthDate,
            user.LastName,
            user.LastName,
            user.PhoneNumber,
            user.UserRoles.Select(ur => ur.ToRoleMode()).ToList(),
            user.Picture,
            token
            );
    }

    public static RoleOutModel ToRoleMode(this UserRole userRole)
    {
        return new RoleOutModel(userRole.Role.Id, userRole.Role.Name ?? string.Empty, userRole.Role.LongName);
    }

}
