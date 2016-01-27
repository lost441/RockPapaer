
namespace RockPaper.Common.ApiClient
{
    using System.Net.Http;
    using System;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class JsonClientBuilder<T> : HttpClient
    {
        /// <summary>
        /// Gets the relative API path.
        /// </summary>
        /// <value>The relative API path</value>
        public string RelativeApiPath { get; private set; }

        public JsonClientBuilder(string relativeApiPath)
        {
            this.BaseAddress = new Uri(Properties.Common.Default.BaseApiUrl);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.RelativeApiPath = relativeApiPath;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>The async task</returns>
        public async Task<T> Get()
        {
            try
            {
                var response = await this.GetAsync(RelativeApiPath);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var task = await response.Content.ReadAsAsync<T>();

                    return task;
                }
            }
            catch (HttpRequestException ex)
            {
                var msg = ex.Message;
            }

            return default(T);
        }
    }
}
