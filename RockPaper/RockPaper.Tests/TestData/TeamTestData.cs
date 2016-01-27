using RockPaper.AdapterImplentations;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.TestData
{
    internal sealed partial class ObjectMother
    {
        internal static class TeamTestData
        {
            public static Guid Team1Id { get; set; }

            public static Guid Team2Id { get; set; }

            public static Guid Team3Id { get; set; }


            public static void Create()
            {
                var adapter = new TeamAdapter();

                Team1Id = adapter.RegisterNewTeam("OM: Team Name 1").Id;
                Team2Id = adapter.RegisterNewTeam("OM: Team Name 2").Id;
                Team3Id = adapter.RegisterNewTeam("OM: Team Name 3").Id;

                adapter.SaveChanges();
            }

        }
    }
}