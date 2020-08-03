<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="WebAPIConsume.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<div>
			<table>
				<tr>
					<td>Id:</td><td><asp:TextBox ID="txtbxId" runat="server" TextMode="Number"></asp:TextBox></td>	</tr>
					<tr><td>Name:</td><td><asp:TextBox ID="txtbxName" runat="server"></asp:TextBox></td>	</tr>
					<tr><td>Position:</td><td><asp:TextBox ID="txtbxPosition" runat="server"></asp:TextBox></td>	</tr>

				    <tr><td colspan="2">
						<asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />&nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
&nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
						</td></tr>
			         <tr><td colspan="2">
						 <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td></tr>

			</table>

				
		</div>
        <div>
            <asp:GridView ID="EmpGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
				<AlternatingRowStyle BackColor="White" />
				<EditRowStyle BackColor="#2461BF" />
				<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
				<RowStyle BackColor="#EFF3FB" />
				<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
				<SortedAscendingCellStyle BackColor="#F5F7FB" />
				<SortedAscendingHeaderStyle BackColor="#6D95E1" />
				<SortedDescendingCellStyle BackColor="#E9EBEF" />
				<SortedDescendingHeaderStyle BackColor="#4870BE" />
		</asp:GridView>
        </div>
    	
    </form>
</body>
</html>
