<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="View.ascx.cs" Inherits="Plugghest.Modules.DisplayPlugg.View" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>

<%----------------------------------------tree -start-----------------------------------------%>
<script src="/DesktopModules/DisplayPlugg/Script/js/jquery-ui-1.10.4.custom.js"></script>
<link href="/DesktopModules/DisplayPlugg/Script/external/prettify.css" rel="stylesheet" />
<link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.1/css/bootstrap-combined.no-icons.min.css" rel="stylesheet">
<link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.1/css/bootstrap-responsive.min.css" rel="stylesheet">
<link href="http://netdna.bootstrapcdn.com/font-awesome/3.0.2/css/font-awesome.css" rel="stylesheet">

<script src="/DesktopModules/DisplayPlugg/Script/external/jquery.hotkeys.js"></script>
<script src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.1/js/bootstrap.min.js"></script>
<link href="/DesktopModules/DisplayPlugg/Script/index.css" rel="stylesheet" />
<script src="/DesktopModules/DisplayPlugg/Script/bootstrap-wysiwyg.js"></script>

<link href="/DesktopModules/DisplayPlugg/Script/js/jqtree.css" rel="stylesheet" />
<script src="/DesktopModules/DisplayPlugg/Script/js/tree.jquery.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $("#" + '<%=pnlTree.ClientID%>').hide();


        $('.btncs').bind('click', function () {
            var clickedID = this.id;
            var string = "#" + clickedID;
            var id = $($(string).prev()).attr("id");
            var newid = $("#" + id).val();
            $('#<%=hdnDDLtxt.ClientID%>').val(newid);
        });

        $(".btnTreeEdit").click(function () {
            $("#" + '<%=pnlTree.ClientID%>').show();
            var $tree = $('#tree2');
            $('#tree2').tree({
                data: eval($("#" + '<%=hdnTreeData.ClientID%>').attr('value')),
                selectable: true,
                autoEscape: false,
                autoOpen: true,
            });

            $tree.bind(
        'tree.select',
        function (event) {
            if (event.node) {
                var node = event.node;
                // alert(node.Mother.getjson)               
                $("#<%=hdnNodeSubjectId.ClientID%>").val(node.SubjectId);
            }
        }
          );

        });
    });
</script>

<%----------------------------------------tree -end-----------------------------------------%>
<script type="text/javascript">
    function SelSub() {
        if ($("#<%=hdnNodeSubjectId.ClientID%>").val() != "") {

        }
        else {
            alert("Please select any one subject");
            return false;
        }
    }

</script>


<asp:HiddenField ID="hdnTreeData" runat="server" />
<asp:HiddenField ID="hdnNodeSubjectId" runat="server" />
<asp:HiddenField ID="hdnDelbtnId" runat="server" />

<asp:Panel ID="pnlloadCnl" runat="server" meta:resourcekey="pnlloadCnlResource1"></asp:Panel>

<div>
    <asp:Button CssClass="cls small_fount" ID="btnlocal"  runat="server" OnClick="btnlocal_Click" resourcekey="btnlocalResource1" OnInit="btnlocal_Init"/>
    <asp:Button CssClass="cls" ID="btncanceltrans" runat="server" OnClick="btncanceltrans_Click" Visible="False" resourcekey="btncanceltransResource1" />
    <asp:Button CssClass="btneditplug" ID="btnEditPlug" runat="server" OnClick="btnEditPlugg_Click" resourcekey="btnEditPlugResource1" />
    <asp:Button CssClass="btneditplug" ID="btncanceledit" runat="server" OnClick="btncanceledit_Click" Visible="False" resourcekey="btncanceleditResource1" />
    <asp:Button CssClass="btneditplug small_fount" ID="btntransplug" resourcekey="btntransplug" runat="server" OnClick="btntransplug_Click" />
</div>
<hr />
<asp:Label ID="lblnoCom" runat="server" Visible="False" meta:resourcekey="lblnoComResource1"></asp:Label>
<asp:HiddenField ID="hdnlabel" runat="server" />
<div class="tree">
    <div id="tree2"></div>
</div>
<asp:Panel runat="server" ID="pnlTree" meta:resourcekey="pnlTreeResource1">
    <asp:Button ID="btnSelSub" OnClientClick="SelSub()" runat="server"  OnClick="btnSelSub_Click" meta:resourcekey="btnSelSubResource1" /><asp:Button ID="btnTreecancel" runat="server" OnClick="Cancel_Click" meta:resourcekey="btnTreecancelResource1" />
</asp:Panel>

<asp:HiddenField ID="hdnDDLtxt" runat="server" />

<asp:Panel ID="pnlPluggCom" runat="server" meta:resourcekey="pnlPluggComResource1">
    <table class="auto-style1">
        <tr>
            <td>
                <div runat="server" id="divTree">
                    <asp:Label ID="lbltree" runat="server" meta:resourcekey="lbltreeResource1"></asp:Label>
                </div>
                <div id="divTitle" runat="server" class="dispalyplug"></div>
            </td>
            <td>
                <div id="divTransaltor" runat="server" class="dispalyplug"></div>
            </td>
        </tr>
    </table>
</asp:Panel>
