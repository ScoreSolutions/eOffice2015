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
    
    }

    ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>เพิ่มข้อมูล Product</title>
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
</head>
<body>

<?php

    
    $pcode=strtolower($_REQUEST['txtPcode']);
    $pname=$_REQUEST['txtPname'];
    $pname=iconv("UTF-8","tis-620", $pname);
    $pdesc=$_REQUEST['txtPdesc'];
    $pdesc=iconv("UTF-8","tis-620", $pdesc);

    $PDmin=$_REQUEST['PDmin'];
    $pactive=$_REQUEST['Psta'];  
    
    $uid=$_REQUEST['optUid'];
    $tid=$_REQUEST['optTid'];
    $vid=$_REQUEST['optVid'];

    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$pname")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=2';";
        echo "</script>";
    }
    else if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$pdesc")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=2';";
        echo "</script>";
    }
    else
    {
        $sql = "INSERT INTO M_PRODUCT (CreateBy,CreateDate,product_code,product_name,product_desc,minimum,active_status,unit_id,type_id,vendor_id) 
            VALUES ('$name',GETDATE(),'$pcode','$pname','$pdesc','$PDmin','$pactive','$uid','$tid','$vid')";
    
        $result = mssql_query($sql);

        if ($result) {
          echo "<script>";
          echo "alert('เพิ่มข้อมูลอุปกรณ์เสร็จสิ้น');";
          echo "window.location.href='Home.php?page=standardUnit&Type=2';";
          echo "</script>";
        }

        else
        {
          echo "<script>";
          echo "alert('เกิดข้อผิดพลาดในการเพิ่มข้อมูล');";
          echo "window.location.href='Home.php?page=standardUnit&Type=2';";
          echo "</script>";
        }
    }
    

    mssql_close($objConnect);
?>

</body>
</html>