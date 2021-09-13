<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="phonebook.aspx.cs" Inherits="PhoneBook2.phonebook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>PhoneBook2</title>

</head>
<body>
    <form id="form1" runat="server">

    <div class="containner">
        <div align="center" class="" style="height:100px; width:auto;background-color:#527a7a">

            <h1>Phone Book 2</h1>

        </div>


        <div align="center" class="" style="height:1200px; width:auto; background-color: #94b8b8;" >

            <asp:HiddenField ID="hfp_id" runat="server" />
        <table>
            <br>
            <br>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Number:"></asp:Label>
                </td>
                <td colspan="2">
                <asp:TextBox ID="text_p_number" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
                </td>
                <td colspan="2">
                <asp:TextBox ID="text_p_name" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Gmail:"></asp:Label>
                </td>
                <td colspan="2">
                <asp:TextBox ID="text_p_gmail" runat="server"></asp:TextBox>
                </td>
            </tr>
             
             <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Address:"></asp:Label>
                </td>
                <td colspan="2">
                <asp:TextBox ID="text_p_address" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    
                </td>
                <td colspan="2">
                ><asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
                ><asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="btn_delete_Click" />
                ><asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click" />
                </td>
            </tr>

                 <tr>
                <td>
                    
                </td>
                <td colspan="2">
                    <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
            </tr>
                <tr>
                <td>
                    
                </td>
                <td colspan="2">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>                
                 </td>
            </tr>
        </table>
            <br>
            <br>
              <h3>Contact List</h3>
            
            <br>
        

 
        <asp:GridView ID="gv_contact" runat="server" AutoGenerateColumns="False">
           <Columns>
               <asp:BoundField DataField="p_number" HeaderText="Number"/>
               <asp:BoundField DataField="p_name" HeaderText="Name"/>
               <asp:BoundField DataField="p_gmail" HeaderText="Gmail"/>
               <asp:BoundField DataField="p_address" HeaderText="Address"/>

               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("p_id") %>' OnClick="lnk_Onclick" >Edit</asp:LinkButton> 
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
        </asp:GridView>
            <br>
        <asp:Button ID="btn_delete_all" runat="server" Text="Delete" OnClick="btn_delete_Click_all" />
       </div>     
    </div>
    </form>
</body>
</html>
