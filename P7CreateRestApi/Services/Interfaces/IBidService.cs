using Dot.Net.WebApi.Domain;
using P7CreateRestApi.ViewsModels;

namespace P7CreateRestApi.Services.Interfaces
{
    public interface IBidService
    {
        Task AddBid(Bid bid);
        Task<List<Bid>> GetAllBids();
        Task<Bid> GetBidByIdAsync(int bidId);
        Task<Bid> UpdateBid(UpdateBidViewModel bid);
        Task RemoveBid(int bidId);

    }
}
