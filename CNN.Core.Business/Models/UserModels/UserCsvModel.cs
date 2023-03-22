using CNN.Core.Business.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.UserModels;

public class UserCsvModel: IFileReadable
{
    public Guid? Id { get; set; }
    [Required]
    public string? UserName { get; set; } = string.Empty;
    [Required]
    public DateTime? BirthDate { get; set; }
    [Required]
    public string? FirstName { get; set; } = string.Empty;
    [Required]
    public string? LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public FIleReadStatus Status { get; set; }
    public Dictionary<string, List<string>>? Errors { get; set; }
}
