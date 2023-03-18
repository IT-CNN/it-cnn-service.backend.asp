using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.UserModels;

public class LoginModel
{
    [Required]
    public string UserName { get; set;} = string.Empty;

    [Required, MinLength(8)]
    public string Password { get; set; } = string.Empty;

    public LoginModel(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public LoginModel()
    {
    }
}
