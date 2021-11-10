using MediatR;
using MS2EShop.Application.Interfaces.Repositories.UsersAndRoles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS2EShop.Application.Features.Users.Queries
{
    public record CountUsersQuery()
    : IRequest<int>;

    public class CountUsersQueryHandler : IRequestHandler<CountUsersQuery, int>
    {
        private readonly IUserRepository _userRepo;

        public CountUsersQueryHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }
        public Task<int> Handle(CountUsersQuery request, CancellationToken cancellationToken)
        {
            return _userRepo.GetUsersNumber(cancellationToken);
        }
    }
}
