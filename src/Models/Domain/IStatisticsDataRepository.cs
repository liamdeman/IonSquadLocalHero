namespace Proj2Aalst_G3.Models.Domain
{
    public interface IStatisticsDataRepository
    {
        StatisticsData GetTodaysDataObject();
        void AddHit(string controller, string action);
    }
}
