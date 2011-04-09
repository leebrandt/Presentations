<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.UI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="search">
      <asp:TextBox ID="PartNumberInput" runat="server" />
      <asp:Button ID="SearchButton" Text="search" runat="server" />
    </div>
    <asp:GridView ID="FloogleListing" runat="server" />
    </form>
</body>
</html>
