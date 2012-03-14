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
        public static IEnumerable<TasksTask> GetDoneTasks(int maxHistoryDays, string siteUrl)
        {
            IEnumerable<SPListDTO> taskLists = SiteBLL.GetSiteTaskLists();
            IEnumerable<TasksTask> foundTasks = null;
            using (RDDataContext dtctx = new RDDataContext(siteUrl))
            {
                if (maxHistoryDays == 0)
                {
                    foreach (SPListDTO currentSPListDTO in taskLists)
                    {
                        foundTasks = foundTasks == null ? dtctx.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed)
                            : foundTasks.Union(dtctx.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed));
                    }
                }
                else
                {
                    DateTime maxHistoryDate = DateTime.Now.AddDays(-maxHistoryDays).Date;
                    foreach (SPListDTO currentSPListDTO in taskLists)
                    {
                        foundTasks = foundTasks == null ? dtctx.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed
                            && task.StartDate > maxHistoryDate)
                            : foundTasks.Union(dtctx.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(task => task.TaskStatus == TaskStatus.Completed
                            && task.StartDate > maxHistoryDate));
                    }
                }
            }
            return foundTasks;
        }

        public static IEnumerable<TasksTask> GetPendigCoolTasks(int coolOffsetDayCount, int warningOffsetDayCount, string siteUrl)
        {
            IEnumerable<SPListDTO> taskLists = SiteBLL.GetSiteTaskLists();
            IEnumerable<TasksTask> foundTasks = null;
            DateTime coolOffsetDate;
            using (RDDataContext dtxtc = new RDDataContext(siteUrl))
            {
                if (coolOffsetDayCount != 0 && warningOffsetDayCount != 0)
                {
                    if (warningOffsetDayCount > coolOffsetDayCount) { throw new ArgumentException("El rango de advertencia debe de ser menor que el rango de tareas pendientes"); }
                    coolOffsetDate = DateTime.Now.Date.AddDays(coolOffsetDayCount);
                }
                else { coolOffsetDate = DateTime.Now.Date.AddDays(1); }
                foreach (SPListDTO currentSPListDTO in taskLists)
                {
                    foundTasks = foundTasks == null ? dtxtc.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(
                        task => task.TaskStatus != TaskStatus.Completed && (task.DueDate == null || task.DueDate >= coolOffsetDate))
                        : foundTasks.Union(dtxtc.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(
                            task => task.TaskStatus != TaskStatus.Completed && (task.DueDate == null || task.DueDate >= coolOffsetDate)));
                }
            }
            return foundTasks;
        }

        public static IEnumerable<TasksTask> GetPendingWarningTasks(int coolOffsetDayCount, int warningOffsetDayCount, string siteUrl)
        {
            IEnumerable<SPListDTO> taskLists = SiteBLL.GetSiteTaskLists();
            IEnumerable<TasksTask> foundTasks = null;

            using (RDDataContext dtxtc = new RDDataContext(siteUrl))
            {
                if (coolOffsetDayCount != 0 && warningOffsetDayCount != 0)
                {
                    if (warningOffsetDayCount > coolOffsetDayCount) { throw new ArgumentException("El rango de advertencia debe de ser menor que el rango de tareas pendientes"); }
                    DateTime coolOffsetDate = DateTime.Now.Date.AddDays(coolOffsetDayCount);
                    DateTime warningOffsetDate = DateTime.Now.Date.AddDays(warningOffsetDayCount);
                    foreach (SPListDTO currentSPListDTO in taskLists)
                    {
                        foundTasks = foundTasks == null ? dtxtc.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(
                            task => task.DueDate != null && (task.DueDate >= warningOffsetDate && task.DueDate < coolOffsetDate))
                            : foundTasks.Union(dtxtc.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(
                                task => task.DueDate != null && (task.DueDate >= warningOffsetDate && task.DueDate < coolOffsetDate)));
                    }
                }

            }
            return foundTasks;
        }

        public static IEnumerable<TasksTask> GetPendingOverdueTasks(int coolOffsetDayCount, int warningOffsetDayCount, string siteUrl)
        {
            IEnumerable<SPListDTO> taskLists = SiteBLL.GetSiteTaskLists();
            IEnumerable<TasksTask> foundTasks = null;
            DateTime warningOffsetDate;
            using (RDDataContext dtxtc = new RDDataContext(siteUrl))
            {
                if (coolOffsetDayCount != 0 && warningOffsetDayCount != 0)
                {
                    if (warningOffsetDayCount > coolOffsetDayCount) { throw new ArgumentException("El rango de advertencia debe de ser menor que el rango de tareas pendientes"); }
                    warningOffsetDate = DateTime.Now.Date.AddDays(warningOffsetDayCount);
                }
                else
                {
                    warningOffsetDate = DateTime.Now.Date;
                }
                foreach (SPListDTO currentSPListDTO in taskLists)
                {
                    foundTasks = foundTasks == null ? dtxtc.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(task => task.DueDate != null
                            && (task.DueDate < warningOffsetDate && task.TaskStatus != TaskStatus.Completed))
                        : foundTasks.Union(dtxtc.GetList<TasksTask>(currentSPListDTO.DisplayName).Where(task => task.DueDate != null
                            && (task.DueDate < warningOffsetDate && task.TaskStatus != TaskStatus.Completed)));
                }

            }
            return foundTasks;
        }
    }
}
