 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="StaffGrid.StaffGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Grid</title>
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="heading">The Staff Table</h1>
            <asp:TextBox runat="server" ID="search"></asp:TextBox>
            <asp:Button runat="server" ID="searchBtn" OnClick="Search" Text="Search" />
            <asp:GridView ID="staffGrid" runat="server"AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" OnRowDeleting="OnRowDeleting" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" onselectedindexchanging="onselectedindexchanging"
                PageSize="15" >
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Role" HeaderText="Role" />
                    <asp:CommandField ShowEditButton="true"
                        HeaderText="Edit Field" />
                    <asp:CommandField ShowDeleteButton="true"
                        HeaderText="Delete Field" />
                    <asp:CommandField ShowSelectButton="true"
                        HeaderText="View Field" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
