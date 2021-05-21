using FluentValidation;
using Proj2Aalst_G3.Models.ViewModels;

namespace Proj2Aalst_G3.Validators
{
    public class TournamentViewModelValidator : AbstractValidator<TournamentViewModels.Edit>
    {
        public TournamentViewModelValidator()
        {
            // Rules for when the viewmodel does not have an Id, meaning it is creating a new one.
            // In that case below fields are required for the post request
            When(x => x.Id is null, () =>
            {
                RuleFor(x => x.Name)
                    .NotNull()
                    .WithName("Naam")
                    .WithMessage("{PropertyName} kan niet leeg zijn.");
                RuleFor(x => x.Timezone)
                    .NotNull()
                    .WithName("Tijdzone")
                    .WithMessage("{PropertyName} kan niet leeg zijn.");
                RuleFor(x => x.Size)
                    .NotNull()
                    .WithName("Grootte")
                    .WithMessage("{PropertyName} kan niet leeg zijn.");
                RuleFor(x => x.Discipline)
                    .NotNull()
                    .WithName("Game")
                    .WithMessage("{PropertyName} kan niet leeg zijn.");
                RuleFor(x => x.ParticipantType)
                    .NotNull()
                    .WithName("Deelnemerstype")
                    .WithMessage("{PropertyName} kan niet leeg zijn.");
                RuleFor(x => x.Platforms)
                    .NotNull()
                    .WithName("Platformen")
                    .WithMessage("{PropertyName} kan niet leeg zijn.");
            });

            When(x => x.ParticipantType != "team", () =>
            {
                RuleFor(x => x.TeamMinSize)
                    .Null()
                    .WithName("Minimum teamgrootte")
                    .WithMessage("{PropertyName} moet leeg zijn.");
                RuleFor(x => x.TeamMaxSize)
                    .Null()
                    .WithName("Minimum teamgrootte")
                    .WithMessage("{PropertyName} moet leeg zijn.");
            });
            
            // General validation rules
            RuleFor(x => x.Name)
                .MaximumLength(30)
                .WithName("Naam")
                .WithMessage("{PropertyName} mag maximum {MaxLength} karakters bevatten.");
            RuleFor(x => x.FullName)
                .MaximumLength(80)
                .WithName("Volledige Naam")
                .WithMessage("{PropertyName} mag maximum {MaxLength} karakters bevatten.");
            RuleFor(x => x.TeamMinSize)
                .LessThanOrEqualTo(x => x.TeamMaxSize)
                .When(x => x.ParticipantType == "team")
                .WithMessage("De minimumgrootte mag niet groter zijn dan de maximumgrootte.");
            RuleFor(x => x.Prize)
                .MaximumLength(1500)
                .WithName("Prijs")
                .WithMessage("{PropertyName} mag maximum {MaxLength} karakters bevatten.");
            RuleFor(x => x.Description)
                .MaximumLength(1500)
                .WithName("Beschrijving")
                .WithMessage("{PropertyName} mag maximum {MaxLength} karakters bevatten.");
            RuleFor(x => x.Rules)
                .MaximumLength(10000)
                .WithName("Regels")
                .WithMessage("{PropertyName} mag maximum {MaxLength} karakters bevatten.");
            RuleFor(x => x.Country)
                .MaximumLength(2)
                .WithName("Land")
                .WithMessage("{PropertyName} moet een 2-letterige landcode bevatten.");
            RuleFor(x => x.Size)
                .GreaterThan(1)
                .WithName("Grootte")
                .WithMessage("{PropertyName} moet groter dan 0 zijn.");
            
            When(x => x.RegistrationEnabled, () =>
            {
                RuleFor(x => x.RegistrationOpeningDatetime)
                    .LessThan(x => x.RegistrationClosingDatetime)
                    .WithName("Openingstijd registratie")
                    .WithMessage("{PropertyName} moet vroeger zijn dan zijn eindtijd.");
            });

            RuleFor(x => x.ScheduledDateStart)
                .LessThanOrEqualTo(x => x.ScheduledDateEnd)
                .WithName("Startdatum")
                .WithMessage("{PropertyName} moet vroeger zijn dan de einddatum.");
        }
    }
}
