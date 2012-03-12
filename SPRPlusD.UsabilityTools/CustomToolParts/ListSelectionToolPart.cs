using System;
using Microsoft.SharePoint.WebPartPages;
using SPRPlusD.UsabilityTools.WebControls;

namespace SPRPlusD.UsabilityTools.CustomToolParts
{
    public class ListSelectionToolPart : ToolPart
    {
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/SPRPlusD.UsabilityTools.ToolParts/ListSelection/ListSelectionUserControl.ascx";

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            ListSelectionUserControl ctrl = Page.LoadControl(_ascxPath) as ListSelectionUserControl;
            Controls.Add(ctrl);
        }

        public override void ApplyChanges()
        {
            //base.ApplyChanges();
            OnChangesApplied(this, new EventArgs { });
        }

        public event HandleApplyChange OnChangesApplied;
        public delegate void HandleApplyChange(object sender, EventArgs e);
    }
}
