<%@ Page Language="VB" AutoEventWireup="false" CodeFile="checkinventory.aspx.vb" Inherits="modules_inventory_checkinventory" %>

<!--#include file="~/view/head.aspx" -->
<!--#include file="~/view/menu.aspx" -->
<br />
<br />
<form id="form1" runat="server">
<div>
    <asp:textbox runat="server" ID="txtSearch" Width="313px" 
       ></asp:textbox>
    <asp:button runat="server" text="Search" id="btnSearchCode" />
    <span style="margin-left:15px;">&nbsp;</span><asp:button runat="server" text="Clear 0 Stock" id="btnSearch0stock" />
    
     <asp:gridview ID="dgvLoadResults" runat="server" CssClass="DataDisplay" 
        AutoGenerateColumns="False">
         <Columns>
         
          <asp:BoundField DataField="CODE" HeaderText="LOCATION"/>
          <asp:BoundField DataField="fechamod" HeaderText="Stock Type Code" />
             <asp:ButtonField ButtonType="Button" Text="Load" CommandName="LOADDATA" />
              <asp:TemplateField>
            <ItemTemplate>
                <button id="btnprint" code="<%# Eval("CODE") %>" fechamod="<%# Eval("fechamod") %>" >Print Report</button>
               
            </ItemTemplate>
        </asp:TemplateField>
         </Columns> 
        </asp:gridview>
<div style="text-align:right; margin-bottom:10px;">
   <button id="btnsaveinfo">Save Info</button>&nbsp;&nbsp;&nbsp;
</div>        
    <asp:gridview ID="grvResults" runat="server" CssClass="DataDisplay" 
        AutoGenerateColumns="False">
        <Columns>
        <asp:BoundField DataField="CODE" HeaderText="LOCATION"  Visible="False"/>
        <asp:BoundField DataField="STOCKTYPECODE" HeaderText="Stock Type Code" />
        <asp:BoundField DataField="PNAME" HeaderText="PART NAME" />
        <asp:BoundField DataField="STOCKTYPEID" Visible="False" />
         <asp:TemplateField HeaderText="Stock ID">
             <ItemTemplate>
            <a href="deatilstockitem.aspx?q=<%# Eval("STOCKUNITID") %>" target="_blank" > <%# Eval("STOCKUNITID") %> </a>
            </ItemTemplate>
         </asp:TemplateField>
        <asp:BoundField DataField="GetStock"  HeaderText="on Hand"   >
             <ControlStyle CssClass="ChechkInv" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <input type="text" value="<%# getValue(Eval("STOCKUNITID"))  %>" id="txtval_<%# Eval("STOCKUNITID") %>_<%# Eval("CODE")  %>" class="TextChechInv" />
               
            </ItemTemplate>
        </asp:TemplateField>
        
        
    </Columns>
    </asp:gridview>
    
   
     

    
   
     
</div>
</form>
<script src="../../js/jquery-3.0.0.min.js"></script>
<script type ="text/javascript">
 var strtosend="";
$('#btnsaveinfo').click(function(){
    strtosend=""
    $.each($('input[id^="txtval_"]'),function(index,value){
        //console.log( $(value).attr("id")+" = "+$(value).val() );
        var valuetext = $(value).val();
        var id=$(value).attr("id");
        var v=id.split("_");
        var idval=v[1];   
        var location=v[2];
        if(valuetext ===""){
        
        }else{
            strtosend=strtosend+""+idval+":"+valuetext+":"+location+"|";
        }  
    });
    //console.log(strtosend);
    saveinfodata(strtosend);
    return false;
});

function saveinfodata(param1){
    $.post(
        "../services/addindCheckInventory.aspx",
        {p:param1},
        function(result){
            var data= result;
            if (data==0){
                alert("Information has been saved Successfully!");
            }else{
                alert("Error saving the information.");
            }
        }
    )
}

$('button[id^="btnprint"]').click(function(){
    var code=$(this).attr("code");
    var fechamod=$(this).attr("fechamod")
    window.open("printcheckinv.aspx?param1="+code+"&param2="+fechamod+"","Easyinv");
    return false;
});

</script>

<!--#include file="~/view/footer.aspx" -->