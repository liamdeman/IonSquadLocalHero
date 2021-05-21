using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Proj2Aalst_G3.Models.Domain;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Proj2Aalst_G3.Services.Toornament
{
    public class ToornamentService : IToornamentService
    {
        private readonly HttpClient client;
        private readonly IMapper mapper;
        private readonly ToornamentApiSettings options;

        private static OAuthToken token;
        
        private const string Scopes = "organizer:view organizer:delete organizer:admin organizer:registration";
        private const string TokenEndpoint = "oauth/v2/token";
        private const string TournamentEndpoint = "organizer/v2/tournaments";
        private const string RegistrationEndpoint = "organizer/v2/registrations";

        public ToornamentService(HttpClient client, IMapper mapper, IOptions<ToornamentApiSettings> options)
        {
            this.options = options.Value;
            this.mapper = mapper;
            this.client = client;
            if (token is null || token.IsExpired)
                RefreshToken().Wait(); //! This might give deadlock issues later, link in teams
            client.DefaultRequestHeaders.Add("Authorization", token?.AccessToken);
        }

        #region OAuth
        
        private async Task RefreshToken()
        {
            IEnumerable<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "client_credentials"),
                new("client_id", options.ClientId),
                new("client_secret", options.ClientSecret),
                new("scope", Scopes)
            };

            var content = new FormUrlEncodedContent(postData);
            var tokenJson = await client.PostAsync(TokenEndpoint, content);
            token = JsonConvert.DeserializeObject<OAuthToken>(await tokenJson.Content.ReadAsStringAsync());
        }
        
        #endregion

        #region Tournament Endpoint
        
        public async Task<IEnumerable<Tournament>> GetTournaments(int startRange, int endRange,
            Filters.TournamentFilter filter = null)
        {
            if ((endRange - startRange) + 1 > 50)
                throw new ArgumentException("Range cannot exceed 50");

            client.DefaultRequestHeaders.Add("Range", $"tournaments={startRange}-{endRange}");

            string uri;
            if (filter is not null)
            {
                var filters = await filter.BuildQueryParameters().ReadAsStringAsync();
                uri = $"{TournamentEndpoint}?{filters}";
            }
            else
                uri = TournamentEndpoint;

            var response = await client.GetAsync(uri);
            if (response.StatusCode != HttpStatusCode.PartialContent)
                throw new ArgumentException("The http GET request returned bad http code.",
                    response.StatusCode.ToString());
            var test = await response.Content.ReadAsStringAsync();
            var tournaments =
                /*await JsonSerializer.DeserializeAsync<IEnumerable<Responses.Tournament>>(
                    await response.Content.ReadAsStreamAsync());*/
                // api gives back null value datetimes, sticking to newtonsoft for now
                JsonConvert.DeserializeObject<IEnumerable<Responses.Tournament>>(test);
            return mapper.Map<IEnumerable<Responses.Tournament>, IEnumerable<Tournament>>(tournaments);
        }

        public async Task<Tournament> GetTournamentDetails(string id)
        {
            var uri = $"{TournamentEndpoint}/{id}";

            var response = await client.GetAsync(uri);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ArgumentException("The http GET request returned bad http code.",
                    response.StatusCode.ToString());

            var tournament = JsonConvert.DeserializeObject<Responses.TournamentDetailed>(
                await response.Content.ReadAsStringAsync());
            return mapper.Map<Responses.TournamentDetailed, Tournament>(tournament);
        }

        public async Task<Tournament> CreateTournament(Queries.Tournament.Create tournament)
        {
            var uri = TournamentEndpoint;
            var jsonBody = JsonConvert.SerializeObject(tournament);

            var response = await client.PostAsync(uri, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            var tournamentResponse = JsonConvert.DeserializeObject<Responses.TournamentDetailed>(
                await response.Content.ReadAsStringAsync());
            return mapper.Map<Responses.TournamentDetailed, Tournament>(tournamentResponse);
        }

        public async Task<HttpStatusCode> DeleteTournament(string id)
        {
            var uri = $"{TournamentEndpoint}/{id}";

            var response = await client.DeleteAsync(uri);
            return response.StatusCode;
        }

        public async Task<Tournament> UpdateTournament(string id, Queries.Tournament.Update tournament)
        {
            var uri = $"{TournamentEndpoint}/{id}";
            var jsonBody = JsonConvert.SerializeObject(tournament);

            var response = await client.PatchAsync(uri, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            var tournamentResponse = JsonConvert.DeserializeObject<Responses.TournamentDetailed>(
                await response.Content.ReadAsStringAsync());

            if (tournamentResponse.Id is null)
            {
                throw new BadHttpRequestException("Update did not succeed", (int)response.StatusCode);
            }

            return mapper.Map<Responses.TournamentDetailed, Tournament>(tournamentResponse);
        }
        
        #endregion

        #region Registration Endpoint
        
        public async Task<Registration> CreateRegistration(string tournamentId, Queries.Registration registrationDto)
        {
            var uri = $"{TournamentEndpoint}/{tournamentId}/registrations";
            var jsonBody = JsonConvert.SerializeObject(registrationDto);

            var response = await client.PostAsync(uri, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            var registrationResponse = JsonConvert.DeserializeObject<Responses.Registration>(
                await response.Content.ReadAsStringAsync());

            if (registrationResponse is null)
            {
                throw new BadHttpRequestException("Something went wrong", (int)response.StatusCode);
            }

            return mapper.Map<Responses.Registration, Registration>(registrationResponse);
        }

        public async Task<IEnumerable<Registration>> GetRegistrations(Filters.RegistrationFilter filter, int startIndex = 0, int endIndex = 49)
        {
            if ((endIndex - startIndex) + 1 > 50)
                throw new ArgumentException("Range cannot exceed 50");

            client.DefaultRequestHeaders.Add("Range", $"registrations={startIndex}-{endIndex}");
            
            var uri = RegistrationEndpoint;
            if (filter is not null)
            {
                var filters = await filter.BuildQueryParameters().ReadAsStringAsync();
                uri += $"?{filters}";
            }

            var response = await client.GetAsync(uri);

            var registrationResponse = JsonConvert.DeserializeObject<IEnumerable<Responses.Registration>>(
                await response.Content.ReadAsStringAsync());

            if (registrationResponse is null)
            {
                throw new BadHttpRequestException("Something went wrong", (int)response.StatusCode);
            }

            return mapper.Map<IEnumerable<Responses.Registration>, IEnumerable<Registration>>(registrationResponse);
        }

        #endregion

    }
}