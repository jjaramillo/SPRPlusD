using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPRPlusD.DAL.DataTransferObjects;
using Microsoft.SharePoint;

namespace SPRPlusD.UsabilityTools.BLL
{
    public class SiteBLL
    {
        public static IEnumerable<SPListDTO> GetSiteTaskLists (){
            SPWeb currentWeb = SPContext.Current.Web;
            SPListCollection siteLists = currentWeb.Lists;
            var taskLists = (from SPList taskList in siteLists
                             where taskList.BaseTemplate == SPListTemplateType.Tasks
                             select new SPListDTO {
                                 DisplayName = taskList.Title,
                                 Guid = taskList.ID
                             });
            return taskLists;
        }
    }
}
