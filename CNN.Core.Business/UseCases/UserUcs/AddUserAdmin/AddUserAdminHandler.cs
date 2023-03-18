using CNN.Core.Business.Helpers;
using CNN.Core.Business.Models.UserModels;
using CNN.Core.Business.Repositories;
using CNN.Core.Domain;
using CNN.Core.Domain.Entities;
using MediatR;
using CNN.Core.Business.Extensions;
using CNN.Core.Domain.Exceptions;

namespace CNN.Core.Business.UseCases.UserUcs.AddUserAdmin;

public class AddUserAdminHandler : IRequestHandler<AddUserAdminCommand, UserOutModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IFileHelper _fileHelper;

    public AddUserAdminHandler(IUserRepository userRepository, IFileHelper fileHelper)
    {
        _userRepository = userRepository;
        _fileHelper = fileHelper;
    }

    /// <summary>
    /// Create new admin user
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="BaseException"></exception>
    /// <returns></returns>
    public async Task<UserOutModel> Handle(AddUserAdminCommand request, CancellationToken cancellationToken)
    {
        ValidatorBehavior<UserInModel>.Validate(request.User);

        var admin = request.User;

        string? picture = null;
        if (admin.Picture is not null)
        {
            var result = await _fileHelper.SaveImageToServerAsync(admin.Picture, new[] { "admin", "pictures" });
            picture = result.Item1;
        }

        var user = new User()
        {
            UserName = admin.UserName,
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            PhoneNumber = admin.PhoneNumber,
            BirthDate = admin.BirthDate,
        };
        if (picture != null) user.Picture = picture;

        try
        {
            User created = await _userRepository.AddAsync(user, admin.Password ?? DefaultParams.defaultPwd, AppRoles.ADMIN);

            return created.ToModel();
        }catch(NotFoundEntityException ex)
        {
            if(picture is not null) _fileHelper.DeleteImageToServer(picture);
            throw new NotFoundEntityException(ex.Errors);
        }
    }
}
