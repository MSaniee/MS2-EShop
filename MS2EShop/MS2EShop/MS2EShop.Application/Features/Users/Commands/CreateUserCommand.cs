using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MS2EShop.Application.Interfaces.Repositories.UsersAndRoles;
using MS2EShop.Application.Services.Base;
using MS2EShop.Common.Resources;
using MS2EShop.Domain.Entities.UserAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS2EShop.Application.Features.Users.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string UserName,
    string Password,
    string DateOfBirth,
    string Phone,
    string ProfilePicture,
    Address Address
    )
    : IRequest<SResult<Guid>>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, SResult<Guid>>
{
    private readonly IUserRepository _userRepo;
    private readonly UserManager<User> _userManager;

    public CreateUserCommandHandler(IUserRepository userRepo,
        UserManager<User> userManager)
    {
        ArgumentNullException.ThrowIfNull(userManager);
        ArgumentNullException.ThrowIfNull(userRepo);

        _userRepo = userRepo;
        _userManager = userManager;
    }

    public async Task<SResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepo.UserExists(request.PhoneNumber, request.UserName, cancellationToken))
            SResult.Failure(Memos.UserIsAlreadyRegistered);

        User user = request.Adapt<User>();

        await _userRepo.AddAsync(user, cancellationToken);

        await _userManager.AddToRoleAsync(user, "User");

        return user.Id;
    }
}

