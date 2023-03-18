using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.UserModels;

public class UserInModel: BaseUserModel
{
    [Required]
    public override string UserName { get; set; } = string.Empty;
    [Required]
    public override string FirstName { get; set; } = string.Empty;
    [Required]
    public override string LastName { get; set; } = string.Empty;
    [Required]
    public override DateTime BirthDate { get; set; }


    public IFormFile? Picture { get; set; }
    [MinLength(8)]
    public string? Password { get; set; } = string.Empty;
}
