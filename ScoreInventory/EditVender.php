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

    $v_code   = $_REQUEST['Vcode'];
    $v_name   = $_REQUEST['Vname'];
    $v_name  = iconv("UTF-8","tis-620", $v_name);  
    
    $v_fname  = $_REQUEST['Vfname'];
    $v_fname  = iconv("UTF-8","tis-620", $v_fname);
    
    $v_lname  = $_REQUEST['Vlname'];
    $v_lname  = iconv("UTF-8","tis-620", $v_lname);

    $homeid  = $_REQUEST['Homeid'];
    $homeid  = iconv("UTF-8","tis-620", $homeid);
    $moono  = $_REQUEST['Moono'];
    $moono  = iconv("UTF-8","tis-620", $moono);
    $district  = $_REQUEST['district'];
    $district  = iconv("UTF-8","tis-620", $district);
    $amphur  = $_REQUEST['amphur'];
    $amphur  = iconv("UTF-8","tis-620", $amphur);
    $province  = $_REQUEST['province'];
    $province  = iconv("UTF-8","tis-620", $province);
    
    $v_mobile = $_REQUEST['Vtel'];
    $v_fax  = $_REQUEST['Vfax'];
    $v_email  = $_REQUEST['Vmail'];
    
    $VDsta=$_REQUEST['VDsta'];

    if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$v_name")) {
        echo "<script>";
        echo "alert('กรุณากรอกหน่วย เฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=3';";
        echo "</script>";
    }
    else if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$v_fname")) {
        echo "<script>";
        echo "alert('กรุณากรอกหน่วย เฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=3';";
        echo "</script>";
    }
    else if (!preg_match("/^[ก-๙a-z0-9]+$/i", "$v_lname")) {
        echo "<script>";
        echo "alert('กรุณากรอกหน่วย เฉพาะตัวอักษร ก-ฮ ๐-๙ a-z, A-Z, 0-9 เท่านั้น');";
        echo "window.location.href='Home.php?page=standardUnit&Type=3';";
        echo "</script>";
    }
    else
    {
        $str = "UPDATE M_VENDOR SET UpdateBy='$name',UpdateDate=getdate(),vendor_code='$v_code',vendor_name='$v_name',
        fname='$v_fname',lname='$v_lname',mobile_no='$v_mobile',email='$v_email',fax_no='$v_fax',
        active_status='$VDsta',homeid='$homeid',moono='$moono',district='$district',amphur='$amphur',
        province='$province' WHERE id = '".$_GET["vnum"]."'";

        $objQuery = mssql_query($str);
        if($objQuery)
        {
                echo "<script>";
                echo "alert('การแก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=standardUnit&Type=3';";
                echo "</script>";
        }
        else
        {
                echo "<script>";
                echo "alert('พบข้อผิดพลาดในการแก้ไข');";
                echo "window.location.href='Home.php?page=standardUnit&Type=3';";
                echo "</script>";
        }
    }


mssql_close($objConnect);
?>
</body>
</html>