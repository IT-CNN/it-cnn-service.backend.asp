using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Domain.Exceptions;

public class NotFoundEntityException: Exception
{
    public Dictionary<string, string> Errors { get; set; }

    public NotFoundEntityException(Dictionary<string, string> errors)
    {
        Errors = errors;
    }
}
