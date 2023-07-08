using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;
using EmployeeManagement.Application.CQRS.Positions.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.Position;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PositionsController>
        [HttpGet]
        public async Task<ActionResult<List<PositionDTO>>> Get()
        {
            var positions = await _mediator.Send(new GetPositionListRequest());
            return Ok(positions);
        }

        // GET api/<PositionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDTO>> Get(int id)
        {
            var position = await _mediator.Send(new GetPositionDetailRequest { Id = id });
            return Ok(position);
        }

        // POST api/<PositionsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePositionDTO position)
        {
            var command = new CreatePositionCommand { PositionDTO = position };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<PositionsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PositionDTO position)
        {
            var command = new UpdatePositionCommand { PositionDTO = position};
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePositionCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
