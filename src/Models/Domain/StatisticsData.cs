using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj2Aalst_G3.Models.Domain
{
    public class StatisticsData
    {
        public DateTime Date { get; }
        public ISet<PageHitCounter> PageHits { get; }

        public StatisticsData()
        {
            Date = DateTime.Today;
            PageHits = new HashSet<PageHitCounter>();
        }

        public IDictionary<Tuple<string, string>, int> ToDictionary()
        {
            return PageHits
                .Select(ph => ph.ToKeyValuePair())
                .ToDictionary(k => k.Key, k => k.Value);
        }

        public class PageHitCounter
        {
            public string Controller { get; }
            public string Action { get; }
            public int Hits { get; private set; }

            public PageHitCounter(string controller, string action)
            {
                Controller = controller;
                Action = action;
            }

            public void AddHit() => Hits++;

            public KeyValuePair<Tuple<string, string>, int> ToKeyValuePair()
            {
                return new(new Tuple<string, string>(Controller, Action), Hits);
            }
            
            public override bool Equals(object? obj)
            {
                if (obj is PageHitCounter other)
                {
                    if (Controller == other.Controller && Action == other.Action)
                        return true;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Controller, Action);
            }
        }
    }
}
