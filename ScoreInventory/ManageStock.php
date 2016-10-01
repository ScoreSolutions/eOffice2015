<?php
    session_start();
    include_once("connect.php");
    $ses_userid =$_SESSION[ses_userid];
    $ses_username = $_SESSION[ses_username];
    if($ses_userid <> session_id() or  $ses_username ==””)
    {
        
        echo "<script>";
        echo "alert('โปรดลงชื่อเข้าสู่ระบบก่อน');";
        echo "window.location.href='index.php';";
        echo "</script>";
    }    
    else 
    {};
    
    $result = mssql_query("select * from M_USER where username ='$_SESSION[ses_username]' ");
    while ($data = mssql_fetch_array($result) ) 
    {
        $name = $data[username];
        $fname = $data[first_name];
        $lname = $data[last_name];
    /*echo $data[lastname],”<br />”;*/
        $gid = $data[group_id];
    }

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>จัดการคลังสินค้า</title>

  <script type="text/javascript" src="autocomplete.js"></script>
  <link rel="stylesheet" href="autocomplete.css"  type="text/css"/>

<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />

<script src="js/jquery-1.11.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>  
<script type="text/javascript" src="js/bootbox.min.js"></script>
<script type="text/javascript" src="js/jconfirmaction.jquery.js"></script>
<script type="text/javascript"> 


    var hd = 0; 
    function displayoff()
    {
        var strPhp = <?php $TT = $_GET['Type']; echo json_encode($TT); ?>;
        if(strPhp=="1")
        {
            document.getElementById('Barcode').style.display = 'none';
            document.getElementById('OnProject').style.display = 'none';
            document.getElementById('StockInDetail').style.display = 'none';
            document.getElementById('BarcodePD').style.display = 'none';
        }
        else if(strPhp=="3")
        {
            document.getElementById('StockIn').style.display = 'none';
            document.getElementById('Barcode').style.display = 'none';
            document.getElementById('StockInDetail').style.display = 'none';
            document.getElementById('BarcodePD').style.display = 'none';
            document.getElementById('onpro').click();
        }
        else if(strPhp=="4")
        {
            document.getElementById('StockIn').style.display = 'none';
            document.getElementById('Barcode').style.display = 'none';
            document.getElementById('OnProject').style.display = 'none';
            document.getElementById('BarcodePD').style.display = 'none';
            document.getElementById('indetail').click();
        }

        else if(strPhp=="5")
        {
            document.getElementById('StockIn').style.display = 'none';
            document.getElementById('Barcode').style.display = 'none';
            document.getElementById('OnProject').style.display = 'none';
            document.getElementById('barcodePd').click();
        }
        else
        {
             document.getElementById('g1').click();
        }  
    }
    function showBarcode()
    {
        document.getElementById('Barcode').style.display = '';
    }
    function showOnpro()
    {
        document.getElementById('OnProject').style.display = '';
    }
    function showIn()
    {
        document.getElementById('StockIn').style.display = '';
    }
    function showInDetail()
    {
        document.getElementById('StockInDetail').style.display = '';
    }
    function showBarcodePD()
    {
        document.getElementById('BarcodePD').style.display = '';
    }
</script>
</head>
<body onload="displayoff();">

<div>
		<ul class="nav nav-tabs con">
            <li class="active">
                <a id="sin" href="#StockIn" data-toggle="tab" onclick="showIn();"><b>ตรวจรับสินค้า</b></a>
            </li>
            <li>
                <a id="indetail" href="#StockInDetail" data-toggle="tab" onclick="showInDetail();"><b>ข้อมูลการรับเข้า</b></a>
            </li>
            <li>
                <a id="g1" href="#Barcode" data-toggle="tab" onclick="showBarcode();"><b>คลังสินค้า</b></a>
            </li>
            <li>
                <a id="onpro" href="#OnProject" data-toggle="tab" onclick="showOnpro();"><b>สินค้าที่ใช้ในโครงการ</b></a>
            </li>
            <li>
                <a id="barcodePd" href="#BarcodePD" data-toggle="tab" onclick="showBarcodePD();"><b>เลขบาร์โค้ดคงเหลือ</b></a>
            </li>

        
        </ul>
 </div>
 <!-- -------------Start Design Content------------ -->
<div class="tab-content content">

  <!------------------------------------------------------------------------------------------------>
<div class="tab-pane active" id="BarcodePD">
    <script type="text/javascript">
    $(document).ready(function(){ 
        $('#BarcodePD2').dataTable(); 
    });
</script>
    <table id="BarcodePD2" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <td>ลำดับ</td>
                <td>เลขบาร์โค้ด</td>
                <td>ชื่อ</td>
                <td>รายละเอียด</td>
                <td>หน่วย</td>
                <td>ประเภท</td>
            </tr>
        </thead>
        <tbody>
            <? 
            $sql2 = "SELECT tpi.Barcode,mp.product_name,mu.unit_name,mt.type_name,mp.product_desc
                        FROM TS_PRODUCT_ITEM tpi
                        inner join M_PRODUCT mp on mp.id = tpi.Product_id
                        inner join M_UNIT mu on mu.id=mp.unit_id
                        inner join M_TYPE mt on mt.id=mp.type_id
                        where tpi.Barcode not in (Select Barcode_pk from TS_STOCK_IN_DETAIL)";
                $objSelect2 = mssql_query($sql2) or die ("Error Query [".$sql2."]");
                $i2=1;
                while($result2 = mssql_fetch_array($objSelect2))
                {   

                    $pid2 = $result2['Barcode'];
                    $pname2 = $result2['product_name'];
                    $pname2 = iconv("tis-620","UTF-8", $pname2);
                    $pdesc2 = $result2['product_desc'];
                    $pdesc2 = iconv("tis-620","UTF-8", $pdesc2);
                    $unit2 = $result2['unit_name'];
                    $unit2 = iconv("tis-620","UTF-8", $unit2);
                    $type2 = $result2['type_name'];
                    $type2 = iconv("tis-620","UTF-8", $type2);
                ?>
        <tr>
            <td><?=$i2?></td>
            <td><?=$pid2?></td>
            <td><?=$pname2?></td>
            <td><?=$pdesc2?></td>
            <td><?=$unit2?></td>
            <td><?=$type2?></td>
        </tr>
<?$i2=$i2+1;}?>
        </tbody>
    </table>

</div>

<!---------------------------------------------------------------------------------------------------------->
<!--------------------------------------------Start Sub1-------------------------------------------------------------------->
 <script type="text/javascript">

 function SearchUser(tableID)
 {
    if (tableID=='tbUser') 
        {
            document.getElementById('TableUser').style.display = '';
            document.getElementById('TableUserSearch').style.display = 'none';
        }
    else
        {
            document.getElementById('TableUserSearch').style.display = '';
        }
 }




 </script>

<script type="text/javascript">
    $(function(){
        $('#txtPO').change(function(){
            var check = $('#txtPO').val();
            if (/[^A-Za-z0-9\-\d]/.test(check)) {
                $('#txtPO').val('');
                alert("กรุณากรอกข้อมูลเป็น A-Z,a-z และ 0-9");
            };
            
        });
    });
</script>
<script type="text/javascript">
    $(function(){
        $('#txtInv').change(function(){
            var check = $('#txtInv').val();
            if (/[^A-Za-z0-9\-\d]/.test(check)) {
                $('#txtInv').val('');
                alert("กรุณากรอกข้อมูลเป็น A-Z,a-z และ 0-9");
            };
            
        });
    });
</script>




 <div class="tab-pane active" id="StockIn">
 <form id="User" name="User" action="AddProductList.php" method="post">


  <?
        $siidget = $_GET['inid'];
        $sqlIND2 =  "SELECT *,si.id as siid,mw.id as mwid,mv.id as mvid
                    FROM TS_STOCK_IN si
                    left join M_VENDOR mv
                    on mv.id=si.vendor_id
                    left join M_WAREHOUSE mw
                    on mw.id=si.ws_id
                    where stockin_code = '$siidget'";

        $QIND2 = mssql_query($sqlIND2) or die ("Error Query [".$sqlIND2."]");

        while($RIND2 = mssql_fetch_array($QIND2))
        {
    ?>



    <? 
        $stockin_code2 = $RIND2["stockin_code"];
        $siid2 = $RIND2["siid"];
        $mvid = $RIND2["mvid"];
        $mwid = $RIND2["mwid"];
        $PO_NO2 = $RIND2["PO_NO"];
        $INV_NO2 = $RIND2["INV_NO"];

        $vendor_name2 = $RIND2["vendor_name"];
        $vendor_name2 = iconv("tis-620","UTF-8", $vendor_name2);
        $ws_name2 = $RIND2["ws_name"];
        $ws_name2 = iconv("tis-620","UTF-8", $ws_name2);


        $stockin_date2 = $RIND2["stockin_date"];
    }
        
    ?>


 <div class="Table1" id="datahead">     

        <div class="TableTH1"><p align="right">เลขที่ Invoice * :</p></div>

        <div class="TableTD1"><p align="left"><input type="text" class="fm3 fm333" name="txtInv" id="txtInv" value="<?=$INV_NO2?>" onchange="chDegit();" required></p></div>

        <div class="TableTH1"><p align="right">เลขที่ PO * :</p></div>

        <div class="TableTD1"><p align="left"><input type="text" class="fm3" name="txtPO" id="txtPO" value="<?=$PO_NO2?>"  required ></p></div>
        
        <div class="TableTH1"><p align="right">คลังจัดเก็บ * :</p></div>

        <div class="TableTD1"><p align="left"><input type="text" class="fm3" value="<?=$ws_name2?>" name="txtStock" id="txtStock1" required checkaz></p></div>

        <div><input type="hidden" style="width:15px;" value="<?=$mwid?>" name="txtStId" id="txtStId" ></div>

        <div class="TableTH1"><p align="right">ผู้ขาย * :</p></div>

        <div class="TableTD1"><p align="left"><input type="text" class="fm3"  name="txtVendor" value="<?=$vendor_name2?>" id="txtVendor" required></p></div>

        <div><input type="hidden" style="width:15px;" value="<?=$mvid?>" name="txtVendorID" id="txtVendorID"></div>

 </div>
<script type="text/javascript">
    $(function(){
        
        

        $('#txtVendor').change(function(){
            var vid = $('#txtVendorID').val();
            if (vid == '') 
            {
                alert('กรุณากรอกข้อมูลผู้ขายให้ถูกต้อง');
                $('#txtVendor').val('');
                $('#txtVendor').focus();
            }
        });
        $('#txtStock1').change(function(){
            var wsid2 = $('#txtStId').val();
            if(wsid2 == '')
            {
                alert('กรุณากรอกข้อมูลคลังสินค้าให้ถูกต้อง');
                $('#txtStock1').val('');
                $('#txtStock1').focus();
            }
        });
    });
</script>
<script type="text/javascript">
    function make_autocom(autoObj,showObj){
  var mkAutoObj=autoObj; 
  var mkSerValObj=showObj;
  new Autocomplete(mkAutoObj, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
    return "AutoComStock.php?&q=" +(this.value); 

    }); 
} 
 make_autocom("txtStock1","txtStId");   
</script>

<script type="text/javascript"> 
function make_autocom2(autoObj2,showObj2){
  var mkAutoObj2=autoObj2; 
  var mkSerValObj2=showObj2; 
  new Autocomplete(mkAutoObj2, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj2).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
    return "AutoComVendor.php?p=" +(this.value); 

    }); 
} 
 make_autocom2("txtVendor","txtVendorID");
</script>


        <!--<div class="TableTD1"><p align="left">
        <select class="ddlsws" name="txtWS" >
            <option value="">เลือกคลัง</option>
            <?
                $WSsql = "SELECT id,ws_name from M_WAREHOUSE";
                $Qws = mssql_query($WSsql) or die ("Error Query [".$WSsql."]");
                while($reWS = mssql_fetch_array($Qws))
                {
            ?>
            <? 
                $idws= $reWS["id"];
                $wsname = $reWS["ws_name"];
                $wsname = iconv("tis-620","UTF-8", $wsname);?>
                <option value="<?php echo $idws; ?>"><? echo $wsname; ?></option>
            
            <?
                }
            ?>

            </select></p></div>-->
        

        <!--<select class="ddlss" name="txtVender" >
            <option value="">เลือกผู้ขาย</option>
            <?
                $vsql = "SELECT id,vendor_name from M_VENDOR";
                $Qven = mssql_query($vsql) or die ("Error Query [".$vsql."]");
                while($reven = mssql_fetch_array($Qven))
                {
            ?>
            <? 
                $idv= $reven["id"];
                $vendern = $reven["vendor_name"];
                $vendern= iconv("tis-620","UTF-8", $vendern);?>
                <option value="<?php echo $idv; ?>"><? echo $vendern; ?></option>
            
            <?
                }
            ?>

            </select>-->
            
            

       
        





<script type="text/javascript">
$(document).ready(function () {
    var counter = 0;
    counter = $('#myTable tr').length - 1;
 
    $("#addrow").on("click", function () {
         
 
        var newRow = $("<tr align='center'>");
        var cols = "";
        
        cols += '<td width="15%"><input type="text" id="txtBc' + counter + '" class="fm3" name="txtBc' + counter + '" required/></td>';
        cols += '<td width="15%"><input type="text" id="txtSerial' + counter + '" class="fm3" name="txtSerial' + counter + '" required/></td>';
        cols += '<td width="15%"><input type="text" id="txtPname' + counter + '" class="fm3" name="txtPname' + counter + '" readonly/></td>';
        cols += '<td width="20%"><input type="text" id="txtPdesc' + counter + '" class="fm3" name="txtPdesc' + counter + '" readonly/></td>';
        cols += '<td width="15%"><input type="text" id="txtPunit' + counter + '" class="fm3" name="txtPunit' + counter + '" readonly/></td>';
        cols += '<td width="15%"><input type="text" id="txtPtype' + counter + '" class="fm3" name="txtPtype' + counter + '" readonly/></td>';
        cols += '<td width="5%"><a id="ibtnDel"><span class="glyphicon glyphicon-remove cursor"></span></a></td>';
        cols += '<td width="1%"><input type="hidden" value="1" name="price' + counter + '"/></td>';
        newRow.append(cols);
         
        $("table.order-list").append(newRow);
        counter++;
        //if (counter == 50) $('#addrow').attr('disabled', true).prop('value', "You've reached the limit");
    });
 
    $("table.order-list").on("click", 'input[name^="addrow"]', function (event) {
        calculateRow($(this).closest("tr"));
        calculateGrandTotal();
    });

    $("table.order-list").on("change", 'input[name^="txtSerial"]', function (event) {
        var counter3 = $(this).closest("tr")[0].rowIndex;
        var counter3 = counter3-1;
        var check = $('#txtSerial'+counter3).val();
        if (/[^A-Za-z0-9\-\d]/.test(check)) 
        {      
            $("#txtSerial"+counter3).focus();
            $('#txtSerial'+counter3).val('');
            alert("กรุณากรอกข้อมูลเป็น A-Z,a-z และ 0-9");
            

        } 
    });



    $("table.order-list").on("change", 'input[name*="txtSerial"]', function (event) {
        var counter3 = $(this).closest("tr")[0].rowIndex;
            var counter3 = counter3-1;
            var strSR = $("#txtSerial"+counter3).val();
            var srStatus =0;
            for (var i2 = 0; i2 < counter3; i2++) {
                var sr1 = $("#txtSerial"+i2).val();

                if (sr1==strSR){
                    srStatus=1;    
                }
            };
            if (srStatus== 0) 
            {

            }
            else
            {
                alert('เลข Serial Number นี้ซ้ำ');
                $("#txtSerial"+counter3).focus();
                $("#txtSerial"+counter3).val('');
            }
    });




      $("table.order-list").on("change", 'input[name*="txtBc"]', function (event) {
            var counter2 = $(this).closest("tr")[0].rowIndex;
            var counter2 = counter2-1;
            var strVal = $("#txtBc"+counter2).val();

            var intStatus =0;
            for (var i = 0; i < counter2; i++) {
                var bc1 = $("#txtBc"+i).val();

                if (bc1==strVal){
                    intStatus=1;
                    
                }
            };
            if (intStatus==0){
            $.ajax({ 

                url: "AutoBarcode.php" ,
                type: "POST",
                data: 'BC=' +$("#txtBc"+counter2).val()

            })
            .success(function(result) { 
                var obj = jQuery.parseJSON(result);

                    
                    if(obj == '')
                    {
                       alert('ไม่พบเลขบาร์โค้ดนี้ในระบบ');
                       $("#txtBc"+counter2).focus();
                       $("#txtBc"+counter2).val('');
                       $("#txtPname"+counter2).val('');
                       $("#txtPdesc"+counter2).val('');
                       $("#txtPunit"+counter2).val('');
                       $("#txtPtype"+counter2).val('');
                       $("#unitid"+counter2).val('');
                       $("#typeid"+counter2).val('');
                    }
                    else if(obj == '1')
                    {
                        alert('มีเลขบาร์โค้ดนี้อยู่ในระบบแล้ว');
                       $("#txtBc"+counter2).focus();
                       $("#txtBc"+counter2).val('');
                       $("#txtPname"+counter2).val('');
                       $("#txtPdesc"+counter2).val('');
                       $("#txtPunit"+counter2).val('');
                       $("#txtPtype"+counter2).val('');
                       $("#unitid"+counter2).val('');
                       $("#typeid"+counter2).val('');
                    }
                    else
                    {
                      $.each(obj, function(key, inval) {

                           $("#txtBc"+counter2).val(inval["Barcode"]);
                           $("#txtPname"+counter2).val(inval["product_name"]);
                           $("#txtPdesc"+counter2).val(inval["product_desc"]);
                           $("#txtPunit"+counter2).val(inval["unit_name"]);
                           $("#txtPtype"+counter2).val(inval["type_name"]);
                           $("#unitid"+counter2).val(inval["uid"]);
                           $("#typeid"+counter2).val(inval["tid"]);

                      });
                    }

                });
        }
        else{
            
            alert('เลขบาร์โค้ดนี้ซ้ำ');
            $("#txtBc"+counter2).focus();
            $("#txtBc"+counter2).val('');


        }
      
    });






         $( document ).ready(function() {
      calculateRow($(this).closest("tr"));
        calculateGrandTotal();
        
    });
     
 
    $("table.order-list").on("click", "#ibtnDel", function (event) {
        $(this).closest("tr").remove();
        calculateGrandTotal();
        counter --;
        //if (counter < 50) $('#addrow').attr("disabled", false).prop('value', "Add Row");
    });
});
function calculateRow(row) {
    var price = +row.find('input[name^="price"]').val();
}
function calculateGrandTotal() {
    var grandTotal = 0;
    $("table.order-list").find('input[name^="price"]').each(function () {
        grandTotal += +$(this).val();
    });
    $("#grandtotal").val(grandTotal); 

  
}   
  $(function(){
    $("#submit").click(function(){
      $.post("AddProductList.php",$("#User").serialize()); //ส่งข้อมูล แบบ Serialize คือส่งข้อมูลไปทั้งหมดที่มีอยู่ในฟอร์มนั้น

      });
  });

</script>

<script type="text/javascript">
    function chDegitSeriql(){
    var ir = counter;
    
        
}
</script>     

<table id="myTable" border="0" class="order-list table table-hover" width="100%">
    <thead>
<?
    $ed = $_GET['ed'];
          if ($ed !='1') {
?>
        <tr align="center">
             
           <td width="15%"><b><input type="submit" value="ยืนยัน" title="ยืนยันการเพิ่มสินค้า" id="savefirst"  name="savefirst" class="btn btn-info"></b></td>
           <td width="15%"><b></b></td>
           <td width="15%"><b></b></td>
           <td width="15%"><b></span></a></b></td>
           
            <td><b></b></td> 
            <td><b></b></td> 

           <td width="5%"><b><input type="button" value="เพิ่ม" title="ยืนยันการเพิ่มสินค้า"  name="addrow" id="addrow" class="btn btn-info"></b></td>
        </tr>


<?}
    else
    {


?>
  <script type="text/javascript">
  $(function(){
      $('#btnClear1').click(function(){
          window.location='Home.php?page=ManageStock&Type=4';
      });
  });
</script>
        <tr align="center">
             
           <td width="15%"><b><input type="submit" value="ยืนยัน" title="ยืนยันการแก้ไข"  name="saveedit" class="btn btn-info"></b></td>
           <td width="15%"><b></b></td>
           <td width="15%"><b></b></td>
           <td width="15%"><b></span></a></b></td>
           
            <td><b></b></td> 
            <td><b></b></td> 
           <td width="5%"><b><input type="button" title="กลับหน้าข้อมูลการรับเข้า" id="btnClear1" value="กลับ" class="btn btn-info"></b></td>
            <td><b></b></td>
        </tr>

        <?}?>


        <tr align="center">

           <td width="15%"><b>บาร์โค้ด<input type="hidden" id="grandtotal" name="grandtotal"></b></td>
           <td width="15%"><b>Serial Number</b></td>
           <td width="15%"><b>ชื่อสินค้า</b></td>
           <td width="20%"><b>รายละเอียดสินค้า</b></td>
           <td width="15%"><b>หน่วย</b></td>
           <td width="15%"><b>ประเภท</b></td>
           <td width="5%"><b>ลบ</b></td>
           <td><b></b></td> 

        </tr>


<script type="text/javascript">
    $(function(){
        $('#txtSerialed').change(function(){
            var check = $('#txtSerialed').val();
            if (/[^A-Za-z0-9\-\d]/.test(check)) {
                $('#txtSerialed').val('');
                alert("กรุณากรอกข้อมูลเป็น A-Z,a-z และ 0-9");
            };
        });
    });
</script>
<script type="text/javascript">
    $(function(){
        $('#txtBced').change(function(){
            var check = $('#txtBced').val();
            if (/[^A-Za-z0-9\-\d]/.test(check)) {
                $('#txtBced').val('');
                alert("กรุณากรอกข้อมูลเป็น A-Z,a-z และ 0-9");
                $('#txtBced').focus();
            };
        });
    });
</script>

<script type="text/javascript">

    $(function(){
        $('#txtAddBc').change(function(){

            $.ajax({ 

                url: "AutoBarcode.php" ,
                type: "POST",
                data: 'BC=' +$("#txtAddBc").val()

            })
            .success(function(result) { 
                var obj = jQuery.parseJSON(result);

                    
                    if(obj == '')
                    {
                       alert('ไม่พบเลขบาร์โค้ดนี้ในระบบ');
                       $("#txtAddBc").focus();
                       $("#txtAddBc").val('');
                       $("#txtNameed").val('');
                       $("#txtDesced").val('');
                       $("#txtUnited").val('');
                       $("#txtTypeed").val('');
                    }
                    else if(obj == '1')
                    {
                        alert('มีเลขบาร์โค้ดนี้อยู่ในระบบแล้ว');
                       $("#txtAddBc").focus();
                       $("#txtAddBc").val('');
                       $("#txtNameed").val('');
                       $("#txtDesced").val('');
                       $("#txtUnited").val('');
                       $("#txtTypeed").val('');
                    }
                    else
                    {
                      $.each(obj, function(key, inval) {

                           $("#txtAddBc").val(inval["Barcode"]);
                           $("#txtNameed").val(inval["product_name"]);
                           $("#txtDesced").val(inval["product_desc"]);
                           $("#txtUnited").val(inval["unit_name"]);
                           $("#txtTypeed").val(inval["type_name"]);
                      });
                    }

                });
        });
    });
                
</script>


        <?
    $ed = $_GET['ed'];
    $sincode = $_GET['inid'];
    if ($ed =='1') {

?>

        <tr align="center">
            <td><input type="text"   id="txtAddBc"     class="fm3" name="txtAddBc"      placeholder="เพิ่มสินค้าใหม่" required/></td>
            <td><input type="text"   id="txtAddSerial" class="fm3" name="txtAddSerial" required ></td>
            <td><input type="text"   id="txtNameed"   class="fm3" name="txtNameed"    readonly></td>
            <td><input type="text"   id="txtDesced"   class="fm3" name="txtDesced"    readonly></td>
            <td><input type="text"   id="txtUnited"   class="fm3" name="txtUnited"    readonly></td>
            <td><input type="text"   id="txtTypeed"   class="fm3" name="txtTypeed"    readonly></td>
            <td><input type="submit" id="btnINSERT"   title="เพิ่มข้อมูลสินค้า"      value="เพิ่ม" name="insert" class="btn btn-info"></td>
            <td></td>
        </tr>
<input type="hidden"   id="txtTypeed"  value="<?=$sincode?>"  class="fm3" name="txtSicode"    readonly>
<?}?>

<?  
        $sicode = $_GET['inid'];
        $sqlInde = "SELECT *,id.id as inid
                    FROM TS_STOCK_IN si
                    left join TS_STOCK_IN_DETAIL id
                    on id.stockin_id=si.stockin_code
                    left join M_VENDOR mv
                    on mv.id=si.vendor_id
                    left join M_WAREHOUSE mw
                    on mw.id=si.ws_id
                    left join TS_PRODUCT_ITEM pii
                    on pii.Barcode=id.Barcode_pk
                    left join M_PRODUCT mp
                    on mp.id=pii.Product_id
                    left join M_UNIT mu
                    on mu.id=mp.unit_id
                    left join M_TYPE mt
                    on mt.id=mp.type_id
                    where stockin_code = '$sicode'";
        $objInde = mssql_query($sqlInde) or die ("Error Query [".$sqlInde."]");
        $ij = 1;
        while($IndeResult = mssql_fetch_array($objInde)){

              $bcode = $IndeResult['Barcode_pk'];
              $stcode = $IndeResult['stockin_code'];
              $inid2 = $IndeResult['inid'];
              $srcode = $IndeResult['SerialNO'];
              $pn1 = $IndeResult['product_name'];$pn1 = iconv("tis-620","UTF-8", $pn1);
              $pd1 = $IndeResult['product_desc'];$pd1 = iconv("tis-620","UTF-8", $pd1);
              $pu1 = $IndeResult['unit_name'];   $pu1 = iconv("tis-620","UTF-8", $pu1);
              $pt1 = $IndeResult['type_name'];   $pt1 = iconv("tis-620","UTF-8", $pt1);


?>

    
        <tr align="center">
            <td><input type="text" value="<? echo $bcode; ?>" class="fm3" name="<? echo "bcode".+$ij; ?>" readonly/></td>
            <td><input type="text" value="<? echo $srcode; ?>" class="fm3" name="<? echo "serialed".+$ij; ?>" id="<? echo "serialed".+$ij; ?>" required/></td>
            <td><input type="hidden" value="<? echo $inid2; ?>" name="<? echo "inid".+$ij; ?>" class="fm3" readonly >
            <input type="text" value="<? echo $pn1; ?>" class="fm3" readonly ></td>
            <td><input type="text" value="<? echo $pd1; ?>" class="fm3" readonly ></td>
            <td><input type="text" value="<? echo $pu1; ?>" class="fm3" readonly ></td>
            <td><input type="text" value="<? echo $pt1; ?>" class="fm3" readonly ></td>
            <td><a class="cursor" href="DeleteSINDetail.php?inid=<?=$inid2?>&rn=<?=$stcode?>" onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
            <span class="glyphicon glyphicon-trash"></span>
            </a></td>
            <td><input type="hidden" id="price" name="price" value="1">
            <input type="hidden" id="nrow" name="nrow" >
            </td>
        </tr>
<?
   $ij = $ij+1; }
?>

    </thead>
</table>
</form>
<script type="text/javascript">
    $(function(){

        $('#txtAddSerial').change(function(){

        var AddSr = $('#txtAddSerial').val();

        var stus = 0;

        var numrow = $('#nrow').val();
        for(var i = 0;i < numrow; i++){
            var AddSe = $('#serialed'+i).val();
            if(AddSe==AddSr){
                stus = 1;
            }
        }
        if (stus==1) 
        {
            alert('เลข Serial Number นี้ ซ้ำ');
            $('#txtAddSerial').focus();
            $('#txtAddSerial').val('');
        }

        });
        
        
    });

    function calculateRow() {
    var numRow = 0;
    $("table.order-list").find('input[name^="price"]').each(function () {
        numRow += +$(this).val();
    });
    $("#nrow").val(numRow); 

  
} 




</script>





</div>

<!-------------------------------------------------End Sub1-------------------------------------------------------------- -->
<style type="text/css" title="currentStyle">
            @import "media/css/demo_page.css";
            @import "media/css/demo_table.css";
            @import "media/css/TableTools.css";
</style>
<script type="text/javascript" src="js/jquery.dataTables.min.js"></script>
<link rel="stylesheet" type="text/css" href="css/jquery.dataTables.min.css" />
<script type="text/javascript">
    $(document).ready(function(){ 
        $('#example').dataTable(); 
    });

</script>

<div class="tab-pane active" id="Barcode">
    <table id="example" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <td>ลำดับ</td>
                <td>ชื่อ</td>
                <td>รายละเอียด</td>
                <td>หน่วย</td>
                <td>ประเภท</td>
                <td>สถานที่จัดเก็บ</td>
                <td>จำนวน</td>
            </tr>
        </thead>
    
        <tbody>

            <? 
            $sql = "SELECT p.product_name,p.product_desc,u.unit_name,t.type_name,w.ws_name,count(i.Product_id) as amount
                    from TS_STOCK_ON_HAND as h
                    left join TS_PRODUCT_ITEM as i  on i.Barcode=h.Barcode_pk
                    left join M_PRODUCT as p    on p.id=i.Product_id
                    left join M_WAREHOUSE as w on w.id=h.ws_id
                    left join M_UNIT as u  on u.id=p.unit_id
                    left join M_TYPE as t on t.id=p.type_id
                    group By ws_name,product_name,product_desc,unit_name,type_name
                    order by ws_name";

                $objSelect = mssql_query($sql) or die ("Error Query [".$sql."]");
                $i=1;
                while($result = mssql_fetch_array($objSelect))
                {   
                    $pid = $result['pid'];
                    $pname = $result['product_name'];
                    $pname = iconv("tis-620","UTF-8", $pname);
                    $pdesc = $result['product_desc'];
                    $pdesc = iconv("tis-620","UTF-8", $pdesc);
                    $unit = $result['unit_name'];
                    $unit = iconv("tis-620","UTF-8", $unit);
                    $type = $result['type_name'];
                    $type = iconv("tis-620","UTF-8", $type);
                    $ws = $result['ws_name'];
                    $ws = iconv("tis-620","UTF-8", $ws);
                    $am = $result['amount'];

                ?>

        <tr>
            <td><?=$i?></td>
            <td><?=$pname?></td>
            <td><?=$pdesc?></td>
            <td><?=$unit?></td>
            <td><?=$type?></td>
            <td><?=$ws?></td>
            <td><?=$am?></td>

        </tr>


<?$i=$i+1;}?>




        </tbody>



    </table>
</div>

<!------------------------------------------------------------------------------------------------>
<script type="text/javascript">
    $(document).ready(function(){ 
        $('#OnProject2').dataTable(); 
    });

</script>
<div class="tab-pane active" id="OnProject">


    <table id="OnProject2" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <td>ลำดับ</td>
                <td>ชื่อ</td>
                <td>รายละเอียด</td>
                <td>หน่วย</td>
                <td>ประเภท</td>
                <td>โครงการ</td>
                <td>สถานที่</td>
                <td>จำนวน</td>
            </tr>
        </thead>
        
        <tbody>

            <? 
            $sql = "SELECT p.product_name,p.product_desc,u.unit_name,t.type_name,pj.project_name,l.location_name,count(i.Product_id) as amount
                    from TS_STOCK_ON_PROJECT as h
                    left join TS_PRODUCT_ITEM as i 
                    on i.Barcode=h.Barcode_pk
                    left join M_PRODUCT as p 
                    on p.id=i.Product_id
                    left join M_UNIT as u 
                    on u.id=p.unit_id
                    left join M_TYPE as t
                    on t.id=p.type_id
                    left join M_LOCATION l
                    on l.id=h.location_id
                    left join M_PROJECT pj
                    on pj.id=h.project_id
                    group By project_name,location_name,product_name,product_desc,unit_name,type_name";

                $objSelect = mssql_query($sql) or die ("Error Query [".$sql."]");
                $i=1;
                while($result = mssql_fetch_array($objSelect))
                {   
                    $pid = $result['pid'];
                    $pname = $result['product_name'];
                    $pname = iconv("tis-620","UTF-8", $pname);
                    $pdesc = $result['product_desc'];
                    $pdesc = iconv("tis-620","UTF-8", $pdesc);
                    $unit = $result['unit_name'];
                    $unit = iconv("tis-620","UTF-8", $unit);
                    $type = $result['type_name'];
                    $type = iconv("tis-620","UTF-8", $type);
                    $project_name = $result['project_name'];
                    $project_name = iconv("tis-620","UTF-8", $project_name);
                    $lc = $result['location_name'];
                    $lc = iconv("tis-620","UTF-8", $lc);
                    $am = $result['amount'];

                ?>

        <tr>
            <td><?=$i?></td>
            <td><?=$pname?></td>
            <td><?=$pdesc?></td>
            <td><?=$unit?></td>
            <td><?=$type?></td>
            <td><?=$project_name?></td>
            <td><?=$lc?></td>
            <td><?=$am?></td>

        </tr>


<?$i=$i+1;}?>




        </tbody>



    </table>
</div>



<!---------------------------------------------------------------------------------------------------------->

<div class="tab-pane active" id="StockInDetail">
<table border="0" width="100%" align="center" class="table table-hover">
    <thead>
        <tr align="center">
          <td width="5%"><b>ลำดับ</b></td>
          <td width="15%"><b>เลขที่ใบรับของ</b></td>
          <td width="10%"><b>เลขที่ Invoice</b></td>
          <td width="10%"><b>เลขที่ PO</b></td>
          <td width="10%"><b>คลังจัดเก็บ</b></td>
          <td width="20%"><b>ผู้ขาย</b></td>
          <td width="15%"><b>วัน/เวลา</b></td>
          <td width="5%"><b>แก้ไข</b></td>
          <td width="5%"><b>ลบ</b></td>
        </tr>
    </thead>



  <tbody>
  <?
        $sqlIND =  "SELECT *,si.id as siid
                    FROM TS_STOCK_IN si
                    left join M_VENDOR mv
                    on mv.id=si.vendor_id
                    left join M_WAREHOUSE mw
                    on mw.id=si.ws_id";

        $QIND = mssql_query($sqlIND) or die ("Error Query [".$sqlIND."]");
        $ik=1;
        while($RIND = mssql_fetch_array($QIND))
        {
    ?>



    <? 
        $stockin_code = $RIND["stockin_code"];
        $siid = $RIND["siid"];
        $PO_NO = $RIND["PO_NO"];
        $INV_NO = $RIND["INV_NO"];

        $vendor_name = $RIND["vendor_name"];
        $vendor_name = iconv("tis-620","UTF-8", $vendor_name);
        $ws_name = $RIND["ws_name"];
        $ws_name = iconv("tis-620","UTF-8", $ws_name);


        $stockin_date = $RIND["stockin_date"];

        
    ?>
<script type="text/javascript">
    $(function  () {
    var i = <? echo json_encode($ik) ?>;
    var inid = <? echo json_encode($stockin_code) ?>;
    var ed = 1;
    $("#"+i).click(function(){
          window.location='Home.php?page=ManageStock&Type=1&inid='+inid+'&ed='+ed;
      }
      );});
</script>
        <tr align="center">
          <td><?=$ik?></td>
          <td><?=$stockin_code?></td>
          <td><?=$INV_NO?></td>
          <td><?=$PO_NO?></td>
          <td><?=$ws_name?></td>
          <td><?=$vendor_name?></td>
          <td align="left"><?=$stockin_date?></td>
          <td><a class="cursor" id="<? echo $ik; ?>"><span class="glyphicon glyphicon-edit"></a></td>
          <td><a class="cursor" href="DeleteStcokCode.php?inid=<?=$stockin_code?>" 
      onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
      <span class="glyphicon glyphicon-trash"></span></a></td>        
        </tr>


       <?
       $ik = $ik+1;
       }?> 
  </tbody>



</div>
</body>
</html>