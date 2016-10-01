<?php
    session_start();
    include_once("connect.php");
?>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<style type="text/css">
    .div1{
        background-color: #33FFCC;
        margin-left: 28%;
        margin-right: 28%;
        margin-top: 15%;
        border-radius: 20px;
        width: 40%;
        position: absolute;
        height: 30%;
        border-style: dashed;   
        bo
    }
    .div2{
        background-color: #33FFCC;
        margin-left: 28%;
        margin-right: 28%;
        margin-top: 12%;
        border-radius: 20px;
        width: 40%;
        position: absolute;
        height: 30%;
        border-style: dashed;   
        border-color: #9933CC;
    }
        .div3{
        background-color: #33FFCC;
        margin-left: 32%;
        margin-right: 32%;
        margin-top: 5%;
        border-radius: 20px;
        width: 40%;
        position: absolute;
        height: 30%;

    }
    p{
        font-size: 16px;
        font-family: Tahoma;
    }
</style>
</head>
<body>
<?

    $s = $_GET['status'];
    $r = $_GET['reqid'];

    $sql3 = "SELECT * FROM TS_REQUEST 
             WHERE req_no = '$r' and 
             (active_status = 'D' or active_status = 'A')";
    $Qsql3 = mssql_query($sql3) or die ("Error Query [".$sql3."]");
    $numrow = mssql_fetch_object($Qsql3);
    

    if($numrow < 1)
    {

                if ($s == 'Y') {
                        $str = "UPDATE TS_REQUEST SET active_status='A' WHERE req_no = '$r'";
                        $objQuery = mssql_query($str);
                        if($objQuery)
                        {
                                ?>      
                                <script type="text/javascript">
                                    alert('อนุมัติการขอเบิกเรียบร้อย');
                                    //window.location.href='http://google.com';
                                    window.close();
                                </script>
                                <?
                        }   
                        else
                        {
                                echo "<script>";
                                echo "alert('เกิดข้อผิดพลาดในการอนุมัติ');";
                                echo "window.close();";
                                echo "</script>";            
                        }
                }
                else
                {
                        $str2 = "UPDATE TS_REQUEST SET active_status='D' WHERE req_no = '$r'";
                        $objQuery2 = mssql_query($str2);
                        if($objQuery2)
                        {
                            ?>
                                <script type="text/javascript">
                                    alert('ปฏิเสธการร้องขออนุมัติเรียบร้อย');
                                    window.close();
                                </script>
                            <?
                        }
                        else {
                            echo "<script>";
                            echo "alert('เกิดข้อผิดพลาดในการอนุมัติ');";
                            echo "window.close();";
                            echo "</script>";
                        }
                }
    }
    else{
        echo "<script>";
        echo "alert('ใบเบิกเลขที่ ".$r." ได้มีการตอบอนุมัติหรือปฏิเสธแล้ว');";
        echo "window.close();";
        echo "</script>";
    }            
?>

</body>
</html>


