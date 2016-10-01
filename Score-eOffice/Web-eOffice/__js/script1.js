<!--
var mydate=new Date()
var year=mydate.getYear()
if (year < 1000)
year+=1900
var day=mydate.getDay()
var month=mydate.getMonth()+1
if (month<10)
month="0"+month
var daym=mydate.getDate()
if (daym<10)
daym=daym//"0"+

//LCD Clock script- by javascriptkit.com
//Visit JavaScript Kit (http://javascriptkit.com) for script
//Credit must stay intact for use
/*
var alternate=0
var standardbrowser=!document.all&&!document.getElementById

if (standardbrowser)
//document.write('<form name="tick"><input type="text" name="tock" size="11"></form>')

function show(){
if (!standardbrowser)
var clockobj=document.getElementById? document.getElementById("digitalclock") : document.all.digitalclock
var Digital=new Date()
var hours=Digital.getHours()
var minutes=Digital.getMinutes()
var dn="AM"

if (hours==12) dn="PM" 
if (hours>12){
dn="PM"
hours=hours
}
if (hours==0) hours=12
if (hours.toString().length==1)
hours="0"+hours
if (minutes<=9)
minutes="0"+minutes

if (standardbrowser){
if (alternate==0)
document.tick.tock.value=hours+" : "+minutes+" "+dn
else
document.tick.tock.value=hours+"   "+minutes+" "+dn
}
else{
if (alternate==0)
clockobj.innerHTML=hours+"<font color='lime'>&nbsp;:&nbsp;</font>"+minutes+" "+"<sup style='font-size:1px'>"+dn+"</sup>"
else
clockobj.innerHTML=hours+"<font color='#000066'>&nbsp;:&nbsp;</font>"+minutes+" "+"<sup style='font-size:1px'>"+dn+"</sup>"
}
clockobj.innerHTML="<font color='000000' bold 16px MS Sans Serif><b>"+daym+"-"+month+"-"+year+" </b></font><br><br>"+clockobj.innerHTML
alternate=(alternate==0)? 1 : 0
setTimeout("show()",1000)
}
window.onload=show

//-->
*/

/*
Drop Down World Clock- By JavaScript Kit (http://www.javascriptkit.com)
Portions of code by Kurt @ http://www.btinternet.com/~kurt.grigg/javascript
This credit notice must stay intact
*/

if (document.all||document.getElementById)
//document.write('<span id="worldclock" style="font:bold 16px Arial;"></span><br>')

zone=0;
isitlocal=true;
ampm='';

function updateclock(z){
zone=z.options[z.selectedIndex].value;
isitlocal=(z.options[0].selected)?true:false;
}

function WorldClock(){
now=new Date();
ofst=now.getTimezoneOffset()/60;
secs=now.getSeconds();
sec=-1.57+Math.PI*secs/30;
mins=now.getMinutes();
min=-1.57+Math.PI*mins/30;
hr=(isitlocal)?now.getHours():(now.getHours() + parseInt(ofst)) + parseInt(zone);
hrs=-1.575+Math.PI*hr/6+Math.PI*parseInt(now.getMinutes())/360;
if (hr < 0) hr+=24;
if (hr > 23) hr-=24;
ampm = (hr > 11)?"PM":"AM";
statusampm = ampm.toLowerCase();

hr2 = hr;
if (hr2 == 0) hr2=12;
(hr2 < 13)?hr2:hr2 %= 12;
if (hr2<10) hr2="0"+hr2

var finaltime=hr2+':'+((mins < 10)?"0"+mins:mins)+':'+((secs < 10)?"0"+secs:secs)+' '+statusampm;

if (document.all)
worldclock.innerHTML="<font color='000000' bold 16px MS Sans Serif><b> "+daym+" : "+month+" : "+year+" </b></font><br><br>"+finaltime
else if (document.getElementById)
document.getElementById("worldclock").innerHTML=finaltime
else if (document.layers){
document.worldclockns.document.worldclockns2.document.write(finaltime)
document.worldclockns.document.worldclockns2.document.close()
}


setTimeout('WorldClock()',1000);
}

window.onload=WorldClock
//-->
