using System.Collections.Generic;
using SPRPlusD.DAL.DataTransferObjects;

namespace SPRPlusD.UsabilityTools.MVP.ListSelectionToolPart
{
    public interface IListSelectionView : IView
    {
        IEnumerable<SPListDTO> Lists { get; set; }
        SPListDTO SelectedSPListDTO { get; set; }
    }
}
