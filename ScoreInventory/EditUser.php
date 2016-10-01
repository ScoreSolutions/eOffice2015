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

    $user   = $_REQUEST['user'];
    $pass   = $_REQUEST['pass'];  
    $fname  = $_REQUEST['fname'];
    $fname  = iconv("UTF-8","tis-620", $fname);
    $lname  = $_REQUEST['lname'];
    $lname  = iconv("UTF-8","tis-620", $lname);
    $mobile = $_REQUEST['tel'];
    $email  = $_REQUEST['mail'];
    $gid  = $_REQUEST['selectgroup'];
    $usersta=$_REQUEST['usta'];

    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$fname")) {
        echo "<script>";
        echo "alert('กรุณากรอกหน่วย เฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=UserGroup&Type=1';";
        echo "</script>";
    }
    else if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$lname")) {
        echo "<script>";
        echo "alert('กรุณากรอกหน่วย เฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=UserGroup&Type=1';";
        echo "</script>";
    }
    else if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$user")) {
        echo "<script>";
        echo "alert('กรุณากรอกหน่วย เฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=UserGroup&Type=1';";
        echo "</script>";
    }
    else
    {
        $str = "UPDATE M_USER SET UpdateBy='$name',UpdateDate=getdate(),username='$user',password='$pass',first_name='$fname',
           last_name='$lname',mobile_no='$mobile',email='$email',active_status='$usersta',group_id='$gid'
           WHERE id = '".$_GET["gnum"]."'";


        $objQuery = mssql_query($str);
        if($objQuery)
        {
                echo "<script>";
                echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=UserGroup&Type=1';";
                echo "</script>";
        }
        else
        {
                echo "<script>";
                echo "alert('พบข้อผิดพลาดในการแก้ไข');";
                echo "window.location.href='Home.php?page=UserGroup&Type=1';";
                echo "</script>";
        }
    }


mssql_close($objConnect);
?>
</body>
</html>