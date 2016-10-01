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
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
</head>
<body>

<?php

    
    $user=strtolower($_REQUEST['txtUser']);
    $pass=$_REQUEST['txtPass'];
    $fname=$_REQUEST['txtFname'];
    $fname= iconv("UTF-8","tis-620", $fname); 
     
    $lname=$_REQUEST['txtLname'];
    $lname= iconv("UTF-8","tis-620", $lname); 
    $email= $_REQUEST['txtEmail'];
    $tel=$_REQUEST['txtTel'];
    $active=$_REQUEST['chxStatus2'];
    $group=$_REQUEST['optGroup'];

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

            $str = "SELECT * from M_USER WHERE username = '$user'";
            $Qstr = mssql_query($str) or die("Error Query [".$str."]");
            $cr = mssql_fetch_object($Qstr);
            if($cr > 0) 
            {
                           echo "<script>";
                           echo "alert('มีชื่อผู้ใช้ ".$user." ในระบบแล้ว');";
                           echo "window.location.href='Home.php?page=UserGroup&Type=1';";
                           echo "</script>";
            }
            else
            {
                        $sql = "INSERT INTO M_USER (CreateBy,CreateDate,username,password,first_name,last_name,mobile_no,email,active_status,group_id,login_status) 
                                VALUES ('$name',GETDATE(),'$user','$pass','$fname','$lname','$tel','$email','$active','$group','0')";

                        $result = mssql_query($sql);

                        if ($result) {
                          echo "<script>";
                          echo "alert('เพิ่มข้อมูลผู้ใช้เสร็จสิ้น');";
                          echo "window.location.href='Home.php?page=UserGroup&Type=1';";
                          echo "</script>";
                        }

                        else
                        {
                          echo "<script>";
                          echo "alert('เกิดข้อผิดพลาดในการเพิ่ม้อมูล');";
                          echo "window.location.href='Home.php?page=UserGroup&Type=1';";
                          echo "</script>";
                        }
            }

    }




    mssql_close($objConnect);
?>

</body>
</html>