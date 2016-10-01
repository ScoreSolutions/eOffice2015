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
    }

    $pid = $_GET['pid'];
    $pjid = $_GET['pjid'];
    $lcid = $_GET['lcid'];
    $num = $_GET['num'];
    $bc = $_GET['bc'];
    $reqno = $_GET['rno'];
    $remark = $_GET['remark'];
    $remark = iconv("UTF-8","tis-620", $remark);

    #echo " ".$lcid." ".$pid." ".$pjid." ".$bc." ".$reqno." ".$remark;



    if ($bc == 'บาร์โค้ด' || $bc == '') {
        echo "<script>";
        echo "alert('ไม่พบบาร์โค้ดนี้ในระบบ');";
        echo "window.location.href='Home.php?page=Request&Type=3';";
        echo "</script>";

        }
    
    else{

        $gr = "SELECT 'ISSUE' + convert(varchar,(select DATEPART(YEAR,GETDATE()))) +
                convert(varchar,(select DATEPART(MONTH,GETDATE()))) +
                convert(varchar,(select DATEPART(Day,GETDATE()))) +
                (select RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) From (                      
                SELECT Replace(isnull(max(RIGHT(stockout_code,3)),0),'#','')+1 as a FROM TS_STOCK_OUT) a) as ISSUE";

        $rgr = mssql_query($gr) or die ("Error Query [".$gr."]");
        while($objResult = mssql_fetch_array($rgr))
            {
                $s = $objResult['ISSUE'];
            }

        $sql1 = "INSERT INTO TS_STOCK_OUT (CreateBy,CreateDate,stockout_code,project_id,location_id,req_id) 
               VALUES ('$name',GETDATE(),'$s','$pjid','$lcid','$reqno')";

        $result1 = mssql_query($sql1);

        $sql2="INSERT INTO TS_STOCK_OUT_DETAIL (CreateBy,CreateDate,Barcode_pk,stockout_id) 
               VALUES ('$name',GETDATE(),'$bc','$s')";


        $result2 = mssql_query($sql2);

        if ($result1 && $result2) {
            echo "<script>";
            echo "alert('เพิ่มข้อมูลเสร็จสิ้น');";
            echo "window.location.href='Home.php?page=Request&Type=3';";
            echo "</script>";
        }
        else
        {
            echo "<script>";
            echo "alert('เกิดข้อผิดพลาดโปรดลองใหม่อีกครั้ง');";
            echo "window.location.href='Home.php?page=Request&Type=3';";
            echo "</script>";
        }
        mssql_close($objConnect);
    }


    


   










?>