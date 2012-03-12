using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SPRPlusD.UsabilityTools.MVP.ListSelectionToolPart;
using System.Linq;

namespace SPRPlusD.UsabilityTools.WebControls
{
    public partial class ListSelectionUserControl : UserControl, IListSelectionView
    {
        private ListSelectionPresenter _Presenter;

        #region [Event Handlers]

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            _Presenter = new ListSelectionPresenter(this, Microsoft.SharePoint.SPContext.Current.Web);
            base.OnInit(e);
        }
 
        #endregion

        #region [IListView Members]

        public System.Collections.Generic.IEnumerable<DAL.DataTransferObjects.SPListDTO> Lists
        {
            get
            {
                return ddlSiteTaskLists.DataSource as System.Collections.Generic.IEnumerable<DAL.DataTransferObjects.SPListDTO>;
            }
            set
            {
                ddlSiteTaskLists.DataSource = value;
                ddlSiteTaskLists.DataBind();
            }
        }

        public DAL.DataTransferObjects.SPListDTO SelectedSPListDTO
        {
            get
            {
                return Lists.SingleOrDefault(spListDTO => spListDTO.Guid.Equals(new Guid(ddlSiteTaskLists.SelectedValue)));
            }
            set
            {
                ddlSiteTaskLists.ClearSelection();
                ddlSiteTaskLists.SelectedValue = value.Guid.ToString();
            }
        }
 
        #endregion
    }
}
