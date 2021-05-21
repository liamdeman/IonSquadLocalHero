using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proj2Aalst_G3.Services.Toornament
{
    public class Responses
    {
        public class Logo
        {
            [JsonProperty("logo_small")] public string LogoSmall { get; set; }

            [JsonProperty("logo_medium")] public string LogoMedium { get; set; }

            [JsonProperty("logo_large")] public string LogoLarge { get; set; }

            [JsonProperty("original")] public string Original { get; set; }
        }

        public class Tournament
        {
            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("full_name")] public string FullName { get; set; }

            [JsonProperty("scheduled_date_start")] public DateTime? ScheduledDateStart { get; set; }

            [JsonProperty("scheduled_date_end")] public DateTime? ScheduledDateEnd { get; set; }

            [JsonProperty("timezone")] public string Timezone { get; set; }

            [JsonProperty("public")] public bool Public { get; set; }

            [JsonProperty("size")] public int Size { get; set; }

            [JsonProperty("online")] public bool Online { get; set; }

            [JsonProperty("location")] public string Location { get; set; }

            [JsonProperty("country")] public string Country { get; set; }

            [JsonProperty("logo")] public Logo Logo { get; set; }

            [JsonProperty("registration_enabled")] public bool RegistrationEnabled { get; set; }

            [JsonProperty("registration_opening_datetime")]
            public DateTime? RegistrationOpeningDatetime { get; set; }

            [JsonProperty("registration_closing_datetime")]
            public DateTime? RegistrationClosingDatetime { get; set; }

            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("discipline")] public string Discipline { get; set; }

            [JsonProperty("status")] public string Status { get; set; }

            [JsonProperty("platforms")] public List<string> Platforms { get; set; }
        }

        public class TournamentDetailed
        {
            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("full_name")] public string FullName { get; set; }

            [JsonProperty("scheduled_date_start")] public DateTime? ScheduledDateStart { get; set; }

            [JsonProperty("scheduled_date_end")] public DateTime? ScheduledDateEnd { get; set; }

            [JsonProperty("timezone")] public string Timezone { get; set; }

            [JsonProperty("public")] public bool Public { get; set; }

            [JsonProperty("size")] public int Size { get; set; }

            [JsonProperty("online")] public bool Online { get; set; }

            [JsonProperty("location")] public string Location { get; set; }

            [JsonProperty("country")] public string Country { get; set; }

            [JsonProperty("logo")] public Logo Logo { get; set; }

            [JsonProperty("registration_enabled")] public bool RegistrationEnabled { get; set; }

            [JsonProperty("registration_opening_datetime")]
            public DateTime? RegistrationOpeningDatetime { get; set; }

            [JsonProperty("registration_closing_datetime")]
            public DateTime? RegistrationClosingDatetime { get; set; }

            [JsonProperty("organization")] public string Organization { get; set; }

            [JsonProperty("contact")] public string Contact { get; set; }

            [JsonProperty("discord")] public string Discord { get; set; }

            [JsonProperty("website")] public string Website { get; set; }

            [JsonProperty("description")] public string Description { get; set; }

            [JsonProperty("rules")] public string Rules { get; set; }

            [JsonProperty("prize")] public string Prize { get; set; }

            [JsonProperty("match_report_enabled")] public bool MatchReportEnabled { get; set; }

            [JsonProperty("registration_request_message")]
            public string RegistrationRequestMessage { get; set; }

            [JsonProperty("check_in_enabled")] public bool CheckInEnabled { get; set; }

            [JsonProperty("check_in_participant_enabled")]
            public bool CheckInParticipantEnabled { get; set; }

            [JsonProperty("check_in_participant_start_datetime")]
            public DateTime? CheckInParticipantStartDatetime { get; set; }

            [JsonProperty("check_in_participant_end_datetime")]
            public DateTime? CheckInParticipantEndDatetime { get; set; }

            [JsonProperty("archived")] public bool Archived { get; set; }

            [JsonProperty("registration_acceptance_message")]
            public string RegistrationAcceptanceMessage { get; set; }

            [JsonProperty("registration_refusal_message")]
            public string RegistrationRefusalMessage { get; set; }

            [JsonProperty("registration_terms_enabled")]
            public bool RegistrationTermsEnabled { get; set; }

            [JsonProperty("registration_terms_url")]
            public string RegistrationTermsUrl { get; set; }

            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("discipline")] public string Discipline { get; set; }

            [JsonProperty("status")] public string Status { get; set; }

            [JsonProperty("participant_type")] public string ParticipantType { get; set; }

            [JsonProperty("platforms")] public List<string> Platforms { get; set; }

            [JsonProperty("featured")] public bool Featured { get; set; }

            [JsonProperty("registration_notification_enabled")]
            public bool RegistrationNotificationEnabled { get; set; }

            [JsonProperty("team_min_size")] public int TeamMinSize { get; set; }

            [JsonProperty("team_max_size")] public int TeamMaxSize { get; set; }
        }

        public class TeamSize
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }

        public class Options
        {
            [JsonProperty("settings_enabled")]
            public bool SettingsEnabled { get; set; }

            [JsonProperty("choices")]
            public List<object> Choices { get; set; }

            [JsonProperty("added_by_default")]
            public bool? AddedByDefault { get; set; }

            [JsonProperty("default_label")]
            public object DefaultLabel { get; set; }

            [JsonProperty("default_required")]
            public bool? DefaultRequired { get; set; }

            [JsonProperty("default_public")]
            public bool? DefaultPublic { get; set; }

            [JsonProperty("field")]
            public string Field { get; set; }
        }

        public class Feature
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("options")]
            public Options Options { get; set; }
        }

        public class Discipline
        {
            [JsonProperty("platforms_available")]
            public List<string> PlatformsAvailable { get; set; }

            [JsonProperty("team_size")]
            public TeamSize TeamSize { get; set; }

            [JsonProperty("features")]
            public List<Feature> Features { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("shortname")]
            public string Shortname { get; set; }

            [JsonProperty("fullname")]
            public string Fullname { get; set; }

            [JsonProperty("copyrights")]
            public string Copyrights { get; set; }
        }

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

            [JsonProperty("user_id")]
            public string UserId { get; set; }

            public Lineup()
            {
            }
        }

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

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("tournament_id")]
            public string TournamentId { get; set; }

            [JsonProperty("participant_id")]
            public string ParticipantId { get; set; }

            [JsonProperty("user_id")]
            public string UserId { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("lineup")]
            public List<Lineup> Lineup { get; set; }

            public Registration()
            {
            }
        }
    }
}