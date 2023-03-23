using CNN.Core.Business.Models.ProductModel;
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
        return new()
        {
            Id = user.Id,
            UserName = user.UserName!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            BirthDate = user.BirthDate,
            Picture = user.Picture,
            Roles = user.UserRoles.Select(ur => ur.ToRoleMode()).ToList(),
            IsActive = user.IsActivate,
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
            token,
            user.IsActivate
            );
    }
    public static RoleOutModel ToRoleMode(this UserRole userRole)
    {
        return new RoleOutModel(userRole.Role.Id, userRole.Role.Name ?? string.Empty, userRole.Role.LongName);
    }
    public static User ToEntity(this UserCsvModel user)
    {
        return new User()
        {
            UserName = user.UserName ?? string.Empty,
            BirthDate = user.BirthDate ?? DateTime.Now,
            FirstName = user.FirstName ?? string.Empty,
            LastName = user.LastName ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
        };
    }
    public static ProductOutModel ToModel(this Product product) => new
    (
        product.Id,
        product.Name,
        product.CaseSize,
        product.CreatedAt,
        product.UpdateAt,
        product.DeletedAt,
        product.IsActive,
        product.Code,
        product.Prices.Select(p => p.ToModel()).ToList(),
        product.Quantities.Select(p => p.ToModel()).ToList(),
        product.Categories.Select(p => p.ToModel()).ToList()
    );
    public static ProductUnitPriceOutModel ToModel(this UnitPrice unitPrice)
    {
        return new ProductUnitPriceOutModel(
            unitPrice.Id,
            unitPrice.CreatedAt,
            unitPrice.UpdateAt,
            unitPrice.DeletedAt,
            unitPrice.Value
            );
    }
    public static ProductQuantityOutModel ToModel(this Quantity quantity)
    {
        return new ProductQuantityOutModel(
            quantity.Id,
            quantity.CreatedAt,
            quantity.UpdateAt,
            quantity.DeletedAt,
            quantity.Value
            );
    }
    public static ProductCategoryOutModel ToModel(this Category category)
    {
        return new ProductCategoryOutModel(
            category.Id, 
            category.Name,
            category.Description
            );
    }
}
