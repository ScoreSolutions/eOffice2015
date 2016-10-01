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
<title>จัดการข้อมูลพื้นฐาน</title>
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
<script type="text/javascript" src="js/jconfirmaction.jquery.js"></script>

<script type="text/javascript">
  function displayoff()
  {
    
    var strPhp = <?php $TT = $_GET['Type']; echo json_encode($TT); ?>;
        if(strPhp=="1")
        {
            document.getElementById('Product').style.display = 'none';
            document.getElementById('Remark').style.display = 'none';   
            document.getElementById('type').click();
        }
        else if(strPhp=="2")
        {
            document.getElementById('Type').style.display = 'none';
            document.getElementById('Remark').style.display = 'none';   
            document.getElementById('product').click();
        }
        else if(strPhp=="3")
        {
            document.getElementById('Type').style.display = 'none';
            document.getElementById('Product').style.display = 'none';
            document.getElementById('Remark').style.display = 'none';   
            document.getElementById('vender').click();
        }
        else if(strPhp=="4")
        {
            document.getElementById('Type').style.display = 'none';
            document.getElementById('Product').style.display = 'none';
            document.getElementById('Remark').style.display = 'none';   
            document.getElementById('ws').click();
        }
        else if(strPhp=="5")
        {
            document.getElementById('Type').style.display = 'none';
            document.getElementById('Product').style.display = 'none';
            document.getElementById('remark').click();
        }
        else
        {
            document.getElementById('Remark').style.display = 'none';  
            document.getElementById('Whouse').style.display = 'none'; 
            document.getElementById('Product').style.display ='none';
            document.getElementById('Type').style.display = 'none';
            document.getElementById('Unit').style.display = '';
            document.getElementById('Vender').style.display = 'none';
            document.getElementById('Stock').style.display = 'none';                
        }  

  }
  function showType()
  {
    document.getElementById('Type').style.display = '';
  }

  function showUnit()
  {
    document.getElementById('Unit').style.display = '';
  }

  function showProduct()
  {
    document.getElementById('Product').style.display = '';
  }
  function showVender()
  {
    document.getElementById('Vender').style.display = '';
  }
  function showWs()
  {
    document.getElementById('Whouse').style.display = '';
  }
  function showRemark()
  {
    document.getElementById('Remark').style.display = '';
  }


</script>

</head>
<body onload="displayoff();">
        <div>
        <ul class="nav nav-tabs con topmenu">
            <li class="active">
                <a href="#Unit" id="unit" data-toggle="tab" onclick="showUnit();"><b>หน่วย</b></a>
            </li>

            <li>
                <a href="#Type" id="type" data-toggle="tab" onclick="showType();"><b>ประเภทสินค้า</b></a>
            </li>

            <li>
                <a href="#Vender" id="vender" data-toggle="tab" onclick="showVender();"><b>ผู้ขาย</b></a>
            </li>
            <li>
                <a href="#Remark" id="remark" data-toggle="tab" onclick="showRemark();"><b>หมายเหตุ</b></a>
            </li>
            <li>
                <a href="#Whouse" id="ws" data-toggle="tab" onclick="showWs();"><b>คลังจัดเก็บ</b></a>
            </li>

            <li>
                <a href="#Product" id="product" data-toggle="tab" onclick="showProduct();"><b>สินค้า</b></a>
            </li>
        </ul>
        </div>


<div class="tab-content content">



<!-- -------------------------------------- Stsrt  Remark --------------------------------- -->
<div class="tab-pane active" id="Remark">
 <form action="AddRemark.php" method="post" >
  <table border="0" width="100%" align="center" >

    <? 
        $sql1 = "SELECT 'RM' + RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) From (                      
                SELECT Replace(isnull(max(RIGHT(remark_code,3)),0),'#','')+1 as a fROM M_REMARK) a";

        $qsql1 = mssql_query($sql1) or die ("Error Query [".$sql1."]");
        while($OBsql1 = mssql_fetch_array($qsql1))
            {
                $remarkcode = $OBsql1[0];
            }
    ?>
    <tr>
      <td align="right" width="40%">รหัสหมายเหตุ :</td>
      <td align="left" width="60%"><input type="text" class="fm1" name="txtRcode" value="<? echo $remarkcode; ?>" readonly></td>
        </tr> 
    <tr>
      <td align="right" width="40%">รายละเอียด :</td>
      <td align="left" width="60%"><input type="text" class="fm2" name="txtRdesc" required></td>
    </tr>
  </table>
  
  <table width="100%" align="center">
  <tr>
      <td align="right" width="40%">ใช้งาน :</td>
      <td align="left" width="60%">&nbsp&nbsp<input type="checkbox" class="ch1" value="Y" name="Remarkcheck" checked></td>
    </tr>
    <tr>
      <td align="right" width="40%"><input type="submit" value="ตกลง" class="btn btn-primary"></td>
      <td align="left" width="60%"><input type="reset" value="เคลียร์" class="btn btn-primary"></td>
    </tr>
    
  </table>
  </form>
  <br>


<table border="0" width="100%" align="center" class="table table-hover">
    <thead>
        <tr align="center">
          <td width="10%"><b>ลำดับ</b></td>
          <td width="30%"><b>รหัสหมายเหตุ</b></td>
          <td width="40%"><b>รายละเอียด</b></td>
          <td width="10%"><b>แก้ไข</b></td>
          <td width="10%"><b>ลบ</b></td>
        </tr>
      </thead>


<?
        
        $strSQL = "SELECT * FROM M_REMARK ORDER BY remark_code";
        $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
        $r=1;
        while($objResult = mssql_fetch_array($objQuery))
        {
            $id = $objResult["id"];
            $Rcode = $objResult["remark_code"];
            $Rname = $objResult["remark_desc"];
            $Rid = $objResult["id"];
            $Rname= iconv("tis-620","UTF-8", $Rname);
        ?>



    <script type="text/javascript">
    $(function  () {
    var re = <? echo json_encode($r) ?>;
    $("#re"+re).click(function(){
      $("#r"+re).modal();
      }
      );});
    </script>

  <tbody>
    <tr align="center">
      <td><? echo $r; ?></td>
      <td><? echo $Rcode; ?></td>
      <td><? echo $Rname; ?></td>
      <td><a class="cursor" id="<? echo 're'.$r; ?>"><span class="glyphicon glyphicon-edit"></a></td>
      <td><a class="cursor" href="DeleteRemark.php?rnum=<?=$objResult["id"]; ?>" 
      onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
      <span class="glyphicon glyphicon-trash"></span></a></td>
    </tr>
  </tbody>
  <form action="EditRemark.php?rnum=<?=$objResult["id"]; ?>" name="frmEditUnit" method="post">
    <div class="modal fade" id="<? echo "r".+$r; ?>">
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel">แก้ไขข้อมูลหมายเหตุ</h4>
      </div>
      <div class="modal-body">
        <div class="Table">
            <div class="TableTH"><p align="right">รหัสหมายเหตุ : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="Rcode" class="fmmodal" readonly value="<?=$Rcode?>"></p></div>
            <div class="TableTH"><p align="right">รายละเอียด : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="Rdesc" class="fmmodal" value="<? echo $Rname; ?>" required></p></div>
            <div class="TableTH"><p align="right">ใช้งาน : </p></div>
            <div class="TableTD"><p align="left"><input type="checkbox" name="Rstatus" Value="Y" checked></p></div>
        </div>
      </div>
      <div align="center">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>

    <?
        $r=$r+1;}
    ?>
  </table>
  </div>



<!-- -------------------------------------- End Remark --------------------------------- -->


<!-- -------------------------------------- Stsrt  Page 1 --------------------------------- -->

<div class="tab-pane active" id="Unit">
 <form action="AddUnit.php" method="post" >
 	<table border="0" width="100%" align="center" >

    <? 
        $sql1 = "SELECT 'UN' + RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) From (                      
                SELECT Replace(isnull(max(RIGHT(unit_code,3)),0),'#','')+1 as a fROM M_UNIT) a";

        $qsql1 = mssql_query($sql1) or die ("Error Query [".$sql1."]");
        while($OBsql1 = mssql_fetch_array($qsql1))
            {
                $unitcode = $OBsql1[0];
            }
    ?>
 		<tr>
 			<td align="right" width="40%">รหัสหน่วย :</td>
 			<td align="left" width="60%"><input type="text" class="fm1" name="txtUcode" value="<? echo $unitcode; ?>" readonly></td>
        </tr>	
 		<tr>
 			<td align="right" width="40%">ชื่อ :</td>
 			<td align="left" width="60%"><input type="text" class="fm2" name="txtUname" required></td>
 		</tr>

 		
 	</table>
  
  <table width="100%" align="center">
  <tr>
      <td align="right" width="40%">ใช้งาน :</td>
      <td align="left" width="60%">&nbsp&nbsp<input type="checkbox" class="ch1" value="Y" name="unitcheck" checked></td>
    </tr>
    <tr>
      <td align="right" width="40%"><input type="submit" value="ตกลง" class="btn btn-primary"></td>
      <td align="left" width="60%"><input type="reset" value="เคลียร์" class="btn btn-primary"></td>
    </tr>
    
  </table>
 	</form>
 	<br>


<table border="0" width="100%" align="center" class="table table-hover">
 		<thead>
        <tr align="center">
          <td width="10%"><b>ลำดับ</b></td>
          <td width="30%"><b>รหัสหน่วย</b></td>
          <td width="40%"><b>ชื่อ</b></td>
          <td width="10%"><b>แก้ไข</b></td>
          <td width="10%"><b>ลบ</b></td>
        </tr>
      </thead>


<?
        
        $strSQL = "SELECT * FROM M_UNIT ORDER BY unit_code";
        $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
        $i=1;
        while($objResult = mssql_fetch_array($objQuery))
        {
            $id = $objResult["id"];
            $ucode = $objResult["unit_code"];
            $uname = $objResult["unit_name"];
            $uid = $objResult["id"];
            $uname= iconv("tis-620","UTF-8", $uname);
        ?>



    <script type="text/javascript">
    $(function  () {
    var i = <? echo json_encode($i) ?>;
    $("#"+i).click(function(){
      $("#m"+i).modal();
      }
      );});
    </script>

 	<tbody>
 		<tr align="center">
 			<td><? echo $i; ?></td>
 			<td><? echo $ucode; ?></td>
 			<td><? echo $uname; ?></td>
 			<td><a class="cursor" id="<? echo $i; ?>"><span class="glyphicon glyphicon-edit"></a></td>
 			<td><a class="cursor" href="DeleteUnit.php?unum=<?=$objResult["id"]; ?>" 
      onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
      <span class="glyphicon glyphicon-trash"></span></a></td>
 		</tr>
 	</tbody>
  <form action="EditUnit.php?unum=<?=$objResult["id"]; ?>" name="frmEditUnit" method="post">
    <div class="modal fade" id=<? echo "m".+$i; ?>>
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel">แก้ไขข้อมูลหน่วย</h4>
      </div>
      <div class="modal-body">
        <div class="Table">
            <div class="TableTH"><p align="right">รหัสหน่วย : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="Ucode" class="fmmodal" readonly value="<?=$objResult["unit_code"];?>"></p></div>
            <div class="TableTH"><p align="right">ชื่อ : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="Uname" class="fmmodal" value="<? echo $uname; ?>" required></p></div>
            <div class="TableTH"><p align="right">ใช้งาน : </p></div>
            <div class="TableTD"><p align="left"><input type="checkbox" name="ustatus" Value="Y" checked></p></div>
        </div>
      </div>
      <div align="center">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>

    <?
        $i=$i+1;}
    ?>
 	</table>
 	</div>


    <!-- ---------------------------------------End Page 1 --------------------------------- -->
    






    <!-- ---------------------------------------Stsrt Page 2 --------------------------------- -->
<div class="tab-pane active" id="Type">
 <form action="AddType.php" method="post" >
   <table border="0" width="100%" align="center" >
        <tr>

            <? 


        $sql2 = "SELECT 'T' + RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) 
                 From (SELECT Replace(isnull(max(RIGHT(type_code,3)),0),'#','')+1 as a 
                 FROM M_TYPE) a";






        $qsql2 = mssql_query($sql2) or die ("Error Query [".$sql2."]");
        while($OBsql2 = mssql_fetch_array($qsql2))
            {
                $typecode = $OBsql2[0];
                #echo $typecode;
            }
    ?>
            <td align="right" width="45%">รหัสประเภท :</td>
            <td align="left" width="55%"><input type="text" name="txtTcode" class="fm1" readonly value="<? echo $typecode; ?>" ></td>
        </tr>   
        <tr>
            <td align="right" width="45%">ชื่อ :</td>
            <td align="left" width="55%"><input type="text" name="txtTname" class="fm2" required></td>
        </tr>
        <tr>
            <td align="right" width="45%">ใช้งาน :</td>
            <td align="left" width="55%">&nbsp&nbsp<input type="checkbox" class="ch1" name="Tcheck" checked></td>
        </tr>
        <tr>
            <td align="right" width="45%"><input type="submit" value="ตกลง" class="btn btn-primary"></td>
            <td align="left" width="55%"><input type="reset" value="เคลียร์" class="btn btn-primary"></td>
        </tr>
    </table>
    </form>
    <br>

<table border="0" width="100%" align="center" class="table table-hover">
        <thead>
        <tr align="center">
          <td width="10%"><b>ลำดับ</b></td>
          <td width="30%"><b>รหัสประเภท</b></td>
          <td width="40%"><b>ชื่อ</b></td>
          <td width="10%"><b>แก้ไข</b></td>
          <td width="10%"><b>ลบ</b></td>
        </tr>
      </thead>

    <?
        

        $sqlType = "SELECT * FROM M_TYPE ORDER BY TYPE_code";




        $objType = mssql_query($sqlType) or die ("Error Query [".$sqlType."]");
        $j=1;
        while($ResultType = mssql_fetch_array($objType))
        {
    ?>
    <? 
        $id = $ResultType["id"];
        $tcode = $ResultType["type_code"];
        $tname = $ResultType["type_name"];
        $tid = $ResultType["id"];
        $tname= iconv("tis-620","UTF-8", $tname);
    ?>
    <script type="text/javascript">
    $(function  () {
    var j = <? echo json_encode($j) ?>;
    $("#u"+j).click(function(){
      $("#n"+j).modal();
      }
      );});
    </script>
    <tbody>
        <tr align="center">
            <td><? echo $j; ?></td>
            <td><? echo $tcode; ?></td>
            <td><? echo $tname; ?></td>
            <td><a class="cursor" id=<? echo "u".+$j; ?>><span class="glyphicon glyphicon-edit"></span></a></td>
            <td><a class="cursor" href="DeleteType.php?tnum=<?=$ResultType["id"]; ?>" onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
            <span class="glyphicon glyphicon-trash"></span></a></td>
        </tr>
    </tbody>
 <form action="EditType.php?tnum=<?=$ResultType["id"]; ?>" name="frmEditType" method="post">
    <div class="modal fade" id=<? echo "n".+$j; ?>>
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel">แก้ไขข้อมูลประเภท</h4>
      </div>
      <div class="modal-body">
        <div class="Table">
          <div class="TableTH"><p align="right">รหัสประเภท : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Tcode" class="fmmodal" readonly value="<?=$ResultType["type_code"];?>"></p></div>
          <div class="TableTH"><p align="right">ชื่อ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Tname" class="fmmodal" value="<? echo $tname; ?>" required></p></div>
          <div class="TableTH"><p align="right">ใช้งาน : </p></div>
          <div class="TableTD"><p align="left"><input type="checkbox" name="Tcheck2" Value="Y" checked></p></div>
      </div>
      </div>
      <div align="center">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>

    <?
        $j=$j+1;}
    ?>


<?
        mssql_close($objConnect);
    ?>


</table>
    </div>

    <!-- ---------------------------------------End Page 2 --------------------------------- -->




<!-- ---------------------------------------Stsrt Page 3 --------------------------------- -->
<div class="tab-pane active" id="Product">
 <form id="Product" name="Product" action="AddProduct.php" method="post">
    <table border="0" width="100%" align="center" >
        <tr>

    <? 


        $sql4 = "SELECT 'PD' + RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) From (                      
                 SELECT Replace(isnull(max(RIGHT(product_code,3)),0),'#','')+1 as a FROM M_PRODUCT) a";

        $qsql4 = mssql_query($sql4) or die ("Error Query [".$sql4."]");
        while($OBsql4 = mssql_fetch_array($qsql4))
            {
                $vendorcode = $OBsql4[0];
                #echo $vendorcode;
            }
    ?>



            <td align="right" width="20%">รหัสสินค้า * :</td>
            <td align="left" width="22%"><input type="text" class="fm3" name="txtPcode" value="<? echo $vendorcode;?>" readonly></td>
            <td align="right" width="20%">หน่วย * :</td>
            <td align="left" width="45%"><select class="ddls" name="optUid" required>
            <option value="">เลือกหน่วย</option>
            <?
                $sqlUnit = "SELECT id,unit_name from M_UNIT";
                $qUnit = mssql_query($sqlUnit) or die ("Error Query [".$sqlUnit."]");
                while($objUnit = mssql_fetch_array($qUnit))
                {
            ?>
            <? 
                $id = $objUnit["id"];
                $uname = $objUnit["unit_name"];
                $uname= iconv("tis-620","UTF-8", $uname);?>
                <option value="<?php echo $id; ?>"><? echo $uname; ?></option>
            
            <?
                }
            ?>

            </select></td> 
  
            
        </tr>   
        <tr>
            
            <td align="right" width="20%">ชื่อสินค้า * :</td>
            <td align="right" width="25%"><input type="test" class="fm3" name="txtPname" id="txtPname" required></td>  
            <td align="right" width="20%">ประเภทสินค้า * :</td>
            <td align="left" width="45%">
            <select class="ddls" name="optTid" required>
            <option value="">เลือกประเภทสินค้า</option>
            <?
                $sqlType = "SELECT id,type_name from M_TYPE";
                $qType = mssql_query($sqlType) or die ("Error Query [".$sqlType."]");
                while($objType = mssql_fetch_array($qType))
                {
            ?>
            <? 
                $tid = $objType["id"];
                $tname = $objType["type_name"];
                $tname= iconv("tis-620","UTF-8", $tname);?>
                <option value="<?php echo $tid; ?>"><? echo $tname; ?></option>
            
            <?
                }
            ?>

            </select>

            </td>
      
            
        </tr>
        <tr>
            <td align="right" width="20%">รายละเอียดเพิ่มเติม * :</td>
            <td align="left" width="25%"><input type="text" class="fm3" name="txtPdesc" required></td>
            <td align="right" width="20%">ผู้ขาย * :</td>
            <td align="left" width="45%"><select class="ddls" name="optVid" required>
            <option value="">เลือกผู้ขาย</option>
            <?
                $sqlV = "SELECT id,vendor_name from M_VENDOR";
                $qV = mssql_query($sqlV) or die ("Error Query [".$sqlV."]");
                while($objV = mssql_fetch_array($qV))
                {
            ?>
            <? 
                $vdid = $objV["id"];
                $vdname = $objV["vendor_name"];
                $vdname= iconv("tis-620","UTF-8", $vdname);?>
                <option value="<?php echo $vdid; ?>"><? echo $vdname; ?></option>
            
            <?
                }
            ?>

            </select></td>

            
        </tr> 
        <tr>
        <script type="text/javascript">
            function countNum(){
                var b1 = document.getElementById('PDmin');
                b1.value++;
            }
            function deNum(){
                var b1 = document.getElementById('PDmin');
                b1.value--;
            }
        </script>


            <td align="right" width="20%">จำนวนต่ำสุด * :</td>
            <td align="left" width="25%">  
            <a class="cursor"  onclick="deNum();"><span class="glyphicon glyphicon-minus" id="oncheck"></span></a>
            <input value="0" style="text-align: center;" type="number" min="0" name="PDmin" id="PDmin" class="fm-s">
            <a class="cursor" onclick="countNum();"><span class="glyphicon glyphicon-plus"></span></a>
            </td>

            <td width="10%" rowspan="2" align="right"></td>
            <td width="40%" rowspan="2"></td>        
        </tr>
        <tr>
            <td align="center" width="20%"></td>
            <td align="center" width="25%">ใช้งาน :&nbsp&nbsp<input type="checkbox" class="ch1" value="Y" name="Psta" checked>
            <a href="#" id="SearchUser"></a><br/>
            &nbsp<input type="submit" value="ตกลง" class="btn btn-primary">
            &nbsp<input type="reset" value="เคลียร์" class="btn btn-primary"></td> 
        </tr>
        <tr>
            <td align="right" width="20%"></td>
            <td align="center" width="25%">
            </td>
            <td width="20%"></td>
            <td width="45%"></td>
            
        </tr>          
</table>
</form>

    <br>
<table border="0" width="100%" align="center" class="table table-hover">
        <thead>
        <tr align="center">
          <td width="5%"><b>ลำดับ</b></td>
          <td width="10%"><b>รหัสสินค้า</b></td>
          <td width="10%"><b>ชื่อ</b></td>
          <td width="27.5%"><b>รายละเอียด</b></td>
          <td width="10%"><b>หน่วย</b></td>
          <td width="10%"><b>ประเภท</b></td>
          <td width="20%"><b>ผู้ขาย</b></td>
          <td width="5%"><b>จำนวนต่ำสุด</b></td>
          <td width="2.5%"><b>พิมพ์</b></td>         
          <td width="2.5%"><b>แก้ไข</b></td>
          <td width="2.5%"><b>ลบ</b></td>
        </tr>
      </thead>
    <?
        $sqlProduct = "SELECT p.id,p.product_code,p.product_name,p.product_desc,p.minimum,
                       p.unit_id,u.unit_name,t.type_name,v.vendor_name,p.type_id,p.vendor_id
                       FROM M_PRODUCT as p 
                       inner join M_UNIT as u on u.id=p.unit_id
                       inner join M_TYPE as t on t.id=p.type_id
                       inner join M_VENDOR as v on v.id=p.vendor_id";

        $objProduct = mssql_query($sqlProduct) or die ("Error Query [".$sqlProduct."]");
        $g=1;
        while($ResultPD = mssql_fetch_array($objProduct))
        {
    ?>
    <? 
        $PDmin = $ResultPD["minimum"];
        $id = $ResultPD["id"];
        $pcode = $ResultPD["product_code"];
        $pname = $ResultPD["product_name"];
        $pname= iconv("tis-620","UTF-8", $pname);
        $pdesc = $ResultPD["product_desc"];
        $pdesc= iconv("tis-620","UTF-8", $pdesc);
        $UNITid = $ResultPD["unit_id"];
        $unitname= $ResultPD["unit_name"];
        $unitname= iconv("tis-620","UTF-8", $unitname);
        $TYPEid = $ResultPD["type_id"];
        $typename= $ResultPD["type_name"];
        $typename= iconv("tis-620","UTF-8", $typename);
        $VENDERid = $ResultPD["vendor_id"];
        $vendername= $ResultPD["vendor_name"];
        $vendername= iconv("tis-620","UTF-8", $vendername);
    ?>
    <script type="text/javascript">
    $(function  () {
    var j = <? echo json_encode($g) ?>;
    $("#PD"+j).click(function(){
      $("#Pedit"+j).modal();
      }
      );});
    </script>


    <script type="text/javascript">
    $(function  () {
    var j = <? echo json_encode($g) ?>;
    $("#PDba"+j).click(function(){
      $("#Pprint"+j).modal();
      }
      );});
    </script>


    <tbody>
        <tr align="center">
            <td><? echo $g; ?></td>
            <td><? echo $pcode; ?></td>
            <td><? echo $pname; ?></td>
            <td><? echo $pdesc; ?></td>
            <td><? echo $unitname; ?></td>
            <td><? echo $typename; ?></td>
            <td><? echo $vendername; ?></td>
            <td><? echo $PDmin; ?></td>
            <td><a class="cursor" id="<? echo "PDba".+$g;?>"><span class="glyphicon glyphicon-print"></span></a></td>
            <td><a class="cursor" id="<? echo "PD".+$g;?>"><span class="glyphicon glyphicon-edit"></span></a></td>
            <td><a class="cursor" href="DeleteProduct.php?pnum=<?=$ResultPD["id"]; ?>" onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')"><span class="glyphicon glyphicon-trash"></span></a></td>
        </tr>
    </tbody>

<form action="EditProduct.php?pnum=<?=$ResultPD["id"]; ?>" name="frmEditPD" method="post">
    <div class="modal fade" id="<? echo "Pedit".+$g; ?>">
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel"><p align="center">แก้ไขข้อมูลสินค้า</p></h4>
      </div>
      <div class="modal-body">
        <div class="Table">
          <div class="TableTH"><p align="right">รหัสสินค้า : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="PDcode" class="fmmodal" readonly value="<? echo $pcode;?>"></p></div>
          <div class="TableTH"><p align="right">ชื่อสินค้า : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="PDname" class="fmmodal" value="<? echo $pname;?>" required></p></div>
          <div class="TableTH"><p align="right">รายละเอียด : </p></div>
          <div class="TableTD"><p align="left"><textarea rows="2" class="fmarea1" name="PDdesc"><? echo $pdesc;?></textarea></p></div>
          <div class="TableTH"><p align="right">จำนวนต่ำสุด : </p></div>
          <div class="TableTD"><p align="left"><input value="<? echo $PDmin;  ?>" min="0" type="text" id="PDmini" name="PDmini" class="fmmodal" required></p></div>
          <div class="TableTH"><p align="right">หน่วย : </p></div>
          <div class="TableTD"><p align="left">
          <select class="fmmodal" name="sUnit" style="width:152px;height:25px;" required>
            <option value="<?php echo $UNITid; ?>"><? echo $unitname; ?></option>
            <?
                $sUnit = "SELECT id,unit_name from M_UNIT";
                $oUnit = mssql_query($sUnit) or die ("Error Query [".$sUnit."]");
                while($rUnit = mssql_fetch_array($oUnit))
                {
            ?>
            <? 
                $UNIT_id = $rUnit["id"];
                $UNIT_name = $rUnit["unit_name"];
                $UNIT_name= iconv("tis-620","UTF-8", $UNIT_name);?>
                <option value="<?php echo $UNIT_id; ?>"><? echo $UNIT_name; ?></option>
            
            <?
                }
            ?>
            </select>
          </p></div>
          <div class="TableTH"><p align="right">ประเภทสินค้า : </p></div>
          <div class="TableTD"><p align="left">
          <select class="fmmodal" name="sType" style="width:152px;height:25px;" required>
            <option value="<?php echo $TYPEid; ?>"><? echo $typename; ?></option>
            <?
                $sType = "SELECT id,type_name from M_TYPE";
                $oType = mssql_query($sType) or die ("Error Query [".$sType."]");
                while($rType = mssql_fetch_array($oType))
                {
            ?>
            <? 
                $TYPE_id = $rType["id"];
                $TYPE_name = $rType["type_name"];
                $TYPE_name= iconv("tis-620","UTF-8", $TYPE_name);?>
                <option value="<?php echo $TYPE_id; ?>"><? echo $TYPE_name; ?></option>
            
            <?
                }
            ?>
            </select>
          </p></div>
          <div class="TableTH"><p align="right">ผู้ขาย : </p></div>
          <div class="TableTD"><p align="left">
          <select class="fmmodal" name="sVender" style="width:152px;height:25px;" required>
            <option value="<?php echo $VENDERid; ?>"><? echo $vendername; ?></option>
            <?
                $sVender = "SELECT id,vendor_name from M_VENDOR";
                $oVender = mssql_query($sVender) or die ("Error Query [".$sVender."]");
                while($rVender = mssql_fetch_array($oVender))
                {
            ?>
            <? 
                $VENDER_id = $rVender["id"];
                $VENDER_name = $rVender["vendor_name"];
                $VENDER_name= iconv("tis-620","UTF-8", $VENDER_name);?>
                <option value="<?php echo $VENDER_id; ?>"><? echo $VENDER_name; ?></option>
            
            <?
                }
            ?>
            </select>
          </p></div>
          <div class="TableTH"><p align="right">ใช้งาน : </p></div>
          <div class="TableTD"><p align="left"><input type="checkbox" name="PDsta" Value="" checked></p></div>
      </div>
      </div>
      <div align="center">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>


    <form action="PrintBarcode.php?pnum=<?=$ResultPD["id"]; ?>" name="frmEditPD" method="post">
    <div class="modal fade" id="<? echo "Pprint".+$g; ?>">
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel"><p align="center">พิมพ์บาร์โค้ด</p></h4>
      </div>
      <div class="modal-body">
        <div class="Table">
          <div class="TableTH"><p align="right">จำนวน : </p></div>
          <div class="TableTD"><p align="left"> 
            <input value="0" style="text-align: center;" type="number" min="0" id="PDprint" name="PDprint" class="fm-s" required>
            </p></div>
      </div>
      </div>
      <div align="center">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>













<?
        $g=$g+1;}
?>






</table>
</div>
<!-- ---------------------------------------End Page 3 --------------------------------- -->







<!-- ---------------------------------------Stsrt Page 4 --------------------------------- -->
 <script type="text/javascript">
    function chDegittel(){
    var check = document.getElementById('txtVtel').value;
        if (/[^0-9\-\d]/.test(check)) 
        {      
            alert("กรุณากรอกข้อมูลเป็นตัวเลข");

            document.getElementsByTagName('txtVtel').value('');
        } 
    }
    function chDegitFax(){
    var check2 = document.getElementById('txtVfax').value;
        if (/[^0-9\-\d]/.test(check2)) 
        {      
            alert("กรุณากรอกข้อมูลเป็นตัวเลข");

            document.getElementsByTagName('txtVfax').value('');
        } 
    }

</script>




<div class="tab-pane active" id="Vender">
 <form id="Vender" name="Vender" action="AddVender.php" method="post">
    <table border="0" width="100%" align="center" >
        <tr>

            <? 

        $sql3 = "SELECT 'VD' + RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) 
                 From (SELECT Replace(isnull(max(RIGHT(vendor_code,3)),0),'#','')+1 as a 
                 FROM M_VENDOR) a";


        $qsql3 = mssql_query($sql3) or die ("Error Query [".$sql3."]");
        while($OBsql3 = mssql_fetch_array($qsql3))
            {
                $vendorcode = $OBsql3[0];
                #echo $vendorcode;
            }
    ?>
            <td align="right" width="15%">รหัสผู้ขาย * :</td>
            <td align="left" width="25%"><input type="text" class="fm3" readonly name="txtVcode" value="<?echo $vendorcode;?>" readonly></td>
            <td align="right" width="15%">เบอร์โทรศัพท์ * :</td>
            <td colspan="3" align="left" width="35%"><input type="text" class="fm4" name="txtVtel" id="txtVtel" onkeypress="chDegittel();"  required></td>
        </tr>   
        <tr>
            
            <td align="right" width="12%">ชื่อผู้ขาย * :</td>
            <td align="left" width="19%"><input type="test" class="fm3" name="txtVname" id="txtPass" required></td>  
            <td align="right" width="13%">เบอร์แฟกซ์ * :</td>
            <td colspan="3" align="left"><input type="text" class="fm4" id="txtVfax" name="txtVfax" onkeypress="chDegitFax();" required></td>
        </tr>
        <script type="text/javascript">
        $(function(){
            $('#txtMoo').change(function(){
                var va = $('#txtMoo').val();
                  if (va < 0) 
                    {
                        alert();
                        $('#txtMoo').val('');
                        $('#txtMoo').focus();
                    };
            });
        });
        </script>
        <tr>
            <td align="right" width="12%">ชื่อผู้ติดต่อ * :</td>
            <td align="left" width="19%"><input type="text" class="fm3" name="txtCfname" required></td>
            <td align="right">ที่อยู่เลขที่ * :</td>
            <td><input name="txtNoHome" class="fm3" type="text" required /></td>
            <td width="5%"  align="right">หมู่ :</td>
            <td><input name="txtMoo" id="txtMoo" class="fm4" type="number"/></td>
        </tr> 
        <tr>
            <td align="right" width="12%">นามสกุลผู้ติดต่อ * :</td>
            <td align="left" width="19%"><input type="text" class="fm3" name="txtClname" required></td>
            <td align="right" width="12%">จังหวัด * :</td>
            <td colspan="3" >

            <input class="fmarea" type="text" name="txtProvince" required>
            <input class="fmarea" type="hidden" name="txtProvinceid" id="txtProvinceid" required></td>

            <td colspan="3" >

            </td>
            

        </tr>

        <tr>
            <td align="right" width="12%"></td>
            <td align="center" width="19%"></td>
            <td width="13%"></td>
            <td width="19%"></td>
            <td width="12%"></td>
            <td width="25%"></td>
        </tr>   
        <tr>
            <td align="right" width="12%">อีเมลล์ * :</td>
            <td align="left" ><input type="email" class="fm3" name="txtVmail"  required></td> 
            <td width="5%" align="right">อำเภอ/เขต* :</td>
            <td width="2%"><input name="txtAmphur" type="text" id="txtAmphur" class="fm3" required="required" />
            <input name="txtAmphurid" id="txtAmphurid" type="hidden" class="fm3" required="required" /></td>
            <td width="13%" align="right">แขวง/ตำบล * :</td>
            <td width="19%"><input name="txtDistrict" id="txtDistrict" type="text" class="fm3" required="required" />
            <input name="txtDistrictid" id="txtDistrictid" type="hidden" class="fm3" required="required" /></td>

        </tr>          
</table>

<table align="center" border="0">
    
    <tr>
            <td align="center" width="15%">ใช้งาน :&nbsp&nbsp<input type="checkbox" class="ch1" value="Y" name="Vsta" checked>
            <a href="#" id="SearchUser"></a><br/>
            &nbsp<input type="submit" value="ตกลง" class="btn btn-primary">
            &nbsp<input type="reset" value="เคลียร์" class="btn btn-primary"></td> 
      </tr>
</table>
        
</form>
<script type="text/javascript">
  $(function(){
        $('#_image_1').click(function(){
          $('#txtProvinceid').val('');
          $('#txtAmphur').val('');
          $('#txtAmphurid').val('');
          $('#txtDistrictid').val('');
            $('#txtDistrict').val('');
      });

         $('#_image_2').click(function(){
            $('#txtAmphurid').val('');
            $('#txtDistrictid').val('');
            $('#txtDistrict').val('');
          });
  });
</script>
<script type="text/javascript">
    $(function(){

        $('#_image_2').click(function(){
            var Citytxt = $('#txtProvinceid').val();
            if (Citytxt == '')
            {
                alert('กรุณากรอกข้อมูลจังหวัดให้ถูกต้อง');
                $('#txtProvince').focus();
                $('#txtProvince').val('');
            }   
        });
        $('#txtAmphur').change(function(){
            var Citytxt = $('#txtProvinceid').val();
            if (Citytxt == '')
            {
                alert('กรุณากรอกข้อมูลจังหวัดให้ถูกต้อง');
                $('#txtAmphur').focus();
                $('#txtProvince').val('');
                $('#txtAmphur').val('');
            }   
        });
        $('#_image_0').click(function(){
            var amphuretxt = $('#txtAmphurid').val();
            if (amphuretxt == '')
            {
                alert('กรุณากรอกข้อมูลอำเภอให้ถูกต้อง');
                $('#txtAmphur').focus();
                $('#txtAmphur').val('');
            }   
        });
        $('#txtDistrict').change(function(){
            var amphuretxt = $('#txtAmphurid').val();
            if (amphuretxt == '')
            {
                alert('กรุณากรอกข้อมูลอำเภอให้ถูกต้อง');
                $('#txtAmphur').focus();
                $('#txtDistrict').val('');
                $('#txtAmphur').val('');
            }   
        });





    });
</script>
<script type="text/javascript"> 
function make_autocom3(autoObj3,showObj3){
  var mkAutoObj3=autoObj3; 
  var mkSerValObj3=showObj3; 
  new Autocomplete(mkAutoObj3, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj3).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;
    var txtAmphurid = document.getElementById('txtAmphurid').value;  
    return "AutoComDistrict.php?amid="+txtAmphurid+"&p=" +(this.value); 

    }); 
} 
 make_autocom3("txtDistrict","txtDistrictid");
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
    return "AutoComProvine.php?p=" +(this.value); 

    }); 
} 
 make_autocom2("txtProvince","txtProvinceid");
</script>

<script type="text/javascript"> 
function make_autocom1(autoObj1,showObj1){
  var mkAutoObj1=autoObj1; 
  var mkSerValObj1=showObj1; 
  new Autocomplete(mkAutoObj1, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj1).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
    var txtProvinceid = document.getElementById('txtProvinceid').value;
    return "AutoComAmphur.php?pvid="+txtProvinceid+"&p=" +(this.value); 

    }); 
} 
 make_autocom1("txtAmphur","txtAmphurid");
</script>



    <br>
<table border="0" width="100%" align="center" class="table table-hover" id="table1">
    <thead>
        <tr align="center">
          <td width="5%"><b>ลำดับ</b></td>
          <td width="10%"><b>รหัสผู้ขาย</b></td>
          <td width="10%"><b>ชื่อผู้ขาย</b></td>
          <td width="30%"><b>ชื่อผู้ติดต่อ</b></td>
          <td width="15%"><b>เบอร์โทร</b></td>
          <td width="10%"><b>ข้อมูลเพิ่มเติม</b></td>
          <td width="10%"><b>แก้ไข</b></td>
          <td width="10%"><b>ลบ</b></td>
        </tr>
    </thead> 
        <?
           

            $sv="SELECT * FROM M_VENDOR ORDER BY vendor_code";
            


            $quV = mssql_query($sv) or die ("Error Query [".$sv."]");
            $p = 1;
            while($oV = mssql_fetch_array($quV))
            {
        ?>
        <?  
            $vcode = $oV["vendor_code"];
            $vname = $oV["vendor_name"]; 
            $vname= iconv("tis-620","UTF-8", $vname);    
            $fname = $oV["fname"];
            $fname= iconv("tis-620","UTF-8", $fname);
            $lname = $oV["lname"];
            $lname= iconv("tis-620","UTF-8", $lname);
            $mobile = $oV["mobile_no"];
            $fax = $oV["fax_no"];
            $email = $oV["email"];
            $vsta = $oV["active_status"];


            $homeid = $oV["homeid"];
            $homeid= iconv("tis-620","UTF-8", $homeid);
            $moono = $oV["moono"];
            $moono= iconv("tis-620","UTF-8", $moono);
            $district = $oV["district"];
            $district= iconv("tis-620","UTF-8", $district);
            $amphur = $oV["amphur"];
            $amphur= iconv("tis-620","UTF-8", $amphur);
            $province = $oV["province"];
            $province= iconv("tis-620","UTF-8", $province);      

        ?>
    <tbody>
        <tr align="center">
            <td><? echo $p; ?></td>
            <td><? echo $vcode; ?></td>
            <td><? echo $vname; ?></td>
            <td><? echo $fname." ".$lname; ?></td>
            <td><? echo $mobile; ?></td>
            <td><a id="<? echo "vdatabtn".+$p; ?>"  class="cursor"><span class="glyphicon glyphicon-search"></span></a></td>
            <td><a id="<? echo "veditbtn".+$p; ?>" class="cursor"><span class="glyphicon glyphicon-edit"></span></a></td>
            <td><a class="cursor" href="DeleteVender.php?vnum=<?=$oV["id"]; ?>" 
            onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
            <span class="glyphicon glyphicon-trash"></span></a></td>
        </tr>
    </tbody>
<script type="text/javascript">
    $(function  () {
    var vet = <? echo json_encode($p) ?>;
    $("#veditbtn"+vet).click(function(){
      $("#vedit"+vet).modal();
      }
      );});
</script>
<!-- ------------------------------------------------  Edit  ------------------------------------------------- -->
    <form action="EditVender.php?vnum=<?=$oV["id"]; ?>" name="frmEditVender" method="post">
    <div class="modal fade" id=<? echo "vedit".+$p; ?>>
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel"><p align="center">แก้ไขข้อมูลผู้ขาย</p></h4>
      </div>
      <div class="modal-body">
        <div class="Table">
          <div class="TableTH"><p align="right">รหัสผู้ขาย : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Vcode" class="fmmodal" readonly value="<? echo $vcode;?>"></p></div>
          <div class="TableTH"><p align="right">ชื่อผู้ขาย : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Vname" class="fmmodal" value="<? echo $vname;?>" required></p></div>
          <div class="TableTH"><p align="right">ชื่อผู้ติดต่อ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Vfname" class="fmmodal" value="<? echo $fname;?>" required></p></div>
          <div class="TableTH"><p align="right">นามสกุลผู้ติดต่อ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Vlname" class="fmmodal" value="<? echo $lname;?>" required></p></div>
          <div class="TableTH"><p align="right">เบอร์โทรศัพท์ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Vtel" class="fmmodal" value="<? echo $mobile;?>" required></p></div>
          <div class="TableTH"><p align="right">เบอร์แฟกซ์ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Vfax" class="fmmodal" value="<? echo $fax;?>" ></p></div>
          <div class="TableTH"><p align="right">อีเมลล์ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Vmail" class="fmmodal" value="<? echo $email;?>" ></p></div>
          <div class="TableTH"><p align="right">ที่อยู่เลขที่ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="Homeid" class="fmmodal" value="<? echo $homeid;?>"></p></div>
          <div class="TableTH"><p align="right">หมู่ : </p></div>
          <div class="TableTD"><p align="left"><input type="number" name="Moono" class="fmmodal" value="<? echo $moono;?>"></p></div>
          <div class="TableTH"><p align="right">แขวง/ตำบล : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="district" class="fmmodal" value="<? echo $district;?>"></p></div>
          <div class="TableTH"><p align="right">เขต/อำเภอ : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="amphur" class="fmmodal" value="<? echo $amphur;?>"></p></div>
          <div class="TableTH"><p align="right">จังหวัด : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="province" class="fmmodal" value="<? echo $province;?>"></p></div>
          <div class="TableTH"><p align="right">ใช้งาน : </p></div>
          <div class="TableTD"><p align="left"><input type="checkbox" name="VDsta" Value="Y" checked></p></div>
      </div>
      </div>
      <div align="center">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>
<!-- ------------------------------------------------  End Edit  ------------------------------------------------- -->
<script type="text/javascript">
    $(function  () {
    var vdb = <? echo json_encode($p) ?>;
    $("#vdatabtn"+vdb).click(function(){
      $("#vdata"+vdb).modal();
      }
      );});
</script>
<!-- -------------------------------------------  Show Vender Data  --------------------------------------------- -->
    <div class="modal fade" id="<? echo "vdata".+$p; ?>" tabindex="-1" role="dialog" aria-labelledby="fee-details-label" aria-hidden="true">
    <div class="modal-dialog viewdata">
    <div class="modal-content viewdata2">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel"><p align="center">ข้อมูลผู้ขาย</p></h4>
      </div>
      <div class="modal-body">

      <div class="Table">
          <div class="TableTH"><p align="right">รหัสผู้ขาย : </p></div>
          <div class="TableTD"><p align="left"><? echo "<font color=\"blue\">$vcode </font>"?></p></div>
          <div class="TableTH"><p align="right">ชื่อผู้ขาย : </p></div>
          <div class="TableTD"><p align="left"><? echo "<font color=\"blue\">$vname </font>"?></p></div>
          <div class="TableTH"><p align="right">ชื่อผู้ติดต่อ : </p></div>
          <div class="TableTD"><p align="left"><? echo "<font color=\"blue\">$fname  $lname</font>"?></p></div>
          <div class="TableTH"><p align="right">เบอร์โทรศัพท์ : </p></div>
          <div class="TableTD"><p align="left"><? echo "<font color=\"blue\">$mobile </font>"?></p></div>
          <div class="TableTH"><p align="right">เบอร์แฟกซ์ : </p></div>
          <div class="TableTD"><p align="left"><? echo "<font color=\"blue\">$fax </font>"?></p></div>
          <div class="TableTH"><p align="right">อีเมลล์ : </p></div>
          <div class="TableTD"><p align="left"><? echo "<font color=\"blue\">$email </font>"?></p></div>
          <div class="TableTH"><p align="right">ที่อยู่ : </p></div>
          <div class="TableTD"><p align="left"><? echo "<font color=\"blue\"> เลขที่ ".$homeid." หมู่ ".$moono." แขวง/ตำบล ".$district." เขต/อำเภอ ".$amphur." จังหวัด ".$province." </font>"?></p></div>
      </div>

      </div>
    </div>  
    </div>
    </div>
<!-- -------------------------------------------  END Vender Data  --------------------------------------------- -->
    

 <?
        $p=$p+1;}
    ?>
</table>
</div>

<!-- ----------------------------------------------------------------End Page 4 ------------------------------------------------- -->



    <!-- ---------------------------------------Stsrt Page 5 --------------------------------- -->
<div class="tab-pane active" id="Whouse">
 <form action="AddWs.php" method="post" >
   <table border="0" width="100%" align="center" >
        <tr>

    <? 


        $sql5 = "SELECT 'WS' + RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) From (                      
                SELECT Replace(isnull(max(RIGHT(ws_code,3)),0),'#','')+1 as a FROM M_WAREHOUSE) a";

        $qsql5 = mssql_query($sql5) or die ("Error Query [".$sql5."]");
        while($OBsql5 = mssql_fetch_array($qsql5))
            {
                $wscode = $OBsql5[0];
                #echo $vendorcode;
            }
    ?>
            <td align="right" width="45%">รหัสคลัง :</td>
            <td align="left" width="55%"><input type="text" name="txtWScode" class="fm1" readonly value="<?echo $wscode?>"></td>
        </tr>   
        <tr>
            <td align="right" width="45%">ชื่อคลัง :</td>
            <td align="left" width="55%"><input type="text" name="txtWSname" class="fm2" required></td>
        </tr>
        <tr>
            <td align="right" width="45%">หมายเหตุ :</td>
            <td align="left" width="55%">
            <select class="ddls" name="optRemark" required>

      <option value="<? echo $rm3; ?>"><? echo $rm3; ?></option>

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
      </select>
            </td>
        </tr>
        <tr>
            <td align="right" width="45%">ใช้งาน :</td>
            <td align="left" width="55%">&nbsp&nbsp<input type="checkbox" class="ch1" value="Y" name="WScheck" checked></td>
        </tr>
        <tr>
            <td align="right" width="45%"><input type="submit" value="ตกลง" class="btn btn-primary"></td>
            <td align="left" width="55%"><input type="reset" value="เคลียร์" class="btn btn-primary"></td>
        </tr>
    </table>
    </form>
    <br>

<table border="0" width="100%" align="center" class="table table-hover">
        <thead>
        <tr align="center">
          <td width="10%"><b>ลำดับ</b></td>
          <td width="20%"><b>รหัสคลัง</b></td>
          <td width="30%"><b>ชื่อคลัง</b></td>
          <td width="20%"><b>หมายเหตุ</b></td>
          <td width="10%"><b>แก้ไข</b></td>
          <td width="10%"><b>ลบ</b></td>
        </tr>
      </thead>

    <?
        $sqlWs = "SELECT *,w.id as wid FROM M_WAREHOUSE w
                  left join M_REMARK r on r.id=w.remark_id 
                  ORDER BY ws_code";
        $objWs = mssql_query($sqlWs) or die ("Error Query [".$sqlWs."]");
        $Ws=1;
        while($ResultWs = mssql_fetch_array($objWs))
        {
    ?>
    <? 
        $wsid = $ResultWs["wid"];
        $wscode = $ResultWs["ws_code"];
        $wsname = $ResultWs["ws_name"];
        $wsname= iconv("tis-620","UTF-8", $wsname);
        $wsremark = $ResultWs["remark_desc"];
        $wsremark= iconv("tis-620","UTF-8", $wsremark);
    ?>
    <script type="text/javascript">
    $(function  () {
    var j = <? echo json_encode($Ws) ?>;
    $("#Wsu"+j).click(function(){
      $("#Wsn"+j).modal();
      }
      );});
    </script>
    <tbody>
        <tr align="center">
            <td><? echo $Ws; ?></td>
            <td><? echo $wscode; ?></td>
            <td><? echo $wsname; ?></td>
            <td><? echo $wsremark; ?></td>
            <td><a class="cursor" id=<? echo "Wsu".+$Ws; ?>><span class="glyphicon glyphicon-edit"></span></a></td>
            <td><a class="cursor" href="DeleteWs.php?Wsnum=<?=$wsid?>" onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
            <span class="glyphicon glyphicon-trash"></span></a></td>
        </tr>
    </tbody>
 <form action="EditWs.php?Wsnum=<?=$wsid?>" name="frmEditType" method="post">
    <div class="modal fade" id=<? echo "Wsn".+$Ws; ?>>
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel">แก้ไขข้อมูลคลังจัดเก็บ</h4>
      </div>
      <div class="modal-body">
        <div class="Table">
          <div class="TableTH"><p align="right">รหัสคลัง : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="WScode" class="fmmodal" readonly value="<?=$ResultWs["ws_code"];?>"></p></div>
          <div class="TableTH"><p align="right">ชื่อคลัง : </p></div>
          <div class="TableTD"><p align="left"><input type="text" name="WSname" class="fmmodal" value="<? echo $wsname; ?>" required></p></div>
          <div class="TableTH"><p align="right">หมายเหตุ : </p></div>
          
          <div class="TableTD"><p align="left">



          <select class="ddls" name="optRemarkEdit" required>

      <option value="<? echo $rm3; ?>"><? echo $rm3; ?></option>

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
      </select>






          </p></div>
          




          <div class="TableTH"><p align="right">ใช้งาน : </p></div>
          <div class="TableTD"><p align="left"><input type="checkbox" name="WScheck2" Value="Y" checked></p></div>
      </div>
      </div>
      <div align="center">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>

    <?
        $Ws=$Ws+1;}
    ?>


<?
        mssql_close($objConnect);
    ?>


</table>
    </div>

    <!-- ---------------------------------------End Page 5 --------------------------------- -->





  </div>
  </body>
  </html>
