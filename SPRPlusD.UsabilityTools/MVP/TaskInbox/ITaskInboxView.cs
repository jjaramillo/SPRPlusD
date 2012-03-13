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
        int MaxHistoricDayNumber { get; set; }
        IEnumerable<TasksTask> CoolTasks { get; set; }
        IEnumerable<TasksTask> WarningTasks { get; set; }
        IEnumerable<TasksTask> OverdueTasks { get; set; }
        IEnumerable<TasksTask> DoneTasks { get; set; }
    }
}
