using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPRPlusD.UsabilityTools.MVP.TaskInbox
{
    public interface ITaskInboxView:IView
    {
        int CoolDayNumber { get; set; }
        int WarningDayNumber { get; set; }
    }
}
