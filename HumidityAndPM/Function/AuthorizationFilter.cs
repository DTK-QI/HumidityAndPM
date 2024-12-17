using Hangfire.Dashboard;

namespace HumidityAndPM.Function
{
    public class AllowAllAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true; // 允許所有訪問者
        }
    }
}
