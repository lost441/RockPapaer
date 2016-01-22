// <copyright file="RockPapercContext.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.DataSource
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RockPapercContext : DbContext
    {
        // Your context has been configured to use a 'RockPaper' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RockPaper.DataSource.RockPaper' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RockPaper' 
        // connection string in the application configuration file.
        public RockPapercContext()
            : base("name=RockPaper")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.


        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        public DbSet<Team> Team { get; set; }

        /// <summary>
        /// Gets or sets the round.
        /// </summary>
        /// <value>
        /// The round.
        /// </value>
        public DbSet<Round> Round { get; set; }

        /// <summary>
        /// Gets or sets the games.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        public DbSet<Game> Games { get; set; }

        
    }
}