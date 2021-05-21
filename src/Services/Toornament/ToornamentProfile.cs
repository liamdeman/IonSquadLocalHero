using AutoMapper;
using Proj2Aalst_G3.Extensions;
using Proj2Aalst_G3.Models.Domain;

namespace Proj2Aalst_G3.Services.Toornament
{
    public class ToornamentProfile : Profile
    {
        public ToornamentProfile()
        {
            CreateMap<Responses.Tournament, Tournament>()
                .Ignore(t => t.Organization)
                .Ignore(t => t.Contact)
                .Ignore(t => t.Discord)
                .Ignore(t => t.Website)
                .Ignore(t => t.Description)
                .Ignore(t => t.Rules)
                .Ignore(t => t.Prize)
                .Ignore(t => t.MatchReportEnabled)
                .Ignore(t => t.RegistrationRequestMessage)
                .Ignore(t => t.CheckInEnabled)
                .Ignore(t => t.CheckInParticipantEnabled)
                .Ignore(t => t.CheckInParticipantStartDatetime)
                .Ignore(t => t.CheckInParticipantEndDatetime)
                .Ignore(t => t.Archived)
                .Ignore(t => t.RegistrationAcceptanceMessage)
                .Ignore(t => t.RegistrationRefusalMessage)
                .Ignore(t => t.RegistrationTermsEnabled)
                .Ignore(t => t.RegistrationTermsUrl)
                .Ignore(t => t.ParticipantType)
                .Ignore(t => t.Featured)
                .Ignore(t => t.RegistrationNotificationEnabled)
                .Ignore(t => t.TeamMinSize)
                .Ignore(t => t.TeamMaxSize)
                .Ignore(t => t.LastUpdated);
            CreateMap<Responses.Logo, Logo>()
                .Ignore(l => l.Id);
            CreateMap<Responses.TournamentDetailed, Tournament>()
                .Ignore(t => t.LastUpdated);
            CreateMap<Responses.Lineup, Lineup>()
                .Ignore(l => l.Id);
            CreateMap<Responses.Registration, Registration>();
        }
    }
}