﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Invensoft.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="categoryMenu" style="text-align: center">
        <asp:ListView ID="categoryList"
            ItemType="Invensoft.Models.ProductCategory"
            runat="server"
            SelectMethod="GetCategories">
            <ItemTemplate>
                <b style="font-size: large; font-style: normal">
                    <a href="<%#:GetRouteUrl("ProductsByCategoryRoute", new {categoryName = Item.Name}) %>">
                        <%#:Item.Name %>
                    </a>
                </b>
            </ItemTemplate>
            <ItemSeparatorTemplate>|</ItemSeparatorTemplate>
        </asp:ListView>
        <br />
    </div>

    <section>
        <div>
            <hgroup>
                <h2><%:Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="productList" runat="server"
                DataKeyNames="ProductId" GroupItemCount="4"
                ItemType="Invensoft.Models.Product"
                SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <%--<a href="<%#: GetRouteUrl("ProductById", new {productId = Item.ProductID}) %>">--%>
                                    <a href="../Production/ProductDetails.aspx?productId=<%#: Item.ProductID %>">
                                        <img src="data:image/png;base64,<%#:Convert.ToBase64String(Item.ProductProductPhotoes.Where(p=>p.ProductID==Item.ProductID).First().ProductPhoto.ThumbNailPhoto) %>" style="border: solid" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.Name}) %>">--%>
                                    <a href="../Production/ProductDetails.aspx?productId=<%#: Item.ProductID %>">
                                        <span>
                                            <%#: Item.Name %>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}",Item.ListPrice) %>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<a href="<%#: GetRouteUrl("ProductByNameRoute", new { productName = Item.Name}) %>"></a>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
