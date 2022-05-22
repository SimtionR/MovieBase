using AutoMapper;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Profiles
{
    public class ConnectionPendingProfile : AutoMapper.Profile
    {
        public ConnectionPendingProfile()
        {
            CreateMap<ConnectionPending, ConnectionPendingResponseModel>();
        }
    }
}
