using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Sheduler.Options
{
    public class SchedulerOptions
    {
        public TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(15);
    }
}
