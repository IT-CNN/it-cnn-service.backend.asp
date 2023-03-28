using CNN.Core.Business.Models.ClientModel;
using CNN.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.ClientUcs.PathClient;

public class PathClientCommand: IRequest<ClientOutModel>
{
    public JsonPatchDocument<Client> PatchDocument { get; set; }
    public Guid Id { get; set; }

    public PathClientCommand(JsonPatchDocument<Client> patchDocument, Guid id)
    {
        PatchDocument = patchDocument;
        Id = id;
    }
}
