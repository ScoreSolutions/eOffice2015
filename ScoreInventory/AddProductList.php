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
    
    }

		if($_POST["savefirst"])
		{

							$ss = $_POST['grandtotal'];
							$gr = "SELECT 'R' + convert(varchar,(select DATEPART(YEAR,GETDATE()))) +
									convert(varchar,(select DATEPART(MONTH,GETDATE()))) +
									convert(varchar,(select DATEPART(Day,GETDATE()))) +
									(select RIGHT(REPLICATE('0', 3) + CAST(a AS VARCHAR(3)), 3) From (                      
									SELECT Replace(isnull(max(RIGHT(stockin_code,3)),0),'#','')+1 as a fROM TS_STOCK_IN) a) as Stock_Code";
							$rgr = mssql_query($gr) or die ("Error Query [".$gr."]");
							while($objResult = mssql_fetch_array($rgr))
					            {
					            	$s = $objResult['Stock_Code'];
					            }
					        $Inv=$_POST['txtInv'];
							$PO=$_POST['txtPO'];
							$WS=$_POST['txtStId'];
							//$WS= iconv("UTF-8","tis-620", $WS);
							$vendor=$_POST['txtVendorID'];
							//$vendor= iconv("UTF-8","tis-620", $vendor);
					        $sql1="INSERT INTO TS_STOCK_IN (CreateBy,CreateDate,stockin_code,stockin_date,PO_NO,INV_NO,vendor_id,ws_id) 
								   VALUES ('$name',GETDATE(),'$s',GETDATE(),'$PO','$Inv','$vendor','$WS')";
							
							$result1 = mssql_query($sql1);
					        

					        for ($i=1; $i<=$ss ; $i++) {
							$barcode=$_POST['txtBc'.+$i];
							$serial=$_POST['txtSerial'.+$i];
							
							
							$Pname=$_POST['txtPname'.+$i];
							$Pname= iconv("UTF-8","tis-620", $Pname);
							$Pdesc=$_POST['txtPdesc'.+$i];
							$Pdesc= iconv("UTF-8","tis-620", $Pdesc);
							$Punit=$_POST['unitid'.+$i];
							$Ptype=$_POST['typeid'.+$i];

							$sql2="INSERT INTO TS_STOCK_IN_DETAIL (CreateBy,CreateDate,SerialNO,Barcode_pk,stockin_id) 
								   VALUES ('$name',GETDATE(),'$serial','$barcode','$s')";


							$result2 = mssql_query($sql2);

							}


							if ($result1 && $result2) {
									echo "<script>";
					      			echo "alert('เพิ่มข้อมูลเสร็จสิ้น');";
					      			echo "window.location.href='Home.php?page=ManageStock&Type=1';";
					      			echo "</script>";

					    	}
					    	else
					    	{
					      		echo "<script>";
					      		echo "alert('เกิดข้อผิดพลาด(1)โปรดลองใหม่อีกครั้ง');";
					      		echo "window.location.href='Home.php?page=ManageStock&Type=1';";
					      		echo "</script>";
					    	}
		}		    	

		else if($_POST["insert"])
		{
				$bc1=$_POST['txtAddBc'];
                $sr1=$_POST['txtAddSerial'];
                $reqnum2=$_POST['txtSicode'];


                if ($bc1 == '') {
                	echo "<script>";
                	echo "alert('กรอกเลขบาร์โค้ดให้ถูกต้องและครบถ้วน');";
                	echo "window.location.href='Home.php?page=ManageStock&Type=1&inid=".$reqnum2."&ed=1';";
                	echo "</script>";
                }

                else if ($sr1 == '') {
                	echo "<script>";
                	echo "alert('กรอกเลข Serial ให้ถูกต้องและครบถ้วน');";
                	echo "window.location.href='Home.php?page=ManageStock&Type=1&inid=".$reqnum2."&ed=1';";
                	echo "</script>";
                }

                else
                {

                $sql3="INSERT INTO TS_STOCK_IN_DETAIL (CreateBy,CreateDate,stockin_id,SerialNO,Barcode_pk) 
                       VALUES ('$name',GETDATE(),'$reqnum2','$sr1','$bc1')";


                $result3 = mssql_query($sql3);
                if ($result3) {
                echo "<script>";
                echo "alert('เพิ่มข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=ManageStock&Type=1&inid=".$reqnum2."&ed=1';";
                echo "</script>";

                }

                else
                {
                echo "<script>";
                echo "alert('เกิดข้อผิดพลาดโปรดลองใหม่อีกครั้ง');";
                #echo "window.location.href='Home.php?page=ManageStock&Type=1&inid=".$reqnum2."&ed=1';";
                echo "</script>";
                }
            }
		}

		else if($_POST["saveedit"])
		{
                $ss2 = $_POST['grandtotal'];


                $reqnum3=$_POST['txtSicode'];
                $Inv=$_POST['txtInv'];
				$PO=$_POST['txtPO'];
				$WS=$_POST['txtStId'];
				$vendor=$_POST['txtVendorID'];

                $str1 = "UPDATE TS_STOCK_IN SET UpdateBy='$name',UpdateDate=getdate(),PO_NO='$PO',INV_NO='$Inv',
                		vendor_id='$vendor',ws_id='$WS'
                        WHERE stockin_code = '$reqnum3'";

                $objQuery1 = mssql_query($str1);

                for ($k=1; $k<=$ss2 ; $k++) {

                    $pdid=$_POST['bcode'.+$k];
                    $sr=$_POST['serialed'.+$k];
                    $trid=$_POST['inid'.+$k];

                    $str2 = "UPDATE TS_STOCK_IN_DETAIL SET UpdateBy='$name',UpdateDate=getdate(),
                                    SerialNO='$sr'
                             WHERE id = '$trid'";



                    $objQuery2 = mssql_query($str2);
                }


                if ($objQuery1 && $objQuery2) {
                echo "<script>";
                echo "alert('แก้ไขข้อมูลเสร็จสิ้น');";
                echo "window.location.href='Home.php?page=ManageStock&Type=1&inid=".$reqnum3."&ed=1';";
                echo "</script>";

                }

                else
                {
                echo "<script>";
                echo "alert('เกิดข้อผิดพลาดโปรดลองใหม่อีกครั้ง');";
                #echo "window.location.href='Home.php?page=ManageStock&Type=1&inid=".$reqnum3."&ed=1';";
                echo "</script>";
                }
		}



    	mssql_close($objConnect);		
?>