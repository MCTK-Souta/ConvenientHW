<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="vendor/bootstrap/js/popper.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="col-12 page-header">
                <h1 style="display:inline"><a href="Index.aspx">首頁</a></h1>
                <button type="button" style="display:inline;float:right"  onclick="location.href='Login.aspx'">登入</button>
            </div>
            <div class="col-12">
                <asp:TextBox ID="txtSeach" runat="server"  placeholder="搜尋店名"></asp:TextBox>
                <asp:Button ID="btn_Sumit" runat="server" Text="Send" OnClick="Page_Load" />
            </div>
            <br />
            <div class="col-12">
                <button type="button" onclick="location.href='CreateTeam.aspx'">建立</button>
            </div>
            <br />
            <div class="col-12">
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="repList_ItemDataBound">
                    <ItemTemplate>
                        <div style="border-style:solid" class="row btn-primary active" 
                            onclick="location.href='TeamDetail.aspx?Team_ID=<%# Eval("Team_ID") %>'">
                            <div class="col-sm-2" style="text-align:center">
                               <asp:Image ID="img" runat="server" Width="100" Height="100"/>
                                <p style="text-align:center">
                                    店名：<%# Eval("Shop_Name") %>
                                </p>
                            </div>
                            <div class="col-sm-10">
                                <h2>
                                    團名：<%# Eval("TeamName") %>
                                </h2>
                                <div>
                                   
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
