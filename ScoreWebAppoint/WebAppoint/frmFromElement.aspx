<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmFromElement.aspx.vb" Inherits="frmFromElement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <!--Edit Styles-->

    
    <div class="main-content">
        <div class="breadcrumbs" id="breadcrumbs">
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home home-icon"></i>
                    <a href="#">Home</a>

                    <span class="divider">
                        <i class="icon-angle-right arrow-icon"></i>
                    </span>
                </li>
                <li class="active">Tables</li>
            </ul>
        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">

                    <div id="dialog"></div>
                    <ul>
                        <li><a href="#" class="dialogify">Dialogify Page 1</a> (<a href="#">view raw content</a>)</li>
                        <li><a href="#" class="dialogify">Dialogify Page 2</a> (<a href="#">view raw content</a>)</li>
                    </ul>


                    <div id="dialog2" title="Alert">
                        <p>
                            Hello this is my first dialog using
                        </p>
                    </div>
                    <input type="button" id="opener" value="show Alert" />
                                  <button class="btn btn-app btn-info btn-mini no-radius" id="btnPrint" name="btnPrint" onclick="opendialog();">
                                    <i class="icon-print bigger-100"></i>
                                    Print
                                </button>

                </div>
            </div>

        </div>

    </div>


</asp:Content>

