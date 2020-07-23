namespace OnlineShopping.Common
{

    /// <summary>
    /// Enum
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Application Status
        /// </summary>
        public enum Status
        {
            None = 0,
            Success = 1,
            Error = 2,
            Warning = 3
        }

        /// <summary>
        /// Application Status Id
        /// </summary>
        public enum StatusId
        {
            Success = 200,
            NoRecords = 400

        }

        public enum Gender
        {
            M, F
        }
    }
}
