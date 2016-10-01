<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="TestWebForm.aspx.vb" Inherits="WebTarget.TestWebForm" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        SearchText();
        SearchText1();
    });
    function SearchText() {
        $(".autosuggest").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "TestWebForm.aspx/GetAutoCompleteData",
                    data: "{'username':'" + document.getElementById('txtSearch').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }
        });
    }
    function SearchText1() {
        $(".autosuggest1").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "TestWebForm.aspx/GetAutoCompleteData1",
                    data: "{'username':'" + document.getElementById('txtSearch1').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }
        });
    }
</script>  
     <style type="text/css">
        .auto-style3 {
            width: 238px;
        }
        #txtSearch0 {
            width: 181px;
        }
        #txtSearch {
            width: 166px;
            margin-left: 0px;
        }
        #txtSearch1 {
            width: 166px;
            margin-left: 8px;
        }
        .auto-style4 {
            width: 125px;
        }
    </style>
    
        <div style="text-align: center; height: 541px;">

            <p style="font-size: large; color: #00CC00; text-align: left;">
                
            </p>
            <p style="font-size: large; color: #00CC00; text-align: left; background-color: #515151;">
                <strong style="color: #FFFFFF">&nbsp;Role</strong>
                <asp:Button ID="Button3" runat="server" Text="Button" />
            </p>
            <p>
                <asp:Button ID="Button4" runat="server" Text="Button" />
                &nbsp;
            </p>
            <table width="100%">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp; &nbsp;Role Code :&nbsp;<asp:TextBox ID="txtname" runat="server" Height="23px" Style="text-align: left"></asp:TextBox>
                    </td>
                    <td rowspan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp; Description
                :
        <asp:TextBox ID="txtpass" runat="server" Height="23px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">
                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" Height="16px" SelectedIndex="0" Width="164px" Skin="Black" Style="margin-left: 51px; text-align: center;">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="User" PageViewID="RadPageView1" Font-Size="15pt" Selected="True">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Project" PageViewID="RadPageView2" Font-Size="15pt">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">

                        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="300px" SelectedIndex="0" Style="margin-left: 0px" Height="16px">
                            <telerik:RadPageView ID="RadPageView1" runat="server" Width="300px" Style="text-align: center" Selected="true">
                                <input id="txtSearch1" class="autosuggest1" size="12" type="text" />
                                <asp:Button ID="Button1" runat="server" Text="Add" />
                                <br />
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="RadPageView2" runat="server" Width="300px" Style="text-align: center">
                                &nbsp;<input id="txtSearch" class="autosuggest" type="text" size="12" />
                                <asp:Button ID="Button2" runat="server" Text="Add" />
                                <br />
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
                    <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;
    
                    <asp:Button ID="btnsearch" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Search" Width="91px" />
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnsave" runat="server" BackColor="#FF9933" BorderColor="#FF9933" Text="Save" Width="91px" />

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>

            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;

        </div>
</asp:Content>
