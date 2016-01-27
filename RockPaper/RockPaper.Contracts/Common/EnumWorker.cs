
namespace Contracts.Common
{
    using System;
    using System.ComponentModel;

    public static class EnumWorker
    {
        /// <summary>
        /// Get the description of the specified enumeration.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="enumValue">The enumeration value.</param>
        /// <returns>The enumeration description.</returns>
        public static string ToDescription<TEnum>(this TEnum enumValue)
        {
            ValidateTypeAsEnum<TEnum>();
            return GetEnumDescription((Enum)(object)(enumValue));
        }

        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The parsed Enum value</returns>
        public static TEnum ParseEnum<TEnum>(string value)
        {
            ValidateTypeAsEnum<TEnum>();
            return (TEnum)Enum.Parse(typeof(TEnum), value, true);
        }

        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultEnum">The enum default.</param>
        /// <returns>The parsed Enum value</returns>
        public static T ParseEnum<T>(string value, T defaultEnum)
        {
            try
            {
                return ParseEnum<T>(value);
            }
            catch (Exception)
            {
                return defaultEnum;
            }
        }

        /// <summary>
        /// Gets the enum description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The Enum description if available</returns>
        private static string GetEnumDescription(Enum value)
        {
            var enumItem = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])enumItem.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Parses the enum from description.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumDescription">The enum description.</param>
        /// <param name="defaultEnum">The default enum.</param>
        /// <returns>The Enum from Description</returns>
        public static TEnum ParseEnumFromDescription<TEnum>(string enumDescription, TEnum defaultEnum)
        {
            ValidateTypeAsEnum<TEnum>();
            foreach (Enum enumItem in Enum.GetValues(typeof(TEnum)))
            {
                if (!string.Equals(enumDescription,
                    GetEnumDescription(enumItem),
                    StringComparison.CurrentCultureIgnoreCase)) continue;

                object result = enumItem;
                return (TEnum)result;
            }

            return defaultEnum;
        }

        /// <summary>
        /// Validates the enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <exception cref="System.InvalidCastException"></exception>
        private static void ValidateTypeAsEnum<TEnum>()
        {
            var theType = typeof(TEnum);

            if (!theType.IsEnum)
            {
                throw new InvalidCastException(string.Format("Enum Worker opperations can only be applied to Enums not [{0}]", theType));
            }
        }
    }
}
