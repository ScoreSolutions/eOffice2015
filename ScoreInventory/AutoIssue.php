<!DOCTYPE html>
<html>
<head>
  <title></title>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="js/autocomplete.js"></script>
  <link rel="stylesheet" href="css/autocomplete.css"  type="text/css"/>
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

<?php
	include_once("connect.php");
	$txt = $_POST['optReqNo'];



	$strSQL = "SELECT tr.CreateDate,tr.req_no,tr.location_id,p.product_name,trd.qty,l.location_name,
                    pj.project_name,u.unit_name,t.type_name,trd.id as reqid,pj.id as pjid,re.remark_desc,re.id as reid
                    FROM TS_REQUEST tr
                    left join TS_REQUEST_DETAIL trd on trd.req_id=tr.req_no
                    left join M_PRODUCT p on p.id=trd.product_id
                    left join M_LOCATION l on l.id=tr.location_id
                    left join M_PROJECT pj on pj.id=l.project_id
                    left join M_UNIT u on u.id=p.unit_id
                    left join M_TYPE t on t.id=p.type_id
                    left join M_REMARK re on re.id=tr.remark_id
                    where req_no = '".$txt."'";
    $k=1;
    $objQuery  = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
    $objQuery2 = mssql_query($strSQL) or die ("Error Query [".$strSQL."]");
    while($Rq = mssql_fetch_array($objQuery2))
    { 
        $pjid = $Rq['pjid'];
        $pj = $Rq['project_name'];
        $pj = iconv("tis-620","UTF-8", $pj);
        $lcid = $Rq['location_id'];
        $lc = $Rq['location_name'];
        $lc = iconv("tis-620","UTF-8", $lc);
        $reid = $Rq['reid'];
        $remark = $Rq['remark_desc'];
        $remark = iconv("tis-620","UTF-8", $remark);
        
    $k = $k+1;}




    
    echo '<div align="center"><label>โครงการ : <font color="blue">'.$pj."</font>&nbsp&nbsp&nbspสถานที่ : <font color='blue'>".$lc.'</font>&nbsp&nbsp&nbspหมายเหตุ : <font color="blue">'.$remark.'</font></label></div>';
    echo '<table border="0" width="100%">';
    echo '<tr>';
    echo '<td align="left"><button class="btn btn-info" id="btnOK" onclick="Test();">บันทึก</button></td>';
    echo '</tr>';
    echo '</table>';
    echo '<table border="0" width="100%" class="order-list table table hover">';
    echo '<tr>';
    echo '<td align="center"></td>';
    echo '<td align="center"><b>ชื่อสินค้า</b></td>';
    echo '<td align="center"><b>หน่วย</b></td>';
    echo '<td align="center"><b>ชนิด</b></td>';
    echo '<td align="center"><b>จำนวน</b></td>';
    echo '<td align="center"><b>จำนวนที่จ่ายแล้ว'.$total123.'</b></td>';
    echo '<td align="center"><b>จ่ายสินค้า</b></td>';
  	echo '</tr>';



    $i = 1;
    while($Rrd = mssql_fetch_array($objQuery))
    {
    		$rno   = $Rrd["req_no"];
    		$reqid = $Rrd["reqid"];
    		$qty   = $Rrd["qty"];
        $pname = $Rrd["product_name"];
        $pname = iconv("tis-620","UTF-8", $pname);
        $runit = $Rrd["unit_name"];
        $runit = iconv("tis-620","UTF-8", $runit);
        $rtype = $Rrd["type_name"];
        $rtype = iconv("tis-620","UTF-8", $rtype);



                      $sql4 = "SELECT qty,req_id,rd.product_id, COUNT(st.barcode_pk) stockout_qty
                    FROM [TS_REQUEST_DETAIL] rd
                    left join (select b.barcode_pk,pd.Product_id 
                    fROM TS_STOCK_OUT a left join ts_stock_out_detail b 
                    on a.stockout_code=b.stockout_id
                    inner join TS_PRODUCT_ITEM pd 
                    on pd.Barcode=b.barcode_pk
                    where req_id='$rno') st 
                    on st.Product_id=rd.product_id
                     where rd.id = $reqid and req_id = '$rno'
                    group by rd.id,qty,req_id,rd.product_id";

             $objQuery4 = mssql_query($sql4) or die ("Error Query [".$sql4."]");
             while($rsql4 = mssql_fetch_array($objQuery4))
             {
                $qtyeds = $rsql4['stockout_qty'];
                $qty = $rsql4['qty'];
             }
?>
<script type="text/javascript">
  $(function  () {
    var c111 = 0;
    var k1 = <? echo json_encode($i) ?>;
    $("#btnOK").focus(function(){
        s1 = $("#s1"+k1).val();
        s2 = $("#s2"+k1).val();
        if (s1==s2) {
          //alert('YES');
          $("#cntNo").val('1');
        }
        else {
         // alert('NO')
          $("#cntNo").val('0');
        };
      }
      );

    $('#delete'+k1).click(function(){
        s1 = $("#s1"+k1).val();
        s2 = $("#s2"+k1).val();
        if (s1==s2) {
            alert('จ่ายสินค้าครบแล้ว !!!');
        }
        else{
                //$("#delete"+k1).click(function(){

                  $("#R2"+k1).modal();
                  //});
        }
    });
  });

  function Test(){
    var counts = document.getElementById('cntNo').value;
    var reqno = <? echo json_encode($rno) ?>;
     if (counts==1){
      window.location='EditStatusReq.php?reqno='+reqno;
    }else{
      alert('ยังจ่ายเอกสารไม่ครบ ไม่สามารถบึนทึกการจ่ายออกได้');
    };
  }
</script>



<script type="text/javascript">


    $(function  () {
    var qty = <? echo json_encode($qty) ?>;
    var qtyed = <? echo json_encode($qtyeds) ?>;
    var i3 = <? echo json_encode($i) ?>;
    $("#btnSub"+i3).click(function(){
        inum = $("#bc"+i3).val();
        lcid = $("#lcid").val();
        pjid = $("#pjid").val();
        rno = $("#rno").val();
        pid = $("#pid"+i3).val();
        window.location='AddIssue.php?bc='+inum+'&lcid='+lcid+'&pjid='+pjid+'&rno='+rno+'&pid='+pid+'&qty='+qty+'&qtyed='+qtyed;
      }
      );});

    </script>

<?	

            
            
            
           	echo '<tr class="parent" id="row123'.+$i.'">';
            echo '<td align="center"><input type="hidden" class="fmmodal"  value="'.$reqid.'" id="pid'.+$i.'"  readonly><input type="hidden" class="fmmodal"  value="0" id="cntNo"  readonly></td>';
            echo '<td align="center">'.$pname.'</td>';
            echo '<td align="center">'.$runit.'</td>';
            echo '<td align="center">'.$rtype.'</td>';
            echo '<td align="center"><span class="badge" >'.$qty.'</span><input id="s1'.+$i.'" type="hidden" value="'.$qty.'"></td>';
            echo '<td align="center"><span class="badge" >'.$qtyeds.'</span><input id="s2'.+$i.'" type="hidden" value="'.$qtyeds.'"></td>';
            echo '<td align="center"><a id="delete'.$i.'" class="cursor"><span class="glyphicon glyphicon-upload"></span></a></td>';
            echo '</tr>';
 ?>

<script type="text/javascript">
	$(document).ready(function(){
	var ni = <? echo json_encode($i) ?>;
	$("#bc"+ni).change(function(){
			$.ajax({ 
				url: "AutoBarcode2.php" ,
				type: "POST",
				data: 'bc=' +$("#bc"+ni).val()+'&reqid='+$("#pid"+ni).val()
			})
			.success(function(result) { 

				var obj = jQuery.parseJSON(result);
				
					if(obj == '')
					{
						alert('ไม่พบบาร์โค้ดนี้ในคลังสินค้า');
						$("#bc"+ni).focus();
            $("#bc"+ni).val('');
            $("#pname"+ni).val('');
						$("#desc"+ni).val('');
						$("#unit"+ni).val('');
						$("#type"+ni).val('');
					}
					else
					{
						  $.each(obj, function(key, inval) {

							   $("#bc"+ni).val(inval["Barcode_pk"]);
							   $("#pname"+ni).val(inval["product_name"]);
							   $("#desc"+ni).val(inval["product_desc"]);
							   $("#unit"+ni).val(inval["unit_name"]);
							   $("#type"+ni).val(inval["type_name"]);
						  });
					}

			});

		});
	});
</script>


    <div class="modal fade bs-modal-lg" id=<? echo "R2".+$i; ?>>
    <div class="modal-dialog modal-lg">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel">ข้อมูลสินค้า</h4>
      </div>
      <div class="modal-body"><div><p><input type="hidden" class="fmmodal" id="pjid" value="<?=$pjid?>" readonly></p>
      <p><input type="hidden" class="fmmodal"  value="<?=$lcid?>" id='lcid' readonly></p>
      <p><input type="hidden" class="fmmodal"  value="<?=$reqid?>" id="<? echo "pid".+$i; ?>" readonly></p>
      <p><input type="hidden" class="fmmodal"  value="<?=$rno?>" id="rno" readonly></p>
      <p><input type="hidden" class="fmmodal"  value="<?=$remark?>" id="remark" readonly></p></div>
        <div class="panel panel-primary" style="width:25%;">
      <div class="panel-heading">
        <h3 class="panel-title" align="center">บาร์โค้ดคำแนะนำ</h3>
      </div>
      <div class="panel-body" style="padding:2px;">
        <ul class="list menu">
        <?
          $sql3 = "SELECT TOP 5 oh.Barcode_pk,id.SerialNO,mp.product_name,mp.product_desc,u.unit_name,
                   t.type_name,trd.id,wa.ws_name,re.remark_desc
                   FROM TS_STOCK_ON_HAND oh
                   left join TS_PRODUCT_ITEM p on p.Barcode=oh.Barcode_pk
                   left join M_PRODUCT mp on mp.id=p.Product_id
                   left join M_UNIT u on u.id=mp.unit_id
                   left join M_TYPE t on t.id=mp.type_id
                   left join TS_STOCK_IN_DETAIL id on id.Barcode_pk=p.Barcode
                   left join TS_REQUEST_DETAIL trd on mp.id=trd.product_id
                   left join M_WAREHOUSE wa on wa.id=oh.ws_id
                   left join M_REMARK re on re.id=wa.remark_id
                   where trd.id = '$reqid' and wa.remark_id = '$reid'  ORDER BY oh.CreateDate";
          $i2 = 1;
          $Qsql3 = mssql_query($sql3) or die ("Error Query [".$sql3."]"); 

          while($RQ3 = mssql_fetch_array($Qsql3)){
            $Barcode_pk = $RQ3['Barcode_pk'];
        ?>
          <li><? echo $i2.". ".$Barcode_pk; ?></li>
        <?
            $i2 = $i2+1;}
        ?>
        </ul>
      </div>
    </div>
    <div class="panel panel-default" style="padding-top:1.5%;padding-right:0.8%;">
    <div class="Row">
        <div class="Cell"><p><input type="text" class="fmmodal" id="<? echo "bc".+$i; ?>" value="บาร์โค้ด" onfocus="this.value=''" onblur="this.value='บาร์โค้ด'" required></p></div>
        <div class="Cell"><p><input type="text" class="fmmodal" id="<? echo "pname".+$i; ?>" value="ชื่อสินค้า" onchange="this.value=''" readonly></p></div>
        <div class="Cell"><p><input type="text" class="fmmodal" id="<? echo "desc".+$i; ?>" value="รายละเอียด" onchange="this.value=''" readonly></p></div>
        <div class="Cell"><p><input type="text" class="fmmodal" id="<? echo "unit".+$i; ?>"  value="หน่วย" onchange="this.value=''" readonly></p></div>
        <div class="Cell"><p><input type="hidden" class="fmmodal"  value="<?=$i?>" name="<? echo "num".+$i; ?>" id="<? echo "num".+$i; ?>" readonly></p></div>
        <div class="Cell"><p><input type="text" class="fmmodal" id="<? echo "type".+$i; ?>" value="ประเภท" onchange="this.value=''" readonly></p></div>
    </div>
    </div>
      </div>
      <div align="center">    
        <button type="submit" id="<? echo "btnSub".+$i; ?>" class="btn btn-primary" onclick="mClick();">ยืนยัน</button>
      </div>
    </div>  
    </div>
    </div>

        <script type="text/javascript">

    </script>

 <?
   $i = $i+1;}
   echo "</table>";
?>

</body>
</html>

