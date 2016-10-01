<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=tis-620" />
	<title>จัดการการเบิกจ่าย</title>
  <script type="text/javascript" src="autocomplete.js"></script>
  <link rel="stylesheet" href="autocomplete.css"  type="text/css"/>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css">
  <script src="js/jquery-1.11.1.min.js"></script>
  <script type="text/javascript" src="js/jquery-ui.js"></script>
  <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
  <link href="css/style.css" rel="stylesheet" type="text/css" />
  <link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
  <script src="js/bootstrap.min.js"></script>
  <script type="text/javascript" src="js/bootstrap.js"></script>  
  <script type="text/javascript" src="js/bootbox.min.js"></script>
  <script type="text/javascript" src="js/jconfirmaction.jquery.js"></script>
  <style type="text/css">
  iframe{
    border:none;
  }
</style>
</head>

<body onload="displayoff();">
    <?php
    $$ses_username= iconv("WINDOWS-874","UTF-8", $ses_username); 
    $result = mssql_query("select * from M_USER where username ='$_SESSION[ses_username]' ");
    while ($data = mssql_fetch_array($result) ) 
    {
        $name = $data[username];
        $fname = $data[first_name];
        $lname = $data[last_name];
        $fname= iconv("tis-620","UTF-8", $fname);

        $lname= iconv("tis-620","UTF-8", $lname);  
        $gid = $data[group_id];
    
    }
 ?>
        <div class="topmenu">
        <ul class="nav nav-tabs con topmenu">
            <li class="active">
                <a href="#Report" id="Report" data-toggle="tab" ><b>รายงาน</b></a>
            </li>
        </ul>
        </div>
<div class="tab-content content">

    <!-- ---------------------------------------Stsrt Page   --------------------------------- -->
<div class="tab-pane active" id="Report">
 <form>
   <table border="0" width="100%" align="center" >
        <tr>
            <td align="right" width="30%">รายงาน :</td>
            <td align="left" width="30%"><select class="ddls" name="optReport" id="optReport" onchange="showrp1();" required>
            <option value=" ">เลือกรายงาน</option>
            <? 
               if($gid=='1' or $gid=='3'){?>
            <option value="rp1">รายงานแสดงการเคลื่อนไหวของสินค้า</option>
            <?}?>
            <? 
               if($gid=='9' or $gid=='3' or $gid=='1'){?>
            <option value="rp2">รายงานแสดงสินค้าที่มีอยู่ในคลังสินค้า</option>
            <option value="rp3">รายงานแสดงสินค้าที่มีอยู่ที่โครงการต่าง ๆ</option>
            <?}?>
            <? 
               if($gid=='1' ){?>
            <option value="rp4">รายงานแสดงสรุปการเบิกสินค้า</option>
            <option value="rp5">รายงานแสดงสรุปการจ่ายสินค้า</option>
            <?}?>
            </select></td>
            <td width="5%"></td>
        </tr>   
    </table>
    </form>
    <br>
<script type="text/javascript">
  $(function(){
      $('#t1').hide();
  });
  $(function(){
      $('#t2').hide();
  });
  $(function(){
      $('#t3').hide();
  });
  $(function(){
      $('#t4').hide();
  });
    $(function(){
      $('#t5').hide();
  });
  $('#optReport').change(function(){
      var val = $('#optReport').val();
      if (val == 'rp1') 
      {
          $('#t1').fadeIn(1000);
          $('#t2').hide();
          $('#t3').hide();
          $('#t4').hide();
          $('#t5').hide();
      }
      else if (val == 'rp2') 
      {
          $('#t2').fadeIn(1000);
          $('#t1').hide();
          $('#t3').hide();
          $('#t4').hide();
          $('#t5').hide();
      }
      else if (val == 'rp3') 
      {
          $('#t3').fadeIn(1000);
          $('#t1').hide();
          $('#t2').hide();
          $('#t4').hide();
          $('#t5').hide();
      }
      else if (val == 'rp4') 
      {
          $('#t4').fadeIn(1000);
          $('#t1').hide();
          $('#t2').hide();
          $('#t3').hide();
          $('#t5').hide();
      }
      else if (val == 'rp5')
      {
          $('#t5').fadeIn(1000);
          $('#t4').hide();
          $('#t1').hide();
          $('#t2').hide();
          $('#t3').hide();
      }
      else
      {
          $('#t4').hide();
          $('#t1').hide();
          $('#t2').hide();
          $('#t3').hide();
          $('#t5').hide();
      }
  });
</script>

<!------------------------------------  ID 1   ------------------------------------>
<div id="t1"><iframe src="rp1.php" width="100%"></iframe></div>
<!------------------------------------  ID 2   ------------------------------------>
<div id="t2"><iframe src="rp2.php" width="100%"></iframe></div>
<!------------------------------------  ID 3   ------------------------------------>
<div id="t3"><iframe src="rp3.php" width="100%"></iframe></div>
<!------------------------------------  ID 4  ------------------------------------>
<div id="t4"><iframe src="rp4.php" width="100%"></iframe></div>
<!------------------------------------  ID 5   ------------------------------------>
<div id="t5"><iframe src="rp5.php" width="100%"></iframe></div>
    <!-- ---------------------------------------End Page --------------------------------- -->
  </div>
  </body>
  </html>