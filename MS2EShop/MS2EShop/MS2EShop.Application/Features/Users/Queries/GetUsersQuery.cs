using MediatR;
using MS2EShop.Application.Dtos.Users;
using MS2EShop.Application.Interfaces.Repositories.UsersAndRoles;
using MS2EShop.Domain.Core.Utilities.PagesSettings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MS2EShop.Application.Features.Users.Queries
{
    public record GetUsersQuery(
        Pagable Pagable)
        : IRequest<List<UserDto>>;


    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepo;

        public GetUsersQueryHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        public Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _userRepo.GetAllUser<UserDto>(request.Pagable, cancellationToken);
        }
    }
}
