using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories.Interfaces;

namespace P7CreateRestApi.Repositories
{
    public class BidListRepository : IBidListRepository
    {
        public readonly LocalDbContext _context;

        public BidListRepository(LocalDbContext context)
        {
            _context = context;
        }   

        public async void AddBidList(BidList bidList)
        {
            _context.Bids.Add(bidList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BidList>> FindAllBidList()
        {
            return await _context.Bids.ToListAsync();
        }

        public async Task<BidList> FindBidListByIdAsync(int bidId)
        {
            return await _context.Bids.FirstOrDefaultAsync(b => b.BidListId == bidId);
        }

        public async void UpdateBidList(BidList bidList)
        {
            _context.Bids.Update(bidList);
            await _context.SaveChangesAsync();
        }

        public async void RemoveBidList(int bidId)
        {
            BidList bidList = await _context.Bids.FindAsync(bidId);
            if (bidList is not null)
            {
                _context.Bids.Remove(bidList);
                await _context.SaveChangesAsync();
            }
        }
    }
}
