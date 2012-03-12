
using Microsoft.SharePoint;
using SPRPlusD.UsabilityTools.BLL;
namespace SPRPlusD.UsabilityTools.MVP.ListSelectionToolPart
{
    public class ListSelectionPresenter:BasePresenter<IListSelectionView>
    {
        public ListSelectionPresenter(IListSelectionView view, SPWeb web) : base(view) { }

        public void HandleLoad() {
            view.Lists = SiteBLL.GetSiteTaskLists();
        }
    }
}
