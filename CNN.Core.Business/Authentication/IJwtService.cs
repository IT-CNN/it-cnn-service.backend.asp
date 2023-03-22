using CNN.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Authentication;

public interface IJwtService
{
    string Generate(User user, List<Role> roles);
}
