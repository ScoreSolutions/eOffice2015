<?php

    session_start();
    @ini_set('display_errors', '0');
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
    $re_code=$_REQUEST['Rcode'];
    $re_code= iconv("UTF-8","tis-620", $re_code);  
    $re_desc=$_REQUEST['Rdesc'];
    $re_desc= iconv("UTF-8","tis-620", $re_desc);
    $re_status=$_REQUEST['Rstatus'];


    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$re_desc")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=5';";
        echo "</script>";
    }
    else
    {
        $str = "UPDATE M_REMARK SET UpdateBy='$name',UpdateDate=getdate(),remark_code='$re_code',
        remark_desc='$re_desc',active_status='$re_status'
        WHERE id = '".$_GET["rnum"]."'";
        $objQuery = mssql_query($str);
        if($objQuery)
        {
                echo "<script>";
                echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=standardUnit&Type=5';";
                echo "</script>";
        }
        else
        {
                echo "<script>";
                echo "alert('ข้อมูล ".$re_desc." ไม่เหมาะสม');";
                echo "window.location.href='Home.php?page=standardUnit&Type=5';";
                echo "</script>";
        }
    }


mssql_close($objConnect);
?>
</body>
</html>