using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oi.Devops.Filters {
    public class HangfireAuthFilter : IDashboardAuthorizationFilter {
        public bool Authorize(DashboardContext context) {
            return true; //for now, still to impliment IsInRole
        }
    }
}
