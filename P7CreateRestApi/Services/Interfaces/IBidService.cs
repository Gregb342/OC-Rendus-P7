using Dot.Net.WebApi.Domain;
using P7CreateRestApi.ViewsModels;
using P7CreateRestApi.ViewsModels.Bids;

namespace P7CreateRestApi.Services.Interfaces
{
    public interface IBidService
    {
        Task AddBid(Bid bid);
        Task<List<GetBidViewModel>> GetAllBids();
        Task<GetBidViewModel> GetBidByIdAsync(int bidId);
        Task<GetBidViewModel> UpdateBid(UpdateBidViewModel bid);
        Task RemoveBid(int bidId);

    }
}
