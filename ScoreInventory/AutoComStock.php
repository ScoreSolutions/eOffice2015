<?php 
header("Content-type:text/html; charset=tis-620"); 
header("Cache-Control: no-store, no-cache, must-revalidate"); 
header("Cache-Control: post-check=0, pre-check=0", false); 
include_once("connect.php");
$q = urldecode($_GET["q"]);
$q= iconv('utf-8', 'tis-620', $q);
mb_http_input('tis-620');
mb_language('uni');
ob_start('mb_output_handler');
$sql = "SELECT id,ws_name from M_WAREHOUSE  where ws_name like '%$q%' ORDER BY ws_name desc";
$results = mssql_query($sql);

while ($row = mssql_fetch_array( $results )) {
$id = $row["id"];
$name =$row["ws_name"];
$name = str_replace("'", "'", $name);
$display_name = preg_replace("/(" . $q . ")/i", "<b>$1</b>", $name);
echo "<li onselect=\"this.setText('$name').setValue('$id');\">$display_name</li>";
}

mssql_close();
?>