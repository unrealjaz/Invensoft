<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInventory.aspx.cs" Inherits="Invensoft.Production.ProductInventory" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="form-group">
        <div class="col-lg-10">
            <asp:Label ID="locationLabel" runat="server" Text="Location" CssClass="col-lg-2 control-label" />
            <asp:DropDownList ID="location" runat="server" CssClass="form-control" SelectMethod="GetLocations" DataTextField="Name" DataValueField="LocationID" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <asp:Label ID="exportLabel" runat="server" Text="Export Options" CssClass="col-lg-2 control-label" />
            <asp:DropDownList ID="exportOptions" runat="server" CssClass="form-control">
                <asp:ListItem Text="Excel" Value="Excel" />
                <asp:ListItem Text="PDF" Value="PDF" />
            </asp:DropDownList>
            <br />
            <asp:Button ID="exportTo" runat="server" OnClick="exportTo_Click" Text="Export"
                CssClass="btn btn-primary" />
        </div>
    </div>
    <br />
    <br />
    <div>
        <asp:GridView ID="productInventoryReportGrid" runat="server"
            SelectMethod="GetProductInventory" AutoGenerateColumns="false"
            CssClass="table table-striped table-hover" PagerStyle-CssClass="pagination"
            AllowPaging="true">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <Columns>

                <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" />
                <asp:BoundField DataField="Name" HeaderText="Product Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:n0}" ItemStyle-HorizontalAlign="Right" />

            </Columns>
        </asp:GridView>
    </div>
    <div>
        <rsweb:ReportViewer ID="productInventoryReport" runat="server" Visible="false">
        </rsweb:ReportViewer>
    </div>
</asp:Content>
