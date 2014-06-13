<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditComponents.aspx.cs" Inherits="Christoc.Modules.DisplayPlugg.EditComponents" %>

<%@ Register Src="~/desktopmodules/USerControl/DisplayPlugg/Label/Edit1.ascx" TagPrefix="uc1" TagName="Label" %>
<%@ Register Src="~/desktopmodules/USerControl/DisplayPlugg/Latex/Edit1.ascx" TagPrefix="uc2" TagName="Latex" %>
<%@ Register Src="~/desktopmodules/USerControl/DisplayPlugg/RichRichText/Edit1.ascx" TagPrefix="uc3" TagName="RichRichText" %>
<%@ Register Src="~/desktopmodules/USerControl/DisplayPlugg/RichText/Edit.ascx" TagPrefix="uc1" TagName="RichText" %>
<%@ Register Src="~/desktopmodules/USerControl/DisplayPlugg/YouTube/Edit1.ascx" TagPrefix="uc4" TagName="YouTube" %>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Label runat="server" id="label" />
        <uc2:Latex runat="server" id="latex" />
        <uc3:RichRichText runat="server" id="RichRichText" />
        <uc1:RichText runat="server" id="RichText" />
        <uc4:YouTube runat="server" id="YouTube" />
    </div>
    </form>
</body>
</html>
