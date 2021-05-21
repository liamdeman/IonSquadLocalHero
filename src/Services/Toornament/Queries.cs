using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Proj2Aalst_G3.Models.ViewModels;

namespace Proj2Aalst_G3.Services.Toornament
{
    public class Queries
    {
        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        public class Logo
        {
            [JsonProperty("logo_small")]
            public string LogoSmall { get; set; }

            [JsonProperty("logo_medium")]
            public string LogoMedium { get; set; }

            [JsonProperty("logo_large")]
            public string LogoLarge { get; set; }

            [JsonProperty("original")]
            public string Original { get; set; }
        }

        public class Tournament
        {
            [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
            public class Update
            {
                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("full_name")]
                public string FullName { get; set; }

                [JsonProperty("scheduled_date_start")]
                public string ScheduledDateStart { get; set; }

                [JsonProperty("scheduled_date_end")]
                public string ScheduledDateEnd { get; set; }

                [JsonProperty("timezone")]
                public string Timezone { get; set; }

                [JsonProperty("public")]
                public bool? Public { get; set; }

                [JsonProperty("size")]
                public int? Size { get; set; }

                [JsonProperty("online")]
                public bool? Online { get; set; }

                [JsonProperty("location")]
                public string Location { get; set; }

                [JsonProperty("country")]
                public string Country { get; set; }

                [JsonProperty("logo")]
                public Logo Logo { get; set; }

                [JsonProperty("registration_enabled")]
                public bool? RegistrationEnabled { get; set; }

                [JsonProperty("registration_opening_datetime")]
                public string RegistrationOpeningDatetime { get; set; }

                [JsonProperty("registration_closing_datetime")]
                public string RegistrationClosingDatetime { get; set; }

                [JsonProperty("organization")]
                public string Organization { get; set; }

                [JsonProperty("contact")]
                public string Contact { get; set; }

                [JsonProperty("discord")]
                public string Discord { get; set; }

                [JsonProperty("website")]
                public string Website { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("rules")]
                public string Rules { get; set; }

                [JsonProperty("prize")]
                public string Prize { get; set; }

                [JsonProperty("match_report_enabled")]
                public bool? MatchReportEnabled { get; set; }

                [JsonProperty("registration_request_message")]
                public string RegistrationRequestMessage { get; set; }

                [JsonProperty("check_in_enabled")]
                public bool? CheckInEnabled { get; set; }

                [JsonProperty("check_in_participant_enabled")]
                public bool? CheckInParticipantEnabled { get; set; }

                [JsonProperty("check_in_participant_start_datetime")]
                public string CheckInParticipantStartDatetime { get; set; }

                [JsonProperty("check_in_participant_end_datetime")]
                public string CheckInParticipantEndDatetime { get; set; }

                [JsonProperty("archived")]
                public bool? Archived { get; set; }

                [JsonProperty("registration_acceptance_message")]
                public string RegistrationAcceptanceMessage { get; set; }

                [JsonProperty("registration_refusal_message")]
                public string RegistrationRefusalMessage { get; set; }

                [JsonProperty("registration_terms_enabled")]
                public bool? RegistrationTermsEnabled { get; set; }

                [JsonProperty("registration_terms_url")]
                public string RegistrationTermsUrl { get; set; }

                [JsonProperty("team_min_size")]
                public int? TeamMinSize { get; set; }

                [JsonProperty("team_max_size")]
                public int? TeamMaxSize { get; set; }

                public Update()
                {
                }

                public Update(TournamentViewModels.Edit viewModel)
                {
                    Name = viewModel.Name;
                    Timezone = viewModel.Timezone;
                    Size = viewModel.Size;
                    FullName = viewModel.FullName;
                    ScheduledDateStart = viewModel.ScheduledDateStart?.ToString("yyyy-MM-dd");
                    ScheduledDateEnd = viewModel.ScheduledDateEnd?.ToString("yyyy-MM-dd");
                    Public = viewModel.Public;
                    Online = viewModel.Online;
                    Location = viewModel.Location;
                    Country = viewModel.Country;
                    Logo = viewModel.Logo is null ? null : new Logo()
                    {
                        LogoLarge = viewModel.Logo.LogoLarge,
                        LogoMedium = viewModel.Logo.LogoMedium,
                        LogoSmall = viewModel.Logo.LogoSmall,
                        Original = viewModel.Logo.Original
                    };
                    RegistrationEnabled = viewModel.RegistrationEnabled;
                    RegistrationOpeningDatetime = viewModel.RegistrationOpeningDatetime?.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
                    RegistrationClosingDatetime = viewModel.RegistrationClosingDatetime?.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
                    Organization = viewModel.Organization;
                    Contact = viewModel.Contact;
                    Discord = viewModel.Discord;
                    Website = viewModel.Website;
                    Description = viewModel.Description;
                    Rules = viewModel.Rules;
                    Prize = viewModel.Prize;
                    MatchReportEnabled = viewModel.MatchReportEnabled;
                    RegistrationRequestMessage = viewModel.RegistrationRequestMessage;
                    CheckInEnabled = viewModel.CheckInEnabled;
                    CheckInParticipantEnabled = viewModel.CheckInParticipantEnabled;
                    CheckInParticipantStartDatetime = viewModel.CheckInParticipantStartDatetime?.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
                    CheckInParticipantEndDatetime = viewModel.CheckInParticipantEndDatetime?.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
                    Archived = viewModel.Archived;
                    RegistrationAcceptanceMessage = viewModel.RegistrationAcceptanceMessage;
                    RegistrationRefusalMessage = viewModel.RegistrationRefusalMessage;
                    RegistrationTermsEnabled = viewModel.RegistrationTermsEnabled;
                    RegistrationTermsUrl = viewModel.RegistrationTermsUrl;
                    TeamMinSize = viewModel.TeamMinSize;
                    TeamMaxSize = viewModel.TeamMaxSize;
                }
            }

            [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
            public class Create
            {
                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("full_name")]
                public string FullName { get; set; }

                [JsonProperty("scheduled_date_start")]
                //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
                public string/*DateTime?*/ ScheduledDateStart { get; set; }

                [JsonProperty("scheduled_date_end")]
                //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
                public string/*DateTime?*/ ScheduledDateEnd { get; set; }

                [JsonProperty("timezone")]
                public string Timezone { get; set; }

                [JsonProperty("public")]
                public bool? Public { get; set; }

                [JsonProperty("size")]
                public int Size { get; set; }

                [JsonProperty("online")]
                public bool? Online { get; set; }

                [JsonProperty("location")]
                public string Location { get; set; }

                [JsonProperty("country")]
                public string Country { get; set; }

                [JsonProperty("logo")]
                public Logo Logo { get; set; }

                [JsonProperty("registration_enabled")]
                public bool? RegistrationEnabled { get; set; }

                [JsonProperty("registration_opening_datetime")]
                public DateTime? RegistrationOpeningDatetime { get; set; }

                [JsonProperty("registration_closing_datetime")]
                public DateTime? RegistrationClosingDatetime { get; set; }

                [JsonProperty("organization")]
                public string Organization { get; set; }

                [JsonProperty("contact")]
                public string Contact { get; set; }

                [JsonProperty("discord")]
                public string Discord { get; set; }

                [JsonProperty("website")]
                public string Website { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("rules")]
                public string Rules { get; set; }

                [JsonProperty("prize")]
                public string Prize { get; set; }

                [JsonProperty("match_report_enabled")]
                public bool? MatchReportEnabled { get; set; }

                [JsonProperty("registration_request_message")]
                public string RegistrationRequestMessage { get; set; }

                [JsonProperty("check_in_enabled")]
                public bool? CheckInEnabled { get; set; }

                [JsonProperty("check_in_participant_enabled")]
                public bool? CheckInParticipantEnabled { get; set; }

                [JsonProperty("check_in_participant_start_datetime")]
                public DateTime? CheckInParticipantStartDatetime { get; set; }

                [JsonProperty("check_in_participant_end_datetime")]
                public DateTime? CheckInParticipantEndDatetime { get; set; }

                [JsonProperty("archived")]
                public bool? Archived { get; set; }

                [JsonProperty("registration_acceptance_message")]
                public string RegistrationAcceptanceMessage { get; set; }

                [JsonProperty("registration_refusal_message")]
                public string RegistrationRefusalMessage { get; set; }

                [JsonProperty("registration_terms_enabled")]
                public bool? RegistrationTermsEnabled { get; set; }

                [JsonProperty("registration_terms_url")]
                public string RegistrationTermsUrl { get; set; }

                [JsonProperty("discipline")]
                public string Discipline { get; set; }

                [JsonProperty("participant_type")]
                public string ParticipantType { get; set; }

                [JsonProperty("platforms")]
                public List<string> Platforms { get; set; }

                [JsonProperty("team_min_size")]
                public int? TeamMinSize { get; set; }

                [JsonProperty("team_max_size")]
                public int? TeamMaxSize { get; set; }

                public Create()
                {
                }
                
                public Create(TournamentViewModels.Edit viewModel)
                {
                    Name = viewModel.Name ?? throw new ArgumentNullException(nameof(viewModel.Name));
                    Timezone = viewModel.Timezone ?? throw new ArgumentNullException(nameof(viewModel.Timezone));
                    Size = viewModel.Size;
                    Discipline = viewModel.Discipline ?? throw new ArgumentNullException(nameof(viewModel.Discipline));
                    ParticipantType = viewModel.ParticipantType ?? throw new ArgumentNullException(nameof(viewModel.ParticipantType));
                    Platforms = viewModel.Platforms ?? throw new ArgumentNullException(nameof(viewModel.Platforms));
                    FullName = viewModel.FullName;
                    ScheduledDateStart = viewModel.ScheduledDateStart?.ToString("yyyy-MM-dd");
                    ScheduledDateEnd = viewModel.ScheduledDateEnd?.ToString("yyyy-MM-dd");
                    Public = viewModel.Public;
                    Online = viewModel.Online;
                    Location = viewModel.Location;
                    Country = viewModel.Country;
                    Logo = viewModel.Logo is null ? null : new Logo()
                    {
                        LogoLarge = viewModel.Logo.LogoLarge,
                        LogoMedium = viewModel.Logo.LogoMedium,
                        LogoSmall = viewModel.Logo.LogoSmall,
                        Original = viewModel.Logo.Original
                    };
                    RegistrationEnabled = viewModel.RegistrationEnabled;
                    RegistrationOpeningDatetime = viewModel.RegistrationOpeningDatetime;
                    RegistrationClosingDatetime = viewModel.RegistrationClosingDatetime;
                    Organization = viewModel.Organization;
                    Contact = viewModel.Contact;
                    Discord = viewModel.Discord;
                    Website = viewModel.Website;
                    Description = viewModel.Description;
                    Rules = viewModel.Rules;
                    Prize = viewModel.Prize;
                    MatchReportEnabled = viewModel.MatchReportEnabled;
                    RegistrationRequestMessage = viewModel.RegistrationRequestMessage;
                    CheckInEnabled = viewModel.CheckInEnabled;
                    CheckInParticipantEnabled = viewModel.CheckInParticipantEnabled;
                    CheckInParticipantStartDatetime = viewModel.CheckInParticipantStartDatetime;
                    CheckInParticipantEndDatetime = viewModel.CheckInParticipantEndDatetime;
                    Archived = viewModel.Archived;
                    RegistrationAcceptanceMessage = viewModel.RegistrationAcceptanceMessage;
                    RegistrationRefusalMessage = viewModel.RegistrationRefusalMessage;
                    RegistrationTermsEnabled = viewModel.RegistrationTermsEnabled;
                    RegistrationTermsUrl = viewModel.RegistrationTermsUrl;
                    TeamMinSize = viewModel.TeamMinSize;
                    TeamMaxSize = viewModel.TeamMaxSize;
                }
            }
        }

        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        public class Lineup
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("custom_user_identifier")]
            public string CustomUserIdentifier { get; set; }

            [JsonProperty("custom_fields")]
            public Dictionary<string, string> CustomFields { get; set; }

            public Lineup(RegistrationViewModels.Create.LineupCreate lineup)
            {
                Name = lineup.Name;
                Email = lineup.Email;
                CustomUserIdentifier = lineup.CustomUserIdentifier;
                CustomFields = lineup.CustomFields;
            }

            public Lineup()
            {
            }
        }

        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        public class Registration
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("custom_user_identifier")]
            public string CustomUserIdentifier { get; set; }

            [JsonProperty("custom_fields")]
            public Dictionary<string, string> CustomFields { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("lineup")]
            public List<Lineup> Lineup { get; set; }

            public Registration(RegistrationViewModels.Create model)
            {
                Name = model.Name;
                Email = model.Email;
                CustomUserIdentifier = model.CustomUserIdentifier;
                CustomFields = model.CustomFields;
                Type = model.Type;
                Lineup = model.Lineup?
                    .Select(l => new Lineup(l))
                    .ToList();
            }

            public Registration()
            {
            }
        }



        private class DateFormatConverter : IsoDateTimeConverter
        {
            public DateFormatConverter(string format)
            {
                DateTimeFormat = format;
            }
        }
    }
}
