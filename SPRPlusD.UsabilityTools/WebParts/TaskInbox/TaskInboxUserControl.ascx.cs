using System;
using System.Web.UI;
using SPRPlusD.UsabilityTools.MVP.TaskInbox;

namespace SPRPlusD.UsabilityTools.WebControls.TaskInbox
{
    public partial class TaskInboxUserControl : UserControl, ITaskInboxView
    {
        #region [Event Hanlders]

        protected void Page_Load(object sender, EventArgs e)
        {
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

        public System.Collections.Generic.IEnumerable<DAL.Task> CoolTasks
        {
            get
            {
                return rpt_CoolTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.Task>;
            }
            set
            {
                rpt_CoolTasks.DataSource = value;
                rpt_CoolTasks.DataBind();
            }
        }

        public System.Collections.Generic.IEnumerable<DAL.Task> WarningTasks
        {
            get
            {
                return rpt_WarningTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.Task>;
            }
            set
            {
                rpt_WarningTasks.DataSource = value;
                rpt_WarningTasks.DataBind();
            }
        }

        public System.Collections.Generic.IEnumerable<DAL.Task> OverdueTasks
        {
            get
            {
                return rpt_OverdueTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.Task>;
            }
            set
            {
                rpt_OverdueTasks.DataSource = value;
                rpt_OverdueTasks.DataBind();
            }
        }

        public System.Collections.Generic.IEnumerable<DAL.Task> DoneTasks
        {
            get
            {
                return rpt_DoneTasks.DataSource as System.Collections.Generic.IEnumerable<DAL.Task>;
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
