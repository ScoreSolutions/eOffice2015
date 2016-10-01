	function toUpper(obj, e){
		obj.value=obj.value.toUpperCase();
		return true;
	}
	function validateAlpha(obj,e) {
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isAlpha(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}

	function validateNumeric(obj,e) {
	    alert(e.keyCode);
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isNumeric(e.keyCode)) { return true; }
		if (isMinusChar(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}
	function validateNumericOnly(obj,e) {
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isNumeric(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}
	
	function validateAlphaNumeric(obj,e) {
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isAlpha(e.keyCode)) { return true; }
		if (isNumeric(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}

	function validateGeneral(obj,e) {
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isDoubleQuote(e.keyCode)) {
			e.keyCode = 0;
			return false;
		}
		return true;
	}

	function validateEmail(obj,e) {
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isAlpha(e.keyCode)) { return true; }
		if (isNumeric(e.keyCode)) { return true; }
		if (isDecimalPlace(e.keyCode)) { return true; }
		if (isAtSign(e.keyCode)) { return true; }
		if (isUnderscore(e.keyCode)) { return true; }
		if (isMinusChar(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}
	function validateFileName(obj,e) {
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isAlpha(e.keyCode)) { return true; }
		if (isNumeric(e.keyCode)) { return true; }
		if (isDecimalPlace(e.keyCode)) { return true; }
		//if (isAtSign(e.keyCode)) { return true; }
		if (isUnderscore(e.keyCode)) { return true; }
		if (isMinusChar(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}
	function validateURL(obj,e) {
		if (e.keyCode==13) { return true; }
		if (e.type!="keypress") { return true; }
		if (isAlpha(e.keyCode)) { return true; }
		if (isNumeric(e.keyCode)) { return true; }
		if (isDecimalPlace(e.keyCode)) { return true; }
		if (isUnderscore(e.keyCode)) { return true; }
		if (isForwardSlash(e.keyCode)) { return true; }
		if (isColon(e.keyCode)) { return true; }
		if (isMinusChar(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}

	function validateDecimal(obj,e) {
		//if (e.keyCode==13) { return false; }
		if (e.type!="keypress") { return true; }
		if (isNumeric(e.keyCode)) { return true; }
		if (isDecimalPlace(e.keyCode)) { return true; }
		if (isMinusChar(e.keyCode)) { return true; }
		e.keyCode = 0;
		return false;
	}

	function isAlpha(myKeyCode) {
		if (myKeyCode >= 97 && myKeyCode <= 122) {
			return true;
		}
		if (myKeyCode >=65 && myKeyCode <=90) {
			return true;
		}
		return false;
	}

	function isNumeric(myKeyCode) {
		if (myKeyCode >= 48 && myKeyCode <=57) {
			return true;
		}
		return false;
	}

	function isDecimalPlace(myKeyCode) {
		if (myKeyCode == 46) { return true; }
		return false;
	}

	function isDoubleQuote(myKeyCode) {
		if (myKeyCode == 34) { return true; }
		return false;
	}

	function isAtSign(myKeyCode) {
		if (myKeyCode == 64) { return true; }
		return false;
	}

	function isUnderscore(myKeyCode) {
		if (myKeyCode == 95) { return true; }
		return false;
	}

	function isForwardSlash(myKeyCode) {
		if (myKeyCode == 47) { return true; }
		return false;
	}

	function isColon(myKeyCode) {
		if (myKeyCode == 58) { return true; }
		return false;
	}
	
	function isSemiColon(myKeyCode) {
		if (myKeyCode == 59) { return true; }
		return false;
	}	

	function isMinusChar(myKeyCode) {
		if (myKeyCode == 45) { return true; }
		return false;
	}
	
	function isAmp(myKeyCode) {
		if (myKeyCode == 38) { return true; }
		return false;
	}
	
	function isEquals(myKeyCode) {
		if (myKeyCode == 61) { return true; }
		return false;
	}

	function conf(myText){
		return confirm(myText);
	}
function trim(inputString) {
   // Removes leading and trailing spaces from the passed string. Also removes
   // consecutive spaces and replaces it with one space. If something besides
   // a string is passed in (null, custom object, etc.) then return the input.
   if (typeof inputString != "string") { return inputString; }
   var retValue = inputString;
   var ch = retValue.substring(0, 1);
   while (ch == " ") { // Check for spaces at the beginning of the string
      retValue = retValue.substring(1, retValue.length);
      ch = retValue.substring(0, 1);
   }
   ch = retValue.substring(retValue.length-1, retValue.length);
   while (ch == " ") { // Check for spaces at the end of the string
      retValue = retValue.substring(0, retValue.length-1);
      ch = retValue.substring(retValue.length-1, retValue.length);
   }
   while (retValue.indexOf("  ") != -1) { // Note that there are two spaces in the string - look for multiple spaces within the string
      retValue = retValue.substring(0, retValue.indexOf("  ")) + retValue.substring(retValue.indexOf("  ")+1, retValue.length); // Again, there are two spaces in each of the strings
   }
   return retValue; // Return the trimmed string back to the user
} // Ends the "trim" function

function NewWindow(winname,file,w,h) {
	var lp = (screen.width) ? (screen.width-w)/2 : 0;
	var tp = (screen.height) ? (screen.height-h)/2 : 0;
window.open(file,winname,'width='+w+',height='+h+',toolbar=0,location=0,status=0,menubar=0,scrollbars=auto,resizeable=yes,left='+lp+',top='+tp+' ');
}

function roundNumber(argNum, argDec) {
	var numberField = argNum;
	if (isNaN(numberField)) numberField=0;
	var rlength = argDec; // The number of decimal places to round to
	if (isNaN(rlength))  rlength=2;
	var newnumber = Math.round(numberField*Math.pow(10,rlength))/Math.pow(10,rlength);
	return newnumber;
}

function ShowHide(argID){
	var fncTemp=document.getElementById(argID);
	if (fncTemp.style.display=='' || fncTemp.style.display=='none'){
		fncTemp.style.display='inline';
		self.location.href='#'+argID+"Anchor"
	}else{
		fncTemp.style.display='none';
	}
	return true;
}

	function validateEnglish(obj,e) {
		if (e.keyCode<3585 || e.keyCode>3673) { return true; }
		e.keyCode = 0;
		return false;
	}
	
		function validateThai(obj,e) {
		//alert(e.keyCode);
		if (e.keyCode>=3585 && e.keyCode<=3673 || e.keyCode>=48 && e.keyCode<=57) { return true; }
		e.keyCode = 0;
		return false;
	}

function ValidRightClick(e) {
    if (navigator.appName == 'Netscape' && e.which == 3) {
        alert("no right click please");
        return false;
    }
    else {
        if (navigator.appName == 'Microsoft Internet Explorer' && event.button == 2)
        alert("no right click please");
        return false;
    }
    return true;
}


function CheckKeyBackSpace(e) {
//ป้องกันการกดปุ่ม Delete , ปุ่ม Backspace , ปุ่ม ctrl และปุ่มตัว V
    //var keyCode = (event.which) ? event.which : event.keyCode;
    
    var evt = e ? e : window.event;
    var keyCode = evt.keyCode;
    if ((keyCode == 8) || (keyCode == 46) || (keyCode == 17) || (keyCode == 86)) {
        if(window.event){//IE
            var ieVersion = parseFloat(navigator.appVersion);
            //alert(ieVersion);
            if(ieVersion==5)  //IE 9, 10
                e.preventDefault();
            else if(ieVersion==4)  //IE 7,8
                event.returnValue = false;
        }else if(e){//Firefox
            e.preventDefault();
        }
    }
}


function txtKeyPress(e) {
    if(window.event){//For IE
        var ieVersion = parseFloat(navigator.appVersion);
        //alert(ieVersion);
        if(ieVersion==5)  //IE 9, 10
            e.preventDefault();
        else if(ieVersion==4)  //IE 7,8
            event.returnValue = false;
    }else if(e)//For Firefox
        e.preventDefault();
}

function txtTime_OnKeyPress(sender,e) {
    var evt = e ? e : window.event;
    var charCode = evt.keyCode || evt.charCode;

    //var charCode = (event.which) ? event.which : event.keyCode
    //alert(charCode);
    if ((charCode != 8) && (charCode != 46)) {
        
        var myTime = sender.value;
        if (myTime.length > 4) {
            if(window.event){//IE
                var ieVersion = parseFloat(navigator.appVersion);
                //alert(ieVersion);
                if(ieVersion==5)  //IE 9, 10
                    e.preventDefault();
                else if(ieVersion==4)  //IE 7,8
                    event.returnValue = false;
            }else if(e){//Firefox
                e.preventDefault();
            }
        }

        switch (myTime.length) {
            case 0:
                if (charCode < 48 || charCode > 50) {
                    if(window.event){//IE
                        var ieVersion = parseFloat(navigator.appVersion);
                        //alert(ieVersion);
                        if(ieVersion==5)  //IE 9, 10
                            e.preventDefault();
                        else if(ieVersion==4)  //IE 7,8
                            event.returnValue = false;
                    }else if(e){//Firefox
                        e.preventDefault();
                    }
                }
                break;
            case 1:
                //alert("charCode=" + charCode + "  $$$$ " + myTime);
                if (myTime == 2) {
                    if (charCode > 51 || charCode < 48) {
                        if(window.event){//IE
                            var ieVersion = parseFloat(navigator.appVersion);
                            //alert(ieVersion);
                            if(ieVersion==5)  //IE 9, 10
                                e.preventDefault();
                            else if(ieVersion==4)  //IE 7,8
                                event.returnValue = false;
                        }else if(e){//Firefox
                            e.preventDefault();
                        }
                    }
                } else {
                    if (charCode < 48 || charCode > 57) {
                        if(window.event){//IE
                            var ieVersion = parseFloat(navigator.appVersion);
                            //alert(ieVersion);
                            if(ieVersion==5)  //IE 9, 10
                                e.preventDefault();
                            else if(ieVersion==4)  //IE 7,8
                                event.returnValue = false;
                        }else if(e){//Firefox
                            e.preventDefault();
                        }
                    }
                }
                break;
            case 2:
                {
                    if (charCode < 48 || charCode > 53) {
                        if(window.event){//IE
                            var ieVersion = parseFloat(navigator.appVersion);
                            //alert(ieVersion);
                            if(ieVersion==5)  //IE 9, 10
                                e.preventDefault();
                            else if(ieVersion==4)  //IE 7,8
                                event.returnValue = false;
                        }else if(e){//Firefox
                            e.preventDefault();
                        }
                    }
                    sender.value = sender.value + ':';
                }
                break;
            case 3:
                if (charCode < 48 || charCode > 53) {
                    if(window.event){//IE
                        var ieVersion = parseFloat(navigator.appVersion);
                        //alert(ieVersion);
                        if(ieVersion==5)  //IE 9, 10
                            e.preventDefault();
                        else if(ieVersion==4)  //IE 7,8
                            event.returnValue = false;
                    }else if(e){//Firefox
                        e.preventDefault();
                    }
                }
                //alert(3);
                break;
            default:
                if (charCode < 48 || charCode > 57) {
                    if(window.event){//IE
                        var ieVersion = parseFloat(navigator.appVersion);
                        //alert(ieVersion);
                        if(ieVersion==5)  //IE 9, 10
                            e.preventDefault();
                        else if(ieVersion==4)  //IE 7,8
                            event.returnValue = false;
                    }else if(e){//Firefox
                        e.preventDefault();
                    }
                }
        }
    }
}

function ValidateTime(sender) {
    if (sender.value.length == 0) return false;
    var regEx = /^(\d{2}):(\d{2})$/;
    var arrMatch = sender.value.match(regEx);
    if (arrMatch == null) {
        alert("Invalid time.");
        sender.value = "";
        return false;
    }
    var hh = arrMatch[1];
    var mm = arrMatch[2];
    if (hh >= 24 || mm >= 60) {
        alert("Invalid time.");
        sender.value = "";
        return false;
    }
    return true;
}

function ChkMinusDbl(ctl, e) {
    //var evt = e ? e : window.event;
    var zz = e.keyCode || e.charCode;
    
    if (zz < 48 || zz > 57) {
        if (zz == 46) {
            if (ctl.value.indexOf(".", 0) >= 0) {
                if(window.event){//IE
                    var ieVersion = parseFloat(navigator.appVersion);
                    if(ieVersion==5)  //IE 9, 10
                        e.preventDefault();
                    else if(ieVersion==4)  //IE 7,8
                        event.returnValue = false;
                }else if(e){//Firefox
                    e.preventDefault();
                }
            }
        }
        else {
            if(window.event){//IE
                var ieVersion = parseFloat(navigator.appVersion);
                if(ieVersion==5)  //IE 9, 10
                    e.preventDefault();
                else if(ieVersion==4)  //IE 7,8
                    event.returnValue = false;
            }else if(e){//Firefox
                e.preventDefault();
            }
        }

    }
}

function ChkMinusInt(ctl, e) {
    //var evt = e ? e : window.event;
    var zz = e.keyCode || e.charCode;

    if (zz < 48 || zz > 57) {
        if(window.event){//IE
            var ieVersion = parseFloat(navigator.appVersion);
            if(ieVersion==5)  //IE 9, 10
                e.preventDefault();
            else if(ieVersion==4)  //IE 7,8
                event.returnValue = false;
        }else if(e){//Firefox
            e.preventDefault();
        }
    }
}