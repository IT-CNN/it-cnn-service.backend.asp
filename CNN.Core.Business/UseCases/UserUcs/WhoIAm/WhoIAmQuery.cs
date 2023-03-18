using CNN.Core.Business.Models.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.WhoIAm;

public class WhoIAmQuery: IRequest<UserOutModel>
{
    public string UserName { get; set; } = string.Empty;
}
