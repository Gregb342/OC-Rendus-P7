using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories.Interfaces
{
    public interface IBidRepository
    {
        Task AddBidAsync(Bid bid);
        Task<List<Bid>> FindAllBidsAsync();
        Task<Bid> FindBidByIdAsync(int bidId);
        Task UpdateBidAsync(Bid bidList);
        Task RemoveBidAsync(int bidId);

    }
}
