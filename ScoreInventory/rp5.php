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
<div id="t5">
<table border="0"  width="100%" align="center">
  <tr>
    <td align="right" width="10%">ชื่อผู้เบิก :</td>
    <td align="left" width="10%"><input type="text" class="fm" id="user2"><input type="hidden" id="userid2"></td>
    <td align="right" width="10%">วันเริ่มต้น :</td>
    <td align="left" width="5%"><select class="ddl" id="d5" >
      <option value="">ว</option>
      <?for ($d3=1; $d3 <= 31; $d3++) { if ($d3 < 10) {$d3 = "0".$d3;}?>
      <option><?=$d3?></option><?}?>
    </select></td>
    <td width="5%"><select class="ddl" id="m5" >
      <option value="">ด</option>
      <?for ($m3=1; $m3 <= 12; $m3++) { if ($m3 < 10) {$m3 = "0".$m3;}?>
      <option><?=$m3?></option><?}?>
    </select></td>
    <td width="7.5%"><select class="ddl" id="y5" >
      <option value="">ป</option>
      <?for ($y3=2014; $y3 <= 2033; $y3++) { ?>
      <option><?=$y3?></option><?}?>
    </select></td>
    <td width="10%" align="right">วันที่สิ้นสุด :</td>
    <td align="left" width="5%"><select class="ddl" id="daydropdown5" >
    <option value="">ว</option>
      <?for ($dd3=1; $dd3 <= 31; $dd3++) { if ($dd3 < 10) {$dd3 = "0".$dd3;}?>
      <option><?=$dd3?></option><?}?>
    </select></td>
    <td align="left" width="5%"><select class="ddl" id="monthdropdown5" >
        <option value="">ด</option>
      <? for ($mm3=1; $mm3 <= 12; $mm3++) { if ($mm3 < 10) {$mm3 = "0".$mm3;}?>
      <option><?=$mm3?></option><?}?>
    </select></td>
    <td align="left" width="7.5%"><select class="ddl" id="yeardropdown5">
      <option value="">ป</option>
      <?for ($yy3=2014; $yy3 <= 2033; $yy3++) { ?>
      <option><?=$yy3?></option><?}?>
    </select></td>
    <td width="7.5%"><button id="btn5" class="btn btn-info">ตกลง</button></td>
  </tr>
</table>
<script type="text/javascript">
      make_autocom6("user2","userid2");
</script>
<script type="text/javascript">
  $(function(){
      $('#btn5').click(function(){
        
        var pid = $('#pid4').val();  
        var userid = $('#userid2').val(); 
        var loid = $('#loid2').val();  
        var pjid = $('#pjid2').val();
        var t = 'rp5';
        var dates = $('#d5').val();  
        var months = $('#m5').val();  
        var years = $('#y5').val();
        var dateE = $('#daydropdown5').val();  
        var mounthE = $('#monthdropdown5').val();  
        var yearE = $('#yeardropdown5').val();
        window.open("http://192.168.1.101/wb/default.aspx?dateStart="+dates+"/"+months+"/"+years+"&dateEnd="+dateE+"/"+mounthE+"/"+yearE+"&userid="+userid+"&type="+t);
        //window.open("http://localhost/report/default.aspx?dateStart="+dates+"/"+months+"/"+years+"&dateEnd="+dateE+"/"+mounthE+"/"+yearE+"&userid="+userid+"&type="+t);
      });});
</script>
</div>
</body>
</html>