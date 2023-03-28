using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.ClientModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ClientUcs.GetClients;

public class GetClientsHandler : IRequestHandler<GetClientsQuery, ICollection<ClientOutModel>>
{
    private readonly IClientRepository _repo;

    public GetClientsHandler(IClientRepository repo)
    {
        _repo = repo;
    }

    public async Task<ICollection<ClientOutModel>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        ICollection<Client> clients = await _repo.GetAsync();
        return clients.Select(c => c.ToModel()).ToList();
    }
}
