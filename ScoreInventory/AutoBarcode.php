

<?
  include_once("connect.php");


  $txt = $_POST["BC"];

  $csql = "SELECT td.Barcode_pk FROM TS_STOCK_IN_DETAIL td
           inner join TS_STOCK_OUT_DETAIL ti on ti.Barcode_pk = td.Barcode_pk 
           WHERE td.Barcode_pk = '".$txt."' or  ti.Barcode_pk = '".$txt."'";

  $Qcheck = mssql_query($csql) or die("Error Query [".$csql."]");

  $cr = mssql_fetch_object($Qcheck);



  if ($cr > 0) {
    echo json_encode('1');

  }
  else
  {
          $sql = "SELECT pd.Barcode,mp.product_name,mp.product_desc,u.id as uid,u.unit_name,t.id as tid,t.type_name
          From TS_PRODUCT_ITEM as pd
          left join M_PRODUCT mp on mp.id=pd.Product_id
          left join M_UNIT u on u.id=mp.unit_id
          left join M_TYPE t on t.id=mp.type_id 
          where pd.Barcode = '".$txt."'";
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

}
  mssql_close($objConnect);
?>

