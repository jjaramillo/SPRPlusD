using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using SPRPlusD.UsabilityTools.WebControls.TaskInbox;

namespace SPRPlusD.UsabilityTools.WebParts.TaskInbox
{
    [ToolboxItemAttribute(false)]
    public class TaskInbox : WebPart
    {

        [WebBrowsable(true), Category("Rangos de Fechas"),
         WebDisplayName("Número de días para categoría 'Próximas a Vencer'"),
         WebDescription("Contiene el número de días entre la fecha actual, y la fecha de vencimiento de la tarea que categoriza una tarea como 'proxima a vencerse.'"),
         Personalizable(PersonalizationScope.Shared)]
        public int WarningDayNumber { get; set; }

        [WebBrowsable(true), Category("Rangos de Fechas"),
         WebDisplayName("Número de días para categoría 'Por realizar'"),
         WebDescription("Contiene el número de días entre la fecha actual, y la fecha de vencimiento de la tarea que categoriza una tarea como 'por realizar.'"),
         Personalizable(PersonalizationScope.Shared)]
        public int CoolDayNumber { get; set; }

        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/SPRPlusD.UsabilityTools.WebParts/TaskInbox/TaskInboxUserControl.ascx";
        private const string _ascxConfigPath = @"~/_CONTROLTEMPLATES/SPRPlusD.UsabilityTools.WebParts/TaskInbox/TaskInboxConfigUserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = GetControl(WebPartManager.GetCurrentWebPartManager(Page).DisplayMode);
            Controls.Add(control);
        }

        private Control GetControl(WebPartDisplayMode mode)
        {
            if (!(mode.Equals(WebPartManager.EditDisplayMode) || mode.Equals(WebPartManager.DesignDisplayMode)))
            {
                TaskInboxUserControl ctrl = Page.LoadControl(_ascxPath) as TaskInboxUserControl;
                ctrl.CoolDayNumber = CoolDayNumber;
                ctrl.WarningDayNumber = WarningDayNumber;
                return ctrl;
            }
            else { return Page.LoadControl(_ascxConfigPath); }
        }

    }
}
