using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Services.Toornament
{
    public class Filters
    {
        public abstract class Filter
        {
            public FormUrlEncodedContent BuildQueryParameters()
            {
                List<KeyValuePair<string, string>> output = new List<KeyValuePair<string, string>>();
                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    string lowerUnderscoreCase = string.Concat(prop.Name
                        .Select((x, i) =>
                            i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())
                    ).ToLower();

                    string value = null;
                    var propValue = prop.GetValue(this);
                    if (propValue is IEnumerable<string> collection)
                    {
                        value = string.Join(',', collection);
                    }
                    else if (propValue is DateTime date)
                    {
                        value = date.ToString("yyyy-mm-dd");
                    }
                    else if (propValue is string stringValue)
                        value = stringValue;
                    else if (propValue is bool boolValue)
                        value = boolValue ? "1" : "0";

                    if (value is not null)
                    {
                        var pair = new KeyValuePair<string, string>(lowerUnderscoreCase, value);
                        output.Add(pair);
                    }
                }

                return new FormUrlEncodedContent(output);
            }
        }

        public class TournamentFilter : Filter
        {
            public IEnumerable<string> Disciplines { get; set; } = null;
            public IEnumerable<string> Statuses { get; set; } = null;
            public DateTime? ScheduledBefore { get; set; } = null;
            public DateTime? ScheduledAfter { get; set; } = null;
            public IEnumerable<string> Countries { get; set; } = null;
            public IEnumerable<string> Platforms { get; set; } = null;
            public bool? IsOnline { get; set; } = null;
            public bool? Archived { get; set; } = null;
            public string CustomUserIdentifier { get; set; } = null;
            public IEnumerable<string> TournamentIds { get; set; } = null;
            public string Sort { get; set; } = null;
        }

        public class RegistrationFilter : Filter
        {
            public IEnumerable<string> TournamentIds { get; set; } = null;
            public IEnumerable<string> Statuses { get; set; } = null;
            public string Order { get; set; } = SortedBy.CreatedAscending;
            public IEnumerable<string> CustomUserIdentifiers { get; set; } = null;
        }

        public static class SortedBy
        {
            public const string CreatedAscending = "created_asc";
            public const string CreatedDescending = "created_desc";
        }
    }
}