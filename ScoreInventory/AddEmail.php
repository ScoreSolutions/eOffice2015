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
<title>เพิ่มข้อมูล Product Type</title>
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script type="text/javascript">



</script>
</head>
<body>

<?php
                    $name2=$name;
                    $ap=$_GET['ap'];
                    $cc=$_GET['cc'];
                    $t =$_GET['t'];
                    if($t == 'A')
                    {
                        $sql = "INSERT INTO M_APPOVE (CreateBy,CreateDate,appove_mail,appove_cc) 
                                VALUES ('$name2',GETDATE(),'$ap','$cc')";

                        $result = mssql_query($sql);
                        if ($result) {
                          echo "<script>";
                          echo "alert('ตั้งค่าอีเมล์เสร็จสิ้น');";
                          echo "window.location.href='Home.php?page=Request&Type=5';";
                          echo "</script>";
                        }
                        else
                        {
                          echo "<script>";
                          echo "alert('เกิดข้อผิดพลาดในการตั้งค่าอีเมลล์');";
                          echo "window.location.href='Home.php?page=Request&Type=5';";
                          echo "</script>";
                        }
                    }
                    else if($t == 'E')
                    {
                        $str = "UPDATE M_APPOVE SET UpdateBy='$name',UpdateDate=getdate(),appove_mail='$ap',
                                appove_cc='$cc' WHERE id = '".$_GET["id"]."'";
                        $objQuery = mssql_query($str);       

                        if ($objQuery) {
                          echo "<script>";
                          echo "alert('แก้ไขการตั้งค่าอีเมล์เสร็จสิ้น');";
                          echo "window.location.href='Home.php?page=Request&Type=5';";
                          echo "</script>";
                        }
                        else
                        {
                          echo "<script>";
                          echo "alert('เกิดข้อผิดพลาดในการตั้งค่าอีเมลล์');";
                          echo "window.location.href='Home.php?page=Request&Type=5';";
                          echo "</script>";
                        }
                    }

    mssql_close($objConnect);
?>

</body>
</html>