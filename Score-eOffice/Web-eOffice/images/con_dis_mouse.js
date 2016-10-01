
var list = new Array("/index/","/index/");

function _disableselect(e){
	return false
}

function _reEnable(){
	return true
}

isProtected = true;
for(i=0;i<list.length;i++)
{
	if (location.pathname.substring(0,list[i].length) == list[i]) isProtected = false;
}
//if IE4+
if (isProtected)
{
	document.onselectstart=new Function ("return false")

	//if NS6
	if (window.sidebar){
		document.onmousedown=_disableselect
		document.onclick=_reEnable
	}
}


