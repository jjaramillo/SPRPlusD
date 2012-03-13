using System;
using System.Web.UI;
using SPRPlusD.UsabilityTools.MVP.TaskInbox;

namespace SPRPlusD.UsabilityTools.WebControls.TaskInbox
{
    public partial class TaskInboxUserControl : UserControl, ITaskInboxView
    {
        #region [Event Hanlders]

        TaskInboxPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
                
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _Presenter = new TaskInboxPresenter(this);
            _Presenter.HandleLoad();
        }

        #endregion

        #region [ITaskInboxView Members]

        public int CoolDayNumber
        {
            get;
            set;
        }

        public int WarningDayNumber
        {
            get;
            set;
        }

        public int MaxHistoricDayNumber { 
            get; 
            set;
        }

        public System.Collections.Generic.IEnumerable<DAL.TasksTask> CoolTasks
        {
            get
            {
                return rpt_CoolTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.TasksTask>;
            }
            set
            {
                rpt_CoolTasks.DataSource = value;
                rpt_CoolTasks.DataBind();
            }
        }

        public System.Collections.Generic.IEnumerable<DAL.TasksTask> WarningTasks
        {
            get
            {
                return rpt_WarningTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.TasksTask>;
            }
            set
            {
                rpt_WarningTasks.DataSource = value;
                rpt_WarningTasks.DataBind();
            }
        }

        public System.Collections.Generic.IEnumerable<DAL.TasksTask> OverdueTasks
        {
            get
            {
                return rpt_OverdueTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.TasksTask>;
            }
            set
            {
                rpt_OverdueTasks.DataSource = value;
                rpt_OverdueTasks.DataBind();
            }
        }

        public System.Collections.Generic.IEnumerable<DAL.TasksTask> DoneTasks
        {
            get
            {
                return rpt_DoneTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.TasksTask>;
            }
            set
            {
                rpt_DoneTasks.DataSource = value;
                rpt_DoneTasks.DataBind();
            }
        }

        #endregion
    }
}
