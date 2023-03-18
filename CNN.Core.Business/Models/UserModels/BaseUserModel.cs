using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.UserModels;

public class BaseUserModel
{
    public virtual string UserName { get; set; } = string.Empty;
    public virtual DateTime BirthDate { get; set; }
    public virtual string FirstName { get; set; } = string.Empty;
    public virtual string LastName { get; set; } = string.Empty;
    public virtual string? PhoneNumber { get; set; } = string.Empty;

    public BaseUserModel()
    {
    }

    public BaseUserModel(string userName, DateTime birthDate, string firstName, string lastName, string? phoneNumber)
    {
        UserName = userName;
        BirthDate = birthDate;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}
