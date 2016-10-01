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

    $pd_code   = $_REQUEST['PDcode'];
    $pd_name   = $_REQUEST['PDname'];
    $pd_name  = iconv("UTF-8","tis-620", $pd_name);  
    $pd_desc  = $_REQUEST['PDdesc'];
    $pd_desc  = iconv("UTF-8","tis-620", $pd_desc);
    $uid = $_REQUEST['sUnit'];
    $tid = $_REQUEST['sType'];
    $vid = $_REQUEST['sVender'];
    $pac = $_REQUEST['PDsta'];
    $PDmin = $_REQUEST['PDmini'];
    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$pd_name")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=2';";
        echo "</script>";
    }
    else if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$pd_desc")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=2';";
        echo "</script>";
    }
    else
    {
        $str = "UPDATE M_PRODUCT SET UpdateBy='$name',UpdateDate=getdate(),product_code='$pd_code',
        product_name='$pd_name',product_desc='$pd_desc',minimum='$PDmin',active_status='$pac',
        unit_id='$uid',type_id='$tid',vendor_id='$vid'
        WHERE id = '".$_GET["pnum"]."'";

        $objQuery = mssql_query($str);
        if($objQuery)
        {
                echo "<script>";
                echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=standardUnit&Type=2';";
                echo "</script>";
        }
        else
        {
                echo "<script>";
                echo "alert('พบข้อผิดพลาดในการแก้ไข');";
                echo "window.location.href='Home.php?page=standardUnit&Type=2';";
                echo "</script>";
        }
    }

mssql_close($objConnect);
?>
</body>
</html>