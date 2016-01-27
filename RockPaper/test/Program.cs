using System;
using Contracts.Api;
using RockPaper.Common.ApiClient;

namespace test
{
    // http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client

    class Program
    {
        static void Main(string[] args)
        {
            var keypressed = 'A';

            while (keypressed != 'x')
            {
                Console.WriteLine("Press any key to get games");
                keypressed = Console.ReadKey().KeyChar;

                if (keypressed != 'x')
                {
                    var client = new JsonClientBuilder<Game>("api/v01/games");
                    client.Get().Wait();

                    var game = client.Get().Result;
                    
                    if (game != null)
                    {
                        Console.WriteLine(game.GameState);
                    }
                    else 
                    {
                        Console.WriteLine("No results to display");
                        Console.ReadKey();
                    }
                }
            }

            Console.Clear();
        }
    }
}
