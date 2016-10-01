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
    $type_code=$_REQUEST['Tcode'];
    $type_code= iconv("UTF-8","tis-620", $type_code);  
    $type_name=$_REQUEST['Tname'];
    $type_name= iconv("UTF-8","tis-620", $type_name);
    $type_status=$_REQUEST['Tcheck2'];

        if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$type_name")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=1';";
        echo "</script>";
    }
    else
    {
        $str = "UPDATE M_TYPE SET UpdateBy='$name',UpdateDate=getdate(),type_code='$type_code',
        type_name='$type_name',active_status='$type_status'
        WHERE id = '".$_GET["tnum"]."'";



            $objQuery = mssql_query($str);
            if($objQuery)
            {
                    echo "<script>";
                    echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                    echo "window.location.href='Home.php?page=standardUnit&Type=1';";
                    echo "</script>";
            }
            else
            {
                    echo "<script>";
                    echo "alert('พบข้อผิดพลาดในการแก้ไข');";
                    echo "window.location.href='Home.php?page=standardUnit&Type=1';";
                    echo "</script>";
            }
    }


mssql_close($objConnect);
?>
</body>
</html>