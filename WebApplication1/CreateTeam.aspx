<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTeam.aspx.cs" Inherits="WebApplication1.CreateTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                團名：<asp:TextBox ID="txtTeamName" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                店名：<asp:DropDownList ID="ShopList" runat="server"></asp:DropDownList>
            </div>
            <br />
            <div>
                圖片：<asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <br />
            <div>
                <asp:Button ID="btn_OK" runat="server" Text="OK" OnClick="btn_OK_Click" />
                <asp:Button ID="btn_Reset" runat="server" Text="Reset" OnClick="btn_Reset_Click" />
            </div>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
