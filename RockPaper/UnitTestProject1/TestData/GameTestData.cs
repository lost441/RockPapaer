using RockPaper.AdapterImplentations;
using RockPaper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.TestData
{
    internal sealed partial class ObjectMother
    {
        internal static class GameTestData
        {
            public static Game Game1 { get; set; }
            public static Game Game2 { get; set; }
            public static Game Game3 { get; set; }


            public static void Create()
            {
                var adapter = new GameAdapter();
                Game1 = adapter.RegisiterNewGame();
                Game2 = adapter.RegisiterNewGame();
                Game3 = adapter.RegisiterNewGame();

                adapter.SaveChanges();
            }

        }
    }
}
