using CNN.Core.Business.Models.UserModels;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Mapper;

public class UserCsvModelMapper: ClassMap<UserCsvModel>
{
    public UserCsvModelMapper()
    {
        Map(m => m.UserName).Name("username");
        Map(m => m.FirstName).Name("firstname");
        Map(m => m.LastName).Name("lastname");
        Map(m => m.PhoneNumber).Name("phone_number");
        Map(m => m.BirthDate).Name("birth_date");
    }
}
