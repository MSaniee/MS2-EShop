using MediatR;
using Microsoft.AspNetCore.Mvc;
using MS2EShop.Application.Dtos.Users;
using MS2EShop.Application.Features.Users.Queries;
using MS2EShop.Application.Utilities.Exceptions;
using MS2EShop.Domain.Core.Utilities.PagesSettings;
using System.Threading;
using System.Threading.Tasks;

namespace MS2EShop.WebSite.Areas.Admin.Controllers;

[Area("Admin")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator.ThrowIfNull();
    }

    public async Task<IActionResult> Index(Pagable pagable, CancellationToken cancellationToken)
    {
        GetUsersQuery getUsersQuery = new(new() { Page = 1, PageSize = 10 });
        CountUsersQuery countUsersQuery = new();

        UsersDto model = new()
        {
            Users = await _mediator.Send(getUsersQuery, cancellationToken),
            Pagination = new(
                pagable: pagable,
                count: await _mediator.Send(countUsersQuery, cancellationToken))
        };

        return View(model);
    }

    //public async Task<IActionResult> Create()
    //{

    //}
}

