using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.WCF_Testing
{
    [TestClass]
    public class WCFTesting
    {
        [TestMethod]
        public void RegisterTeamWCF()
        {
            var client = new RockPaperDEV.RockPaperServiceClient();
            var team = client.GetTeamByTeamName("Test");

            if (team.Data == null)
            {

            }
        }
    }
}
