using CNN.Core.Business.Models.ClientModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ClientUcs.GetClient;

public class GetClientQuery: IRequest<ClientOutModel>
{
    public Guid Id { get; set; }

    public GetClientQuery(Guid id)
    {
        Id = id;
    }
}
