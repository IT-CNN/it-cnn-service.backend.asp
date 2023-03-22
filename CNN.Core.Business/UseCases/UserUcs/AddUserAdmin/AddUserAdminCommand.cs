using CNN.Core.Business.Models.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.AddUserAdmin;

public class AddUserAdminCommand: IRequest<UserOutModel>
{
    public UserInModel User { get; set; } = null!;
}
