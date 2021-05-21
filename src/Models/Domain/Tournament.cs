using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Tournament
    {
        #region Properties

        public string Name { get; set; }

        public string FullName { get; set; }

        public DateTime? ScheduledDateStart { get; set; }

        public DateTime? ScheduledDateEnd { get; set; }

        public string Timezone { get; set; }

        public bool Public { get; set; }

        public int Size { get; set; }

        public bool Online { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }

        public Logo Logo { get; set; }

        public bool RegistrationEnabled { get; set; }

        public DateTime? RegistrationOpeningDatetime { get; set; }

        public DateTime? RegistrationClosingDatetime { get; set; }

        public string Organization { get; set; }

        public string Contact { get; set; }

        public string Discord { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public string Rules { get; set; }

        public string Prize { get; set; }

        public bool MatchReportEnabled { get; set; }

        public string RegistrationRequestMessage { get; set; }

        public bool CheckInEnabled { get; set; }

        public bool CheckInParticipantEnabled { get; set; }

        public DateTime? CheckInParticipantStartDatetime { get; set; }

        public DateTime? CheckInParticipantEndDatetime { get; set; }

        public bool Archived { get; set; }

        public string RegistrationAcceptanceMessage { get; set; }

        public string RegistrationRefusalMessage { get; set; }

        public bool RegistrationTermsEnabled { get; set; }

        public string RegistrationTermsUrl { get; set; }

        public string Id { get; init; }

        public string Discipline { get; set; }

        public string Status { get; set; }

        public string ParticipantType { get; set; }

        public List<string> Platforms { get; set; }

        public bool Featured { get; set; }

        public bool RegistrationNotificationEnabled { get; set; }

        public int TeamMinSize { get; set; }

        public int TeamMaxSize { get; set; }

        public DateTime? LastUpdated { get; set; } = null;

        #endregion

        #region Constructors

        public Tournament()
        {
        }

        #endregion

        public void Update(Tournament updatedTournament)
        {
            Name = updatedTournament.Name;
            FullName = updatedTournament.FullName;
            ScheduledDateStart = updatedTournament.ScheduledDateStart;
            ScheduledDateEnd = updatedTournament.ScheduledDateEnd;
            Timezone = updatedTournament.Timezone;
            Public = updatedTournament.Public;
            Size = updatedTournament.Size;
            Online = updatedTournament.Online;
            Location = updatedTournament.Location;
            Country = updatedTournament.Country;
            Logo = updatedTournament.Logo;
            RegistrationEnabled = updatedTournament.RegistrationEnabled;
            RegistrationOpeningDatetime = updatedTournament.RegistrationOpeningDatetime;
            RegistrationClosingDatetime = updatedTournament.RegistrationClosingDatetime;
            Organization = updatedTournament.Organization;
            Contact = updatedTournament.Contact;
            Discord = updatedTournament.Discord;
            Website = updatedTournament.Website;
            Description = updatedTournament.Description;
            Rules = updatedTournament.Rules;
            Prize = updatedTournament.Prize;
            MatchReportEnabled = updatedTournament.MatchReportEnabled;
            RegistrationRequestMessage = updatedTournament.RegistrationRequestMessage;
            CheckInEnabled = updatedTournament.CheckInEnabled;
            CheckInParticipantEnabled = updatedTournament.CheckInParticipantEnabled;
            CheckInParticipantStartDatetime = updatedTournament.CheckInParticipantStartDatetime;
            CheckInParticipantEndDatetime = updatedTournament.CheckInParticipantEndDatetime;
            Archived = updatedTournament.Archived;
            RegistrationAcceptanceMessage = updatedTournament.RegistrationAcceptanceMessage;
            RegistrationRefusalMessage = updatedTournament.RegistrationRefusalMessage;
            RegistrationTermsEnabled = updatedTournament.RegistrationTermsEnabled;
            RegistrationTermsUrl = updatedTournament.RegistrationTermsUrl;
            Discipline = updatedTournament.Discipline;
            Status = updatedTournament.Status;
            ParticipantType = updatedTournament.ParticipantType;
            Platforms = updatedTournament.Platforms;
            Featured = updatedTournament.Featured;
            RegistrationNotificationEnabled = updatedTournament.RegistrationNotificationEnabled;
            TeamMinSize = updatedTournament.TeamMinSize;
            TeamMaxSize = updatedTournament.TeamMaxSize;
            LastUpdated = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            if (obj is Tournament other)
            {
                if (other.Id == Id)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}