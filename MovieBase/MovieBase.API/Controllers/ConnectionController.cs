using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.ConnectionCommands;
using MovieBase.Application.Queries;
using MovieBase.Application.Queries.ConnectionQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ConnectionController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        

        public ConnectionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddConnectionPending/{receiverId}")]
        public async Task<ActionResult<ConnectionPendingResponseModel>> SendConnectionPending(int receiverId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);


            var senderProfile = await _mediator.Send(new GetProfileByUserIdQuery { userId = userId });

            if (senderProfile == null)
            {
                return BadRequest();
            }

            try
            {
                var command = new AddConnectionPendingCommand { ReceiverProfileId = receiverId, SenderProfile = senderProfile };

                var result = await _mediator.Send(command);

                return _mapper.Map<ConnectionPendingResponseModel>(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("GetConnectionPendingById/{connectionPendingId}")]
        public async Task<ActionResult<ConnectionPendingResponseModel>> GetConnectionPendingById(int connectionPendingId)
        {
            var command = new GetConnectionPendingByIdQuery { ConnectionPendingId = connectionPendingId };
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return BadRequest();
            }

            return _mapper.Map<ConnectionPendingResponseModel>(result);
        }
        [HttpGet]
        [Route("connectionPendingsByProfile/{profileId}")]
        public async Task<IEnumerable<ConnectionPendingResponseModel>> GetConnectionsPendingByProfileId(int profileId)
        {
            var command = new GetConnectionsPendingByProfileIdQuery { ProfileId = profileId };
            var result = await _mediator.Send(command);

            var connectionsPendingResponseList = new List<ConnectionPendingResponseModel>();

            foreach(var connectionPending in result)
            {
                connectionsPendingResponseList.Add(_mapper.Map<ConnectionPendingResponseModel>(connectionPending));
            }

            return connectionsPendingResponseList;
        }

        [HttpPost]
        [Route("acceptPendingResponse")]
        public async Task<ActionResult<ResponsePendingResponseModel>> AccepteConnectionPending(ResponsePendingRequestModel model)
        {
            var command = _mapper.Map<AddAcceptedConnectionPendingCommand>(model);

            

            var result = await _mediator.Send(command);

            if(result == null)
            {
                return BadRequest();
            }

            return _mapper.Map<ResponsePendingResponseModel>(result);

        }
        [HttpPost]
        [Route("decliningPendingResponse")]
        public async Task<ActionResult<ResponsePendingResponseModel>> DeclineConnectionPending(ResponsePendingRequestModel model)
        {
            var command = _mapper.Map<AddDeclinedConnectionPendingCommand>(model);

            var result = await _mediator.Send(command);

            if(result == null)
            {
                return BadRequest();
            }

            return _mapper.Map<ResponsePendingResponseModel>(result);
        }

    }
}
