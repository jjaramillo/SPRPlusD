using System;
using System.Web.UI;
using SPRPlusD.UsabilityTools.MVP.TaskInbox;

namespace SPRPlusD.UsabilityTools.WebControls.TaskInbox
{
    public partial class TaskInboxUserControl : UserControl,ITaskInboxView
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
 
        #endregion
    }
}
