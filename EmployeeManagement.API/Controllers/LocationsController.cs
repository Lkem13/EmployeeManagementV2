﻿using EmployeeManagement.Application.CQRS.Locations.Requests.Commands;
using EmployeeManagement.Application.CQRS.Locations.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LocationDTO>>> Get()
        {
            var locations = await _mediator.Send(new GetLocationListRequest());
            return Ok(locations);
        }

        // GET api/<LocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> Get(int id)
        {
            var location = await _mediator.Send(new GetLocationDetailRequest { Id = id });
            return Ok(location);
        }

        // POST api/<LocationsController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLocationDTO location)
        {
            var command = new CreateLocationCommand { LocationDTO = location };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LocationsController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] LocationDTO location)
        {
            var command = new UpdateLocationCommand { LocationDTO = location };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
