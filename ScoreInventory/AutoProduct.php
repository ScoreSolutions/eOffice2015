<!DOCTYPE html>
<html>
<head>
  <title></title>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>

</body>
</html>

<?
  include_once("connect.php");


  $txt = $_POST["PN"];
  #$txt = iconv("UTF-8","tis-620", $txt);

  $sql = "SELECT p.id,p.product_name,p.product_desc as pd,u.unit_name,t.type_name
          FROM M_PRODUCT p
          left join M_UNIT u
          on u.id=p.unit_id
          left join M_TYPE t
          on t.id=p.type_id
          WHERE p.id = '".$txt."'";


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
  mssql_close($objConnect);

  echo json_encode($resultArray);


?>

