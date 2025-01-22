using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Services.Interfaces
{
    public interface IBidService
    {
        Task AddBid(Bid bid);
        Task<List<Bid>> FindAllBids();
        Task<Bid> FindBidByIdAsync(int bidId);
        Task UpdateBid(Bid bidList);
        Task RemoveBid(int bidId);

    }
}
