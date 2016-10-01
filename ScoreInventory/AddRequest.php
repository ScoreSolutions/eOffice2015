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

<?php
    
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
        $em = $data['email'];
        $fname = $data[first_name];
        $lname = $data[last_name];
    /*echo $data[lastname],”<br />”;*/
    
    }
        if($_POST["save"])
        { //Start IF

        $ss = $_POST['grandtotal'];
    

        $gr = "SELECT 'REQ' + convert(varchar,(select DATEPART(YEAR,GETDATE()))) +
                convert(varchar,(select DATEPART(MONTH,GETDATE()))) +
                convert(varchar,(select DATEPART(Day,GETDATE()))) +
                (select RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) From (                      
                SELECT Replace(isnull(max(RIGHT(req_no,3)),0),'#','')+1 as a fROM TS_REQUEST) a) as REQ_NO";

        $rgr = mssql_query($gr) or die ("Error Query [".$gr."]");
        while($objResult = mssql_fetch_array($rgr))
            {
                $s = $objResult['REQ_NO'];
            }


        $pjid=$_POST['ProID'];
        $txtUser=$_POST['txtUser'];
        $loid=$_POST['LocaID'];
        $rm=$_POST['optRemark'];
        $rm= iconv("UTF-8","tis-620", $rm);            

        $sql1="INSERT INTO TS_REQUEST (req_no,CreateBy,CreateDate,active_status,location_id,user_id,remark_id) 
               VALUES ('$s','$name',GETDATE(),'Y','$loid','$txtUser','$rm')";

        $result1 = mssql_query($sql1);
        
        for ($i=1; $i<=$ss ; $i++) {

        $pdid=$_POST['optProduct'.+$i];
        $qty=$_POST['txtQty'.+$i];

        $sql2="INSERT INTO TS_REQUEST_DETAIL (CreateBy,CreateDate,qty,req_id,product_id) 
               VALUES ('$name',GETDATE(),'$qty','$s','$pdid')";    
        $result2 = mssql_query($sql2);
         }


                if ($result1 && $result2) {
                echo "<script>";
                echo "alert('เพิ่มข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=Request&Type=1';";
                echo "</script>";

                }

                else
                {
                echo "<script>";
                echo "alert('เกิดข้อผิดพลาดโปรดลองใหม่อีกครั้ง');";
                echo "window.location.href='Home.php?page=Request&Type=1';";
                echo "</script>";
                }

       
        
        }//END IF

        else if($_POST["insert"])
        {
                $pdid2=$_POST['optProducted'];
                $qty2=$_POST['txtQtyed'];
                $reqnum2=$_POST['reqnum'];

                if ($pdid2 == '') {
                        echo "<script>";
                        echo "alert('เลือกข้อมูลสินค้าก่อน');";
                        echo "window.location.href='Home.php?page=Request&Type=1&reqno=".$reqnum2."&ed=1';";
                        echo "</script>";
                }
                else if($qty2 < 1 ){
                        echo "<script>";
                        echo "alert('ระบุจำนวนที่ต้องการเบิก');";
                        echo "window.location.href='Home.php?page=Request&Type=1&reqno=".$reqnum2."&ed=1';";
                        echo "</script>";
                }
                else{

                $sql3="INSERT INTO TS_REQUEST_DETAIL (CreateBy,CreateDate,qty,req_id,product_id) 
                       VALUES ('$name',GETDATE(),'$qty2','$reqnum2','$pdid2')";
  
                $result3 = mssql_query($sql3);
                if ($result3) {
                echo "<script>";
                echo "alert('เพิ่มข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=Request&Type=1&reqno=".$reqnum2."&ed=1';";
                echo "</script>";

                }

                else
                {
                echo "<script>";
                echo "alert('เกิดข้อผิดพลาดโปรดลองใหม่อีกครั้ง');";
                echo "window.location.href='Home.php?page=Request&Type=1&reqno=".$reqnum2."&ed=1';";
                echo "</script>";
                }
            }
        }

        else //Start Else For EDIT Req
        {
                $ss2 = $_POST['grandtotal'];
                $ss2 = $ss2-1;
                $pjid=$_POST['ProID'];
                $loid=$_POST['LocaID'];
                $reqnum=$_POST['reqnum'];
                $rm=$_POST['optRemark'];
                $rm= iconv("UTF-8","tis-620", $rm);

                $str1 = "UPDATE TS_REQUEST SET UpdateBy='$name',UpdateDate=getdate(),remark_id='$rm',location_id='$loid'
                        WHERE req_no = '$reqnum'";


                $objQuery1 = mssql_query($str1);

                for ($k=1; $k<=$ss2 ; $k++) {

                    $pdid=$_POST['optProduct'.+$k];
                    $qty=$_POST['txtQty'.+$k];
                    $trid=$_POST['trdid'.+$k];

                    $str2 = "UPDATE TS_REQUEST_DETAIL SET UpdateBy='$name',UpdateDate=getdate(),
                                    qty='$qty',product_id='$pdid'
                             WHERE id = '$trid'";



                    $objQuery2 = mssql_query($str2);
                }


                if ($objQuery1 && $objQuery2) {
                echo "<script>";
                echo "alert('แก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=Request&Type=1&reqno=".$reqnum."&ed=1';";
                echo "</script>";

                }

                else
                {
                echo "<script>";
                echo "alert('เกิดข้อผิดพลาดโปรดลองใหม่อีกครั้ง');";
                echo "window.location.href='Home.php?page=Request&Type=1&reqno=".$reqnum."&ed=1';";
                echo "</script>";
                }

        }//END ELSE

        

        mssql_close($objConnect);

  
?>








