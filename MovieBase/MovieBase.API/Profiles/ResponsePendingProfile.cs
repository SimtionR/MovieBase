using AutoMapper;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.ConnectionCommands;
using MovieBase.Application.Handlers.ConnectionHandleres;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Profiles
{
    public class ResponsePendingProfile : AutoMapper.Profile
    {
        public ResponsePendingProfile()
        {
            CreateMap<ResponsePendingRequestModel, AddDeclinedConnectionPendingCommand>();
            CreateMap<ResponsePendingRequestModel, AddAcceptedConnectionPendingCommand>();
            CreateMap<AddAcceptedConnectionPendingCommand, ResponsePending>();
            CreateMap<AddDeclinedConnectionPendingCommand, ResponsePending>();
            CreateMap<ResponsePending, ResponsePendingResponseModel>();
        }
    }
}
