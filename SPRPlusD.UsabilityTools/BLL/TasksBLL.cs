using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPRPlusD.DAL;
using SPRPlusD.DAL.DataTransferObjects;

namespace SPRPlusD.UsabilityTools.BLL
{
    public class TasksBLL
    {
        public static IEnumerable<Task> GetDoneTasks(int maxHistoryDays, string siteUrl)
        {
            IEnumerable<SPListDTO> taskLists = SiteBLL.GetSiteTaskLists();
            IEnumerable<Task> foundTasks = null;
            using (RDDataContext dtctx = new RDDataContext(siteUrl))
            {
                if (maxHistoryDays == 0)
                {
                    foreach (SPListDTO currentSPListDTO in taskLists)
                    {
                        foundTasks = foundTasks == null ? dtctx.GetList<Task>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed)
                            : foundTasks.Union(dtctx.GetList<Task>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed));
                    }
                }
                else
                {
                    DateTime maxHistoryDate = DateTime.Now.AddDays(-maxHistoryDays).Date;
                    foreach (SPListDTO currentSPListDTO in taskLists)
                    {
                        foundTasks = foundTasks == null ? dtctx.GetList<Task>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed
                            && task.StartDate > maxHistoryDate)
                            : foundTasks.Union(dtctx.GetList<Task>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed
                            && task.StartDate > maxHistoryDate));
                    }
                }
            }
            return foundTasks;
        }
    }
}
