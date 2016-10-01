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
<script type="text/javascript"> function make_autocom6(autoObj6,showObj6){
  var mkAutoObj6=autoObj6; 
  var mkSerValObj6=showObj6;
  new Autocomplete(mkAutoObj6, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj6).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
    return "AutoComUser.php?q=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

    }); 
} </script>
<div id="t4"> 
<table border="0"  width="100%" align="center">
  <tr>
    <td align="right" width="10%">ชื่อผู้เบิก :</td>
    <td align="left" width="10%"><input type="text" class="fm" id="user"><input type="hidden" id="userid"></td>
        <td align="right" width="10%">วันเริ่มต้น :</td>
    <td align="left" width="5%"><select class="ddl" id="d1">
      <option value="">ว</option>
      <?for ($d2=1; $d2 <= 31; $d2++) { if ($d2 < 10) {$d2 = "0".$d2;}?>
      <option><?=$d2?></option>
      <?}?>
    </select></td>
    <td width="5%"><select class="ddl" id="m1" >
      <option value="">ด</option>
      <?for ($m2=1; $m2 <= 12; $m2++) { if ($m2 < 10) {$m2 = "0".$m2;}?>
      <option><?=$m2?></option><?}?>
    </select></td>
    <td width="7.5%"><select class="ddl" id="y1" >
      <option value="">ป</option>
      <?for ($y2=2014; $y2 <= 2033; $y2++) { # code...?>
      <option><?=$y2?></option><?}?>
    </select></td>
    <td width="10%" align="right">วันที่สิ้นสุด :</td>
    <td align="left" width="5%"><select class="ddl" id="daydropdown4" >
      <option value="">ว</option>
      <?for ($dd2=1; $dd2 <= 31; $dd2++) { if ($dd2 < 10) {$dd2 = "0".$dd2;}?>
      <option><?=$dd2?></option>
      <?}?>
    </select></td>
    <td align="left" width="5%"><select class="ddl" id="monthdropdown4" >
        <option value="">ด</option>
      <?for ($mm2=1; $mm2 <= 12; $mm2++) { if ($mm2 < 10) {$mm2 = "0".$mm2;}?>
      <option><?=$mm2?></option><?}?>
    </select></td>
    <td align="left" width="7.5%"><select class="ddl" id="yeardropdown4">
      <option value="">ป</option>
      <?for ($yy2=2014; $yy2 <= 2033; $yy2++) { ?>
      <option><?=$yy2?></option><?}?>
    </select></td>
    <td width="7.5%"><button id="btn4" class="btn btn-info">ตกลง</button></td>
  </tr>
</table>
  <script type="text/javascript">
      make_autocom6("user","userid");
  </script>
<script type="text/javascript">
  $(function(){
      $('#btn4').click(function(){
        
        var pid = $('#pid4').val();  
        var userid = $('#userid').val(); 
        var loid = $('#loid2').val();  
        var pjid = $('#pjid2').val();
        var t = 'rp4';
        var dates = $('#d1').val();  
        var months = $('#m1').val();  
        var years = $('#y1').val();
        var dateE = $('#daydropdown4').val();  
        var mounthE = $('#monthdropdown4').val();  
        var yearE = $('#yeardropdown4').val();  
        //window.open("http://localhost/report/default.aspx?dateStart="+dates+"/"+months+"/"+years+"&dateEnd="+dateE+"/"+mounthE+"/"+yearE+"&userid="+userid+"&type="+t);
        window.open("http://192.168.1.101/wb/default.aspx?dateStart="+dates+"/"+months+"/"+years+"&dateEnd="+dateE+"/"+mounthE+"/"+yearE+"&userid="+userid+"&type="+t);
      });
  });
</script>
</div>
</body>
</html>