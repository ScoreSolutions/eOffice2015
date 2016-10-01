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
        $fname = $data[first_name];
        $lname = $data[last_name];
    /*echo $data[lastname],”<br />”;*/
    
    }

    ?>


<?


    require_once("nusoap/lib/nusoap.php");

    $client = new nusoap_client("http://192.168.1.101/print/service1.asmx?wsdl",true);

    $pnum = $_GET["pnum"];
    
    $sql = "SELECT t.type_code,p.product_code,p.id,p.product_name,p.Barcoderunning
            from M_TYPE as t
            inner join M_PRODUCT as p on t.id=p.type_id
            where p.id='$pnum' ";

    $obj = mssql_query($sql) or die ("Error Query [".$sql."]");
    $pd = $_REQUEST['PDprint'];

    $br;
    $t;
    $pname;
    $p;
    while($Result = mssql_fetch_array($obj))
    {
        $pid = $Result["id"];
        $br = $Result["Barcoderunning"];
        $t = $Result["type_code"];
        $pname = $Result["product_name"];
        $pname= iconv("tis-620","UTF-8", $pname);
        $p = $Result["product_code"];
        }
    $pms = array('ProductType' => $t
              ,'ProductCode' => $p
              ,'Qty' => $pd
              ,'RunningNo' => $br
              ,'ProductName' => $pname);

    $check = $client->call("Print",$pms);


    if ($check["PrintResult"]==1) {
        
        $test;
        for($i=1;$i<=$pd;$i++)
        {
            $brun = $br+$i;
            $brnew = str_pad($brun, 3, '0', STR_PAD_LEFT);

            $total = $t."".$p."".$brnew;

        $sqlIN = "INSERT INTO TS_PRODUCT_ITEM (CreateBy,CreateDate,Barcode,Product_id)
                  VALUES ('$name',GETDATE(),'$total','$pid')";
        $test = $sqlIN."<br/>";
        $result = mssql_query($sqlIN);
        }
        if ($result) {
 


            $sqlBR ="UPDATE M_PRODUCT SET UpdateBy='$name',UpdateDate=getdate(),Barcoderunning=Barcoderunning+$pd
                     WHERE id ='$pnum' ";
            $result = mssql_query($sqlBR);
            echo "<script>";
            echo "alert('พิมพ์บาร์โค้ดเสร็จสิ้น');";
            echo "window.location.href='Home.php?page=standardUnit&Type=2';";
            echo "</script>";
        }
        else{
            echo "<script>";
            echo "alert('Fail');";
            echo "window.location.href='Home.php?page=standardUnit&Type=2';";
            echo "</script>";
        }

    
    }
    else {
       
      echo "<script>";
      echo "alert('เกิดข้อผิดพลาด');";
      echo "window.location.href='Home.php?page=standardUnit&Type=2';";
      echo "</script>";
    }
mssql_close($objConnect);


?>


