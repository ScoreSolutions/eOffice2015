<?php
    session_start();
    ini_set("session.cookie_lifetime","3600");
    include_once("connect.php");
    $ses_userid =$_SESSION[ses_userid];
    $ses_username = $_SESSION[ses_username];
    if($ses_userid <> session_id() or  $ses_username ==””)
    {
        echo "<script>";
        echo "alert('โปรดลงชื่อเข้าสู่ระบบก่อน');";
        echo "window.location.href='index.php';";
        echo "</script>";
    } 

    $val = $_SESSION[ses_userid];

    if(!isset($val))
    {
        echo "<script>";
        echo "alert('โปรดลงชื่อเข้าสู่ระบบก่อน');";
        echo "window.location.href='index.php';";
        echo "</script>";
    }
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
<link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script type="text/javascript" src="js/bootstrap-popover.js"></script>
<script type="text/javascript" src="js/bootbox.min.js"></script>
<script src="js/jquery-1.11.1.min.js"></script>

</head>
<body>
    <?php
    $$ses_username= iconv("WINDOWS-874","UTF-8", $ses_username); 
    $result = mssql_query("select * from M_USER where username ='$_SESSION[ses_username]' ");
    while ($data = mssql_fetch_array($result) ) 
    {
        $name = $data[username];
        $fname = $data[first_name];
        $lname = $data[last_name];
        $fname= iconv("tis-620","UTF-8", $fname);

        $lname= iconv("tis-620","UTF-8", $lname);  
        $gid = $data[group_id];
    
    }
 ?>
	<div class="navbar navbar-fixed-top header">
        <h3 style="margin-left:40px; font-family:Tahoma; font-weight:bold; color:#FFF;">
        ระบบจัดการอุปกรณ์ที่ใช้ในการพัฒนาโครงการ
        <a href="logout.php?user=<?=$name?>" onclick="return confirm('ต้องการออกจากระบบใช่หรือไม่ !!!')"><button class="btn-sm btn-default mybtn"><span class="glyphicon glyphicon-off"></span> ลงชื่อออกจากระบบ</button></a>

        <div class="mybtn2"><h4><?php echo $fname," ",$lname; ?></h4></div>

        </h3>
    

    </div>
    
    <div class="container-fluid">
        <div class="sidebar">
        	<ul class="list menu">


            <? 
               $t = $_GET['page'];
               if ($t == 'Homes') {
                   
               $urlhome = "img/MuneMain/bt_active/bt_homeactive.png"; 
            ?>
                <li>
                    <a href="Home.php?page=Homes" class="HomeImg">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/bt_homeactive.png'"  />
                    </div>
                    </a>
                </li>
            <?}
                else{
                    $urlhome = "img/MuneMain/bt_home.png"; 
            ?>
                <li>
                    <a href="Home.php?page=Homes" class="HomeImg">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/bt_homeactive.png'" onmouseout="this.src='img/MuneMain/bt_home.png'" />
                    </div>
                    </a>
                </li>
            <?       
                }
            ?>

            <? 
               if($gid=='1' or $gid=='3'){
               if ($t == 'standardUnit') {
                   
               $urlhome = "img/MuneMain/bt_active/btactive_01.png"; 
            ?>
            	<li>
                    <a href="Home.php?page=standardUnit" >
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_01.png'"  />
                    </div>
                    
                    </a>
                </li>
            <?}
                else{
                    $urlhome = "img/MuneMain/bt_01.png"; 
            ?>

                <li>
                    <a href="Home.php?page=standardUnit" >
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_01.png'" onmouseout="this.src='img/MuneMain/bt_01.png'" />
                    </div>
                    
                    </a>
                </li>
            <?       
                }}
            ?>    


            <? 
               if($gid=='1' or $gid=='3'){
               if ($t == 'ManageStock') {
                   
               $urlhome = "img/MuneMain/bt_active/btactive_03.png"; 
            ?>
                 <li>
                    <a href="Home.php?page=ManageStock&Type=1">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_03.png'" />
                    </div>
                    </a>
                </li>
            <?}
                else{
                    $urlhome = "img/MuneMain/bt_03.png"; 
            ?>
                <li>
                    <a href="Home.php?page=ManageStock&Type=1">
                    <div>
                    <img src="img/MuneMain/bt_03.png" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_03.png'" onmouseout="this.src='img/MuneMain/bt_03.png'"/>
                    </div>
                    </a>
                </li>
            <?       
                }}
            ?>  





                <?php  
                        if($gid=='1' or $gid=='9'){ 
                        if ($t == 'Request') {
                        $urlhome = "img/MuneMain/bt_active/btactive_04.png"; 
                ?>
               <li>
                    <a href="Home.php?page=Request&Type=1">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_04.png'" />
                    </div>
                    </a>
                </li>
                <?}
                else{
                    $urlhome = "img/MuneMain/bt_04.png"; 
                ?>
                <li>
                    <a href="Home.php?page=Request&Type=1">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_04.png'" onmouseout="this.src='img/MuneMain/bt_04.png'" />
                    </div>
                    </a>

                </li>
                <? }} ?>
                 
            







                <? 
                    $t = $_GET['page'];
                    if ($t == 'Report') {
                    $urlhome = "img/MuneMain/bt_active/btactive_07.png"; 
                ?>
            	<li>
                	<a href="Home.php?page=Report" id="btn-more">
					<div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_07.png'" />
					</div>
				    </a>
                </li>
                <?}
                    else{
                    $urlhome = "img/MuneMain/bt_07.png"; 
                ?>
                <li>
                    <a href="Home.php?page=Report" id="btn-more">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_07.png'" onmouseout="this.src='img/MuneMain/bt_07.png'" />
                    </div>
                    </a>
                </li>
                <?       
                }
                ?>  





                
                <?php  if($gid=='1')
                        { 
                            if ($t == 'UserGroup') {
                            $urlhome = "img/MuneMain/bt_active/btactive_02.png"; 
                ?>
                <li>
                    <a href="Home.php?page=UserGroup&Type=1">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_02.png'"  />
                    </div>
                    </a>
                </li>
                <?}
                    else{
                    $urlhome = "img/MuneMain/bt_02.png"; 
                ?>
                <li>
                    <a href="Home.php?page=UserGroup&Type=1">
                    <div>
                    <img src="<?=$urlhome?>" id="mainmenu" onmouseover="this.src='img/MuneMain/bt_active/btactive_02.png'" onmouseout="this.src='img/MuneMain/bt_02.png'" />
                    </div>
                    </a>
                </li>
                <? }} ?>
                

            </ul>
        </div>



        <?php
        
        $Type = $_GET['Type'];


        include $_GET['page'].".php";


        
        ?>







       </div>




 
</body>
</html>

