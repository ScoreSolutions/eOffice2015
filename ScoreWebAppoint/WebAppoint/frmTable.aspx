<%@ Page Title="" Language="VB" MasterPageFile="~/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmTable.aspx.vb" Inherits="frmTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   

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
            <!--.breadcrumb-->

            <%--            <div class="nav-search" id="nav-search">
                <form class="form-search" />
                <span class="input-icon">
                    <input type="text" placeholder="Search ..." class="input-small nav-search-input" id="nav-search-input" autocomplete="off" />
                    <i class="icon-search nav-search-icon"></i>
                </span>
                </form>
            </div>--%>
            <!--#nav-search-->
        </div>

        <div class="page-content">


            <div class="row-fluid">
                <div class="span12">
                    <!--PAGE CONTENT BEGINS-->


                    <div class="row-fluid">
                        <h3 class="header smaller lighter blue">Demo</h3>
                        <div class="table-header">
                            View Demo
                        </div>


                        <div class="dt_out_actions">
                            <div class="btn-group pull-Left">
                                <button class="btn btn-app btn-info btn-mini no-radius" id="btnPrint" name="btnPrint">
                                    <i class="icon-print bigger-100"></i>
                                    Print
                                </button>
                                <button class="btn btn-app btn-success btn-mini no-radius" id="btnAddnew" name="btnAddnew">
                                    <i class="icon-folder-open bigger-100"></i>
                                    Add New
                                </button>
                                <button class="btn btn-app btn-danger btn-mini no-radius" id="btnDelete" name="btnDelete">
                                    <i class="icon-trash bigger-100"></i>
                                    Delete
                                </button>

                            </div>
                        </div>
                    </div>
                    <table class="table table-striped table-bordered table-hover" id="dt_out"></table>

                </div>
               
            </div>
            <!--/.span-->
        </div>
        <!--/.row-fluid-->

        <!--/.page-content-->

        <div class="ace-settings-container" id="ace-settings-container">
            <div class="btn btn-app btn-mini btn-warning ace-settings-btn" id="ace-settings-btn">
                <i class="icon-cog bigger-150"></i>
            </div>

            <div class="ace-settings-box" id="ace-settings-box">
                <div>
                    <div class="pull-left">
                        <select id="skin-colorpicker" class="hide">
                            <option data-class="default" value="#438EB9" />
                            #438EB9
									<option data-class="skin-1" value="#222A2D" />
                            #222A2D
									<option data-class="skin-2" value="#C6487E" />
                            #C6487E
									<option data-class="skin-3" value="#D0D0D0" />
                            #D0D0D0
                        </select>
                    </div>
                    <span>&nbsp; Choose Skin</span>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-header" />
                    <label class="lbl" for="ace-settings-header">Fixed Header</label>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-sidebar" />
                    <label class="lbl" for="ace-settings-sidebar">Fixed Sidebar</label>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-breadcrumbs" />
                    <label class="lbl" for="ace-settings-breadcrumbs">Fixed Breadcrumbs</label>
                </div>

                <div>
                    <input type="checkbox" class="ace-checkbox-2" id="ace-settings-rtl" />
                    <label class="lbl" for="ace-settings-rtl">Right To Left (rtl)</label>
                </div>
            </div>
        </div>
        <!--/#ace-settings-container-->
    </div>

    <!--/.main-content-->
     <input id="txtKeepId" type="text" runat="server" value="0" style="display: none" />
                 <div id="dialog-View" style="display: none;">

                    <div class="row-fluid">
                        <div class="span12">
                            <!--PAGE CONTENT BEGINS-->

                            <form class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label" for="form-field-11">Name Field</label>

                                    <div class="controls">
                                        <label class="control-label" for="form-field-12">Name Field</label>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label" for="form-field-21">Description Field</label>

                                    <div class="controls">
                                        <label class="control-label" for="form-field-22">Description Field</label>

                                    </div>
                                </div>
                            </form>



                        </div>
                    </div>
                </div>

                <div id="dialog-edit" style="display: none;">

                    <div class="row-fluid">
                        <div class="span12">
                            <!--PAGE CONTENT BEGINS-->

                            <form class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label" for="form-field-1">Name Field</label>

                                    <div class="controls">
                                        <input type="text" id="form-field-1" placeholder="Name" />
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label" for="form-field-2">Description Field</label>

                                    <div class="controls">
                                        <input type="text" id="form-field-2" placeholder="Description" />
                                        <span class="help-inline">Inline help text</span>
                                    </div>
                                </div>
                            </form>



                        </div>
                    </div>
                </div>


    <script type="text/javascript">



        var oTable;
        var isAddNew = false;
        $(document).ready(function () {
            //* datatable must be rendered first
            LoadData();

        });


        //Print
        //$('#btnPrint').click(function () {
        //    alertify();
        //});
        //Add New
        $('#btnAddnew').click(function () {
            onEdit(0);
        });
        //Delete
        //$('#btnDelete').click(function () {
        //    alert('Delete Complete');
        //});

        $("#btnDelete").click(function () {
            var msg = 'Please confirm The delete';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Confirm",
                buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    //add ur stuffs here
                                    alert('Delete Complete');
                                }
                            },
                            {
                                text: "No",
                                click: function () {
                                    div.dialog("close");
                                }
                            }
                ]
            });
        });

        function reset() {
            $("#toggleCSS").attr("href", "../assets/alertify.js-0.3.11/themes/alertify.default.css");
            alertify.set({
                labels: {
                    ok: "OK",
                    cancel: "Cancel"
                },
                delay: 5000,
                buttonReverse: false,
                buttonFocus: "ok"
            });
        }

        // ==============================
        // Standard Dialogs
        $("#btnPrint").on('click', function () {
            //reset();
            //alertify.alert("This is an alert dialog");
            //return false;

            //reset();
            //alertify.success("Success log message");
            //return false;
            alertify.success("Print Complete");
            return false;
 
        });

        function onConfirm2(id) {
            reset();
            alertify.set({ labels: { ok: "Ok", cancel: "Cancel" } });
            alertify.confirm("Please confirm The delete", function (e) {
                if (e) {
                    alertify.success("Delete Complete");
                } else {
                    alertify.error("Delete Failed");
                }
            });
            return false;
        }



        function onConfirm(id) {

            var msg = 'Please confirm The delete';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Confirm",
                buttons: [
                            {
                                text: "Yes",
                                click: function () {
                                    //add ur stuffs here
                                    div.dialog("close");
                                    msgAlert();
                                }
                            },
                            {
                                text: "No",
                                click: function () {
                                    div.dialog("close");
                                }
                            }
                ]
            });


        }

        function msgAlert() {
            var msg = 'Complete';
            var div = $("<div>" + msg + "</div>");
            div.dialog({
                title: "Message",
                buttons: [

                            {
                                text: "Ok",
                                click: function () {
                                   // div.dialog("close");
                                    alertify();
                                }
                            }
                ]
            });

        }









            function LoadData() {
                var dataurl = 'DemoData.ashx';
                $.ajax({
                    "type": "POST",
                    "dataType": 'json',
                    "contentType": "application/json; charset=utf-8",
                    "url": dataurl,
                    "success": PopulateGrid
                });
            }

            function PopulateGrid(jsondata) {
                var columns = [{
                    "sTitle": '<label><input type="checkbox" id="checkall" class="select_rows"  data-tableid="dt_out" onclick=CheckSelectAll(this); value="0" /><span class="lbl"></span>Select All</label>',
                    "bSortable": false,
                    "fnRender": function (obj) {
                        return '<label><input type="checkbox" id="row_sel" name="row_sel" class="select_rows" onclick=KeepID($(this).val(),this.checked); value=' + obj.aData.RowID + '  /><span class="lbl"></span></label>';
                    },
                    "sDefaultContent": "",
                    "bUseRendered": true
                },
                                {
                                    "sTitle": "No",
                                    "sType": "numeric",
                                    "mDataProp": "RowID",
                                    "bUseRendered": false

                                },
                                {
                                    "sTitle": "Name",
                                    "sType": "string",
                                    "sDefaultContent": "",
                                    "mDataProp": "Name"

                                },
                                {
                                    "sTitle": "Description",
                                    "sType": "string",
                                    "sDefaultContent": "",
                                    "mDataProp": "Description",
                                },
                                {
                                    "sTitle": "",
                                    "bSortable": false,
                                    "fnRender": function (obj) {
                                        return '<div class="hidden-phone visible-desktop action-buttons">'
                                                + '<a href="#" data-toggle="modal" class="blue"  title="View" onClick="onView(' + obj.aData.RowID + ');">'
                                                + '<span class="blue"><i class="icon-zoom-in bigger-130"></i></span>'
                                                + '</a>'
                                                + '&nbsp;'
                                                + '<a href="#" class="Green"  title="Edit" onClick="onEdit(' + obj.aData.RowID + ');">'
                                                + '<span class="green"><i class="icon-pencil bigger-130"></i></span>'
                                                + '</a>'
                                                + '&nbsp;'
                                                + '<a href="#" class="Red"  title="Delete" onclick="onConfirm2(' + obj.aData.RowID + ');" >'
                                                + '<span class="red"><i class="icon-trash bigger-130"></i></span>'
                                                + '</a>'
                                                + '</div>'
                                                + '<div class="hidden-desktop visible-phone">'
                                                + '			<div class="inline position-relative">'
                                                + '				<button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">'
                                                + '					<i class="icon-cog icon-only bigger-110"></i>'
                                                + '				</button>'
                                                + ''
                                                + '				<ul class="dropdown-menu dropdown-icon-only dropdown-yellow pull-right dropdown-caret dropdown-close">'
                                                + '					<li>'
                                                + '						<a href="#"  class="tooltip-info" data-rel="tooltip" title="View" onClick="onView(' + obj.aData.RowID + ');">'
                                                + '							<span class="blue">'
                                                + '								<i class="icon-zoom-in bigger-120"></i>'
                                                + '							</span>'
                                                + '						</a>'
                                                + '					</li>'
                                                + ''
                                                + '					<li>'
                                                + '						<a href="#"  class="tooltip-success" data-rel="tooltip" title="Edit" onClick="onEdit(' + obj.aData.RowID + ');">'
                                                + '							<span class="green">'
                                                + '								<i class="icon-edit bigger-120"></i>'
                                                + '							</span>'
                                                + '						</a>'
                                                + '					</li>'
                                                + ''
                                                + '					<li>'
                                                + '						<a href="#" class="tooltip-error" data-rel="tooltip" title="Delete" onclick="onDelete(' + obj.aData.RowID + ');">'
                                                + '							<span class="red">'
                                                + '								<i class="icon-trash bigger-120"></i>'
                                                + '							</span>'
                                                + '						</a>'
                                                + '					</li>'
                                                + '				</ul>'
                                                + '			</div>'
                                                + '		</div>'


                                        ;
                                    },
                                    "sDefaultContent": "",
                                    "bUseRendered": false
                                }
                ];

                oTable = $('#dt_out').dataTable({
                    "aaData": jsondata,
                    "bAutoWidth": false,
                    "aoColumnDefs": [
                    { "sWidth": "10%", "sClass": "aligncenter", "aTargets": [0] },
                    { "sWidth": "10%", "aTargets": [1] },
                    { "sWidth": "35%", "aTargets": [2] },
                    { "sWidth": "35%", "aTargets": [3] },
                    { "sWidth": "10%", "sClass": "aligncenter", "aTargets": [4] }
                    ],
                    "aoColumns": columns,
                    "bDestroy": true,
                });


            }

            //คลิก checkbox ที่ Header
            function CheckSelectAll(e) {

                if (e.checked) { // check select status
                    $('.select_rows').each(function () { //loop through each checkbox
                        this.checked = true;  //select all checkboxes with class "checkbox1" 
                        KeepID($(this).val(), this.checked);
                    });
                } else {
                    $('.select_rows').each(function () { //loop through each checkbox
                        this.checked = false; //deselect all checkboxes with class "checkbox1"  
                        KeepID($(this).val(), this.checked);
                    });
                }
            }

            //เก็บ ID ที่เลือกเก็ยไว้ใน Textbook  (รุปแบบคือ:1#,2#,3#)
            function KeepID(value, check) {
                var strId = $("#<%= txtKeepId.ClientID%>").val();
                if (strId.indexOf(value + '#') == -1) {

                    $("#<%= txtKeepId.ClientID%>").val(strId + ',' + value + '#');
                }

                if (check == false) {
                    $("#<%= txtKeepId.ClientID%>").val(strId.replace(',' + value + '#', ''));
                }



            }

            // fucntion ลบข้อมูล
            function onDelete(RowID) {
                if (confirm("Please confirm the delete")) {
                    var param = "{'RowID':" + JSON.stringify(RowID) + "}";
                    $.ajax({
                        type: "POST",
                        url: "WebAppointService/WebAppointService.asmx/DeleteDemo",
                        data: param,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: onSuccess,
                        error: onFailed
                    });
                }

            }
            function onSuccess(result) {

                if (result.d == true) {
                    alert('Delete complete');
                } else {
                    alert('Delete fail');
                }

            }

            function onFailed() {
                alert('Delete fail');
            }

            function onSave() {
                alert('Save Call');
            }



            function onView(id) {
                $("#dialog-View").dialog({
                    autoOpen: false,
                    resizable: false,
                    width: "auto",
                    hight: "auto",
                    modal: true,
                    buttons: {
                        "Close": function () {
                            $(this).dialog("close");
                        }

                    },
                    show: {
                        effect: 'size',
                        duration: 500
                    },
                    hide: {
                        effect: 'size',
                        duration: 500
                    }
                });

                $("#dialog-View").dialog("option", "title", "View").dialog("open");

            }

            function onEdit(id) {
                $("#dialog-edit").dialog({
                    autoOpen: false,
                    resizable: false,
                    width: "auto",
                    hight: "auto",
                    modal: true,
                    buttons: {
                        "Save": function () {
                            onSave();
                        },
                        "Close": function () {
                            $(this).dialog("close");
                        }

                    },
                    show: {
                        effect: 'size',
                        duration: 500
                    },
                    hide: {
                        effect: 'size',
                        duration: 500
                    }
                });

                $("#dialog-edit").dialog("option", "title", "Edit").dialog("open");

            }


    </script>



</asp:Content>

