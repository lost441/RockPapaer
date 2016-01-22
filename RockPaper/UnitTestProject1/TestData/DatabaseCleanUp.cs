using RockPaper.DataSource;

namespace TestProject.TestData
{
    public static class DatabaseCleanUp
    {
        public static void ClearDataInDatabase()
        {
            using (var context = new RockPapercContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Rounds");
                context.Database.ExecuteSqlCommand("DELETE FROM Games");
                context.Database.ExecuteSqlCommand("DELETE FROM Teams");

                context.SaveChanges();
            }
        }
    }
}
