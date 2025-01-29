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
            List<Bid> AllBids = (List<Bid>) await _bidRepository.GetAllAsync();

            if (AllBids is null)
            {
                throw new ArgumentNullException(nameof(AllBids));
            }

            List<GetBidViewModel> AllBidsViewModel = new List<GetBidViewModel>();

            foreach (var Bid in AllBids)
            {
                GetBidViewModel getBidViewModel = new GetBidViewModel();

                getBidViewModel.BidId = Bid.BidId;
                getBidViewModel.Account = Bid.Account;
                getBidViewModel.BidQuantity = Bid.BidQuantity;
                getBidViewModel.BidType = Bid.BidType;

                AllBidsViewModel.Add(getBidViewModel);
            }

            return AllBidsViewModel;
        }

        public async Task<GetBidViewModel> GetBidByIdAsync(int bidId)
        {
            Bid existingBid = await _bidRepository.GetByIdAsync(bidId) 
                    ?? throw new KeyNotFoundException($"L'offre {bidId} n'existe pas");

            GetBidViewModel bidViewModel = new GetBidViewModel();

            bidViewModel.BidId = existingBid.BidId;
            bidViewModel.Account = existingBid.Account;
            bidViewModel.BidQuantity = existingBid.BidQuantity;
            bidViewModel.BidType = existingBid.BidType; 
            
            return bidViewModel;
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
