using CNN.Core.Business.Models.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.ToggleUserActivationState;

public class ToggleUserActivationStateCommand: IRequest<ICollection<UserOutModel>>
{
    public List<Guid> Ids { get; set; } = null!;
}
