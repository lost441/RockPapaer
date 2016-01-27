using RockPaper.Wpf.Common;
using RockPaper.Wpf.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RockPaper.Wpf.Adapters
{
    public class RestAdapter : IAdapter
    {
        public Result<Guid> GetNextAvailableGame(Guid teamId, bool? useSimulator)
        {
            var url = string.Format(@"http://localhost:49207/api/V01/games?isActive={0}&teamId={1}&playAgainstSimulator={2}", true, teamId, useSimulator);
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

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string returnedData = reader.ReadToEnd();
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

        public Result<bool> IsItMyTurn(Guid gameId, Guid teamId)
        {
            throw new NotImplementedException();
        }

        public Result<OperationOutcome> PlayHand(Guid gameId, Guid teamId, Hand hand)
        {
            var url = string.Format(@"http://localhost:49207/api/V01/games/PlayHand?gameId={0}&teamId={1}&hand={2}", gameId, teamId, hand);
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

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseItem<bool>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseItem<bool>));

                    return new Result<OperationOutcome>()
                    {
                        Data = new OperationOutcome { Result = serializedResult.Data, Error = string.Format(", ", serializedResult.Errors) },
                        IsSuccessfull = serializedResult.isSuccessfull
                    };
                }
            }
        }

        public Result<Game> GetGamebyGameId(Guid gameId)
        {
            var url = string.Format(@"http://localhost:49207/api/V01/games/{0}", gameId);
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

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string returnedData = reader.ReadToEnd();
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

        public Result<Team> RegisterTeam(string teamName)
        {
            var url = string.Format(@"http://localhost:49207/api/V01/teams");
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

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string returnedData = reader.ReadToEnd();
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

        public Result<Team> GetTeamByTeamName(string teamName)
        {
            var url = string.Format(@"http://localhost:49207/api/V01/teams?teamName={0}", teamName);
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

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string returnedData = reader.ReadToEnd();
                    var serializedResult = (ResponseList<Team>)JsonConvert.DeserializeObject(returnedData, typeof(ResponseList<Team>));
                    var team = serializedResult.Data.FirstOrDefault();
                    return new Result<Team>
                    {
                        Data = team != null ? team : null,
                        IsSuccessfull = serializedResult.isSuccessfull,
                        Errors = string.Join(", ", serializedResult.Errors)
                    };
                }
            }
        }

        public IEnumerable<Round> GetCompletedRoundByGameId(Guid gameId)
        {
            //var url = string.Format(@"http://api/V01/teams={0}", gameId);
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "application/json";
            //request.Credentials = new NetworkCredential("PayM8User", "password");
            //try
            //{
            //    using (var response = request.GetResponse() as HttpWebResponse)
            //    {
            //        if (response.StatusCode != HttpStatusCode.OK)
            //        {
            //            throw new ApplicationException("Failed API request");
            //        }

            //        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //        {
            //            string returnedData = reader.ReadToEnd();
            //            var serializedResult = (IEnumerable<Round>)JsonConvert.DeserializeObject(returnedData, typeof(IEnumerable<Round>));
            //            return serializedResult;
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    throw;
            //}


            //var url = string.Format(@"http://localhost:49207/api/V01/teams?teamName={0}", teamName);
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            ////request.Headers.Add("Authorization: OAuth " + accessToken);
            ////string postData = string.Format("param1=something&param2=something_else");
            ////byte[] data = Encoding.UTF8.GetBytes(postData);

            //request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "application/json";
            ////var _auth = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "PayM8Yser", "password")));
            ////var credentials = string.Format("{0} {1}", "Basic", _auth);
            ////request.Headers[HttpRequestHeader.Authorization] = credentials;
            //request.Credentials = new NetworkCredential("PayM8User", "password");

            ////request.ContentLength = data.Length;

            ////using (var requestStream = request.GetRequestStream())
            ////{
            ////    requestStream.Write(data, 0, data.Length);
            ////}
            ////System.Net.WebClient client = new WebClient();
            ////client.BaseAddress = url;
            ////client.Encoding = Encoding.UTF8;    
            //try
            //{
            //    using (var response = request.GetResponse() as HttpWebResponse)
            //    {
            //        if (response.StatusCode != HttpStatusCode.OK)
            //        {
            //            throw new ApplicationException("Failed API request");
            //        }

            //        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //        {
            //            string returnedData = reader.ReadToEnd();
            //            var serializedResult JsonConvert.DeserializeObject<IEnumerable<Team>>(returnedData);
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    throw;
            //}

            throw new NotImplementedException();
        }        
    }
}
