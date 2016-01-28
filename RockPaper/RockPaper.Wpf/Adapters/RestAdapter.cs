
namespace RockPaper.Wpf.Adapters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Common;
    using Models;
    using Newtonsoft.Json;
    using Properties;

    /// <summary>
    /// REST adapter implementation.
    /// </summary>
    public class RestAdapter : IAdapter
    {
        /// <summary>
        /// Gets the next available game.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="useSimulator">The use simulator.</param>
        /// <returns>
        /// Game identifier
        /// </returns>
        /// <exception cref="System.ApplicationException">Failed API request</exception>
        public Result<Guid> GetNextAvailableGame(Guid teamId, bool? useSimulator)
        {
            var url = string.Format(Settings.Default.GetNextAvailableGameLink, true, teamId, useSimulator);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            request.Credentials = new NetworkCredential("PayM8User", "password");

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Failed API request");
                }

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseList<Game>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseList<Game>));
                    var game = serializedResult.Data.FirstOrDefault();
                    return new Result<Guid>
                    {
                        Data = game != null ? game.Id : Guid.Empty,
                        IsSuccessfull = serializedResult.isSuccessfull,
                        Errors = string.Join(", ", serializedResult.Errors)
                    };
                }
            }
        }

        /// <summary>
        /// Determines whether [is it my turn] [the specified game identifier].
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <returns>
        /// A bool indicating if its the teams turn.
        /// </returns>
        /// <exception cref="System.ApplicationException">Failed API request</exception>
        public Result<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            var url = string.Format(Settings.Default.IsItMyTurnLink, gameId, teamId);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            request.Credentials = new NetworkCredential("PayM8User", "password");

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Failed API request");
                }

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseItem<bool>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseItem<bool>));
                    return new Result<bool>
                    {
                        Data = serializedResult.Data,
                        IsSuccessfull = serializedResult.isSuccessfull,
                        Errors = string.Join(", ", serializedResult.Errors)
                    };
                }
            }
        }

        /// <summary>
        /// Plays the hand.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="hand">The hand.</param>
        /// <returns>
        /// The outcome
        /// </returns>
        /// <exception cref="System.ApplicationException">Failed API request</exception>
        public Result<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand)
        {
            var url = string.Format(Settings.Default.PlayHandLink, gameId, teamId, hand);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Credentials = new NetworkCredential("PayM8User", "password");
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Failed API request");
                }

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseItem<bool>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseItem<bool>));

                    return new Result<OperationOutcome>()
                    {
                        Data = new OperationOutcome { Result = serializedResult.Data, Error = string.Format(", ", serializedResult.Errors) },
                        IsSuccessfull = serializedResult.isSuccessfull
                    };
                }
            }
        }

        /// <summary>
        /// Gets the gameby game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>
        /// The game
        /// </returns>
        /// <exception cref="System.ApplicationException">Failed API request</exception>
        public Result<Game> GetGamebyGameId(Guid gameId)
        {
            var url = string.Format(Settings.Default.GetGamebyGameIdLink, gameId);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            request.Credentials = new NetworkCredential("PayM8User", "password");

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Failed API request");
                }

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseItem<Game>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseItem<Game>));
                    return new Result<Game>()
                    {
                        Data = serializedResult.Data,
                        Errors = string.Format(", ", serializedResult.Errors),
                        IsSuccessfull = serializedResult.isSuccessfull
                    };
                }
            }
        }

        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>
        /// The team
        /// </returns>
        /// <exception cref="System.ApplicationException">Failed API request</exception>
        public Result<Team> RegisterTeam(string teamName)
        {
            var url = string.Format(Settings.Default.RegisterTeamLink);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Credentials = new NetworkCredential("PayM8User", "password");
            var team = new Team { TeamName = teamName };
            var dataToSend = JsonConvert.SerializeObject(team);
            byte[] buffer = Encoding.UTF8.GetBytes(dataToSend);
            request.ContentLength = buffer.Length;

            using (var postData = request.GetRequestStream())
            {
                postData.Write(buffer, 0, buffer.Length);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Failed API request");
                }

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseItem<Team>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseItem<Team>));

                    return new Result<Team>()
                    {
                        Data = serializedResult.Data,
                        Errors = string.Format(", ", serializedResult.Errors),
                        IsSuccessfull = serializedResult.isSuccessfull
                    };
                }
            }
        }

        /// <summary>
        /// Gets the name of the team by team.
        /// </summary>
        /// <param name="teamName">Name of the team.</param>
        /// <returns>
        /// The team
        /// </returns>
        /// <exception cref="System.ApplicationException">Failed API request</exception>
        public Result<Team> GetTeamByTeamName(string teamName)
        {
            var url = string.Format(Settings.Default.GetTeamByTeamNameLink, teamName);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            request.Credentials = new NetworkCredential("PayM8User", "password");

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Failed API request");
                }

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseList<Team>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseList<Team>));
                    var team = serializedResult.Data.FirstOrDefault();
                    return new Result<Team>
                    {
                        Data = team,
                        IsSuccessfull = serializedResult.isSuccessfull,
                        Errors = string.Join(", ", serializedResult.Errors)
                    };
                }
            }
        }

        /// <summary>
        /// Gets the completed round by game identifier.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>
        /// The rounds
        /// </returns>
        /// <exception cref="System.ApplicationException">Failed API request</exception>
        public IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId)
        {
            //TODO: Implement API call.
            return new List<Round>();
        }        
    }
}
