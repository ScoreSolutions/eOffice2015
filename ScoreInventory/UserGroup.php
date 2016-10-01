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
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<title>จัดการข้อมูลผู้ใช้</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />




<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.11.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>  
<script type="text/javascript" src="js/bootbox.min.js"></script>





<script type="text/javascript" src="js/jconfirmaction.jquery.js"></script>
<script type="text/javascript">  
    function displayoff()
    {
        var strPhp = <?php $TT = $_GET['Type']; echo json_encode($TT); ?>;
        if(strPhp=="1")
        {
            document.getElementById('Group').style.display = 'none';

        }
        else
        {
             document.getElementById('g1').click();
        }  
    }
    function showGroup()
    {
        document.getElementById('Group').style.display = '';
    }
    function showUser()
    {
        document.getElementById('User').style.display = '';
    }

</script>
</head>
<body onload="displayoff(); tbsu();">
<div>
		<ul class="nav nav-tabs con">
            <li class="active">
                <a href="#User" data-toggle="tab" onclick="showUser();"><b>ผู้ใช้</b></a>
            </li>
            <li>
                <a id="g1" href="#Group" data-toggle="tab" onclick="showGroup();"><b>กลุ่มของผู้ใช้</b></a>
            </li>
        </ul>
 </div>
 <!-- -------------Start Design Content------------ -->
<div class="tab-content content">

<!--------------------------------------------Srart Sub1-------------------------------------------------------------------->

 <div class="tab-pane active" id="User">
 <form id="User" name="User" action="AddUser.php" method="post">
    <table border="0" width="100%" align="center" >
        <tr>
            <td align="right" width="20%"></td>
            <td align="left" width="25%"><h4>ข้อมูลการเข้าสู่ระบบ</h4></td>  
            <td align="center" width="10%"></td>
            <td align="left" width="45%"><h4>ข้อมูลทั่วไป</h4></td>
        </tr>
        <tr>
            <td align="right" width="20%">ชื่อผู้ใช้ * :</td>
            <td align="left" width="25%"><input type="text" class="fm3" name="txtUser" required></td>
            <td align="right" width="10%">ชื่อ * :</td>
            <td align="left" width="45%"><input type="text" class="fm4" name="txtFname" required></td>  

        </tr>   
        <tr>
            <td align="right" width="20%">รหัสผ่าน * :</td>
            <td align="right" width="25%"><input type="Password" class="fm3" name="txtPass" id="txtPass" required></td>  
            <td align="right" width="10%">นามสกุล * :</td>
            <td align="left" width="45%"><input type="text" class="fm4" name="txtLname" required></td>    
        </tr>
        <tr>
            <td align="right" width="20%">ยืนยันรหัสผ่าน * :</td>
            <td align="right" width="25%"><input type="Password" class="fm3"  id="confirm_password" name="confirm_password" ></td>  
            <td align="right" width="10%">กลุ่ม * :</td>
            <td align="left" width="45%">
            <select class="ddls" name="optGroup" required>
            <option value="">เลือกกลุ่ม</option>
            <?
                $strSQL = "SELECT id,group_desc from M_GROUP";
                $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
                while($objResult = mssql_fetch_array($objQuery))
                {
            ?>
            <? 
                $id = $objResult["id"];
                $gdesc = $objResult["group_desc"];
                $gdesc= iconv("tis-620","UTF-8", $gdesc);?>


                <option value="<?php echo $id; ?>"><? echo $gdesc; ?></option>
            
            <?
                }
            ?>

            </select></td> 
        </tr> 
        <tr>
            <td align="center" width="25%"></td>
            <td align="center" width="25%">ใช้งาน :&nbsp&nbsp<input type="checkbox" class="ch1" value="Y" name="chxStatus2" checked></td> 
            <td align="right" width="10%">อีเมลล์ * :</td>
            <td align="left" width="45%"><input type="email" class="fm4" name="txtEmail"  required></td>
        </tr>
        <tr>
            <td align="right" width="20%"></td>
            <td align="center" width="25%">
            
            &nbsp<input type="submit" value="ตกลง" class="btn btn-primary">
            &nbsp<input type="reset" value="เคลียร์" class="btn btn-primary"></td>
            <td align="right" width="10%">เบอร์โทรศัพท์ * :</td>
            <td align="left" width="45%"><input type="text" class="fm4" name="txtTel" required></td>
        </tr>        
</table>
</form>




<br>
    <table border="0" width="100%" align="center" class="table table-hover" id="TableUser">
    <thead>
        <tr align="center">
           <td width="5%"><b>ลำดับ</b></td>
           <td width="15%"><b>ชื่อผู้ใช้</b></td>
           <td width="20%"><b>ชื่อ - นามสกุล</b></td>
           <td width="10%"><b>กลุ่ม</b></td>
           <td width="20%"><b>อีเมลล์</b></td>
           <td width="10%"><b>เบอร์โทรศัพท์</b></td>
           <td width="10%"><b>แก้ไข</b></td>
           <td width="10%"><b>ลบ</b></td>
        </tr>
    </thead>




        <?
            $strSQL = "SELECT m.id,m.username,m.password,m.first_name,m.last_name,m.mobile_no,m.email,g.group_desc,m.group_id
            from M_USER as m
            inner join M_GROUP g on g.id=m.group_id";
            $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
            $j = 1;
            while($objResult = mssql_fetch_array($objQuery))
            {

        ?>
        <? 
            $id = $objResult["id"];  
            $user = $objResult["username"];
            $password = $objResult["password"];
            $password= iconv("tis-620","UTF-8", $password);

            $fname = $objResult["first_name"];
            $fname= iconv("tis-620","UTF-8", $fname);
            $lname = $objResult["last_name"];
            $lname= iconv("tis-620","UTF-8", $lname);
            $mobile = $objResult["mobile_no"];
            $email = $objResult["email"];
            $gid = $objResult["group_id"];
            $gdesc = $objResult["group_desc"];
            $gdesc= iconv("tis-620","UTF-8", $gdesc);
        ?>
    <script type="text/javascript">
        $(function  () {
        var k = <? echo json_encode($j) ?>;
        $("#u"+k).click(function(){

        $("#um"+k).modal();
        }
        );});
    </script>
    <tbody>
        <tr align="center">
            <td><? echo $j; ?></td>
            <td><? echo $user; ?></td>
            <td><? echo $fname," ",$lname; ?></td>
            <td><? echo $gdesc; ?></td>
            <td><? echo $email; ?></td>
            <td><? echo $mobile; ?></td>
            <td><a class="cursor" id=<? echo "u".+$j; ?>><span class="glyphicon glyphicon-edit"></a></td>
            <td><a class="cursor" href="DeleteUser.php?gnum=<?=$objResult["id"]; ?>" onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')"><span class="glyphicon glyphicon-trash"></span></a></td>
        </tr>
    </tbody>
           
<form action="EditUser.php?gnum=<?=$objResult["id"];?>" name="frmEditUser" method="post">
    <div class="modal fade" id=<? echo "um".+$j; ?>>
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel"><p align="center">แก้ไขข้อมูลผู้ใช้</p></h4>
      </div>
      <div class="modal-body">
        <div class="Table">
            <div class="TableTH"><p align="right">ชื่อผู้ใช้ : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="user" class="fmmodal" value="<?=$objResult["username"];?>" required></p></div>
            <div class="TableTH"><p align="right">รหัสผ่าน : </p></div>
            <div class="TableTD"><p align="left"><input type="password" name="pass" class="fmmodal" value="<?=$password?>" required></p></div>
            <div class="TableTH"><p align="right">ชื่อ : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="fname" class="fmmodal" value="<? echo $fname; ?>" required></p></div>
            <div class="TableTH"><p align="right">นามสกุล : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="lname" class="fmmodal" value="<? echo $lname; ?>" required></p></div>
            <div class="TableTH"><p align="right">กลุ่ม : </p></div>
            <div class="TableTD"><p align="left">
            <select class="fmmodal" name="selectgroup" style="width:152px;height:25px;">
            <option value="<?php echo $gid; ?>"><? echo $gdesc; ?></option>
            <?
                $sqlselect = "SELECT id,group_desc from M_GROUP";
                $objSelect = mssql_query($sqlselect) or die ("Error Query [".$strSQL."]");
                while($resultSelect = mssql_fetch_array($objSelect))
                {
            ?>
            <? 
                $id = $resultSelect["id"];
                $gdesc = $resultSelect["group_desc"];
                $gdesc= iconv("tis-620","UTF-8", $gdesc);
            ?>
                <option value="<?php echo $id; ?>"><? echo $gdesc; ?></option>
            
            <?
                }
            ?>

            </select></p></div>
            <div class="TableTH"><p align="right">อีเมลล์ : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="mail" class="fmmodal" value="<? echo $email; ?>"></p></div>
            <div class="TableTH"><p align="right">เบอร์โทรศัพท์ : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="tel" class="fmmodal" value="<? echo $mobile; ?>"></p></div>
            <div class="TableTH"><p align="right"></p></div>
            <div class="TableTD"><p align="left"></p></div>
            <div class="TableTH"><p align="right">ใช้งาน : </p></div>
            <div class="TableTD"><p align="left"><input type="checkbox" name="ustatus" Value="Y" checked></p></div>
            
        </div> 
        <p align="right"><button type="submit" class="btn btn-primary">บันทึก</button></p> 
      </div>
       
    </div>  
    </div>
    </div>
</form>
<?
    $j=$j+1;}
?>
</table>
</div>

    <?
        mssql_close($objConnect);
    ?>
<!-------------------------------------------------End Sub1-------------------------------------------------------------- -->

<div class="tab-pane active" id="Group">
 <form action="AddGroup.php" method="post" id="form1" >
    <table border="0" width="100%" align="center" >
        <tr>
            <td align="right" width="45%">รหัสกลุ่ม :</td>
            <td align="left" width="55%"><input type="text" class="fm1" name="txtGcode" required></td>
        </tr>   
        <tr>
            <td align="right" width="45%">ชื่อกลุ่ม :</td>
            <td align="left" width="55%"><input type="text" class="fm2" name="txtGdesc" required></td>
        </tr>
        <tr>
            <td align="right" width="45%">ใช้งาน :</td>
            <td align="left" width="55%">&nbsp&nbsp<input type="checkbox" class="ch1" value="Y" name="chxGStatus" checked></td>
        </tr>
        <tr>
            <td align="right" width="45%"><input type="submit" value="ตกลง" class="btn btn-primary"></td>
            <td align="left" width="55%"><input type="reset" value="เคลียร์" class="btn btn-primary"></td>
        </tr>
    </table>
    </form><br>
<table border="0" width="100%" align="center" class="table table-hover">
        <thead>
        <tr align="center">
          <td width="10%"><b>ลำดับ</b></td>
          <td width="30%"><b>รหัสกลุ่ม</b></td>
          <td width="40%"><b>ชื่อกลุ่ม</b></td>
          <td width="10%"><b>แก้ไข</b></td>
          <td width="10%"><b>ลบ</b></td>
        </tr>
      </thead>
    <?
        $strSQL = "SELECT * FROM M_GROUP order by group_code";
        $objQuery = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
        $i=1;
        while($objResult = mssql_fetch_array($objQuery))
        {
    ?>
    <? 
        $id = $objResult["id"];
        $gcode = $objResult["group_code"];
        $gdesc = $objResult["group_desc"];
        $gid = $objResult["id"];
        $gdesc= iconv("tis-620","UTF-8", $gdesc);
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
            <td><? echo $gcode; ?></td>
            <td><? echo $gdesc; ?></td>
            <td><a class="cursor" id=<? echo $i; ?>><span class="glyphicon glyphicon-edit"></span></a></td>
            <td>
            <a class="cursor" href="DeleteGroup.php?gnum=<?=$objResult["id"]; ?>" onclick="return confirm('กรุณายืนยันการลบอีกครั้ง !!!')">
            <span class="glyphicon glyphicon-trash"></span>
            </a></td>
        </tr>
    </tbody>

    <!------- Modal ของการแก้ไขข้อมูลกลุ่ม ------>
    <form action="EditGroup.php?gnum=<?=$objResult["id"]; ?>" name="frmEditGroup" method="post">
    <div class="modal fade" id=<? echo "m".+$i; ?>>
    <div class="modal-dialog">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel"><p align="center">แก้ไขข้อมูลกลุ่ม</p></h4>
      </div>
      <div class="modal-body">
        <div class="Table">
            <div class="TableTH"><p align="right">รหัสกลุ่ม : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="txtG" class="fmmodal" value="<?=$objResult["group_code"];?>" required></p></div>
            <div class="TableTH"><p align="right">ชื่อกลุ่ม : </p></div>
            <div class="TableTD"><p align="left"><input type="text" name="txtD" class="fmmodal" value="<? echo $gdesc; ?>" required></p></div>
            <div class="TableTH"><p align="right">ใช้งาน : </p></div>
            <div class="TableTD"><p align="left"><input type="checkbox" name="sta" Value="Y" checked></p></div>
        </div>
      </div>
      <div align="right">    
        <button type="submit" class="btn btn-primary">บันทึก</button>
      </div>
    </div>  
    </div>
    </div>
    </form>
    <!------- Modal ของการแก้ไขข้อมูลกลุ่ม ------>


    <?
        $i=$i+1;}
    ?>


</table>
</div>
    <?
        mssql_close($objConnect);
    ?>

</div>
</body>
</html>