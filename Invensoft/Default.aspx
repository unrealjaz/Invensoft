<%@ Page Title="InvenSoft" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Invensoft._Default" %>

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


</asp:Content>
