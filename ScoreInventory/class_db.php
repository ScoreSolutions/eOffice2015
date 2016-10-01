<?

	$sv = "localhost";
	$us = "root";
	$pw = "1234";
	$dbn = "Inventory";
	class Class_DB
	{	

		private $result;
		public function __construct($sv,$us,$pw,$dbn)
		{
			mssql_connect($sv,$us,$pw,$dbn) or die("Error Connect to Database");
			mssql_select_db("Inventory");
		}
		public function showEmail($sql)
		{
			$this->result = mssql_query($sql);
		}
	}

?>