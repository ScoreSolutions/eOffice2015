<?
$objConnect = mssql_connect("ScoreDb01","sa","1qaz@WSX") or die("Error Connect to Database");
$objDB = mssql_select_db("Inventory");

#$objConnect = mssql_connect("localhost","sa","1234") or die("Error Connect to Database");
#$objDB = mssql_select_db("Inventory");



?>