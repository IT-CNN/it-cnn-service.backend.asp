using CNN.Core.Business.Extensions;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.ToggleUserActivationState;

public class ToggleUserActivationStateHandler : IRequestHandler<ToggleUserActivationStateCommand, ICollection<UserOutModel>>
{
    private readonly IUserRepository _repo;

    public ToggleUserActivationStateHandler(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<ICollection<UserOutModel>> Handle(ToggleUserActivationStateCommand request, CancellationToken cancellationToken)
    {
        ICollection<User> users = await _repo.GetUsersByIdsAsync(ids: request.Ids);
        if (users.Count != request.Ids.Count) 
            throw new NotFoundEntityException(new Dictionary<string, string> { { "ids", "Some users are not found !"} });

        await _repo.ToggleActivationStateAsync(users);

        return users
            .Select(u => u.ToModel())
            .ToList();
    }
}
