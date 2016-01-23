// <copyright file="ObjectMother.cs"  company="PayM8">
//     PayM8 All rights reserved.
// </copyright>

namespace TestProject.TestData
{
    using System.Linq;

    /// <summary>
    /// Create objects for use in tests.
    /// </summary>
    internal sealed partial class ObjectMother
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        private static readonly ObjectMother ObjectMotherInstance = new ObjectMother();

        /// <summary>
        /// Initializes static members of the <see cref="ObjectMother"/> class.
        /// </summary>
        static ObjectMother()
        {
            ClearAndCreateAllData();
        }

        /// <summary>
        /// Clears the and create all data.
        /// </summary>
        public static void ClearAndCreateAllData()
        {
            //// Clear all data
            DatabaseCleanUp.ClearDataInDatabase();

            //// Start pumping in data
            TeamTestData.Create();
            GameTestData.Create();
            RoundTestData.Create();
        }

        public static void ClearData()
        {

        }

        /// <summary>
        /// Prevents a default instance of the <see cref="ObjectMother"/> class from being created.
        /// </summary>
        private ObjectMother()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ObjectMother Instance
        {
            get
            {
                return ObjectMotherInstance;
            }
        }
    }
}
