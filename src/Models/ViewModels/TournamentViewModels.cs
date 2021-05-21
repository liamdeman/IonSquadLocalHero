using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Models.ViewModels
{
    public class TournamentViewModels
    {
        public class Detail
        {
            public string Name { get; }
            
            [Display(Name = "Volledige Naam")]
            public string FullName { get; }

            [Display(Name = "Startdatum")]
            public DateTime? ScheduledDateStart { get; }

            [Display(Name = "Einddatum")]
            public DateTime? ScheduledDateEnd { get; }

            [Display(Name = "Aantal spelers/teams")]
            public int Size { get; }

            [Display(Name = "Wordt online gespeeld?")]
            public bool Online { get; }

            [Display(Name = "Plaats")]
            public string Location { get; }

            [Display(Name = "Logo")]
            public string Logo { get; }
            
            public bool RegistrationEnabled { get; }

            [Display(Name = "Registraties open sinds")]
            public DateTime? RegistrationOpeningDatetime { get; }

            [Display(Name = "Registraties gesloten op")]
            public DateTime? RegistrationClosingDatetime { get; }

            [Display(Name = "Organisator")]
            public string Organization { get; }

            [Display(Name = "Contactpersoon")]
            public string Contact { get; }

            [Display(Name = "Beschrijving")]
            public string Description { get; }

            [Display(Name = "Regels")]
            public string Rules { get; }

            [Display(Name = "Prijs")]
            public string Prize { get; }

            [Display(Name = "Staat resultaatingave aan?")]
            public bool MatchReportEnabled { get; }

            [Display(Name = "Registratieboodschap")]
            public string RegistrationRequestMessage { get; }

            /*[Display(Name = "Staat Check-in aan voor organisator?")]
            public bool CheckInEnabled { get; }*/
            
            public bool CheckInParticipantEnabled { get; }

            [Display(Name = "Starttijd check-in")]
            public DateTime? CheckInParticipantStartDatetime { get; }

            [Display(Name = "eindtijd check-in")]
            public DateTime? CheckInParticipantEndDatetime { get; }

            [Display(Name = "Gearchiveerd")]
            public bool Archived { get; }
            
            public string RegistrationAcceptanceMessage { get; }

            public string RegistrationRefusalMessage { get; }

            public bool RegistrationTermsEnabled { get; }

            [Display(Name = "Registratietermen")]
            public string RegistrationTermsUrl { get; }

            [Display(Name = "Game")]
            public string Discipline { get; }

            [Display(Name = "Status")]
            public string Status { get; }

            [Display(Name = "Individueel of in team?")]
            public string ParticipantType { get; }

            public List<string> Platforms { get; }

            [Display(Name = "Minimum teamgrootte")]
            public int? TeamMinSize { get; }

            [Display(Name = "Maximum check-in")]
            public int? TeamMaxSize { get; }

            public string Id { get; }

            [Display(Name = "Registraties")]
            public IEnumerable<RegistrationViewModels.Create> Registrations { get; set; }

            public Detail()
            {
            }

            public Detail(Tournament tournament, IEnumerable<Registration> registrations)
            {
                Name = tournament.Name;
                FullName = tournament.FullName;
                ScheduledDateStart = tournament.ScheduledDateStart;
                ScheduledDateEnd = tournament.ScheduledDateEnd;
                Size = tournament.Size;
                Online = tournament.Online;
                Location = tournament.Location;
                Logo = tournament.Logo?.LogoLarge;
                RegistrationEnabled = tournament.RegistrationEnabled;
                RegistrationOpeningDatetime = tournament.RegistrationOpeningDatetime;
                RegistrationClosingDatetime = tournament.RegistrationClosingDatetime;
                Organization = tournament.Organization;
                Contact = tournament.Contact;
                Description = tournament.Description;
                Rules = tournament.Rules;
                Prize = tournament.Prize;
                MatchReportEnabled = tournament.MatchReportEnabled;
                RegistrationRequestMessage = tournament.RegistrationRequestMessage;
                //CheckInEnabled = tournament.CheckInEnabled;
                CheckInParticipantEnabled = tournament.CheckInParticipantEnabled;
                CheckInParticipantStartDatetime = tournament.CheckInParticipantStartDatetime;
                CheckInParticipantEndDatetime = tournament.CheckInParticipantEndDatetime;
                Archived = tournament.Archived;
                RegistrationAcceptanceMessage = tournament.RegistrationAcceptanceMessage;
                RegistrationRefusalMessage = tournament.RegistrationRefusalMessage;
                RegistrationTermsEnabled = tournament.RegistrationTermsEnabled;
                RegistrationTermsUrl = tournament.RegistrationTermsUrl;
                Discipline = tournament.Discipline;
                Status = tournament.Status;
                ParticipantType = tournament.ParticipantType;
                Platforms = tournament.Platforms;
                TeamMinSize = tournament.TeamMinSize;
                TeamMaxSize = tournament.TeamMaxSize;
                Id = tournament.Id;
                Registrations = registrations?.Select(r => new RegistrationViewModels.Create(r));
            }
        }

        public class Edit
        {
            public string Id { get; set; }
            [Display(Name = "Naam")]
            public string Name { get; set; }
            [Display(Name = "Volledige naam")]
            public string FullName { get; set; }
            [Display(Name = "Geplande startdatum")]
            public DateTime? ScheduledDateStart { get; set; }
            [Display(Name = "Geplande einddatum")]
            public DateTime? ScheduledDateEnd { get; set; }
            [Display(Name = "Tijdzone")]
            public string Timezone { get; set; }
            [Display(Name = "Zichtbaar")]
            public bool Public { get; set; }
            [Display(Name = "Aantal deelnemers of teams")]
            public int Size { get; set; }
            [Display(Name = "Wordt online gespeeld")]
            public bool Online { get; set; }
            [Display(Name = "Locatie")]
            public string Location { get; set; }
            [Display(Name = "Land")]
            public string Country { get; set; }
            public Logo Logo { get; set; }
            [Display(Name = "Registratie open")]
            public bool RegistrationEnabled { get; set; }
            [Display(Name = "Registratie opent op")]
            public DateTime? RegistrationOpeningDatetime { get; set; }
            [Display(Name = "Registratie sluit op")]
            public DateTime? RegistrationClosingDatetime { get; set; }
            [Display(Name = "Organisatie")]
            public string Organization { get; set; }
            [Display(Name = "Contactpersoon")]
            public string Contact { get; set; }
            [Display(Name = "Discord Link")]
            public string Discord { get; set; }
            [Display(Name = "Website")]
            public string Website { get; set; }
            [Display(Name = "Beschrijving")]
            public string Description { get; set; }
            [Display(Name = "Regels")]
            public string Rules { get; set; }
            [Display(Name = "Winnaarsprijs")]
            public string Prize { get; set; }
            [Display(Name = "Uitslagingave")]
            public bool MatchReportEnabled { get; set; }
            [Display(Name = "Registratieboodschap")]
            public string RegistrationRequestMessage { get; set; }
            [Display(Name = "Check in")]
            public bool CheckInEnabled { get; set; }
            [Display(Name = "Deelnemer check in")]
            public bool CheckInParticipantEnabled { get; set; }
            [Display(Name = "Deelnemer check in begintijd")]
            public DateTime? CheckInParticipantStartDatetime { get; set; }
            [Display(Name = "Deelnemer check in eindtijd")]
            public DateTime? CheckInParticipantEndDatetime { get; set; }
            [Display(Name = "Gearchiveerd")]
            public bool Archived { get; set; }
            [Display(Name = "Boodschap bij geaccepteerde registratie")]
            public string RegistrationAcceptanceMessage { get; set; }
            [Display(Name = "Boodschap bij geweigerde registratie")]
            public string RegistrationRefusalMessage { get; set; }
            [Display(Name = "Registratievoorwaarden")]
            public bool RegistrationTermsEnabled { get; set; }
            [Display(Name = "URL registratievoorwaarden")]
            public string RegistrationTermsUrl { get; set; }
            [Display(Name = "Game")]
            public string Discipline { get; set; }
            [Display(Name = "Deelnemertype")]
            public string ParticipantType { get; set; }
            [Display(Name = "Platformen")]
            public List<string> Platforms { get; set; }
            [Display(Name = "Minimum teamgrootte")]
            public int? TeamMinSize { get; set; }
            [Display(Name = "Maximum teamgrootte")]
            public int? TeamMaxSize { get; set; }

            public Edit()
            {
            }

            public Edit(Tournament tournament)
            {
                Id = tournament.Id;
                Name = tournament.Name;
                FullName = tournament.FullName;
                ScheduledDateStart = tournament.ScheduledDateStart;
                ScheduledDateEnd = tournament.ScheduledDateEnd;
                Timezone = tournament.Timezone;
                Public = tournament.Public;
                Size = tournament.Size;
                Online = tournament.Online;
                Location = tournament.Location;
                Country = tournament.Country;
                Logo = tournament.Logo;
                RegistrationEnabled = tournament.RegistrationEnabled;
                RegistrationOpeningDatetime = tournament.RegistrationOpeningDatetime;
                RegistrationClosingDatetime = tournament.RegistrationClosingDatetime;
                Organization = tournament.Organization;
                Contact = tournament.Contact;
                Discord = tournament.Discord;
                Website = tournament.Website;
                Description = tournament.Description;
                Rules = tournament.Rules;
                Prize = tournament.Prize;
                MatchReportEnabled = tournament.MatchReportEnabled;
                RegistrationRequestMessage = tournament.RegistrationRequestMessage;
                CheckInEnabled = tournament.CheckInEnabled;
                CheckInParticipantEnabled = tournament.CheckInParticipantEnabled;
                CheckInParticipantStartDatetime = tournament.CheckInParticipantStartDatetime;
                CheckInParticipantEndDatetime = tournament.CheckInParticipantEndDatetime;
                Archived = tournament.Archived;
                RegistrationAcceptanceMessage = tournament.RegistrationAcceptanceMessage;
                RegistrationRefusalMessage = tournament.RegistrationRefusalMessage;
                RegistrationTermsEnabled = tournament.RegistrationTermsEnabled;
                RegistrationTermsUrl = tournament.RegistrationTermsUrl;
                Discipline = tournament.Discipline;
                ParticipantType = tournament.ParticipantType;
                Platforms = tournament.Platforms;
                TeamMinSize = tournament.TeamMinSize;
                TeamMaxSize = tournament.TeamMaxSize;
            }
        }
    }
}
