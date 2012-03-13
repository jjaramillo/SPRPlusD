using SPRPlusD.UsabilityTools.BLL;

namespace SPRPlusD.UsabilityTools.MVP.TaskInbox
{
    public class TaskInboxPresenter : BasePresenter<ITaskInboxView>
    {
        public TaskInboxPresenter(ITaskInboxView view) : base(view) { }

        public void HandleLoad() {
            view.WarningTasks = TasksBLL.GetPendingWarningTasks(view.CoolDayNumber, view.WarningDayNumber, Microsoft.SharePoint.SPContext.Current.Web.Url);
            view.CoolTasks = TasksBLL.GetPendigCoolTasks(view.CoolDayNumber, view.WarningDayNumber, Microsoft.SharePoint.SPContext.Current.Web.Url);
            view.OverdueTasks = TasksBLL.GetPendingOverdueTasks(view.CoolDayNumber, view.WarningDayNumber, Microsoft.SharePoint.SPContext.Current.Web.Url);
            view.DoneTasks = TasksBLL.GetDoneTasks(view.MaxHistoricDayNumber, Microsoft.SharePoint.SPContext.Current.Web.Url);
        }
    }
}
