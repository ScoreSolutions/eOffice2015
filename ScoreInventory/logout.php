<?php
session_start();
?>
<html>
<head>
<title></title>
    <script src="_assets/js/jquery.js" type="text/javascript"></script>
    <script src="_assets/js/jquery.ui.draggable.js" type="text/javascript"></script>    
    <script src="_assets/js/jquery.alerts.js" type="text/javascript"></script>
    <link href="_assets/css/jquery.alerts.css" rel="stylesheet" type="text/css" media="screen" />  
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>

<?
include_once("connect.php");
unset ( $_SESSION['ses_userid'] );
unset ( $_SESSION['ses_username'] );
session_destroy();
		if(isset($_SESSION['ses_userid']))
		{
			
				echo "<script>";
		    	echo "window.location.href='index.php';";
		    	echo "alert('2');";
		    	echo "</script>";
		}

		else
		{

		$us = $_GET['user'];
				
		$sqlUpdate = "UPDATE M_USER SET login_status='0' WHERE username = '$us' ";
		$rs = mssql_query($sqlUpdate);
			if ($rs) {
				echo "<script>";
		    	echo "window.location.href='index.php';";
		    	echo "alert('ลงชื่ออกจากระบบเสร็จสิ้น');";
		    	echo "</script>";
			}
			else
			{
				echo "<script>";
		    	echo "window.location.href='index.php';";
		    	echo "alert('3');";
		    	echo "</script>";
			}
		
		}
?>
</body></html>