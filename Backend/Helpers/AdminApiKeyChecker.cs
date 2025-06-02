namespace Backend.Helpers
{
    public class AdminApiKeyChecker
    {
        public static bool IsAdmin(HttpRequest request)
        {
            return request.Headers.TryGetValue("X-Api-Key", out var key) && key == "admin";
        }
    }
}
