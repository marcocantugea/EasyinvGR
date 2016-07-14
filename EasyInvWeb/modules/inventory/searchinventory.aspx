<%@ Page Language="VB" AutoEventWireup="false" CodeFile="searchinventory.aspx.vb" Inherits="modules_inventory_captureinventory" %>
<!--#include file="~/view/head.aspx" -->
<!--#include file="~/view/menu.aspx" -->

<form id="frmsearch" runat="server" style="margin-top:35px;">

<div>

<asp:TextBox ID="txtSearchcode" runat="server" Width="313px"></asp:TextBox>
<asp:Button ID="btnSearchCode" runat="server" Text="Search Code" />
<span style="margin-left:15px;">&nbsp;</span>
<asp:button runat="server" text="Clear 0 stock" id="btnsearchnozero" />

<asp:GridView ID="grvResults" runat="server" CssClass="DataDisplay" 
        AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="CODE" HeaderText="LOCATION"  Visible="False"/>
        <asp:BoundField DataField="STOCKTYPECODE" HeaderText="Stock Type Code" />
        <asp:BoundField DataField="PNAME" HeaderText="PART NAME" />
        <asp:BoundField DataField="STOCKTYPEID" Visible="False" />
        <asp:BoundField DataField="STOCKUNITID" HeaderText="Stock ID" />
        <asp:BoundField DataField="GetStock"  HeaderText="on Hand" >
            <ControlStyle CssClass="ChechkInv" />
        </asp:BoundField>
        <asp:ButtonField ButtonType="Button" Text="Detail" CommandName="VIEWDETAIL" />
    </Columns>
</asp:GridView>


</div>

<div>

</div>
</form>

<!--#include file="~/view/footer.aspx" -->