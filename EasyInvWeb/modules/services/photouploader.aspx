<%@ Page Language="VB" AutoEventWireup="false" CodeFile="photouploader.aspx.vb" Inherits="modules_services_photouploader" %>

<!--#include file="~/view/head.aspx" -->
<!--#include file="~/view/menu.aspx" -->
<form runat="server" id="fmr1">

<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" CssClass="DataDisplay">
<Columns>
    <asp:BoundField DataField="id" HeaderText="" />
    <asp:TemplateField>
     <ItemTemplate>
            <img src="<%# Eval("tmpimagepath") %>" width="100px" />
     </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="Photoname" HeaderText="Photo File Name" />
    <asp:BoundField DataField="STOCKTYPECODE" HeaderText="Stock Code" />
    <asp:BoundField DataField="PNAME" HeaderText="PART NAME" />
    <asp:TemplateField>
     <ItemTemplate>
           <a  href="../inventory/deatilstockitem.aspx?q=<%# Eval("STOCKUNITID") %>" target="_blank"><asp:Label id="lblstockunitid" runat="server" Text='<%# Eval("STOCKUNITID") %>'></asp:Label></a>
     </ItemTemplate>
    </asp:TemplateField>
    <asp:ButtonField ButtonType="Button" Text="Save Photo" CommandName="SaveLinkRel" />
    <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteLinkRel" />
    <asp:BoundField DataField="STOCKUNITID" visible="false" />
</Columns>
</asp:GridView>

</form>
<!--#include file="~/view/footer.aspx" -->