<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=tis-620" />
	<title>จัดการการเบิกจ่าย</title>
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
  <script type="text/javascript" src="autocomplete.js"></script>
  <link rel="stylesheet" href="autocomplete.css"  type="text/css"/>
	<script type="text/javascript">
  function displayoff()
    {
        var strPhp = <?php $TT = $_GET['Type']; echo json_encode($TT); ?>;
        if(strPhp=="3")
        {
            document.getElementById('iss').click();
        }
        else if (strPhp=="2") 
          {
            document.getElementById('issDetail').click();
          }
          else if (strPhp=="4") 
          {
            document.getElementById('app').click();

          }
          else if (strPhp=="5") 
          {
            document.getElementById('email').click();
          }
        else
        {
             document.getElementById('Issue').style.display = 'none';
             document.getElementById('IssueDetail').style.display = 'none';
             document.getElementById('ManageEmail').style.display = 'none';
        }  
    }

  	function showReq()
  	{
    	document.getElementById('Request').style.display = '';
  	}
    function showIssue()
    {
      document.getElementById('Issue').style.display = '';
    }
    function showIssueDetail()
    {
      document.getElementById('IssueDetail').style.display = '';
    }
    function showSetApproved()
    {
      document.getElementById('SetApproved').style.display = '';
    }
    function showManageEmail()
    {
      document.getElementById('ManageEmail').style.display = '';
    }
	
	</script>

</head>
<body onload="displayoff();">
<?php
    $$ses_username= iconv("WINDOWS-874","UTF-8", $ses_username); 
    $result = mssql_query("select *,id as uid from M_USER where username ='$_SESSION[ses_username]' ");
    while ($data = mssql_fetch_array($result) ) 
    {
        $name = $data[username];
        $uid = $data[uid];
        $fname = $data[first_name];
        $lname = $data[last_name];
        $fname= iconv("tis-620","UTF-8", $fname);

        $lname= iconv("tis-620","UTF-8", $lname);  
        $gid = $data[group_id];

        $fullname2 = $fname." ".$lname;
    
    }
 ?>
        <div class="topmenu">
        <ul class="nav nav-tabs con topmenu">
            <li class="active">
                <a href="#Request" id="Req" data-toggle="tab" onclick="showReq();"><b>เบิกสินค้า</b></a>
            </li>
            
            <li>
                <a href="#IssueDetail" id="issDetail" data-toggle="tab" onclick="showIssueDetail();"><b>ข้อมูลการเบิก</b></a>
            </li>
            <?php  if($gid=='1'){?>
            <li>
                <a href="#Issue" id="iss" data-toggle="tab" onclick="showIssue();"><b>จ่ายสินค้า</b></a>
            </li>
            <li>
                <a href="#ManageEmail" id="email" data-toggle="tab" onclick="showManageEmail();"><b>กำหนดผู้อนุมัติ</b></a>
            </li>
            <?}?>
        </ul>
        </div>
<div class="tab-content content">

<!---------------------------------------------------------------------------------------------------------------->
<script language="javascript" type="text/javascript">
      function addtext1() {
        var newtext1 = document.getElementById('inputtext1').value;
        document.getElementById('outputtext1').value = newtext1;

      }
</script>

  <div class="tab-pane active" id="ManageEmail">

<form id="SetEmail" method="post" action="AddEmail.php">
  <table width="80%" border="0" align="center">
      <br>
      <tr>
      <td align="right" width="20%"><label>อีเมล์ผู้อนุมัติ :</label></td>
      <td><select id="inputtext1" multiple class="fform-control" ondblclick="addtext1();">
        <?
            $sqlUser2 = "SELECT * FROM M_USER";
            $objsqlUser2 = mssql_query($sqlUser2) or die ("Error Query [".$sqlUser2."]");
            while($rsUser2= mssql_fetch_array($objsqlUser2)) {
              $fn2 = $rsUser2['first_name'];
              $fn2 = iconv("tis-620","UTF-8", $fn2);
              $ln2 = $rsUser2['last_name'];
              $ln2 = iconv("tis-620","UTF-8", $ln2);
              $em2 = $rsUser2['email']; 
 
        ?>
        <option value="<?=$em2?>"><?echo $em2." ".$fn2." ".$ln2?></option>

        <?
          }
        ?>
      </select></td>
      
      <td align="center" width="10%"><button type="button" id="addlist1" onclick="addtext1();" class="btn btn-info" >>></button></td>
      <td align="center" width="40%">
            
      <div class="input-group">
      <?
            $sqlAppove = "SELECT * FROM M_APPOVE";
            $objAppove = mssql_query($sqlAppove) or die ("Error Query [".$sqlAppove."]");
            while($rsAppove= mssql_fetch_array($objAppove)) {
            $apm = $rsAppove['appove_mail'];
            $id = $rsAppove['id'];
            }
        ?>

          <input id="outputtext1" name="outputtext1" value="<?=$apm?>" required rows="4" class="form-control textarea">
          <input type="hidden" id="idappove" name="idappove" value="<?=$id?>">
          <span class="input-group-btn">
            <button type="button" id="resetid" class="btn btn-default" >x</button>
          </span>
<script type="text/javascript">
  $(function(){
      $('#resetid').click(function(){
          $('#idappove').val('');
          $('#outputtext1').val('');
          
      });
  });
</script>
      </div>
      </td>
    </tr>
<!--------------------------------------------End <tr>---------------------------------------------------->
    <tr>
      <td align="right" width="20%"><label>อีเมล์ CC :</label></td>
      <td><br><select id="inputtext2" multiple class="form-control">
        <?
            $sqlUser = "SELECT * FROM M_USER";
            $objsqlUser = mssql_query($sqlUser) or die ("Error Query [".$sqlUser."]");
            while($rsUser= mssql_fetch_array($objsqlUser)) {
              $fn = $rsUser['first_name'];
              $fn = iconv("tis-620","UTF-8", $fn);
              $ln = $rsUser['last_name'];
              $ln = iconv("tis-620","UTF-8", $ln);
              $em = $rsUser['email']; 
 
        ?>
        <option value="<?=$em?>"><?echo $em." ".$fn." ".$ln?></option>

        <?
          }
        ?>
      </select></td>
      <td align="center" width="10%">
<br>
      <button type="button" class="btn btn-info" id="addlist2" >>></button>
      <button type="button" class="btn btn-info" id="dellist2" ><<</span></button></td>
      <td align="center" width="40%">
      <br>
      <select name="setmail" id="setmail" multiple="multiple" class="form-control" required>
        <?
            $sqlAppove2 = "SELECT * FROM M_APPOVE";
            $objAppove2 = mssql_query($sqlAppove2) or die ("Error Query [".$sqlAppove2."]");
            while($rsAppove2= mssql_fetch_array($objAppove2)) {
              $cc = $rsAppove2['appove_cc'];

              $arr = explode (";", $cc);
              $cnt = count($arr);
              $newcnt = $cnt-1;
              for ($i2=0; $i2 < $newcnt; $i2++) { 
        ?>
        <option value="<?=$arr[$i2]?>"><? echo $arr[$i2];?></option>

        <?
              }}
        ?>
      </select>


      </td>
      <td><button type="button" id="clear" class="btn btn-info">ล้าง</button></td>
    </tr>
  </table>
  <br>
  <table align="center" align="100%">
    <td align="center">
    <td><button type="button" onclick="allData();" id="sendvalue" class="btn btn-info">บันทึก</button></td>
    
  </table>
</form>
  </div>

<script type="text/javascript">
          function allData() {
          var cnt = <?php echo json_encode($cnt); ?>;
          var x = document.getElementById("setmail");
          var v = document.getElementById("outputtext1").value;
          var appid = document.getElementById("idappove").value;
          var txt = "";
          var t1 = "A";
          var t2 = "E";
          var i;
          for (i = 0; i < x.length; i++) {
              txt = txt + x.options[i].value+";";
          }
          if (cnt > 0 && v != '') 
          {
              window.location="AddEmail.php?ap="+v+"&cc="+txt+"&t="+t2+"&id="+appid;
          }
          else
          {
              window.location="AddEmail.php?ap="+v+"&cc="+txt+"&t="+t1;
          }
      }
</script>
<script type="text/javascript">
  function addOptionToSelect(sel, txt, val, obj) {
    var opt = document.createElement('option');
    opt.appendChild( document.createTextNode(txt) );

    if ( typeof val === 'string' ) {
        opt.text = val;
        
       
    }
    
    if ( !obj ) {
        sel.appendChild(opt);
        opt.value = txt;
        return;
    }
    }


    function removeAllOptions(sel, removeGrp) {
    var len, groups, par;    
    len = sel.options.length;
    for (var i=len; i; i--) {
        par = sel.options[i-1].parentNode;
        par.removeChild( sel.options[i-1] );
    }
}


    function removeOption(sel, opt) {
    var el = (typeof opt === 'object')? opt: (typeof opt === 'number')? sel.options[ opt ]: null;
    if (el) {
        el.parentNode.removeChild(el);
      }
    }


    var form = document.forms['SetEmail'];
    form.elements['addlist2'].onclick = function(e) {
 
      var newtext2 = document.getElementById('inputtext2').value;
        var sel = this.form.elements['setmail'];
        var cnt = sel.length

        var strResult='';
           //alert(cnt);
           for (var i=0;i<cnt;i++){
                strResult = strResult + sel.options[i].value + '/';
                //alert(strResult);
           }

           if(strResult.indexOf(newtext2) != -1){
                alert("ไม่สามารถเพิ่มอีเมล์ซ้ำได้");
            }else{
           addOptionToSelect(sel, newtext2  );

           }
    };


    form.elements['inputtext2'].ondblclick = function(e) {
 
      var newtext2 = document.getElementById('inputtext2').value;
        var sel = this.form.elements['setmail'];
        var cnt = sel.length
        var strResult='';
           //alert(cnt);
           for (var i=0;i<cnt;i++){
                strResult = strResult + sel.options[i].value + '/';
                //alert(strResult);
           }

           if(strResult.indexOf(newtext2) != -1){
                alert("ไม่สามารถเพิ่มอีเมล์ซ้ำได้");
            }else{
           addOptionToSelect(sel, newtext2 );
           }
    };



    form.elements['dellist2'].onclick = function(e) {

    var sel = this.form.elements['setmail'];
    //alert(sel.selectedIndex);
    removeOption(sel, sel.options[sel.selectedIndex] );
    };

    form.elements['setmail'].ondblclick = function(e) {

    var sel = this.form.elements['setmail'];
    //alert(sel.selectedIndex);
    removeOption(sel, sel.options[sel.selectedIndex] );
    };

    form.elements['clear'].onclick = function(e) {
    var sel = this.form.elements['setmail'];
    removeAllOptions(sel, true);
    };


</script>





<!-- -------------------------------------- Stsrt  Page  Request --------------------------------- -->
	<div class="tab-pane active" id="Request">
  	<form id="Request" name="Request" action="AddRequest.php" method="post">
    <table border="0" width="100%" align="center" style="margin-top:40px;" class="listitem">
    <tr>
      <? $reqid = $_GET['reqno']; 

          $sqlReq3 = "SELECT tr.req_no,pj.project_name,l.location_name,pj.id as pjid,l.id as lcid,
                              mus.first_name+' '+mus.last_name as name,tr.user_id,re.remark_desc,re.id as reid
                      FROM TS_REQUEST tr
                      inner join M_LOCATION l on l.id=tr.location_id
                      inner join M_PROJECT pj on pj.id=l.project_id
                      inner join M_USER mus on mus.id=tr.user_id
                      inner join M_REMARK re on re.id=tr.remark_id
                      where req_no = '$reqid'";
          $objReq3 = mssql_query($sqlReq3) or die ("Error Query [".$sqlReq3."]");
          while($resultReq3= mssql_fetch_array($objReq3)) {
            $userid = $resultReq3['user_id'];

            $fullname = $resultReq3['name'];
            $fullname = iconv("tis-620","UTF-8", $fullname);
            $rnum = $resultReq3['req_no'];
            $pj3 = $resultReq3['project_name'];
            $pj3 = iconv("tis-620","UTF-8", $pj3);
            $reid = $resultReq3['reid'];
            $remark_desc = $resultReq3['remark_desc'];
            $remark_desc = iconv("tis-620","UTF-8", $remark_desc);
            $pjid = $resultReq3['pjid'];
            $lcid = $resultReq3['lcid'];
            $lc3 = $resultReq3['location_name'];
            $lc3 = iconv("tis-620","UTF-8", $lc3);

          }    

      ?>
      <td align="right" width="0%"></td>
      <td width="3%"><input type="hidden" class="fm3" name="ProID" id="ProID" value="<?php echo $pjid; ?>">
      <input type="hidden" class="fm3" name="LocaID" id="LocaID" value="<?php echo $lcid; ?>">
      <input type="hidden" class="fm3" name="reqnum" id="reqnum" value="<?php echo $rnum; ?>"></td>
      

      
      <?php  if($gid=='9'){?>
      <td align="right" width="10%"><label for="autocomplete">ผู้เบิก :</label></td>
      <td align="left" width="15%">
      <select name="txtUser" id="txtUser" class="fm3">
      <option value="<?=$uid?>"><?=$fullname2?></option>
      </select>
      </td>
      <?}?>

      <?php  if($gid=='1'){?>
      <td align="right" width="10%"><label for="autocomplete">ผู้เบิก :</label></td>
      <td align="left" width="15%">
      <select name="txtUser" id="txtUser" class="fm3">
      <option value="<?=$userid?>"><?=$fullname?></option>
      <?
          $sup = "SELECT * FROM M_USER";
          $objsup = mssql_query($sup) or die ("Error Query [".$sup."]");
          while($resultsup= mssql_fetch_array($objsup)) {
            $fid = $resultsup['id'];
            $fname = $resultsup['first_name'];
            $fname = iconv("tis-620","UTF-8", $fname);
            $lname = $resultsup['last_name'];
            $lname = iconv("tis-620","UTF-8", $lname);
      ?>
      <option value="<?=$fid?>"><? echo $fname."  ".$lname; ?></option>
      <?}?>
      </select>
      </td>
      <?}?>


      <td align="right" width="10%"><label for="autocomplete">โครงการ :</label></td>
      <td align="left" width="15%"><input type="text" class="fm3" value="<?php echo $pj3; ?>" name="txtProject" id="txtProject" required></td>
      <td align="right" width="10%"><label for="autocomplete">สถานที่ตั้ง :</label></td>
      <td align="left" width="15%"><input type="text" class="fm3" name="txtLoca" id="txtLoca" value="<?=$lc3?>" required></td>
      <td align="right" width="10%"><label for="autocomplete">หมายเหตุ :</label></td>
      <td width="30%"><select class="ddls" name="optRemark" required>

      <option value="<? echo $reid; ?>"><? echo $remark_desc; ?></option>

      <?
          $sql = "SELECT * FROM M_REMARK";
          $objsql = mssql_query($sql) or die ("Error Query [".$sql."]");
          while($resultsql= mssql_fetch_array($objsql)) {
          $remark_desc =  $resultsql['remark_desc'];
          $remark_desc = iconv("tis-620","UTF-8", $remark_desc);

      ?>
        <option value="<?=$resultsql['id'];?>"><?=$remark_desc?></option>
      <?
          }
      ?>
      </select></td>
      <td align="right" width="0%"></td>
      <td width="10%"></td>
    </tr>

<script type="text/javascript">
  $(function(){
     
        $('#_image_1').click(function(){
         
          $('#ProID').val('');
          $('#LocaID').val('');
          $('#txtLoca').val('');
      });
  });
</script>
<script type="text/javascript">
    $(function(){
        $('#txtProject').change(function(){
            var pjcode = $('#ProID').val();
            if (pjcode == '') 
            {
                alert('กรุณากรอกข้อมูลผู้ขายให้ถูกต้อง');
                $('#txtProject').val('');
                $('#txtProject').focus();
            }
        });
        $('#txtLoca').change(function(){
            var LocaID = $('#LocaID').val();
            if(LocaID == '')
            {
                alert('กรุณากรอกข้อมูลคลังสินค้าให้ถูกต้อง');
                $('#txtLoca').val('');
                $('#txtLoca').focus();
            }
        });
    });
</script>

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
    var lct = document.getElementById('ProID').value;
    return "AutoComLocation.php?pjid="+lct+"&q=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

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
  <script type="text/javascript">
  $(function(){
      $('#btnClear1').click(function(){
          window.location='Home.php?page=Request&Type=2';
      });
  });
</script>
  <script type="text/javascript">
      $(function(){
          $('#btnOK1').click(function(){
                var v1 = $('#11').val();
          });
      });
  </script>
<?
    $ed = $_GET['ed'];
    if ($ed=='1') 
    {
?>
<div align="center"><input type="submit" value="ยืนยัน" name="update" id="update" class="btn btn-info"><button id="btnClear1" type="button" class="btn btn-info">กลับ</button></div>
<?
    }
?>



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
        cols += '<td ><label>'+ counter +'</label></td>';
        cols += '<td><select class="ddls" id="optProduct' + counter + '" name="optProduct' + counter + '"><option value="">เลือกสินค้า</option><?$strSQL = "SELECT id,product_name,product_desc from M_PRODUCT";$objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");while($objResult = mssql_fetch_array($objQuery)){?><? $pid = $objResult["id"];$pname = $objResult["product_name"];$pname= iconv("tis-620","UTF-8", $pname);$pdesc = $objResult["product_desc"];$pdesc= iconv("tis-620","UTF-8", $pdesc);?><option value="<?php echo $pid; ?>"><? echo "".$pname; ?></option><?}?></select></td>';
        //cols += '<td ><input type="text" id="txtProduct' + counter + '" class="fm3" name="txtProduct' + counter + '"/></td>';
        cols += '<td ><input type="number" min="0" id="txtQty' + counter + '" class="fm3" name="txtQty' + counter + '"/></td>';
        cols += '<td ><a id="ibtnDel"><span class="glyphicon glyphicon-remove cursor"></span></a></td>';
        cols += '<td width="1%"><input type="hidden" value="1" name="price' + counter + '"/></td>';
        cols += '<td width="1%"><input type="hidden" value="1" id="Prohid"/></td>';
        newRow.append(cols);

              var cnt = $('#cntRow').val();
              var cnr = $('#cntRow').val(Number(cnt)+1);

              var ccc = $('#counter').val(counter);

        $("table.order-list").append(newRow);
        counter++;
    });
    
    $( document ).ready(function() {
      calculateRow($(this).closest("tr"));
        calculateGrandTotal();
        
    });

    $("table.order-list").on("click", 'input[name^="addrow"]', function (event) {
        calculateRow($(this).closest("tr"));
        calculateGrandTotal();
    });
    $("table.order-list").on("click", "#ibtnDel", function (event) {
        var cnt2 = $('#cntRow').val();
        $('#cntRow').val(Number(cnt2)-1);
        
        $(this).closest("tr").remove();
        calculateGrandTotal();
        counter --;
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

    $(function(){
    $("#update").click(function(){
      $.post("AddRequest.php",$("#Request2").serialize()); //ส่งข้อมูล แบบ Serialize คือส่งข้อมูลไปทั้งหมดที่มีอยู่ในฟอร์มนั้น

      });
  });

</script>

<table id="myTable" border="0" class="order-list table table-hover" width="50%" align="center">
    <thead>
<?
    $ed = $_GET['ed'];
          if ($ed !='1') {
?>
        <tr align="center">             
           <td width="25%"><b>
            <input type="submit" value="ยืนยัน" name="save" class="btn btn-info">
          </b></td>
           <td width="40%"><b></b></td>
           <td width="10%"><b></b></td>
           <td width="25%"><b>
           <input type="button" value="เพิ่ม" id="addrow" name="addrow" class="btn btn-info"></b></td>
           <td width="0%"><b></b></td>
           <td width="0%"><b></b></td>
        </tr>
        <?}?> 



        <tr align="center">
           <td width="25%"><b>ลำดับ</b></td>
           <td width="40%"><b>ชื่อสินค้า</b></td>
           <td width="10%"><b>จำนวน</b></td>
           <td width="25%"><b>ลบ<input type="hidden" id="grandtotal" name="grandtotal" ></b></td>
           <td width="0%"><b><input type="hidden" id="counter" name="counter" ></b></td>
           <td width="0%"><b></b></td>
        </tr>
        

<?
    $ed = $_GET['ed'];
    if ($ed =='1') {
?>

        <tr align="center">
           <td width="25%">


           <span class="badge" >ใหม่</span>

           </td>
           <td width="40%"><select class="ddls" id="optProducted" name="optProducted">
           <option value="">เลือกสินค้า</option>
           <?
                  $strSQL = "SELECT id,product_name,product_desc from M_PRODUCT";
                  $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
                  while($objResult = mssql_fetch_array($objQuery)){
           ?>
                  <? 
                        $pid = $objResult["id"];
                        $pname = $objResult["product_name"];
                        $pname= iconv("tis-620","UTF-8", $pname);
                        $pdesc = $objResult["product_desc"];
                        $pdesc= iconv("tis-620","UTF-8", $pdesc);
                  ?>
                  <option value="<?php echo $pid; ?>"><? echo "".$pname; ?></option>
          <?}?>
          </select></td>
           <td width="10%"><input type="number" min="0"  class="fm3"  id="txtQtyed" name="txtQtyed" ></td>
           <td width="25%"><input type="submit" value="เพิ่ม" name="insert" class="btn btn-info"></td>
           <td width="0%"><b><input type="hidden" id="price" name="price" value="1"></b></b></td>
           <td width="0%"><b></b></td>
        </tr>

<?}?>
        <?
          $sqlReq2 = "SELECT trd.id as trdid,tr.req_no,mp.product_name,mp.id as pid,trd.qty,pj.project_name,l.location_name
                      FROM TS_REQUEST tr
                      left join TS_REQUEST_DETAIL trd
                      on trd.req_id=tr.req_no
                      left join M_PRODUCT mp
                      on mp.id=trd.product_id
                      left join M_LOCATION l
                      on l.id=tr.location_id
                      left join M_PROJECT pj
                      on pj.id=l.project_id
                      where req_no = '$reqid'";
          $objReq2 = mssql_query($sqlReq2) or die ("Error Query [".$sqlReq2."]");
          $ik =1;
          while($resultReq2= mssql_fetch_array($objReq2))              

          {
              $reqno1 = $resultReq2['req_no'];
              $pname1 = $resultReq2['product_name'];
              $pname1 = iconv("tis-620","UTF-8", $pname1);
              $qty1 = $resultReq2['qty'];
              $pid1 = $resultReq2['pid'];
              $trdid = $resultReq2['trdid'];

          $ed = $_GET['ed'];
          if ($ed=='1') {
            
         
          ?>

        <tr align="center">
           <td width="25%"><?=$ik?><input type="hidden" value="<?=$trdid?>" name="<? echo "trdid".+$ik; ?>"></td>
           <td width="40%"><select class="ddls" id="<? echo "optProduct".+$ik; ?>" name="<? echo "optProduct".+$ik; ?>">
           <option value="<?=$pid1?>"><?=$pname1?></option>
           <?
                  $strSQL = "SELECT id,product_name,product_desc from M_PRODUCT";
                  $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
                  while($objResult = mssql_fetch_array($objQuery)){?>
                  <? 
                        $pid = $objResult["id"];
                        $pname = $objResult["product_name"];
                        $pname= iconv("tis-620","UTF-8", $pname);
                        $pdesc = $objResult["product_desc"];
                        $pdesc= iconv("tis-620","UTF-8", $pdesc);
                  ?>
                  <option value="<?php echo $pid; ?>"><? echo "".$pname; ?></option>
          <?}?>
          </select></td>
           <td width="10%"><input type="number" min="0"  class="fm3" value="<?=$qty1?>" id="<? echo "txtQty".+$ik; ?>" name="<? echo "txtQty".+$ik; ?>" ></td>
           <td width="25%"><a class="cursor" href="DeleteRqDetail.php?rnum=<?=$trdid?>&rn=<?=$reqno1?>" onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
            <span class="glyphicon glyphicon-trash"></span>
            </a></td>
           <td width="0%"><b><input type="hidden" id="price" name="price" value="1"></b></b></td>
           <td width="0%"><b></b></td>
        </tr>

        <? }

        $ik = $ik+1;}

        ?>
  
    </thead>

</table>
	</form>   
 	<br>
 	</div>
    <!-- ---------------------------------------End Page 1 --------------------------------- -->


    <!-- -------------------------------------- Stsrt  Page IssueDetail รายการเบิก --------------------------------- -->

<div class="tab-pane active" id="IssueDetail">
<table border="0" width="100%" align="center" class="table table-hover" style="font-size:12px">
    <thead>
        <tr align="center">
          <td width="2.5%"><b>ลำดับ</b></td>
          <td width="12.5%"><b>วันที่เบิก</b></td>
          <td width="12.5%"><b>เลขที่ใบเบิก</b></td>
          <td width="12.5%"><b>ผู้เบิก</b></td>
          <td width="15%"><b>โครงการ</b></td>
          <td width="15%"><b>สถานที่</b></td>
          <td width="10%"><b>หมายเหตุ</b></td>
          <td width="10%"><b>สถานะ</b></td>
          <td width="15%"><b>ขออนุมัติ</b></td>
          <td width="5%"><b>แก้ไข</b></td>
          <td width="5%"><b>ลบ</b></td>
        </tr>
    </thead>
<?
        $r1 = "ขาย";
        $r1 = iconv("UTF-8","tis-620", $r1);

        $r2 = "ซ่อม";
        $r2 = iconv("UTF-8","tis-620", $r2);

        $sqlReq = "SELECT 
                    case 
                      when tr.active_status = 'A' then 'อนุมัติแล้ว'
                      when tr.active_status = 'Y' then 'รอขออนุมัติ'
                      when tr.active_status = 'S' then 'จ่ายแล้ว'
                      when tr.active_status = 'W' then 'รอการอนุมัติ'
                      when tr.active_status = 'D' then 'ไม่อนุมัติ'
                      else 'NO' end as status,*,tr.active_status as act,CONVERT(VARCHAR(10),tr.CreateDate,103) as datereq  
                   From TS_REQUEST tr
                   inner join M_LOCATION l on l.id=tr.location_id
                   inner join M_PROJECT p on p.id=l.project_id
                   inner join M_USER mus on mus.id=tr.user_id
                   inner join M_REMARK re on re.id=tr.remark_id
                   where tr.active_status <> 'S' and tr.active_status <> 'A'
                   order by tr.CreateDate desc";
        $QReq = mssql_query($sqlReq) or die ("Error Query [".$sqlReq."]");
        $i=1;
        while($RReq = mssql_fetch_array($QReq))
        {
    ?>
    <? 
        $id = $RReq["req_no"];
        $proid = $RReq["product_id"];
        $qtyReq = $RReq["qty"];
        $ats = $RReq["act"];
        $datereq = $RReq["datereq"];
        $status = $RReq["status"];
        $rm = $RReq["remark_id"];
        $rm = iconv("tis-620","UTF-8", $rm);
        $rmdesc = $RReq["remark_desc"];
        $rmdesc = iconv("tis-620","UTF-8", $rmdesc);
        $rs = $RReq["reson"];
        $lname = $RReq["location_name"];
        $lname = iconv("tis-620","UTF-8", $lname);
        $pjname = $RReq["project_name"];
        $pjname = iconv("tis-620","UTF-8", $pjname);

        $first_name = $RReq["first_name"];
        $first_name = iconv("tis-620","UTF-8", $first_name);
        $last_name = $RReq["last_name"];
        $last_name = iconv("tis-620","UTF-8", $last_name);
        $none = "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp";

        $rdate = $RReq["CreateDate"];
        
    ?>

<script type="text/javascript">
//Script การเรียกใช้ Modal ที่มี ID ต่างกัน
    $(function  () {
    var i = <? echo json_encode($i) ?>;
    var id = <? echo json_encode($id) ?>;
    var ed = 1;
    $("#"+i).click(function(){
          window.location='Home.php?page=Request&Type=1&reqno='+id+'&ed='+ed;
      }
      );});
</script>


  <tbody>
    <tr align="center">
      <td><? echo $i; ?></td>
      <td><? echo $datereq; ?></td>
      <td><? echo $id; ?></td>
      <td><? echo $first_name." ".$last_name; ?></td>
      <td><? echo $pjname; ?></td>
      <td><? echo $lname; ?></td>
      <td><? echo $rmdesc; ?></td>
      <td><? echo $status; ?></td>

      <td>

      <?
          if ($ats != 'D' && $ats != 'W') {
             if($gid=='1'){
      ?>
      <a class="cursor" id="<? echo "Req".+$i; ?>">
      <?
          }}
      ?>
      <span class="glyphicon glyphicon-send">
      </a></td><td>
      <?
      if($ats == 'Y')
          {
      ?>
      <a class="cursor" id="<? echo $i; ?>">
      <?
          }
      ?>
      <span class="glyphicon glyphicon-edit"></a>
      </td>
      <td>
      <?
      if($ats != 'W')
          {
      ?>
      <a class="cursor" href="DeleteRequest.php?rid=<?=$id?>" 
      onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
      <?
          }
      ?>
      <span class="glyphicon glyphicon-trash"></span>
      </a></td>
    </tr>
  </tbody>

  <!-- ------------------------------------------------------------------------ -->
<script type="text/javascript">
//Script การเรียกใช้ Modal ที่มี ID ต่างกัน
    $(function  () {
    var i = <? echo json_encode($i) ?>;
    $("#Req"+i).click(function(){
      $("#R"+i).modal();
      }
      );});
</script>

  
    <!-- ------------------------------------------------------------------------ -->

    <form action="Activated.php"  id="formEmail" method="get">
    <div class="modal fade" id=<? echo "R".+$i; ?>>
    <div class="modal-dialog modal-lg">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel">ส่งอีเมลล์</h4>
        <hr>
        <p align="center"><? echo "<b>โครงการ : </b>".$pjname." ".$none."<b>สถานที่ : </b>".$lname." ".$none."<b> หมายเหตุ : </b>".$rmdesc;?><p>
      </div>
      <div class="modal-body">
      <?  
          $sqlrd2 = "SELECT tr.CreateDate,tr.req_no,tr.location_id,p.product_name,trd.qty as qty,
                     l.location_name,pj.project_name,u.unit_name,t.type_name,p.id as productid
                     FROM TS_REQUEST tr
                     left join TS_REQUEST_DETAIL trd on trd.req_id=tr.req_no
                     left join M_PRODUCT p on p.id=trd.product_id
                     left join M_LOCATION l on l.id=tr.location_id
                     left join M_PROJECT pj on pj.id=l.project_id
                     left join M_UNIT u on u.id=p.unit_id
                     left join M_TYPE t on t.id=p.type_id
                     left join M_REMARK re on re.id=tr.remark_id
                     where req_no = '".$id."'";

          $Qrd2 = mssql_query($sqlrd2) or die ("Error Query [".$sqlrd2."]");
          $v = 1;
          while($Rrd2 = mssql_fetch_array($Qrd2)){
            $qty = $Rrd2["qty"];
            $productid2 = $Rrd2["productid"]; 
            $req_no = $Rrd2["req_no"];
            $pname = $Rrd2["product_name"];
            $pname = iconv("tis-620","UTF-8", $pname);
            $runit = $Rrd2["unit_name"];
            $runit = iconv("tis-620","UTF-8", $runit);
            $rtype = $Rrd2["type_name"];
            $rtype = iconv("tis-620","UTF-8", $rtype);
      ?>
<script type="text/javascript">
        $(function(){
          var i = <? echo json_encode($i) ?>;
          var v = <? echo json_encode($v) ?>;
          var pname = $('#pname'+v+''+i).val();
          var qtyReq = $('#qtyReq'+v+''+i).val();
          var desc = $('#desc'+v+''+i).val();
          var sale = $('#TotalSale'+v+''+i).val();
          var repair = $('#TotalRepair'+v+''+i).val();
          
            $('#sendmail'+i).click(function(){

              if(desc==16)
              {
                  if(qtyReq>sale)
                  {
                      alert('ไม่สามารถขอเบิกได้เนื่องจากสินค้า >'+pname+'< ไม่เพียงพอ')
                  }
                  else
                  {
                       $('#submitfm'+i).click();
                  }
              }
              else
              {
                  if(qtyReq>repair)
                  {
                      var n1 = Number(sale);
                      var n2 = Number(repair);
                      var sum = n1+n2;
                      if(sum<qtyReq)
                      {
                          alert('ไม่สามารถขอเบิกได้เนื่องจากสินค้า >'+pname+'< ไม่เพียงพอ')
                      }
                      else
                      {
                            
                          var cf = confirm('เนื่องจากสินค้า >'+pname+'< จากคลังอื่นรวมกันมีเพียงพอ ต้องการดำเนินการต่อหรือไม่');
                          if (cf == true) 
                          {
                            var txt = "เนื่องจากสินค้าไม่เพียงพอ จึงต้องใช้คลังอื่นร่วมด้วย";
                            $('#remarkReq').val(txt);
                            $('#submitfm'+i).click();

                          }
                          else
                          {
                            window.location="Home.php?page=Request&Type=2";
                          }

                      }
                  }
                  else
                  {
                      $('#submitfm'+i).click();
                  }
              }

            });
        });

      function cf(){
            confirm('เนื่องจากสินค้า >'+pname+'< จากคลังอื่นรวมกันมีเพียงพอ ต้องการดำเนินการต่อหรือไม่') 
            return false;
      }
</script>
    <div class="Table">
    <div class="Row">
    <div class="Cell"><p align="right"><? echo $v; ?></p></div>
        <div class="Cell"><p>
        <?
          $sqlCheckqty= "SELECT count(sh.id) on_hand_qty ,w.ws_name,w.remark_id, req.qty ,count(sh.id)-req.qty amount
                          from TS_STOCK_ON_HAND sh
                          inner join M_WAREHOUSE w on w.id=sh.ws_id
                          inner join TS_PRODUCT_ITEM pdi on pdi.Barcode=sh.Barcode_pk
                          inner join M_PRODUCT p on p.id=pdi.Product_id
                          inner join
                          (
                                 select rd.qty,r.remark_id, rd.product_id, r.active_status
                                 from TS_REQUEST_DETAIL rd
                                 inner join TS_REQUEST r on r.req_no=rd.req_id
                                 inner join M_PRODUCT p on p.id=rd.product_id
                                 where  r.active_status in('W','A')
                          ) req on req.remark_id=w.remark_id and req.product_id=p.id
                          where w.remark_id='$rm' and p.id='$productid2'
                          group by w.ws_name,w.remark_id,req.qty";

          $Qsql = mssql_query($sqlCheckqty) or die ("Error Query [".$sqlCheckqty."]");
          $qtyTotal;
          $rowTotal = mssql_num_rows($Qsql);
          if($rowTotal < 1)
          {
                  $qtyTotal = 0;
          }
          while($total = mssql_fetch_array($Qsql) ){
          $qtyTotal = $total['amount'];
          }
        ?>
        <?

        
        ?>
        <input type="hidden" id="TotalSale<?=$v?><?=$i?>" value="<?=$qtyTotal2?>">
        <input type="hidden" id="TotalRepair<?=$v?><?=$i?>" value="<?=$qtyTotal?>">
        <input type="hidden" id="desc<?=$v?><?=$i?>" name="desc" value="<?=$rm?>">
        <input type="text" class="fmmodal" value="<? echo $pname; ?>" id="pname<?=$v?><?=$i?>" readonly></p></div>
        <div class="Cell"><p><input type="text" class="fmmodal" value="<? echo $runit; ?>" readonly></p></div>
        <div class="Cell"><p><input type="text" class="fmmodal" value="<? echo $rtype; ?>" readonly></p></div>
        <div class="Cell"><p><input type="text" class="fmmodal" id="qtyReq<?=$v?><?=$i?>" value="<? echo $qty; ?>" readonly></p></div>
    </div>
 
</div>
      <?
         $v=$v+1; }
      ?>

      </div>
      <div class="Row">
        <div class="Cell2" style="vertical-align: top;"><p>อีเมลล์ผู้อนุมัติ :
        <?
            $sqlAppove = "SELECT * FROM M_APPOVE";
            $objAppove = mssql_query($sqlAppove) or die ("Error Query [".$sqlAppove."]");
            while($rsAppove= mssql_fetch_array($objAppove)) {
            $apm = $rsAppove['appove_mail']; 
            }
        ?>
        <input type="hidden" id="remarkReq" name="remarkReq">
        <input class="fmmodal2" type="email" id="EmailTo" name="EmailTo" value="<?=$apm?>" readonly></p></div>
        <div class="Cell2"><p style="vertical-align: top;">อีเมลล์ CC :
        <select name="setmail" id="setmail" multiple="multiple" class="fmselect" readonly>
        <?
            $sqlAppove2 = "SELECT * FROM M_APPOVE";
            $objAppove2 = mssql_query($sqlAppove2) or die ("Error Query [".$sqlAppove2."]");
            while($rsAppove2= mssql_fetch_array($objAppove2)) {
              $cc = $rsAppove2['appove_cc'];

              $arr = explode ( ";", $cc);
              $cnt = count($arr);
              $ncnt = $cnt-1;
              for ($i2=0; $i2 < $ncnt; $i2++) { 
        ?>
        <option value="<?=$arr[$i2]?>"><? echo $arr[$i2];?></option>
        <?
              }}
        ?>
      </select>

      <input type="hidden" name="dataCC" id="dataCC" value="<?=$cc?>">
         </p></div>
      <input type="hidden" value="<?echo $id;?>" id="reqid1" name="reqid1">
    </div>
      <div align="center">
      <input type="submit" id="submitfm<?=$i?>" class="btnHide">
          <button type="button" class="btn btn-primary" id="sendmail<?=$i?>" name="sendmail">ส่งอีเมลล์</button>
      </div>
      </div>
    </div>  
    </div>
    </div>
    </form>
    <input type="hidden" id="reqNo" value="<?=$id?>">
    <!-- ------------------------------------------------------------------------ -->
    <?
        $i=$i+1;}
    ?>
  </table>

  </div>

    <!-- ---------------------------------------End Page IssueDetail --------------------------------- -->
    
  

    <!-- ---------------------------------------Stsrt Page การจ่ายออก  --------------------------------- -->
<script>

$(document).ready(function()
    {
    $('#optReqNo').on('change',function(e)
      {
        $.ajax(
          {
            url:'AutoIssue.php',
            data:$(this).serialize(),
            type:'POST',
            success:function(data)
              {
                console.log(data);
                $("#success").show().fadeOut(5000);
                $('#show').html(data);
              },
            error:function(data)
              {
                $("#error").show().fadeOut(5000);
              }
          });
        e.preventDefault();
      });
  });
</script>
<div class="tab-pane active" id="Issue">
 <form>
   <table border="0" width="100%" align="center" >
        <tr>
            <td align="right" width="30%">เลขที่ใบเบิก :</td>
            <td align="left" width="30%"><select class="ddls" name="optReqNo" id="optReqNo" onchange="sendReq();" required>
            <option value=" ">เลือกเลขที่ใบเบิก</option>
            <?
                $strSQL = "SELECT req_no from TS_REQUEST WHERE active_status = 'A' ORDER BY req_no";
                $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
                while($objResult = mssql_fetch_array($objQuery))
                {
            ?>
            <? 
                $req_no = $objResult["req_no"];
            ?>
                <option value="<?php echo $req_no; ?>"><? echo $req_no; ?></option>
            
            <?
                }
            ?>

            </select></td>
            <td width="5%"></td>
        </tr>   

    </table>
    </form>
    <br>
<table id="show" width="80%" class="table table hover">
  
</table>
    </div>

    <!-- ---------------------------------------End Page การจ่ายออก --------------------------------- -->
  </div>
  </body>
  </html>