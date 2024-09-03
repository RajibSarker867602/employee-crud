using Newtonsoft.Json;

namespace EmployeeManagement.Web.Utilities
{
    public class Utility
    {
        public static string CouponAPIBaseUrl { get; set; }
        public static string ProductAPIBaseUrl { get; set; }
        public static string AuthAPIBaseUrl { get; set; }
        public static string CartAPIBaseUrl { get; set; }
        public static string OrderAPIBaseUrl { get; set; }


        public const string AdminRole = "ADMIN";
        public const string CustomerRole = "CUSTOMER";
        public const string TokenCookie = "JwtToken";

        public const string Status_Pending = "Pending";
        public const string Status_Approved = "Approved";
        public const string Status_ReadyForPickup = "ReadyForPickup";
        public const string Status_Completed = "Completed";
        public const string Status_Refund = "Refund";
        public const string Status_Cancelled = "Cancelled";

        /// <summary>
        /// Deserialize the response result
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static TResponse MapToResponse<TResponse>(object? response)
        {
            return JsonConvert.DeserializeObject<TResponse>(Convert.ToString(response));
        }
    }
}
