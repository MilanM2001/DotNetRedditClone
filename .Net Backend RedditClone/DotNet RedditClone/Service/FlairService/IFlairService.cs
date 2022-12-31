namespace DotNet_RedditClone.Service.FlairService
{
    public interface IFlairService
    {
        Task<List<Flair>> GetAll();

        Task<Flair> GetSingle(int flairId);

        Task<Flair> AddFlair(Flair newFlair);

        Task<Flair> UpdateFlair(Flair updateFlair);

        Task<Flair> DeleteFlair(int flairId);
    }
}
