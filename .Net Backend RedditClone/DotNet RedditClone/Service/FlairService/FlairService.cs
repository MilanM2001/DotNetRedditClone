namespace DotNet_RedditClone.Service.FlairService
{
    public class FlairService : IFlairService
    {
        private readonly DataContext _context;

        public FlairService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Flair>> GetAll()
        {
            return await _context.Flairs.ToListAsync();
        }

        public async Task<Flair> GetSingle(int flairId)
        {
            return await _context.Flairs.FindAsync(flairId);
        }

        public async Task<Flair> AddFlair(Flair newFlair)
        {
            _context.Flairs.Add(newFlair);
            await _context.SaveChangesAsync();
            return newFlair;
        }

        public async Task<Flair> UpdateFlair(Flair updateFlair)
        {
            await _context.SaveChangesAsync();
            return updateFlair;
        }

        public async Task<Flair> DeleteFlair(int flairId)
        {
            Flair flair = await _context.Flairs.FindAsync(flairId);

            if (flair == null)
            {
                throw new Exception("Flair not found.");
            }

            _context.Flairs.Remove(flair);
            await _context.SaveChangesAsync();
            return flair;
        }


    }
}
