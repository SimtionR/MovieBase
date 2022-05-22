using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IConnectionRepository
    {
        Task<ConnectionPending> SendConnectionPendingAsync(Profile sendeerProfile, int receiverProfileId);
        Task<ConnectionPending> GetConnectionPendingByIdAsync(int connectionPendingId);
        Task<IEnumerable<ConnectionPending>> GetConnectionsPendingByProfileIdAsync(int profileId);

        Task<ResponsePending> AcceptConnectionPendingAsync(ResponsePending responsePending);
        Task<ResponsePending> DeclineConnectionPendingAsync(ResponsePending responsePending);
        Task CreateConnectionAsync(ResponsePending acceptedPending);
       
        Task<bool> DeleteConnectinPendingAsync(int conncetionPending);
        Task<Connection> GetConnectionByIdAsync(int connectionId);
        Task<IEnumerable<Connection>> GetConnectionsByProfileId(int profileId);

    }
}
