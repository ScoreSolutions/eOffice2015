<?include_once("connect.php");?>
<!doctype html>
<html lang="en">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>จัดการการเบิกจ่าย</title>
  <script type="text/javascript" src="js/autocomplete.js"></script>
  <link rel="stylesheet" href="css/autocomplete.css"  type="text/css"/>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css">
  <script src="js/jquery-1.11.1.min.js"></script>
  <script type="text/javascript" src="js/jquery-ui.js"></script>
  <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
  <link href="css/style.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
  <script src="js/bootstrap.min.js"></script>
  <script type="text/javascript" src="js/bootstrap.js"></script>  
  <script type="text/javascript" src="js/bootbox.min.js"></script>
  <script type="text/javascript" src="js/jconfirmaction.jquery.js"></script>

</head>
<body>

    <form id="Request" name="Request" action="AddRequest.php" method="post">
    <table border="0" width="100%" align="center" style="margin-top:40px;" class="listitem">
    <tr>
      
      <td align="right" width="0%"></td>
      <td width="0%"><input type="hidden" class="fm3" name="ProID" id="ProID"></td>
      <td align="right" width="10%"><label for="autocomplete">โครงการ :</label></td>
      <td align="left" width="15%"><input type="text" class="fm3" name="txtProject" id="txtProject" required></td>
      <td align="right" width="10%"><label for="autocomplete">สถานที่ตั้ง :</label></td>
      <td align="left" width="15%"><input type="text" class="fm3" name="txtLoca" id="txtLoca" required></td>
      <td align="right" width="10%"><label for="autocomplete">หมายเหตุ :</label></td>
      <td width="30%"><select class="ddls" name="optRemark" required><option value="">เลือกเหตุผล</option>
      <option value="เบิกเพื่อขาย">เบิกเพื่อขาย</option><option value="เบิกเพื่อซ่อม">เบิกเพื่อซ่อม</option>
      </select></textarea></td>
      <td align="right" width="0%"></td>
      <td width="0%"><input type="hidden" class="fm3" name="LocaID" id="LocaID"></td>
    </tr>

<script type="text/javascript"> 

//AUTO COMPLETE ของ Location
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
    return "AutoComLocation.php?&q=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

    }); 
} 
 make_autocom("txtLoca","LocaID");
</script>



<script type="text/javascript">
//AUTO COMPLETE ของ Project 
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
    return "AutoComProject.php?p=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

    }); 
} 
 make_autocom2("txtProject","ProID"); // ระบุ ID ของ textbox ที่ต้องการค้นหาและต้องการดึง ID มาแสดง
</script>




  </table>
  <div class="Table1" id="datahead">     
</div>



<script type="text/javascript">
//Java Script ของการเพิ่ม ROW
$(document).ready(function () {
    var counter = 0;
    counter = $('#myTable tr').length - 1;

    $("#addrow").on("click", function () {
        var newRow = $("<tr align='center'>");
        var cols = "";
        cols += '<td><select class="ddlsss" id="optProduct' + counter + '" name="optProduct' + counter + '"><option value="">เลือกสินค้า</option><?$strSQL = "SELECT id,product_name,product_desc from M_PRODUCT";$objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");while($objResult = mssql_fetch_array($objQuery)){?><? $pid = $objResult["id"];$pname = $objResult["product_name"];$pname= iconv("tis-620","UTF-8", $pname);$pdesc = $objResult["product_desc"];$pdesc= iconv("tis-620","UTF-8", $pdesc);?><option value="<?php echo $pid; ?>"><? echo "".$pname." | ".$pdesc.""; ?></option><?}?></select></td>';
        //cols += '<td ><input type="text" id="txtProduct' + counter + '" class="fm3" name="txtProduct' + counter + '"/></td>';
        cols += '<td ><input type="number" min="0" id="txtQty' + counter + '" class="fm3" name="txtQty' + counter + '"/></td>';
        cols += '<td ><a id="ibtnDel"><span class="glyphicon glyphicon-remove cursor"></span></a></td>';
        cols += '<td width="1%"><input type="hidden" value="1" name="price' + counter + '"/></td>';
        cols += '<td width="1%"><input type="hidden" value="1" id="Prohid"/></td>';
        newRow.append(cols);

        $("table.order-list").append(newRow);
        counter++;
        //if (counter == 50) $('#addrow').attr('disabled', true).prop('value', "You've reached the limit");
    });
    $("table.order-list").on("click", 'a[name^="price"]', function (event) {
        calculateRow($(this).closest("tr"));
        calculateGrandTotal();
    });
    $("table.order-list").on("click", "#ibtnDel", function (event) {
        $(this).closest("tr").remove();
        calculateGrandTotal();
        counter --;
        if (counter < 50) $('#addrow').attr("disabled", false).prop('value', "Add Row");
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
    $("#btnReq").click(function(){
      $.post("AddRequest.php",$("#Request").serialize()); //ส่งข้อมูล แบบ Serialize คือส่งข้อมูลไปทั้งหมดที่มีอยู่ในฟอร์มนั้น
      });
  });

</script>




<table id="myTable" border="0" class="order-list" width="100%" align="center">
    <thead>

        <tr align="center">
             
           <td width="25%"><b><button type="submit" class="btnnull" id="btnReq"><a><span class="glyphicon glyphicon-ok"></span></a></button></b></td>

           <td width="10%"><b></b></td>
           <td width="25%"><b><a id="addrow" class="cursor" name="price"><span class="glyphicon glyphicon-plus"></span></a></b></td>
           <td width="1%"><b></b></td>
           <td width="1%"><b></b></td>
        </tr>
        <tr align="center">


           <td width="40%"><b>ชื่อสินค้า</b></td>
           <td width="10%"><b>จำนวน</b></td>
           <td width="25%"><b>ลบ<input type="hidden" id="grandtotal" name="grandtotal"></b></td>
           <td width="1%"><b></b></td>
           <td width="1%"><b></b></td>
        </tr>
<?
  $sqlReq = "SELECT * 
                   From TS_REQUEST tr
                   left join M_LOCATION l
                   on l.id=tr.location_id
                   left join M_PROJECT p
                   on p.id=l.project_id";
        $QReq = mssql_query($sqlReq) or die ("Error Query [".$sqlReq."]");
        $i=1;
        while($RReq = mssql_fetch_array($QReq))
        {
    ?>
    <? 
        $id = $RReq["req_no"];
        $rm = $RReq["remark"];
        $rm = iconv("tis-620","UTF-8", $rm);
        $lname = $RReq["location_name"];
        $lname = iconv("tis-620","UTF-8", $lname);
        $pjname = $RReq["project_name"];
        $pjname = iconv("tis-620","UTF-8", $pjname);


        $rdate = $RReq["CreateDate"];
        
    ?>


        <?

          $sqlrd = "SELECT tr.CreateDate,tr.req_no,tr.location_id,tr.remark,p.product_name,trd.qty,l.location_name,
                           pj.project_name,u.unit_name,t.type_name
                    FROM TS_REQUEST tr
                    left join TS_REQUEST_DETAIL trd
                    on trd.req_id=tr.req_no
                    left join M_PRODUCT p
                    on p.id=trd.product_id
                    left join M_LOCATION l
                    on l.id=tr.location_id
                    left join M_PROJECT pj
                    on pj.id=l.project_id
                    left join M_UNIT u
                    on u.id=p.unit_id
                    left join M_TYPE t
                    on t.id=p.type_id
                    where req_no = '".$id."'";
          $Qrd = mssql_query($sqlrd) or die ("Error Query [".$sqlrd."]");
       
          while($Rrd = mssql_fetch_array($Qrd)){
            $qty = $Rrd["qty"];
            $pname = $Rrd["product_name"];
            $pname = iconv("tis-620","UTF-8", $pname);
            $runit = $Rrd["unit_name"];
            $runit = iconv("tis-620","UTF-8", $runit);
            $rtype = $Rrd["type_name"];
            $rtype = iconv("tis-620","UTF-8", $rtype);
        ?>

        <tr align="center">
           <td width="40%">
           <select class="ddlsss">
           <option value="">เลือกสินค้า</option>
           <option value=""></option>
           </select></td>
           <td width="10%"></td>
           <td width="25%"></td>
           <td width="1%"></td>
           <td width="1%"></td>
        </tr>
      <?
        
          }
      ?>
        <?
$i = $i+1;}

?>
    </thead>
</table>





  </form>
  <br>

</body>
</html>
