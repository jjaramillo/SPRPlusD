<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskInboxUserControl.ascx.cs"
    Inherits="SPRPlusD.UsabilityTools.WebControls.TaskInbox.TaskInboxUserControl" %>
<link href='http://fonts.googleapis.com/css?family=Allerta|Crimson+Text|Prosto+One&subset=latin,latin-ext'
    rel='stylesheet' type='text/css' />
<link href='/_layouts/inc/SPRPlusD.UsabilityTools/css/SPRPlusD.UsabilityTools.TaskInbox.debug.css'
    rel='stylesheet' type='text/css' />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
<asp:ScriptManagerProxy runat="server" ID="smngproxy">
    <Scripts>
        <asp:ScriptReference Path="~/_layouts/inc/SPRPlusD.UsabilityTools/scripts/SPRPlusD.UsabilityTools.TaskInbox.debug.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<script type="text/javascript">
    $(document).ready(function () {
        SPRPlusD.UsabilityTools.TaskInbox.initialize();
    })
</script>
<div id="inbox">
    <div id="data-container-background">
    </div>
    <div id="data-container">
        <div style="margin: 10px; color: white;">
            <h1>
                Mis Tareas</h1>
            <p>
                Tienes <span>0</span> nuevas tareas desde su ultima visita y <span>0</span> tareas
                pendientes.</p>
            <div id="task-tabs">
                <ul id="task-categories-tabs">
                    <li><a href='#cool' class="tab tab-cool">Por realizar</a></li>
                    <li><a href='#warning' class="tab tab-warning">Próxima a vencer</a></li>
                    <li><a href='#overdue' class="tab tab-overdue">Vencidas</a></li>
                    <li><a href='#done' class="tab tab-done">Finalizadas</a></li>
                </ul>
                <div id="cool" class="cool">
                    <asp:Repeater runat="server" ID="rpt_CoolTasks">
                        <ItemTemplate>
                            <div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="warning" class="warning">
                    <asp:Repeater runat="server" ID="rpt_WarningTasks">
                        <ItemTemplate>
                            <div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="overdue" class="overdue">
                    <asp:Repeater runat="server" ID="rpt_OverdueTasks">
                        <ItemTemplate>
                            <div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="done" class="done">
                    <asp:Repeater runat="server" ID="rpt_DoneTasks">
                        <ItemTemplate>
                            <div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <div id="inbox-trigger">
        <span id="inbox-trigger-open">Mis Tareas</span> <span id="inbox-trigger-close" class="hidden">
            Cerrar Mis Tareas</span>
    </div>
</div>
