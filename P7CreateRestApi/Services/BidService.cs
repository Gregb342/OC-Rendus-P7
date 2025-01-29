using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels;
using P7CreateRestApi.ViewsModels.Bids;

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
            await _bidRepository.AddAsync(bid);
        }

        public async Task<List<GetBidViewModel>> GetAllBids()
        {
            List<Bid> allBids = (List<Bid>) await _bidRepository.GetAllAsync();

            return allBids.Select(b => new GetBidViewModel
            {
                BidId = b.BidId,
                Account = b.Account,
                BidQuantity = b.BidQuantity,
                BidType = b.BidType
            }).ToList();
        }

        public async Task<GetBidViewModel> GetBidByIdAsync(int bidId)
        {
            Bid existingBid = await _bidRepository.GetByIdAsync(bidId)
                ?? throw new KeyNotFoundException($"L'offre {bidId} n'existe pas");

            return new GetBidViewModel
            {
                BidId = existingBid.BidId,
                Account = existingBid.Account,
                BidQuantity = existingBid.BidQuantity,
                BidType = existingBid.BidType
            };
        }

        public async Task RemoveBid(int bidId)
        {
            Bid bid = await _bidRepository.GetByIdAsync(bidId)
                        ?? throw new KeyNotFoundException($"L'offre {bidId} n'existe pas");

            await _bidRepository.DeleteAsync(bid.BidId);
        }

        public async Task<GetBidViewModel> UpdateBid(UpdateBidViewModel newBid)
        {
            Bid existingBid = await _bidRepository.GetByIdAsync(newBid.BidId) 
                        ?? throw new KeyNotFoundException($"L'offre {newBid.BidId} n'existe pas");

            existingBid.Account = newBid.Account;
            existingBid.BidType = newBid.BidType;
            existingBid.BidQuantity = newBid.BidQuantity;

            await _bidRepository.UpdateAsync(existingBid);

            GetBidViewModel getBidViewModel = new GetBidViewModel();

            getBidViewModel.BidId = existingBid.BidId;
            getBidViewModel.Account = existingBid.Account;
            getBidViewModel.BidQuantity= existingBid.BidQuantity;
            getBidViewModel.BidType= existingBid.BidType;

            return getBidViewModel;
        }
    }
}
