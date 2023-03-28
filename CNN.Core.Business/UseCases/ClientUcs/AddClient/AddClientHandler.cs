using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.ClientModel;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ClientUcs.AddClient;

public class AddClientHandler : IRequestHandler<AddClientCommand, ClientOutModel>
{
    private readonly IClientRepository _repo;

    public AddClientHandler(IClientRepository repo)
    {
        _repo = repo;
    }

    public async Task<ClientOutModel> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        ValidatorBehavior<ClientInModel>.Validate(request.Model);
        Client? existing = await _repo.GetAsync(request.Model.Name, request.Model.PhoneNumber);
        Dictionary<string, string> errors = new Dictionary<string, string>();

        if (existing is not null && existing.Name == request.Model.Name)
            errors.Add("Name", "This client already exist !");
        if (existing is not null && existing.PhoneNumber == request.Model.PhoneNumber)
            errors.Add("PhoneNumber", "This phone number already exist !");

        if (errors.Count > 0) throw new NotFoundEntityException(errors);

        Client client = new()
        {
            Name = request.Model.Name,
            PhoneNumber = request.Model.PhoneNumber,
        };
        await _repo.CreateAsync(client);
        return client.ToModel();
    }
}
