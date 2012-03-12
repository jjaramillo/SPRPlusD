
using Microsoft.SharePoint;
namespace SPRPlusD.UsabilityTools.MVP
{
    public class BasePresenter<I>
        where I : IView
    {
        public I view;

        public BasePresenter(I view)
        {
            this.view = view;
        }
    }
}