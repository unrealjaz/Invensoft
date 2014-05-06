<%@ Page Title="InvenSoft" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Invensoft._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <h1>
                <%: Title %>
            </h1>
            <h2></h2>
            <p class="lead">
                InvenSoft is an application for Production Planning.
            </p>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrator">
                <ContentTemplate>
                    <p class="lead">
                        Admin
                    </p>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Sales">
                <ContentTemplate>

                    <p class="lead">
                        Sales
                    </p>



                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Production">
                <ContentTemplate>

                    <p class="lead">
                        Prod
                    </p>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>


    <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="SalesChart" ChartType="Pie"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

</asp:Content>
