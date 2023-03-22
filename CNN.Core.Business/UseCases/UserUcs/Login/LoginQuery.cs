using CNN.Core.Business.Models.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.Login;

public class LoginQuery: IRequest<UserAuthOutModel>
{
    public LoginModel Credentials { get; set; }

    public LoginQuery(LoginModel credentials)
    {
        Credentials = credentials;
    }
}
