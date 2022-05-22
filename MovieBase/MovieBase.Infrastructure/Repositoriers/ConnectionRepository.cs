using Microsoft.EntityFrameworkCore;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Repositoriers
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly IProfileRepository _profileRepository;
        private readonly MovieBaseDbContext _ctx;
        public ConnectionRepository(IProfileRepository profileRepository, MovieBaseDbContext ctx)
        {
            _profileRepository = profileRepository;
            _ctx = ctx;
        }
        public async Task<ResponsePending> AcceptConnectionPendingAsync(ResponsePending responsePending)
        {
            var receiverProfile = await _profileRepository.GetProfileByProfileId(responsePending.ReceiverId);

            if(receiverProfile != null)
            {
                responsePending.IsAccepted = true;
                await _ctx.AddAsync(responsePending);
                
                receiverProfile.ResponsePendings.Add(responsePending);
                var connectionPendingToRemove = await _ctx.ConnectionPendings.Where(c => c.Id == responsePending.PendingId).FirstOrDefaultAsync();
                _ctx.ConnectionPendings.Remove(connectionPendingToRemove);
                await _ctx.SaveChangesAsync();

                await CreateConnectionAsync(responsePending);

                

                return responsePending;

            }

            throw new Exception("Could not accept request");
        }

        public async Task CreateConnectionAsync(ResponsePending responsePending)
        {
            try
            {
                var senderConnection = new Connection
                {
                    ProfileConnectionId = responsePending.SenderId,
                    ProfileUserName = responsePending.SenderName,
                    ProfilePicture = responsePending.SenderPhoto
                };

                var receiverConnection = new Connection
                {
                    ProfileConnectionId = responsePending.ReceiverId,
                    ProfileUserName = responsePending.ReceiverName,
                    ProfilePicture = responsePending.ReceiverPhoto
                };

                await _ctx.Connections.AddAsync(senderConnection);
                await _ctx.Connections.AddAsync(receiverConnection);

                var receiverProfileToUpdate = await _profileRepository.GetProfileByProfileId(responsePending.ReceiverId);
                var senderProfileToUpdate = await _profileRepository.GetProfileByProfileId(responsePending.SenderId);


                receiverProfileToUpdate.Connections.Add(receiverConnection);
                senderProfileToUpdate.Connections.Add(senderConnection);

                await _ctx.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception("Could not create connection:"+ex.Message);
            }


            
        }

        public async Task<ResponsePending> DeclineConnectionPendingAsync(ResponsePending responsePending)
        {
            

            var receiverProfile = await _profileRepository.GetProfileByProfileId(responsePending.ReceiverId);

            if(receiverProfile != null)
            {
                responsePending.IsAccepted = false;
                await _ctx.AddAsync(responsePending);

                receiverProfile.ResponsePendings.Add(responsePending);
                var connectionPendingToRemove = await _ctx.ConnectionPendings.Where(c => c.Id == responsePending.PendingId).FirstOrDefaultAsync();
                _ctx.ConnectionPendings.Remove(connectionPendingToRemove);
                await _ctx.SaveChangesAsync();

                return responsePending;
            }

            throw new Exception("Could not decline request");



        }

        public async Task<bool> DeleteConnectinPendingAsync(int conncetionPending)
        {
            var connectionPendingToDelete = await GetConnectionPendingByIdAsync(conncetionPending);

            if(connectionPendingToDelete !=null)
            {
                _ctx.ConnectionPendings.Remove(connectionPendingToDelete);

                await _ctx.SaveChangesAsync();
                return true;
            }

            return false;
           
        }

        public async Task<Connection> GetConnectionByIdAsync(int connectionId)
        {
            return await _ctx.Connections.Where(c => c.Id == connectionId).FirstOrDefaultAsync();
        }

        public async Task<ConnectionPending> GetConnectionPendingByIdAsync(int connectionPendingId)
        {
            return await _ctx.ConnectionPendings.Where(c => c.Id == connectionPendingId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Connection>> GetConnectionsByProfileId(int profileId)
        {
            return await _ctx.Connections.Where(c => c.ProfileConnectionId == profileId).ToListAsync();
        }

        public async Task<IEnumerable<ConnectionPending>> GetConnectionsPendingByProfileIdAsync(int profileId)
        {
            return await _ctx.ConnectionPendings.Where(c => c.ReceiverId == profileId).ToListAsync();
        }

        public async Task<ConnectionPending> SendConnectionPendingAsync(Profile senderProfile, int receiverProfileId)
        {
            var connectionPending = new ConnectionPending { 
                ReceiverId = receiverProfileId,
                SenderId = senderProfile.Id,
                SenderPhoto = senderProfile.ProfilePicture,
                SenderName = senderProfile.UserName
            };

            var profileToReceive = await _profileRepository.GetProfileByProfileId(receiverProfileId);

            if(profileToReceive != null)
            {
                await _ctx.ConnectionPendings.AddAsync(connectionPending);
                profileToReceive.ConnectionPendings.Add(connectionPending);
                await _ctx.SaveChangesAsync();

                return connectionPending;
            }

            throw new Exception("Could not found profile to send connection request");
        }
    }
}
