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
$strSQL = "DELETE FROM M_USER ";
$strSQL .="WHERE id = '".$_GET["gnum"]."' ";



$objQuery = mssql_query($strSQL);
if($objQuery)
{
		echo "<script>";
        echo "alert('การลบข้อมูลเสร็จสิ้น');";
        echo "window.location.href='Home.php?page=UserGroup&Type=1';";
        echo "</script>";
}
else
{
		echo "<script>";
        echo "alert('พบข้อผิดพลาดในการลบข้อมูล');";
        echo "window.location.href='Home.php?page=UserGroup&Type=1';";
        echo "</script>";
}
mssql_close($objConnect);
?>
</body>
</html>