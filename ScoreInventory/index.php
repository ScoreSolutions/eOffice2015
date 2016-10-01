<?php   
    session_start();
    include_once("connect.php");
    $ses_userid =$_SESSION['ses_userid'];
    $ses_username = $_SESSION['ses_username'];
    if($ses_userid <> session_id() or  $ses_username =="")
    {
        
    }    
    else 
    {
        echo "<script>";
        echo "window.location.href='Home.php?page=Homes';";
        echo "</script>";

    };
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>เข้าสู่ระบบ</title>
<link rel="stylesheet" href="css/font-awesome.min.css">
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
<script src="js/bootstrap.min.js"></script>
<script src="js/bootstrap.js"></script>
<script src="js/jquery-1.11.1.min.js"></script>
</head>
<body class="bodylogin">
	<div class="container-fluid">
    	<div class="row-fluid">
        <div class="span4"></div>
			<div class="span5">
        	<div class="container-fluid login">
            		<div class="page-header">
					<h2><center><p class="badge-warning">Inventory System</p></center></h2>
					<div id="res"></div>
					</div>
            
                    <form method="post" name="flogin" id="flogin" action="checklogin.php">
                    <table border="0" width="100%" align="center">
                        <tr>
                            <td align="right" width="30%"><img src="img/login/user_icon.png" style="width:30px; height:30px;" /></td>
                            <td><input type="text"  name="txtUser" class="fm4" placeholder="Username"  required/></td>
                        </tr>
                        <tr>

                            <td align="right" width="30%"><img src="img/login/pass_icon.png" style="width:30px; height:30px;" /></td>
                            <td><input type="Password"  name="txtPass" class="fm4" placeholder="Password"  required/></td>
                        </tr>
                    </table>
                    <table border="0" width="100%">
                    <tr>
                        <td align="center"><input type="submit" value="ตกลง" class="btn btn-success" role="button" /></td>
                    </tr>
                    
                    </table>
                    </form>
				</div>			
            </div>
        </div>   
    </div>
</body>
</html>

