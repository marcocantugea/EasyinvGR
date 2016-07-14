<%@ Page Language="VB" AutoEventWireup="false" CodeFile="printcheckinv.aspx.vb" Inherits="modules_inventory_printcheckinv" %>

<!--#include file="~/view/head.aspx" -->

<form id="form1" runat="server">
<div class="PrintForm">
    <h1>Inventory Check</h1>
    <div>
       Location:&nbsp;<strong><asp:label runat="server" text="Label" id="lbllocation" ></asp:label></strong>
    </div>
    <div>
       date:&nbsp;<strong><asp:label runat="server" text="Label" id="lbldate"></asp:label></strong>
    </div>
    <div>
        <asp:gridview runat="server" id="dgvPrintCheckinv"
        AutoGenerateColumns="False" >
            <Columns>
        <asp:BoundField DataField="CODE" HeaderText="LOCATION"  Visible="False"/>
        <asp:BoundField DataField="STOCKTYPECODE" HeaderText="Stock Type Code" />
        <asp:BoundField DataField="PNAME" HeaderText="PART NAME" />
        <asp:BoundField DataField="STOCKTYPEID" Visible="False" />
         <asp:TemplateField HeaderText="Stock ID">
             <ItemTemplate>
            <%# Eval("STOCKUNITID") %> 
            </ItemTemplate>
         </asp:TemplateField>
        <asp:BoundField DataField="GetStock"  HeaderText="on Hand"   >
             <ControlStyle CssClass="" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <input type="text" value="<%# getValue(Eval("STOCKUNITID"))  %>" id="txtval_<%# Eval("STOCKUNITID") %>_<%# Eval("CODE")  %>" />
               
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
        </asp:gridview>
    </div>
</div>

</form>
<!--#include file="~/view/footer.aspx" -->