using static OnlineShopping.Common.Enums;

namespace OnlineShopping.Common
{
    /// <summary>
    /// Operation Result
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// StatusId
        /// </summary>
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public dynamic Data { get; set; }
    }
}
