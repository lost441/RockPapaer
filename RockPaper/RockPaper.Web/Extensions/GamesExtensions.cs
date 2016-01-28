using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockPaper.Web.Models;

namespace RockPaper.Web.Extensions
{
    /// <summary>
    /// Class GamesExtensions.
    /// </summary>
    public static class GamesExtensions
    {

        /// <summary>
        /// Compares two game objects by their created date property.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="other">The other.</param>
        /// <returns>System.Int32.</returns>
        public static int CompareByDate(this GameResult self, GameResult other)
       {
            //if self is null return a positive number and exit
           if(self == null)
               return 1;
           
            //if other is null return a negative number and exit
               if(other == null)
                   return -1;

            //if we made it this point we need to compare by properties
            if(self.Game.CreatedDate < other.Game.CreatedDate)
            {
                return -1;
            }
            else
                if(self.Game.CreatedDate > other.Game.CreatedDate)
                {
                    return 1;
                }
                else
                {
                    //they are likely created at the same time, return 0 to denote equality.
                    return 0;
                }
               
       }
    }
}