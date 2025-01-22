using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories.Interfaces
{
    public interface IBidListRepository
    {
        void AddBidList(BidList bidList);
        Task<List<BidList>> FindAllBidList();
        Task<BidList> FindBidListByIdAsync(int bidId);
        void UpdateBidList(BidList bidList);
        void RemoveBidList(int bidId);

    }
}
