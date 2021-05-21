using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Data.Repositories
{
    public class StatisticsDataRepository : IStatisticsDataRepository
    {
        private readonly ApplicationDbContext dbContext;

        public StatisticsDataRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StatisticsData GetTodaysDataObject()
        {
            var statistics = dbContext.StatisticsData
                .Include(s => s.PageHits)
                .FirstOrDefault(d => d.Date.CompareTo(DateTime.Today) == 0);
            if (statistics == null)
            {
                statistics = new StatisticsData();
                dbContext.StatisticsData.Add(statistics);
                SaveChanges();
            }

            return statistics;
        }

        public void AddHit(string controller, string action)
        {
            controller = controller.Replace("Controller", "");
            var statistics = GetTodaysDataObject();
            var pageHit = dbContext.PageHitCounters
                .FirstOrDefault(ph => ph.Controller == controller && ph.Action == action);
            if (pageHit is null)
            {
                pageHit = new StatisticsData.PageHitCounter(controller, action);
                dbContext.PageHitCounters.Add(pageHit);
                statistics.PageHits.Add(pageHit);
            }
            pageHit.AddHit();
            SaveChanges();
        }

        private void SaveChanges() => dbContext.SaveChanges();
    }
}
