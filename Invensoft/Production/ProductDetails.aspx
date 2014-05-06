<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Invensoft.Production.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="productDetail" runat="server" ItemType="Invensoft.Models.Product" SelectMethod="GetProduct"
        RenderOuterTable="false" DataKeyNames="ProductID" UpdateMethod="SetProductPrice">

        <ItemTemplate>
            <div>
                <h1><%#: Item.Name %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="data:image/png;base64,<%#:Convert.ToBase64String(Item.ProductProductPhotoes.Where(p=>p.ProductID==Item.ProductID).First().ProductPhoto.LargePhoto) %>" style="border: solid" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left">
                        <b>Description:</b><br />
                        <%#: Item.Name %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#:String.Format("{0:c}", Item.ListPrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.ProductNumber %></span>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button ID="editProduct" runat="server" Text="Edit" CssClass="btn btn-primary" CommandName="Edit" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <EditItemTemplate>
            <div>
                <h1><%#: Item.Name %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="data:image/png;base64,<%#:Convert.ToBase64String(Item.ProductProductPhotoes.Where(p=>p.ProductID==Item.ProductID).First().ProductPhoto.LargePhoto) %>" style="border: solid" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left">
                        <b>Description:</b><br />
                        <%#: Item.Name %>
                        <br />
                        <span>
                            <b>Price:</b>&nbsp;
                            <asp:TextBox ID="price" runat="server" Text='<%#: Bind("ListPrice") %>' />

                        </span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.ProductNumber %></span>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button ID="saveProduct" runat="server" Text="Save" CssClass="btn btn-primary" CommandName="Update"  />
                        <asp:Button ID="cancelProduct" runat="server" Text="Cancel" CssClass="btn btn-danger" CommandName="Cancel" />
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
    </asp:FormView>

</asp:Content>
