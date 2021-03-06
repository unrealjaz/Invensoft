﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="Invensoft.SalesReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="form-group" style="">

        <div class="col-lg-10">
            <asp:Label ID="yearsLabel" runat="server" Text="Year" CssClass="col-lg-2 control-label" />
            <asp:DropDownList ID="years" runat="server" CssClass="form-control" SelectMethod="GetYears" DataTextField="Year" DataValueField="Year" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="exportLabel" runat="server" Text="Export Options" CssClass="col-lg-2 control-label" />
            <asp:DropDownList ID="exportOptions" runat="server" CssClass="form-control">
                <asp:ListItem Text="Excel" Value="Excel" />
                <asp:ListItem Text="PDF" Value="PDF" />
            </asp:DropDownList>
            <br />

            <asp:Button ID="exportTo" runat="server" OnClick="exportTo_Click" Text="Export"
                CssClass="btn btn-primary" />
            <br />
            <br />
        </div>
    </div>
    <br />
    <div>
        <asp:GridView ID="salesReportGrid" runat="server"
            SelectMethod="GetSalesReport" AutoGenerateColumns="false"
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
                <asp:BoundField DataField="SalesQty" HeaderText="Quantity" DataFormatString="{0:n0}" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="SalesTotal" HeaderText="Sales Total" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" />

            </Columns>
        </asp:GridView>
    </div>

    <rsweb:ReportViewer ID="reportSales" runat="server" Visible="False">
    </rsweb:ReportViewer>

</asp:Content>
