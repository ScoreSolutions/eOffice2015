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
<script type="text/javascript">
  function make_autocom1(autoObj1,showObj1){
  var mkAutoObj1=autoObj1; 
  var mkSerValObj1=showObj1;
  new Autocomplete(mkAutoObj1, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj1).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
    return "AutoComProduct.php?&q=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

    }); 
} 

    function make_autocom2(autoObj2,showObj2){
  var mkAutoObj2=autoObj2; 
  var mkSerValObj2=showObj2;
  new Autocomplete(mkAutoObj2, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj2).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
    return "AutoComStock.php?&q=" +(this.value); 

    }); 
} 
</script>
<div id="t2">
<table border="0"  width="80%" align="center">
  <tr>
    <td align="right" width="20%">ชื่อสินค้า :</td>
    <td align="left" width="25%"><input type="text" class="fm" id="pname2"><input type="hidden" id="pid2" value="0"></td>
    <td align="right" width="20%">สถานที่จัดเก็บ :</td>
    <td align="left" width="25%"><input type="text" class="fm" id="ws2" ><input type="hidden" id="wsid2" ></td>
    <td align="center"><button id="btn2" class="btn btn-info">ตกลง</button></td>
    <td></td>
  </tr>
</table>
<script type="text/javascript">make_autocom1('pname2','pid2');</script>
<script type="text/javascript">make_autocom2('ws2','wsid2');</script>
<script type="text/javascript">
  $(function(){
      $('#btn2').click(function(){
        var t = 'rp2';
        var pid = $('#pid2').val();  
        var bcode = $('#bc2').val(); 
        var wsid = $('#wsid2').val();  
        var dates = $('#d2').val();  
        var months = $('#m2').val();  
        var years = $('#y2').val();
        var dateE = $('#daydropdown1').val();  
        var mounthE = $('#monthdropdown1').val();  
        var yearE = $('#yeardropdown1').val(); 
        if (wsid == '') {
          alert('โปรดกรอกข้อมูลคลังจัดเก็บสินค้า');
          $('#ws2').focus();
        }
        else{
        //window.open("http://localhost/report/default.aspx?pid="+pid+"&type="+t+"&wsid="+wsid);
        window.open("http://192.168.1.101/wb/default.aspx?pid="+pid+"&type="+t+"&wsid="+wsid);
        }
      });
  });
</script>
</div>
</body>
</html>