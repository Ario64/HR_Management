using HR_Management.Application.DTOs.LeaveAllocationDTOs;
using HR_Management.Application.features.LeaveAllocation.Requests.Commands;
using HR_Management.Application.features.LeaveAllocation.Requests.Queries;
using HR_Management.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<leaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveAllocation>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<leaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocation>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationWithDetailRequest { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<leaveAllocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = leaveAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<leaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = leaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<leaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
