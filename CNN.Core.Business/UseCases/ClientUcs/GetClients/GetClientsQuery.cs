using CNN.Core.Business.Models.ClientModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ClientUcs.GetClients;

public record GetClientsQuery(): IRequest<ICollection<ClientOutModel>>;
