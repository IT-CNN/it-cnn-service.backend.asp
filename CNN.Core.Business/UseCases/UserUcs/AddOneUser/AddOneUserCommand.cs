using CNN.Core.Business.Models.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.AddOneUser;

public class AddOneUserCommand: IRequest<UserOutModel>
{
    public UserInModel User { get; set; } = null!;
    public string Role { get; set; } = string.Empty;
}
