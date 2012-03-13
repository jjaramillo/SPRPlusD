using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPRPlusD.DAL;

namespace SPRPlusD.UsabilityTools.MVP.TaskInbox
{
    public interface ITaskInboxView:IView
    {
        int CoolDayNumber { get; set; }
        int WarningDayNumber { get; set; }
        IEnumerable<Task> CoolTasks { get; set; }
        IEnumerable<Task> WarningTasks { get; set; }
        IEnumerable<Task> OverdueTasks { get; set; }
        IEnumerable<Task> DoneTasks { get; set; }
    }
}
