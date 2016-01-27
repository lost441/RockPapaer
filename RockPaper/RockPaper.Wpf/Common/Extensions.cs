
namespace RockPaper.Wpf.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// To the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The enumerator</returns>
        /// <exception cref="System.InvalidCastException">value</exception>
        public static T ToEnum<T>(this string value) where T: struct
        {
            T myEnum;
            if (!Enum.TryParse<T>(value,  out myEnum))
            {
                throw new InvalidCastException(value);
            }

            return myEnum;
        }
    }
}
