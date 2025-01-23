using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories.Interfaces;

namespace P7CreateRestApi.Repositories
{
    public class BidRepository : IBidRepository
    {
        public readonly LocalDbContext _context;

        public BidRepository(LocalDbContext context)
        {
            _context = context;
        }   

        public async Task AddBidAsync(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bid>> GetAllBidsAsync()
        {
            return await _context.Bids.ToListAsync();
        }

        public async Task<Bid> GetBidByIdAsync(int bidId)
        {
            return await _context.Bids.FirstOrDefaultAsync(b => b.BidId == bidId);
        }

        public async Task UpdateBidAsync(Bid bid)
        {
            _context.Bids.Update(bid);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveBidAsync(int bidId)
        {
            Bid bid = await _context.Bids.FindAsync(bidId);
            if (bid is not null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync();
            }
        }
    }
}
