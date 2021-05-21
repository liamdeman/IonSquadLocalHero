using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Lineup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CustomUserIdentifier { get; set; }
        [NotMapped]
        public Dictionary<string, string> CustomFields { get; set; }
        public string UserId { get; set; }
    }

    public class Registration
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CustomUserIdentifier { get; set; }
        [NotMapped]
        public Dictionary<string, string> CustomFields { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string TournamentId { get; set; }
        public string ParticipantId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Lineup> Lineup { get; set; }
    }
}
