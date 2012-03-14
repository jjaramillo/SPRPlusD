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
<link href='http://fonts.googleapis.com/css?family=Allerta|Crimson+Text|Prosto+One|Annie+Use+Your+Telescope&subset=latin,latin-ext'
    rel='stylesheet' type='text/css' />
<link href='/_layouts/inc/SPRPlusD.UsabilityTools/css/SPRPlusD.UsabilityTools.TaskInbox.debug.css'
    rel='stylesheet' type='text/css' />
<link href='/_layouts/inc/SPRPlusD.UsabilityTools/css/jquery.jscrollpane.css' rel='stylesheet'
    type='text/css' />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.js"></script>
<script type="text/javascript" src="/_layouts/inc/SPRPlusD.UsabilityTools/scripts/jquery.mousewheel.js"></script>
<script type="text/javascript" src="/_layouts/inc/SPRPlusD.UsabilityTools/scripts/jquery.jscrollpane.min.js"></script>
<asp:ScriptManagerProxy runat="server" ID="smngproxy">
    <Scripts>
        <asp:ScriptReference Path="~/_layouts/inc/SPRPlusD.UsabilityTools/scripts/SPRPlusD.UsabilityTools.TaskInbox.debug.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<script type="text/javascript">
    $(document).ready(function () {
        SPRPlusD.UsabilityTools.TaskInbox.initialize();
        $('.jspDrag').css({ opacity: 0.3 });
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
                            <div class="task">
                                <div class="start-date left">
                                    <span class="month"><%#Eval("StartDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("StartDate", "{0:dd}") %></span>
                                </div>
                                <%--<div class='calendar calendar-icon-<%#Eval("StartDate", "{0:MM}") %>'>
                                    <div class="calendar-day">
                                        <%#Eval("StartDate", "{0:dd}") %>
                                    </div>
                                </div>--%>
                                <h3>
                                    <asp:Literal runat="server" Text='<%#Bind("Title") %>' ID="ltr_Title"></asp:Literal>
                                </h3>
                                <div class="overdue-date right">
                                    <span class="month"><%#Eval("DueDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("DueDate", "{0:dd}") %></span>
                                </div>
                                <p>
                                    Esta tarea tiene prioridad
                                    <asp:Literal runat="server" ID="ltrlPriority" Text='<%#Bind("Priority") %>' /><br />
                                    Se encuentra en estado
                                    <asp:Literal runat="server" ID="ltrlStatus" Text='<%#Bind("TaskStatus") %>' />
                                    (<asp:Literal runat="server" ID="ltrlPercentage" Text='<%# Eval("Complete") == null? "0.0 %" : Eval("Complete", "{0:#0.0 %}") %>' />
                                    Completado)
                                </p>
                                <p>
                                    <asp:Literal runat="server" ID="ltrl_description" Text='<%#Bind("Body") %>'></asp:Literal>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="warning" class="warning">
                    <asp:Repeater runat="server" ID="rpt_WarningTasks">
                        <ItemTemplate>
                            <div class="task">
                                <div class="start-date left">
                                    <span class="month"><%#Eval("StartDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("StartDate", "{0:dd}") %></span>
                                </div>
                                <%--<div class='calendar calendar-icon-<%#Eval("StartDate", "{0:MM}") %>'>
                                    <div class="calendar-day">
                                        <%#Eval("StartDate", "{0:dd}") %>
                                    </div>
                                </div>--%>
                                <h3>
                                    <asp:Literal runat="server" Text='<%#Bind("Title") %>' ID="ltr_Title"></asp:Literal>
                                </h3>
                                <div class="overdue-date right">
                                    <span class="month"><%#Eval("DueDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("DueDate", "{0:dd}") %></span>
                                </div>
                                <p>
                                    Esta tarea tiene prioridad
                                    <asp:Literal runat="server" ID="ltrlPriority" Text='<%#Bind("Priority") %>' /><br />
                                    Se encuentra en estado
                                    <asp:Literal runat="server" ID="ltrlStatus" Text='<%#Bind("TaskStatus") %>' />
                                    (<asp:Literal runat="server" ID="ltrlPercentage" Text='<%# Eval("Complete") == null? "0.0 %" : Eval("Complete", "{0:#0.0 %}") %>' />
                                    Completado)
                                </p>
                                <p>
                                    <asp:Literal runat="server" ID="ltrl_description" Text='<%#Bind("Body") %>'></asp:Literal>
                                </p>                                
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="overdue" class="overdue">
                    <asp:Repeater runat="server" ID="rpt_OverdueTasks">
                        <ItemTemplate>
                            <div class="task">
                                <div class="start-date left">
                                    <span class="month"><%#Eval("StartDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("StartDate", "{0:dd}") %></span>
                                </div>
                                <%--<div class='calendar calendar-icon-<%#Eval("StartDate", "{0:MM}") %>'>
                                    <div class="calendar-day">
                                        <%#Eval("StartDate", "{0:dd}") %>
                                    </div>
                                </div>--%>
                                <h3>
                                    <asp:Literal runat="server" Text='<%#Bind("Title") %>' ID="ltr_Title"></asp:Literal>
                                </h3>
                                <div class="overdue-date right">
                                    <span class="month"><%#Eval("DueDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("DueDate", "{0:dd}") %></span>
                                </div>
                                <p>
                                    Esta tarea tiene prioridad
                                    <asp:Literal runat="server" ID="ltrlPriority" Text='<%#Bind("Priority") %>' /><br />
                                    Se encuentra en estado
                                    <asp:Literal runat="server" ID="ltrlStatus" Text='<%#Bind("TaskStatus") %>' />
                                    (<asp:Literal runat="server" ID="ltrlPercentage" Text='<%# Eval("Complete") == null? "0.0 %" : Eval("Complete", "{0:#0.0 %}") %>' />
                                    Completado)
                                </p>
                                <p>
                                    <asp:Literal runat="server" ID="ltrl_description" Text='<%#Bind("Body") %>'></asp:Literal>
                                </p>                                
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="done" class="done">
                    <asp:Repeater runat="server" ID="rpt_DoneTasks">
                        <ItemTemplate>
                            <div class="task">
                                <div class="start-date left">
                                    <span class="month"><%#Eval("StartDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("StartDate", "{0:dd}") %></span>
                                </div>
                                <%--<div class='calendar calendar-icon-<%#Eval("StartDate", "{0:MM}") %>'>
                                    <div class="calendar-day">
                                        <%#Eval("StartDate", "{0:dd}") %>
                                    </div>
                                </div>--%>
                                <h3>
                                    <asp:Literal runat="server" Text='<%#Bind("Title") %>' ID="ltr_Title"></asp:Literal>
                                </h3>
                                <div class="overdue-date right">
                                    <span class="month"><%#Eval("DueDate", "{0:MMM}") %></span>
                                    <span class="day"><%#Eval("DueDate", "{0:dd}") %></span>
                                </div>
                                <p>
                                    Esta tarea tiene prioridad
                                    <asp:Literal runat="server" ID="ltrlPriority" Text='<%#Bind("Priority") %>' /><br />
                                    Se encuentra en estado
                                    <asp:Literal runat="server" ID="ltrlStatus" Text='<%#Bind("TaskStatus") %>' />
                                    (<asp:Literal runat="server" ID="ltrlPercentage" Text='<%# Eval("Complete") == null? "0.0 %" : Eval("Complete", "{0:#0.0 %}") %>' />
                                    Completado)
                                </p>
                                <p>
                                    <asp:Literal runat="server" ID="ltrl_description" Text='<%#Bind("Body") %>'></asp:Literal>
                                </p>                                
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
