using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.ClientModel;

public class ClientInModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required, MinLength(9)]
    public string PhoneNumber { get; set; } = string.Empty;

    public ClientInModel(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public ClientInModel()
    {
    }
}
