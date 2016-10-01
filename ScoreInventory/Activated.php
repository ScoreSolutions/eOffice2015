<html>
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
</head>
<body>
<?
	include_once("connect.php");

    require_once("nusoap/lib/nusoap.php");

    $client = new nusoap_client("http://192.168.1.101/WS_SendCC/service1.asmx?wsdl",true);

    $pnum = $_GET["pnum"];





    $myFile = "email.html";

    $fh = fopen($myFile, 'w') or die("can't open file");

    $strSQL = "<html xmlns='http://www.w3.org/1999/xhtml'>";
    $strSQL .="<head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />";
    $strSQL .="<title>ขออนุมัติใบเบิก</title>";
    $strSQL .="<meta name='viewport' content='width=device-width, initial-scale=1.0'/>";
    $strSQL .="<link rel='stylesheet' type='text/css' href='192.168.1.192/'></head>";
    $strSQL .="<body><table border='0' cellpadding='0' cellspacing='0' width='100%'>";
    $strSQL .="<tr><td style='padding: 0 0 30px 0;'>";
    $strSQL .="<table align='center' border='0' cellpadding='0' cellspacing='0' width='600px' style='border: 1px solid #cccccc; border-collapse: collapse;'>";  
    $strSQL .="<tr><td align='center' bgcolor='#70bbd9' style='padding: 40px 0 30px 0; color: #153643; font-size: 28px; font-weight: bold; font-family: Arial, sans-serif;'>";
    $strSQL .="<img src='http://www.nightjar.com.au/tests/magic/images/h1.gif' alt='Creating Email Magic' width='300' height='230' style='display: block;' /></td>";
    $strSQL .="</tr><tr><td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'>";
    $strSQL .="<table width='100%' border='0' cellpadding='0' cellspacing='0' style='margin-bottom:20px;'>";
    

    $reqid2 = $_GET['reqid1'];

    $sql1 = "SELECT * 
            from TS_REQUEST tr
            inner join M_LOCATION ml on ml.id=tr.location_id
            inner join M_PROJECT mp on mp.id=ml.project_id
            inner join M_REMARK re on re.id=tr.remark_id
            where req_no = '$reqid2'";

    $obj1 = mssql_query($sql1) or die ("Error Query [".$sql1."]");
    while($Result1 = mssql_fetch_array($obj1))
    {

        $location_name = $Result1["location_name"];
        $location_name= iconv("tis-620","UTF-8", $location_name);
        $reqno = $Result1["req_no"];
        $project_name = $Result1["project_name"];
        $project_name= iconv("tis-620","UTF-8", $project_name);

        $remark = $Result1["remark_desc"];
        $remark= iconv("tis-620","UTF-8", $remark);

    $strSQL .="<tr><td align='right'>เลขที่ใบเบิก :</td>";

    $strSQL .="<td align='left'><p align='left'>".$reqno."</p></td>";

    $strSQL .="<td align='right'>โครงการ :</td>";

    $strSQL .="<td align='left'><p align='left'>".$project_name."</p></td></tr>";



    
    $strSQL .="<tr><td align='right'>สถานที่ :</td>";
    
    $strSQL .="<td align='left'><p align='left'>".$location_name."</p></td>";

    $remarkReq = $_GET['remarkReq'];

    $strSQL .="<tr><td align='right'>ข้อมูลเพิ่มเติม :</td>";
    
    $strSQL .="<td align='left'><p align='left'>".$remarkReq."</p></td>";
    
    $strSQL .="<td align='right'>หมายเหตุ :</td>";
    
    $strSQL .="<td align='left'><p align='left'>".$remark."</p></td></tr></table>";
    
    }

    $strSQL .="<table border='1' cellpadding='0' cellspacing='0' width='100%' style='border: 1px solid #009933; border-collapse: collapse;'>";
    $strSQL .="<thead><tr align='center'>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: tahoma,Arial, sans-serif; font-size: 14px;'><b>ชื่อสินค้า</b></td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'><b>รายละเอียด</b></td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'><b>หน่วย</b></td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'><b>ประเภท</b></td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'><b>จำนวน</b></td>";
    $strSQL .="</tr></thead><tbody>";
    
    $reqid1 = $_GET['reqid1'];
    $sql5 = "SELECT tr.CreateDate,tr.req_no,tr.location_id,re.remark_desc,p.product_name,trd.qty as qty
                    ,l.location_name,pj.project_name,u.unit_name,t.type_name,p.product_desc
                   FROM TS_REQUEST tr
                   left join TS_REQUEST_DETAIL trd on trd.req_id=tr.req_no
                   left join M_PRODUCT p on p.id=trd.product_id
                   left join M_LOCATION l  on l.id=tr.location_id
                   left join M_PROJECT pj on pj.id=l.project_id
                   left join M_UNIT u on u.id=p.unit_id
                   left join M_TYPE t on t.id=p.type_id
                   left join M_REMARK re on re.id=tr.remark_id
                   where req_no = '$reqid1'";

    $obj5 = mssql_query($sql5) or die ("Error Query [".$sql5."]");
    while($Result5 = mssql_fetch_array($obj5))
    {

        $qty = $Result5["qty"];

        $product_name = $Result5["product_name"];
        $product_name= iconv("tis-620","UTF-8", $product_name);

        $product_desc = $Result5["product_desc"];
        $product_desc= iconv("tis-620","UTF-8", $product_desc);

        $unit_name = $Result5["unit_name"];
        $unit_name= iconv("tis-620","UTF-8", $unit_name);

        $type_name = $Result5["type_name"];
        $type_name= iconv("tis-620","UTF-8", $type_name);



    $strSQL .="<tr align='center'>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'>".$product_name."</td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'>".$product_desc."</td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'>".$unit_name."</td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'>".$type_name."</td>";
    $strSQL .="<td style='padding: 8px 0 0 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px;'>".$qty."</td>";
    $strSQL .="</tr>";

        

        }

        $reqid3 = $_GET['reqid1'];
    $strSQL .="</tbody></table><table border='0' width='100%'>";
    $strSQL .="<tr align='center'><td>";
    $strSQL .="<a href='http://192.168.1.107:81/inventory/activemail.php?status=Y&reqid=".$reqid3."' onclick='return confirm('กรุณายืนยันการอนุมัติอีกครั้ง !!!')'>อนุมัติ</a>";
    $strSQL .="&nbsp;&nbsp;&nbsp;";
    $strSQL .="<a href='http://192.168.1.107:81/inventory/activemail.php?status=N&reqid=".$reqid3."' onclick='return confirm('กรุณายืนยันการปฏิเสธอีกครั้ง !!!')'>ไม่อนุมัติ</a>";
    #$strSQL .="<a href='activemail.php?status=Y&reqid=".$reqid3."'><button style='margin:5px;border-radius: 5px;border-color: #66afe9;'>อนุมัติ</button></a>";
   # $strSQL .="<a href='activemail.php?status=N&reqid=".$reqid3."'><button style='margin:5px;border-radius: 5px;border-color: #66afe9;'>ไม่อนุมัติ</button></a>";
    $strSQL .="</td></tr></table></td></tr><tr>";
    $strSQL .="<td bgcolor='#3399FF' style='padding: 30px 30px 30px 30px;'>";
    $strSQL .="<table border='0' cellpadding='0' cellspacing='0' width='100%'><tr>";
    $strSQL .="<td style='color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;' width='75%'>";
    $strSQL .="&reg; ระบบจัดการคลังสินค้าที่ใช้ในการพัฒนาโครงการ<br/>";
    $strSQL .="&copy; บริษัท สกอร์ โซลูชั่น จำกัด | SCORE SOLUTIONS CO.,LTD.";
    $strSQL .="</td><td align='right' width='25%'>";
    $strSQL .="<table border='0' cellpadding='0' cellspacing='0'><tr>";
    $strSQL .="<td style='font-family: Arial, sans-serif; font-size: 12px; font-weight: bold;'></td>";
    $strSQL .="<td style='font-size: 0; line-height: 0;' width='20'>&nbsp;</td>";
    $strSQL .="<td style='font-family: Arial, sans-serif; font-size: 12px; font-weight: bold;'>";
    $strSQL .="</td></tr></table></td></tr></table></td></tr></table></td></tr></table></body></html>";
    $strSQL .="</body></html>";


    fwrite($fh, $strSQL);
    fclose($fh);

$reqid4 = $_GET['reqid1'];
$cc = $_GET['dataCC'];
$ccsub = substr($cc, 0, -1);



$sbj = "Stock>Appove Request";
$apn = "Stock";

    if ($fh) {


    $To = $_GET['EmailTo'];

    #$html ="http://localhost/inventory/email.html";
    $html ="http://192.168.1.107:81/inventory/email.html";
$pms = array('strEmail' => $html ,'strTo' => $To ,'strCC' => $ccsub,'strSubject' => $sbj, 'strApplicationName' => $apn);

    $check = $client->call("SendEmail",$pms);
    if ($check["SendEmailResult"]==1) {



    $strUpStatus = "UPDATE TS_REQUEST SET UpdateBy='$name',UpdateDate=getdate(),active_status='W' WHERE req_no = '$reqid4'";
    $objUpStatus = mssql_query($strUpStatus);

            if ($objUpStatus) {
                echo "<script>";
                echo "alert('ส่งอีเมลล์เสร็จสิ้น');";
                echo "window.location.href='Home.php?page=Request&Type=2';";
                echo "</script>";
            }
            else
            {
                echo "<script>";
                echo "alert('เกิดข้อผิดพลาดในการส่งอีเมลล์');";
                echo "window.location.href='Home.php?page=Request&Type=2';";
                echo "</script>";
            }
            
        }
        else
        {
                echo "<script>";
                echo "alert('เกิดข้อผิดพลาดในการส่งอีเมลล์(1)');";
                echo "window.location.href='Home.php?page=Request&Type=2';";
                echo "</script>";
        }




}
    else {
            echo "<script>";
            echo "alert('ไม่สามารถสร้างไฟล์ได้');";
            echo "window.location.href='Home.php?page=Request&Type=2';";
            echo "</script>";
    }
?>
</body>
</html>


