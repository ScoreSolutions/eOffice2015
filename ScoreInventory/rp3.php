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
  
  function make_autocom3(autoObj3,showObj3){
  var mkAutoObj3=autoObj3; 
  var mkSerValObj3=showObj3;
  new Autocomplete(mkAutoObj3, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj3).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
    return "AutoComProduct.php?&q=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

    }); 
} 

//AUTO COMPLETE ของ Project 
function make_autocom4(autoObj4,showObj4){
  var mkAutoObj4=autoObj4; 
  var mkSerValObj4=showObj4; 
  new Autocomplete(mkAutoObj4, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj4).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  

    return "AutoComProject.php?p=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

    }); 
} 

//AUTO COMPLETE ของ Location
function make_autocom5(autoObj5,showObj5,Loid){

  var mkAutoObj5=autoObj5;
  var mkSerValObj5=showObj5;
 
  new Autocomplete(mkAutoObj5, function() {
    this.setValue = function(id) {    
      document.getElementById(mkSerValObj5).value = id;
    }
    if ( this.isModified )
      this.setValue("");
    if ( this.value.length < 1 && this.isNotClick ) 
      return ;  
     var lct = document.getElementById('pjid1').value;
    return "AutoComLocation.php?pjid="+lct+"&q=" +(this.value); //ตรงนี้สำคัญมากครับ หากdatabase เป็น UTF-8 จะใช้ +encodeURIComponent +(this.value); แต่ถ้าเป็น tis-620 ต้องเป็น +(this.value); ครับ 

    }); 
} 
</script>
<div id="t3">
<table border="0"  width="100%" align="center">
  <tr>
    <td align="right" width="10%">ชื่อสินค้า :</td>
    <td align="left" width="20%"><input type="text" class="fm" id="pname3"><input type="hidden" id="pid3" value="0"></td>
    <td align="right" width="10%">โครงการ :</td>
    <td align="left" width="20%"><input type="text" class="fm" id="pjname1" ><input type="hidden" id="pjid1" ></td>
    <td align="right" width="10%">สถานที่ :</td>
    <td align="left" width="20%"><input type="text" class="fm" id="loname1" ><input type="hidden" id="loid1"></td>
    <td align="center"><button id="btn3" class="btn btn-info">ตกลง</button></td>
  </tr>
</table>

<script type="text/javascript">
  $(function(){
     
        $('#_image_1').click(function(){
         
          $('#pjid1').val('');
          $('#loid1').val('');
          $('#loname1').val('');
      });
  });
</script>
<script type="text/javascript">
  $(function(){
      $('#loname1').keypress(function(){
        var pjcode = $('#pjid1').val();
        if (pjcode == '') {
        alert('กรุณากรอกข้อมูลโครงการให้ถูกต้อง');
        $('#pjname1').val('');
        $('#pjname1').focus();}});});
</script>
<script type="text/javascript">make_autocom5("loname1","loid1");</script>
<script type="text/javascript">make_autocom4("pjname1","pjid1");</script>
<script type="text/javascript">make_autocom3("pname3","pid3");</script>
<script type="text/javascript">
  $(function(){
      $('#btn3').click(function(){
        var t = 'rp3';
        var pid = $('#pid3').val();  
        var bcode = $('#bc3').val(); 
        var loid = $('#loid1').val();  
        var pjid = $('#pjid1').val();
        var v1 = $('#pjname1').val();
        var v2 = $('#loname1').val();

          if (v1 == '') 
          {
              alert('กรุณากรอกข้อมูลโครงการให้ถูกต้อง');
          }
          else if(v2 == '')
          { 
              alert('กรุณากรอกข้อมูลสถานที่ให้ถูกต้อง');
          }
          else{
              //window.open("http://localhost/report/default.aspx?pid="+pid+"&type="+t+"&pjid="+pjid+"&loid="+loid);
              window.open("http://192.168.1.101/wb/default.aspx?pid="+pid+"&type="+t+"&pjid="+pjid+"&loid="+loid);
              }

              
            });});
          

        
</script>
</div>

</body>
</html>