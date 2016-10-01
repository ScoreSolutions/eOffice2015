<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
</head>
<body>
    <div id="t1">
<table border="0"  width="100%" align="center">
  <tr>
    <!--<td align="right" width="10%">ชื่อสินค้า :</td>
    <td align="left" width="10%"><input type="text" class="fm" id="pname"><input type="hidden" id="pid"></td>-->
    <td align="right" width="10%">บาร์โค้ด :</td>
    <td align="left" width="10%"><input type="text" class="fm" id="bcode"></td>
    <td align="right" width="10%">วันเริ่มต้น :</td>
    <td align="left" width="5%"><select class="ddl" id="d">
    <option value="">ว</option>
      <?for ($d1=1; $d1 <= 31; $d1++) { if ($d1 < 10) {$d1 = "0".$d1;}?>
      <option><?=$d1?></option><?}?>
    </select></td>
    <td width="5%"><select class="ddl" id="m" >
      <option value="">ด</option>
      <?for ($m1=1; $m1 <= 12; $m1++) { if ($m1 < 10) {$m1 = "0".$m1;}?>
      <option><?=$m1?></option>
      <?}?>
    </select></td>
    <td width="7.5%"><select class="ddl" id="y" >
      <option value="">ป</option>
      <?for ($y1=2014; $y1 <= 2033; $y1++) {     ?>
      <option><?=$y1?></option><?}?>
    </select>
    </select></td>
    <td width="10%" align="right">วันที่สิ้นสุด :</td>
    <td align="left" width="5%"><select class="ddl" id="daydropdown2" >
      <option value="">ว</option>
      <?for ($dd1=1; $dd1 <= 31; $dd1++) { if ($dd1 < 10) {$dd1 = "0".$dd1;}  ?>
      <option><?=$dd1?></option>
      <?}?>
    </select></td>
    <td align="left" width="5%"><select class="ddl" id="monthdropdown2" >
      <option value="">ด</option>
      <?for ($mm1=1; $mm1 <= 12; $mm1++) { if ($mm1 < 10) {$mm1 = "0".$mm1;}?>
      <option><?=$mm1?></option>
      <?}?>
    </select>
    </select></td>
    <td align="left" width="7.5%"><select class="ddl" id="yeardropdown2">
      <option value="">ป</option>
      <?for ($yy1=2014; $yy1 <= 2033; $yy1++) {  ?>
      <option><?=$yy1?></option>
      <?}?>
    </select></td>
    <td width="5%"><button id="btn1" class="btn btn-info">ตกลง</button></td>
  </tr>
<script type="text/javascript"> 
 make_autocom("pname","pid");
</script>
</table>
<script type="text/javascript">
  $(function(){
      $('#btn1').click(function(){
        var t = 'rp1';
        var pid = $('#pid').val();  
        var bcode = $('#bcode').val();  
        var dates = $('#d').val();  
        var months = $('#m').val();  
        var years = $('#y').val();
        var dateE = $('#daydropdown2').val();  
        var mounthE = $('#monthdropdown2').val();  
        var yearE = $('#yeardropdown2').val();  
        //window.open("http://localhost/report/default.aspx?dateStart="+dates+"/"+months+"/"+years+"&dateEnd="+dateE+"/"+mounthE+"/"+yearE+"&bcode="+bcode+"&type="+t);
        window.open("http://192.168.1.101/wb/default.aspx?dateStart="+dates+"/"+months+"/"+years+"&dateEnd="+dateE+"/"+mounthE+"/"+yearE+"&bcode="+bcode+"&type="+t);
      });
  });
</script>
</div>
</body>
</html>