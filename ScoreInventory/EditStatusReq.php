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

	$reqno=$_GET['reqno'];

$str = "UPDATE TS_REQUEST SET UpdateBy='$name',UpdateDate=getdate(),active_status='S'
		   WHERE req_no = '$reqno'";

$objQuery = mssql_query($str);
if($objQuery)
{
		/*echo "Error Save [".$str."]";*/
  		echo "<script>";
        echo "alert('บันทึกการจ่ายออกเสร็จสิ้น');";
        echo "window.location.href='Home.php?page=Request&Type=3';";
        echo "</script>";
}
else
{
  		echo "<script>";
        echo "alert('พบข้อผิดพลาดในการบันทึกการจ่ายออก');";
        echo "window.location.href='Home.php?page=Request&Type=3';";
        echo "</script>";
}
mssql_close($objConnect);
?>
</body>
</html>