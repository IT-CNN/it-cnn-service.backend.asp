using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Domain.Exceptions;

public class BadRequestException: Exception
{
    public Dictionary<string, List<string>> Errors { get; set; }

    public BadRequestException(Dictionary<string, List<string>> errors)
    {
        Errors = errors;
    }
}
