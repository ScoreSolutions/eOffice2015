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
<html>
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<?
    $ws_code=$_REQUEST['WScode'];
    $ws_code= iconv("UTF-8","tis-620", $ws_code);  
    $ws_name=$_REQUEST['WSname'];
    $ws_name= iconv("UTF-8","tis-620", $ws_name);
    $ws_status=$_REQUEST['WScheck2'];
    $ws_remark=$_REQUEST['optRemarkEdit'];

    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$ws_name")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=4';";
        echo "</script>";
    }
    else
    {
        $str = "UPDATE M_WAREHOUSE SET UpdateBy='$name',UpdateDate=getdate(),ws_code='$ws_code',
        ws_name='$ws_name',active_status='$ws_status',remark_id='$ws_remark'
        WHERE id = '".$_GET["Wsnum"]."'";
        $objQuery = mssql_query($str);
        if($objQuery)
        {
                echo "<script>";
                echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=standardUnit&Type=4';";
                echo "</script>";
        }
        else
        {
                echo "<script>";
                echo "alert('พบข้อผิดพลาดในการแก้ไข');";
                echo "window.location.href='Home.php?page=standardUnit&Type=4';";
                echo "</script>";
        }
    }


mssql_close($objConnect);
?>
</body>
</html>