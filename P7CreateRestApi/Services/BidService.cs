using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels;

namespace P7CreateRestApi.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }   

        public async Task AddBid(Bid bid)
        {
            await _bidRepository.AddBidAsync(bid);
        }

        public async Task<List<Bid>> GetAllBids()
        {
            return await _bidRepository.GetAllBidsAsync();
        }

        public async Task<Bid> GetBidByIdAsync(int bidId)
        {
            Bid existingBid = await _bidRepository.GetBidByIdAsync(bidId);

            if (existingBid is null)
            {
                throw new KeyNotFoundException($"L'offre {existingBid.BidId} n'existe pas");
            }
            
            return existingBid;
        }

        public async Task RemoveBid(int bidId)
        {
            Bid bid = await _bidRepository.GetBidByIdAsync(bidId)
                       ?? throw new KeyNotFoundException($"L'offre {bidId} n'existe pas");

            await _bidRepository.RemoveBidAsync(bid.BidId);
        }

        public async Task<Bid> UpdateBid(UpdateBidViewModel newBid)
        {
            Bid existingBid = await _bidRepository.GetBidByIdAsync(newBid.BidId);

            if (existingBid is null)
            {
                throw new KeyNotFoundException($"L'offre {newBid.BidId} n'existe pas");
            }

            existingBid.Account = newBid.Account;
            existingBid.BidType = newBid.BidType;
            existingBid.BidQuantity = newBid.BidQuantity;

            await _bidRepository.UpdateBidAsync(existingBid);

            return existingBid;
        }
    }
}
