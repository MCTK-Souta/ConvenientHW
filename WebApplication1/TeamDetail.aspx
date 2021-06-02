<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamDetail.aspx.cs" Inherits="WebApplication1.TeamDetail" %>

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
        <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="repList_ItemDataBound">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-sm-2">
                            <asp:Image ID="img" runat="server" Height="100" Width="100" />
                            <p>店名：<%# Eval("Shop_Name") %></p>
                            <asp:Label ID="lbshopid" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                        <div class="col-sm-10">
                            <p>團：<%# Eval("TeamName") %></p>
                            <asp:Literal ID="State" runat="server"></asp:Literal>
                            <p>主揪：<%# Eval("Ac_Account") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="row col-sm-3" style="border-style:solid">
                            <div class="col-sm-3">
                                <asp:Image ID="Image1" runat="server" />
                            </div>
                            <div class="col-sm-9"> 
                                <div><%# Eval("Menu_Name") %></div>
                                <asp:DropDownList ID="QuantityList1" runat="server">
                                    <asp:ListItem Value="" Text="請選擇數量"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
