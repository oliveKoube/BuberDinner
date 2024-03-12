using BuberDinner.Application.Menus.Commands;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers.Menu
{
    [Route("/host/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public MenusController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request,hostId));
            var createMenuResult = await _mediator.Send(command);

            return createMenuResult.Match(
                result => Accepted(_mapper.Map<MenuResponse>(result)),
                errors => Problem(errors));
        }
    }
}
