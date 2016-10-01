<?session_start();?>

<!DOCTYPE html>
<html>
<head>
	<title></title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
</body>
</html>

<?

	
	include_once("connect.php");
	
	$user=strtolower($_REQUEST['txtUser']);
  	$pass=$_REQUEST['txtPass'];
 	$sql= "SELECT * FROM M_USER WHERE username = '$user' AND password = '$pass'";
	$result = mssql_query($sql);
	$num = mssql_num_rows($result);
			if($num<=0){
						echo "<script>";
						echo "alert('โปรดกรอกชื่อและรหัสผ่านให้ครบถ้วนและถูกต้อง');";
				    	echo "window.location.href='index.php';";
				    	echo "</script>";
			}
			else {
					$sql2 = "SELECT * FROM M_USER WHERE username = '$user' AND login_status = 0";
					$result2 = mssql_query($sql2);
					$num2 = mssql_num_rows($result2);
					if($num2 > 0)
					{
						$_SESSION[ses_userid] = session_id();
						$_SESSION[ses_username] = $user;

						$sqlUpdate = "UPDATE M_USER SET login_status='1' WHERE username = '$user' ";
						$rs = mssql_query($sqlUpdate);
						if($rs)
						{
						echo "<script>";
						echo "alert('ยินดีต้อนรับเข้าสู่ระบบ');";
				    	echo "window.location='Home.php?page=Homes';";
				    	echo "</script>";
				    	}
				    	else
				    	{
				    		echo "<script>";
							echo "alert('ยินดีต้อนรับเข้าสู่ระบบ');";
					    	echo "window.location='Home.php?page=Homes';";
					    	echo "</script>";
				    	}
						exit(); 
					}
					else{
				    		echo "<script>";
							echo "alert('มีผู้อื่นให้งานชื่อผู้ใช้ ".$user." นี้อยู่ในขณะนี้');";
							echo "window.location.href='index.php';";
					    	echo "</script>";
					}
			}
	mssql_close();
?>



