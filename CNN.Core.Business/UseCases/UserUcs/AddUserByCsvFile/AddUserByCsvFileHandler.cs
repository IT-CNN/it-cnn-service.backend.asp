using CNN.Core.Business.Extensions;
using CNN.Core.Business.Helpers;
using CNN.Core.Business.Mapper;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain.Entities;
using CNN.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.UserUcs.AddUserByCsvFile;

public class AddUserByCsvFileHandler : IRequestHandler<AddUserByCsvFileCommand, ICollection<UserCsvModel>>
{

    private readonly IFileHelper _fileHelper;
    private readonly IUserRepository _userRepository;

    public AddUserByCsvFileHandler(IFileHelper fileHelper, IUserRepository userRepository)
    {
        _fileHelper = fileHelper;
        _userRepository = userRepository;
    }

    public async Task<ICollection<UserCsvModel>> Handle(AddUserByCsvFileCommand request, CancellationToken cancellationToken)
    {
        var dataExtract =
            _fileHelper.ReadCsvFile<UserCsvModel, UserCsvModelMapper>(request.File);
        foreach(var item in dataExtract)
        {
            try
            {
                ValidatorBehavior<UserCsvModel>.Validate(item);
            }catch(BadRequestException ex)
            {
                item.Status = FIleReadStatus.Invalid;
                item.Errors = ex.Errors;
            }
        }
        ICollection<UserCsvModel> usersCsv = await _userRepository.AddManyByCsvAsync(dataExtract, role: request.Role);

        return usersCsv;
    }
}
