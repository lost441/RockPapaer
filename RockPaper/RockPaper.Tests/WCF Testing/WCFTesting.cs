
namespace TestProject.WCF_Testing
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WCFTesting
    {
        [TestMethod, Ignore]
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
