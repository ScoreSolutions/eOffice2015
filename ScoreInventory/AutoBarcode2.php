

<?
include_once("connect.php");

  $txt = $_POST["bc"];
  $reqid = $_POST["reqid"];

  $sql = "  SELECT oh.Barcode_pk,id.SerialNO,mp.product_name,mp.product_desc,u.unit_name,t.type_name,
                   trd.id
             FROM TS_STOCK_ON_HAND oh
             left join TS_PRODUCT_ITEM p
             on p.Barcode=oh.Barcode_pk
             left join M_PRODUCT mp
             on mp.id=p.Product_id
             left join M_UNIT u
             on u.id=mp.unit_id
             left join M_TYPE t
             on t.id=mp.type_id
             left join TS_STOCK_IN_DETAIL id
             on id.Barcode_pk=p.Barcode
             left join TS_REQUEST_DETAIL trd
             on mp.id=trd.product_id 
             where oh.Barcode_pk = '$txt' and  trd.id = '$reqid' ";
          $sqlQuery = mssql_query($sql) or die("Error Query [".$sql."]");
          $numf = mssql_num_fields($sqlQuery);
          $resultArray = array();
          while ($result = mssql_fetch_array($sqlQuery)) 
          { 
          $arrCol = array();
          for ($i=0; $i < $numf; $i++) 
          { 
          $a = mssql_field_name($sqlQuery,$i);
          $arrCol[$a] = $result[$i];
          $arrCol[$a] = iconv("tis-620","UTF-8", $arrCol[$a]);
          }
          array_push($resultArray, $arrCol);
          }
          echo json_encode($resultArray);

  ?>