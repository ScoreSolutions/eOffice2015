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

    $unit_code=$_REQUEST['Ucode'];
    $unit_code= iconv("UTF-8","tis-620", $unit_code);  
    $unit_name=$_REQUEST['Uname'];
    $unit_name= iconv("UTF-8","tis-620", $unit_name);
    $unit_status=$_REQUEST['ustatus'];


    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$unit_name")) {
        echo "<script>";
        echo "alert('กรุณากรอกเฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=9';";
        echo "</script>";
    }

    else
    {
                    $str = "UPDATE M_UNIT SET UpdateBy='$name',UpdateDate=getdate(),unit_code='$unit_code',
                       unit_name='$unit_name',active_status='$unit_status'
                       WHERE id = '".$_GET["unum"]."'";

            $objQuery = mssql_query($str);
            if($objQuery)
            {
                    echo "<script>";
                    echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                    echo "window.location.href='Home.php?page=standardUnit&Type=9';";
                    echo "</script>";
            }
            else
            {
                    echo "<script>";
                    echo "alert('ข้อมูล ".$unit_name." ไม่เหมาะสม');";
                    echo "window.location.href='Home.php?page=standardUnit&Type=9';";
                    echo "</script>";
            }
    }


mssql_close($objConnect);
?>
</body>
</html>