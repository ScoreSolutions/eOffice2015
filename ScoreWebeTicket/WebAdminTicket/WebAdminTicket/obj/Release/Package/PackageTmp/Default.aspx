<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebTarget._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html, body, form
        {
            height: 100%;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
        }
         
    .RadGrid_Black
{
	border:1px solid #1c1c1c;
}

.RadGrid_Black
{
	font:11px "segoe ui",arial,sans-serif;
}

.RadGrid_Black
{
	outline-color:#858585;
}

.RadGrid_Black
{
	background:#313131;
	color:#858585;
}

.MasterTable_Black
{
	border-collapse:separate !important;
}

.MasterTable_Black
{
	font:11px "segoe ui",arial,sans-serif;
}

.RadGrid_Black *
{
	outline-color:#858585;
}

.GridHeader_Black
{
	color:#006a96;
	text-decoration:none;
}

.GridHeader_Black
{
	border-top:1px solid #3e3e3e;
	border-bottom:1px solid #171717;
	background:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif') 0 0 repeat-x #202020;
	padding:9px 7px 10px 11px;
	text-align:left;
	font-size:1.2em;
	font-weight:normal;
}

.GridPager_Black
{
	color:#aaa;
}

.GridPager_Black
{
	line-height:26px;
}

.PagerLeft_Black
{
	float:left;
}

.RadGrid_Black .rgPagePrev
{
	background-position:4px -992px;
}

.RadGrid_Black .rgPagePrev
{
	width:16px;
	height:16px;
	border:0;
	padding:0;
	background-color:transparent;
	background-image:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif');
	background-repeat:no-repeat;
	vertical-align:middle;
	cursor:pointer;
}

.RadGrid_Black .rgPageNext
{
	background-position:-20px -992px;
}

.RadGrid_Black .rgPageNext
{
	width:16px;
	height:16px;
	border:0;
	padding:0;
	background-color:transparent;
	background-image:url('mvwres://Telerik.Web.UI, Version=2008.2.826.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Black.Grid.sprite.gif');
	background-repeat:no-repeat;
	vertical-align:middle;
	cursor:pointer;
}

.PagerRight_Black
{
	float:right;
}

    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <div id="ParentDivElement" style="height: 100%;">
        <telerik:RadSplitter ID="MainSplitter" runat="server" Height="100%" Width="100%"
            Orientation="Horizontal" style="margin-top: 4px" Skin="Default" BorderSize="0" BorderStyle="None" >
            <telerik:RadPane ID="TopPane" ContentUrl="~/Header.aspx" runat="server" Height="129px"
                MinHeight="78" MaxHeight="78" Scrolling="none" Width="17px" PersistScrollPosition="False">
            </telerik:RadPane>
            <telerik:RadSplitBar ID="RadsplitbarTop" runat="server" CollapseMode="Forward" />
            <telerik:RadPane ID="MainPane" runat="server" Scrolling="none" MinWidth="500" MaxWidth="1200" Height="100%" Width="48px">
                <telerik:RadSplitter ID="NestedSplitter" runat="server" Skin="Default" Width="204px">
                    <telerik:RadPane ID="LeftPane" runat="server" Height="100%" Index="0" Width="20%" ContentUrl="leftpane.aspx">
                    </telerik:RadPane>
                    <telerik:RadSplitBar ID="VerticalSplitBar" runat="server" CollapseMode="Forward" />
                    <telerik:RadPane ID="contentPane" runat="server" ContentUrl="MainPage.aspx" Height="100%" Index="0" Scrolling="Both" Width="80%">  
                    </telerik:RadPane>
                </telerik:RadSplitter>
            </telerik:RadPane>
        </telerik:RadSplitter>
    </div>
    </form>
</body>
</html>
