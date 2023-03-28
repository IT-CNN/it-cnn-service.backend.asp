using CNN.Core.Business.Models.RoleModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.RoleUcs.GetRoleById;

public record GetRoleByIdQuery(Guid Id): IRequest<RoleOutModel>;
