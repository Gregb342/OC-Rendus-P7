using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;

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

        public async Task<List<Bid>> FindAllBids()
        {
            return await _bidRepository.FindAllBidsAsync();
        }

        public async Task<Bid> FindBidByIdAsync(int bidId)
        {
            return await _bidRepository.FindBidByIdAsync(bidId);
        }

        public async Task RemoveBid(int bidId)
        {
            await _bidRepository.RemoveBidAsync(bidId);
        }

        public async Task UpdateBid(Bid bidList)
        {
            Bid bid = await _bidRepository.FindBidByIdAsync(bidList.BidId);

            // TODO IMPLEMENTER LE RESTE DE L'UPDATE
        }
    }
}
