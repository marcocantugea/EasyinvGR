<%@ Page Language="VB" AutoEventWireup="false" CodeFile="deatilstockitem.aspx.vb" Inherits="modules_inventory_deatilstockitem" %>

<!--#include file="~/view/head.aspx" -->
<!--#include file="~/view/menu.aspx" -->
<br />

<form id="form1" runat="server">

<div>
<input type="hidden" runat="server" ID="hdstocktypeid" />
<asp:GridView ID="grvResults" runat="server" CssClass="DataDisplay" 
        AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="STOCKTYPECODE" HeaderText="Stock Type Code" />
        <asp:BoundField DataField="NAME" HeaderText="Name" />
        <asp:BoundField DataField="STOCKTYPEID" Visible="False" />
        <asp:BoundField DataField="STOCKUNITID" HeaderText="Stock ID" />
        <asp:BoundField DataField="GetStock"  HeaderText="on Hand" >
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<p></p>
    <asp:gridview runat="server" ID="dgvLocations" CssClass="DataDisplay" AutoGenerateColumns="False">
    <Columns>
    <asp:BoundField DataField="CODE" HeaderText="Location Code" />
    <asp:BoundField DataField="NAME" HeaderText="Location" />
    <asp:BoundField DataField="ONHAND" HeaderText="ONHAND" />
    </Columns>
    </asp:gridview>
<p>&nbsp;</p>
<div>
    <asp:button runat="server" text="Create QR Code" onclick="Unnamed1_Click" />
    &nbsp;&nbsp;&nbsp;Size:&nbsp;&nbsp;<asp:dropdownlist runat="server" ID="cmbqrsize" >
        <asp:ListItem Value="1">Small (100X100)</asp:ListItem>
        <asp:ListItem Value="2">Medium (150X150)</asp:ListItem>
        <asp:ListItem Value="3">Large (200X200)</asp:ListItem>
        <asp:ListItem Value="4">X-Large(300X300)</asp:ListItem>
        <asp:ListItem Value="5">XX-Large(400X400)</asp:ListItem>
    </asp:dropdownlist>
</div>
</div>


<div id="imageuploader">
<h3>Photos</h3>
<div>
    <label class="file-upload">
     <span><strong>Upload Image</strong></span>
    <asp:FileUpload ID="FileUpload1" runat="server"  onchange ="CheckExt(this)" />
    </div>
    </label>
 </div>
    <br />
     <asp:Button ID="Button1" runat="server" Text="Save Photo" />
  <br />
  <br />      
<div id="PhotosGridview" style="width:100%">

<% 
    Dim photos As New EasyinvCore.com.objects.StockTypePhotoCollection
    Dim _ADOEasyInv As New EasyinvCore.com.ADO.ADOEasyInv
    If Not IsNothing(Request.QueryString("q")) Then
        Dim stocktypeid As Long = Long.Parse(Request.QueryString("q"))
        _ADOEasyInv.GetPhotosStock(stocktypeid, photos)
    End If
    
    For Each Items As EasyinvCore.com.objects.stocktypephoto In photos.items
        Dim imagelink As String = ConfigurationManager.AppSettings("domain") & "/modules/inventory/" & Items.pathphoto
    
%>
     <div class="PhotoGridView" id="img_cont_<%=Items.IDstocktypephoto %>">
        <a href="<%Response.write(imagelink)%>"><img src="<% Response.write(imagelink) %>" /></a>
        <br />
        <button id="btn_rm_<%=Items.IDstocktypephoto %>">Remove Photo</button>
     </div>
<%
 Next
 %>
</div>
<p></p>
</form>
<script src="../../js/jquery-3.0.0.min.js"></script>
<script type ="text/javascript">

    var validFiles=["bmp","gif","png","jpg","jpeg"];
        function CheckExt(obj)
        {
          var source=obj.value;
          var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
          for (var i=0; i<validFiles.length; i++)
          {
            if (validFiles[i]==ext)
                break;
          }
          if (i>=validFiles.length)
          {
            alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n"+validFiles.join(", "));
          }
         }
         
      $("button[id^=btn_rm_] ").click(function(){
          var idbutton=$(this).attr("id");
          var val=idbutton.split("_");
          var id=val[2];
          DeletePhoto(id);
          $("#img_cont_"+id).remove();
          
         /* alert("test");*/
          return false;
      });
      
      function DeletePhoto(param1){
        $.ajax({
            url:'../services/deletestockphoto.aspx?param1='+param1+'',
            type:'get',
            datatype:'json',
            success:function(result){
                var obj1=result;
            }
        });
      }
      
</script>

<!--#include file="~/view/footer.aspx" -->