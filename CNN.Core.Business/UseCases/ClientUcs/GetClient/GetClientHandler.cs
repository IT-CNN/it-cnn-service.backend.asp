using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.ClientModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ClientUcs.GetClient;

public class GetClientHandler : IRequestHandler<GetClientQuery, ClientOutModel>
{
    private readonly IClientRepository _repo;

    public GetClientHandler(IClientRepository repo)
    {
        _repo = repo;
    }

    public async Task<ClientOutModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        Client? client = 
            await _repo.GetAsync(request.Id) 
            ?? throw new NotFoundEntityException(new Dictionary<string, string> { { "Id", "This client not exist !"} });
        return client.ToModel();
    }
}
