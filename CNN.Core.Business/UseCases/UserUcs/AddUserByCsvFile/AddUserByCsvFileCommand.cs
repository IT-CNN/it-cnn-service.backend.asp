using CNN.Core.Business.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.AddUserByCsvFile;

public class AddUserByCsvFileCommand: IRequest<ICollection<UserCsvModel>>
{

    [Required]
    public IFormFile File { get; set; } = null!;
    [Required]
    public string Role { get; set; } = null!;
}
