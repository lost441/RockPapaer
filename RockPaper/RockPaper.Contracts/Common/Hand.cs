// <copyright file="Hand.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace RockPaper.Contracts.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The enumeration for hand.
    /// </summary>
    public enum Hand
    {
        /// <summary>
        /// The rock.
        /// </summary>
        Rock,

        /// <summary>
        /// The paper.
        /// </summary>
        [Description("Paper")]
        Paper,

        /// <summary>
        /// The scissor.
        /// </summary>
        Scissor,

        /// <summary>
        /// The lizard.
        /// </summary>
        Lizard,

        /// <summary>
        /// The spock.
        /// </summary>
        Spock,

        /// <summary>
        /// The none.
        /// </summary>
        None,
    }
}
