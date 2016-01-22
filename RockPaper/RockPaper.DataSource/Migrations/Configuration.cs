// <copyright file="Configuration.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.DataSource.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// The Confguration file.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<RockPaper.DataSource.RockPapercContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "RockPaper.DataSource.RockPapercContext";
            
        }

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(RockPaper.DataSource.RockPapercContext context)
        {   
            //context.Database.Delete();
            //context.Database.Create();
        }
    }
}
