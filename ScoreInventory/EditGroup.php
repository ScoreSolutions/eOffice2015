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

	$group_code=$_REQUEST['txtG'];
    $group_code= iconv("UTF-8","tis-620", $group_code);  
    $group_desc=$_REQUEST['txtD'];
    $group_desc= iconv("UTF-8","tis-620", $group_desc);
    $group_status=$_REQUEST['sta'];
    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$group_desc")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=2';";
        echo "</script>";
    }
    else
    {
        $str = "UPDATE M_GROUP SET UpdateBy='$name',UpdateDate=getdate(),group_code='$group_code',
           group_desc='$group_desc',active_status='$group_status'
           WHERE id = '".$_GET["gnum"]."'";

        $objQuery = mssql_query($str);
        if($objQuery)
        {
                /*echo "Error Save [".$str."]";*/
                echo "<script>";
                echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=UserGroup&Type=2';";
                echo "</script>";
        }
        else
        {
                echo "<script>";
                echo "alert('พบข้อผิดพลาดในการแก้ไข');";
                echo "window.location.href='Home.php?page=UserGroup&Type=2';";
                echo "</script>";
        }
    }

mssql_close($objConnect);
?>
</body>
</html>