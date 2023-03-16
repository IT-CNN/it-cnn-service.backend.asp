using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.TestUcs;

public class TestHandler : IRequestHandler<TestQuery, string>
{
    public Task<string> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Test de teste");
    }
}
