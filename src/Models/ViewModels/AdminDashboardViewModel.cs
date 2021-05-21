using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public IDictionary<Tuple<string, string>, int> PageStatistics { get; }
        public int ProfileCount { get; }
        public int NewSiteUsers { get; }
        public int NewDiscordLinkedUsers { get; }

        public AdminDashboardViewModel(StatisticsData todaysStatistics, int profileCount, int newSiteUsers, int newDiscordLinkedUsers)
        {
            PageStatistics = todaysStatistics.ToDictionary();
            ProfileCount = profileCount;
            NewSiteUsers = newSiteUsers;
            NewDiscordLinkedUsers = newDiscordLinkedUsers;
        }
    }
}
