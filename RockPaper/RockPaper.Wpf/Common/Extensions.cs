using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper.Wpf.Common
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Maps the specified original.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>Mapped object.</returns>
        public static Models.Team Map(this RockPaperServiceReference.Team original)
        {
            return new Models.Team
            {
                Id = original.Id,
                TeamName = original.TeamName
            };
        }
    }
}
