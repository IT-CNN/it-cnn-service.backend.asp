using CNN.Core.Business.Models.ClientModel;
using MediatR;

namespace CNN.Core.Business.UseCases.ClientUcs.DeleteClient;

public record DeleteClientCommand(Guid Id): IRequest<ClientOutModel>;
