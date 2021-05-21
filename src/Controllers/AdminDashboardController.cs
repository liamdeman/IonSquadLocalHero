using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Models.ViewModels;

namespace Proj2Aalst_G3.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IStatisticsDataRepository statisticsDataRepository;
        private readonly IApplicationUserRepository userRepository;
        private readonly IGameRepository gameRepository;
        private readonly ApplicationDbContext dbContext;

        public AdminDashboardController(
            IStatisticsDataRepository statisticsDataRepository,
            IApplicationUserRepository userRepository,
            IGameRepository gameRepository,
            ApplicationDbContext dbContext)
        {
            this.statisticsDataRepository = statisticsDataRepository;
            this.userRepository = userRepository;
            this.gameRepository = gameRepository;
            this.dbContext = dbContext;
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(/*DateTime? startDate = null, DateTime? endDate = null*/)
        {
            ViewData["userChart"] = GenerateUserChart();
            ViewData["gameChart"] = await GenerateGameChart();
            
            var usersThisMonth = userRepository.GetAll()
                .Where(u => u.CreationDate.Month == DateTime.Today.Month
                            && u.CreationDate.Year == DateTime.Today.Year)
                .ToList();

            var viewModel = new AdminDashboardViewModel(statisticsDataRepository.GetTodaysDataObject(),
                userRepository.GetAll().Count(),
                usersThisMonth.Count(u => u.DiscordUserName is null),
                usersThisMonth.Count(u => u.DiscordUserName is not null));

            return View(viewModel);
        }
        
        [Authorize(Roles = "admin")]
        public IActionResult Games()
        {
            return Redirect("~/Game/Index");
        }

        private Chart GenerateUserChart()
        {
            var chart = new Chart
            {
                Type = Enums.ChartType.Bar
            };

            var data = new ChartJSCore.Models.Data
            {
                Labels = new List<string>()
                {
                    "Juni",
                    "Juli",
                    "Augustus",
                    "September",
                    "Oktober",
                    "November",
                    "December",
                    "Januari",
                    "Februari",
                    "Maart",
                    "April",
                    "Mei"
                }
            };

            var datasetSiteUsers = new BarDataset()
            {
                Label = "Nieuwe gebruikers zonder Discord",
                Data = new List<double?>(),
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                    ChartColor.FromRgba(0, 159, 227, 0.9),
                },
                BorderColor = new List<ChartColor>
                {
                    
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227),
                    ChartColor.FromRgb(0, 159, 227)
                },
            };
            
            var datasetDiscordUsers = new BarDataset()
            {
                Label = "Nieuwe gebruikers met Discord",
                Data = new List<double?>(),
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9),
                    ChartColor.FromRgba(230, 0, 126, 0.9)
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126),
                    ChartColor.FromRgb(230, 0, 126)
                },
            };

            for (int i = 0; i < 12; i++)
            {
                var time = DateTime.Today.AddMonths(-i);
                var users = userRepository.GetAll()
                    .Where(u => u.CreationDate.Month == time.Month)
                    .ToList();
                datasetSiteUsers.Data.Add(users.Count(u => u.DiscordUserName is null));
                datasetDiscordUsers.Data.Add(users.Count(u => u.DiscordUserName is not null));
            }

            data.Datasets = new List<Dataset> { datasetSiteUsers, datasetDiscordUsers };

            chart.Data = data;
            
            return chart;
        }

        private async Task<Chart> GenerateGameChart()
        {
            var allGames = gameRepository.GetAll();
            var allProfiles = dbContext.Users
                .Include(u => u.GameProfiles)
                .ThenInclude(gp => gp.Game)
                .SelectMany(u => u.GameProfiles)
                .ToList();
            var usersPerGame = new Dictionary<string, int>();

            foreach (var game in allGames)
            {
                var count = allProfiles
                    .Count(p => p.Game.Id == game.Id);
                usersPerGame.Add(game.Name, count);
            }
            
            var chart = new Chart { Type = Enums.ChartType.PolarArea };

            var data = new ChartJSCore.Models.Data
            {
                Labels = usersPerGame.Keys.ToList()
            };

            var dataset = new PolarDataset
            {
                Label = "My dataset",
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FF6384"),
                    ChartColor.FromHexString("#4BC0C0"),
                    ChartColor.FromHexString("#FFCE56")
                },
                Data = usersPerGame.Values.Select<int, double?>(i => i).ToList()
            };

            data.Datasets = new List<Dataset> { dataset };

            chart.Data = data;

            return chart;
        }
    }
}
