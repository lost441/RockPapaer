using RockPaper.AdapterImplentations;
using Contracts;
using Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Providers;

namespace TestProject.TestData
{
    internal sealed partial class ObjectMother
    {
        internal static class RoundTestData
        {
            public static Round Round1 { get; set; }

            public static Round Round2 { get; set; }

            public static Round Round3 { get; set; }

            public static Round Round4 { get; set; }

            public static Round Round5 { get; set; }

            public static void Create()
            {
                var round = new Round
                {
                    GameId = ObjectMother.GameTestData.Game2.Id,
                    Result = RoundResult.Team1Won,
                    Team1Hand = Hand.Paper,
                    Team2Hand = Hand.None,
                    SequenceNumber = 1,
                };

                var adapter = new RoundAdapter();
                Round1 = adapter.CreateRound(round);

                round = new Round
                {
                    GameId = ObjectMother.GameTestData.Game2.Id,
                    Result = RoundResult.Team1Won,
                    Team1Hand = Hand.Rock,
                    Team2Hand = Hand.None,
                    SequenceNumber = 1
                };

                Round2 = adapter.CreateRound(round);

                round = new Round
                {
                    GameId = ObjectMother.GameTestData.Game2.Id,
                    Result = RoundResult.Team1Won,
                    Team1Hand = Hand.Spock,
                    Team2Hand = Hand.None,
                    SequenceNumber = 1
                };

                Round3 = adapter.CreateRound(round);

                round = new Round
                {
                    GameId = ObjectMother.GameTestData.Game2.Id,
                    Result = RoundResult.Draw,
                    Team1Hand = Hand.Spock,
                    Team2Hand = Hand.Spock,
                    SequenceNumber = 1
                };

                Round4 = adapter.CreateRound(round);

                round = new Round
                {
                    GameId = ObjectMother.GameTestData.Game2.Id,
                    Result = RoundResult.Team1Won,
                    Team1Hand = Hand.Spock,
                    Team2Hand = Hand.Rock,
                    SequenceNumber = 1
                };

                Round5 = adapter.CreateRound(round);
                adapter.SaveChanges();
            }
        }
    }
}