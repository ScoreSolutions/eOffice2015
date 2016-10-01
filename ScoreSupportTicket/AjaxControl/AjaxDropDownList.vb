Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports Microsoft.VisualBasic


Public Class AjaxDropDownList : Inherits System.Web.UI.WebControls.DropDownList
    Dim _observes As New ArrayList()
    Dim _sourceURL As String = ""
    Dim _lookupName As String = ""
    Dim _delimiter As Char = "|"

    '<summary>
    'Get/Set collection of boserves for this dropdownlist
    '</summary>
    <Category("AJAX"), Description("Collection of observers that listen to the this control. Populate this property through server code")> _
    Public Property Observers() As ArrayList
        Get
            Return _observes
        End Get
        Set(ByVal value As ArrayList)
            _observes = value
        End Set
    End Property

    <Category("AJAX"), Description("URL of source data, eg. http://localhost/getLookupHandler.ashx")> _
    Public Property SourceURL() As String
        Get
            Return _sourceURL
        End Get
        Set(ByVal value As String)
            _sourceURL = value
        End Set
    End Property

    <Category("AJAX"), Description("Lookup Name, eg. Country, Currency or OrderStatus")> _
    Public Property LookupName() As String
        Get
            Return _lookupName
        End Get
        Set(ByVal value As String)
            _lookupName = value
        End Set
    End Property


    <Category("AJAX"), Description("Delimiter for data persistence in the client side")> _
    Public Property Dliimiter() As Char
        Get
            Return _delimiter
        End Get
        Set(ByVal value As Char)
            _delimiter = value
        End Set
    End Property


    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        If (Page.IsPostBack = True) Then
            Dim selectedValue As String = ""
            If (HttpContext.Current.Request.Params(Me.UniqueID) IsNot Nothing) Then
                Me.Items.Clear()
                Dim content = HttpContext.Current.Request.Params("__" & Me.ClientID)
                Dim listItems() As String = content.Split(_delimiter)
                For i As Integer = 0 To listItems.Length - 2
                    Me.Items.Add(New ListItem(listItems(i), listItems(i + 1)))
                    i += 1
                Next
                Dim selectedListItem As ListItem = Me.Items.FindByValue(selectedValue)
                If selectedListItem IsNot Nothing Then
                    selectedListItem.Selected = True
                End If
            End If
        End If

        MyBase.OnLoad(e)
    End Sub
    Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
        If (Page.IsClientScriptBlockRegistered("controller") = False) Then
            Page.RegisterClientScriptBlock("controller", getControllerScript())
        End If
        Page.RegisterStartupScript("init_" & Me.ClientID, getStartupScript())
        MyBase.OnPreRender(e)
    End Sub

    Private Function getStartupScript() As String
        Dim sb As New StringBuilder()
        sb.Append("<script language='javascript'>" & vbNewLine)
        sb.AppendFormat("var {0} = new AjaxDropDownController('{0}','{1}','{2}');" & vbNewLine, Me.ClientID, Me.LookupName, Me.SourceURL)
        For i As Integer = 0 To Me.Observers.Count - 1
            Dim ctl As AjaxDropDownList = Me.Observers(i)
            If ctl IsNot Nothing Then
                sb.AppendFormat("{0}.addObserver('{1}');" & vbNewLine, Me.ClientID, ctl.ClientID)
            End If
        Next
        sb.AppendFormat("{0}.init()" & vbNewLine, Me.ClientID)
        sb.Append("</script>" & vbNewLine)
        Return sb.ToString()
    End Function

    Private Function getControllerScript() As String
        Dim sb As New StringBuilder()
        sb.Append("<script type='text/javascript'>" & vbNewLine)

        sb.Append("function getXMLHTTP() " & vbNewLine & _
        "{var A=null;try{A=new ActiveXObject('Msxml2.XMLHTTP');}" & vbNewLine & _
        "catch(e){try{A=new ActiveXObject('Microsoft.XMLHTTP');}catch(oc){A=null;}}" & vbNewLine & _
        "if(!A&&typeof XMLHttpRequest!='undefined'){A=new XMLHttpRequest();} " & vbNewLine & _
        "return A;} " & vbNewLine & _
        "function AjaxDropDownController(controlClientId,lookupName,baseUrl)")

        sb.AppendFormat("{{var self=this;this.controlClientId=controlClientId;this.hiddenId='__'+self.controlClientId;this.lookupName=lookupName;this.baseUrl=baseUrl;this.delimiter='{0}';var xmlHttp;var observers=[];this.getSource=getSource;this.addObserver=addObserver;this.notify=notify;this.load=load;this.init=init;this.persist=persist;function getSource(filter)" & vbNewLine, _delimiter)

        Dim strAjax As String = ""
        strAjax += vbNewLine & " {var requestUrl=baseUrl+'?id='+self.lookupName;if(filter!=undefined&&filter!='')"
        strAjax += vbNewLine & " {requestUrl+='&filter='+filter;}"
        strAjax += vbNewLine & " xmlHttp=getXMLHTTP();if(xmlHttp)"
        strAjax += vbNewLine & " {xmlHttp.onreadystatechange=doReadyStateChange;xmlHttp.open('GET',requestUrl,true);xmlHttp.send(null);}}"
        strAjax += vbNewLine & " function doReadyStateChange()"
        strAjax += vbNewLine & " {if(xmlHttp.readyState==4)"
        strAjax += vbNewLine & " {if(xmlHttp.status==200)"
        strAjax += vbNewLine & " {eval('var d='+xmlHttp.responseText);if(d!=null)"
        strAjax += vbNewLine & " {populateList(d);}}"
        strAjax += vbNewLine & " else"
        strAjax += vbNewLine & " {alert('There was a problem retrieving the data:\n'+xmlHttp.statusText);}}}"
        strAjax += vbNewLine & " function populateList(namevalue)"
        strAjax += vbNewLine & " {if(oSelect=document.getElementById(self.controlClientId))"
        strAjax += vbNewLine & " {var content='';for(var i=oSelect.length-1;i>=0;i--)"
        strAjax += vbNewLine & " {oSelect.options[i]=null;}"
        strAjax += vbNewLine & " for(var i=0;i<namevalue.length;i++)"
        strAjax += vbNewLine & " {if(namevalue[i].value==undefined)"
        strAjax += vbNewLine & " {oSelect.options[oSelect.length]=new Option(namevalue[i].name);content+=namevalue[i].name+self.delimiter+namevalue[i].name+self.delimiter;}"
        strAjax += vbNewLine & " else"
        strAjax += vbNewLine & " {opt=new Option(namevalue[i].name,namevalue[i].value);oSelect.options[oSelect.length]=opt;content+=namevalue[i].name+self.delimiter+namevalue[i].value+self.delimiter;}}"
        strAjax += vbNewLine & " if(content.substr(content.length-1,1)==self.delimiter)"
        strAjax += vbNewLine & " {content=content.substr(0,content.length-1);}"
        strAjax += vbNewLine & " if(oHidden=document.getElementById(self.hiddenId))"
        strAjax += vbNewLine & " {oHidden.value=content;}"
        strAjax += vbNewLine & " if(oSelect.selectedIndex>-1){if(oSelect.fireEvent)"
        strAjax += vbNewLine & " {oSelect.fireEvent('onchange');}"
        strAjax += vbNewLine & " else if(oSelect.dispatchEvent)"
        strAjax += vbNewLine & " {var oEvent=document.createEvent('HTMLEvents');oEvent.initEvent('change',true,true);oSelect.dispatchEvent(oEvent);}}}}"
        strAjax += vbNewLine & " function addObserver(obj)"
        strAjax += vbNewLine & " {var length=observers.length;var found=false;for(var i=0;i<length;i++)"
        strAjax += vbNewLine & " {if(observers[i]==obj)"
        strAjax += vbNewLine & " {found=true;break;}}"
        strAjax += vbNewLine & " if(!found)"
        strAjax += vbNewLine & " {observers[observers.length]=obj;}}"
        strAjax += vbNewLine & " function notify()"
        strAjax += vbNewLine & " {var filter='';var oSelect=document.getElementById(self.controlClientId);if(oSelect!=null&&oSelect.selectedIndex!=-1)"
        strAjax += vbNewLine & " {filter=self.lookupName+','+oSelect.options[oSelect.selectedIndex].value;}"
        strAjax += vbNewLine & " for(i=0;i<observers.length;i++)"
        strAjax += vbNewLine & " {eval(observers[i]+'.load(filter);');}}"
        strAjax += vbNewLine & " function load(filter)"
        strAjax += vbNewLine & " {this.getSource(filter);}"
        strAjax += vbNewLine & " function init()"
        strAjax += vbNewLine & " {if((oSelect=document.getElementById(self.controlClientId)))"
        strAjax += vbNewLine & " {if(!(hidden=document.getElementById(self.hiddenId)))"
        strAjax += vbNewLine & " {hidden=document.createElement('input');hidden.id=self.hiddenId;hidden.name=self.hiddenId;hidden.type='hidden';oSelect.form.appendChild(hidden);}"
        strAjax += vbNewLine & " if(oSelect.options.length==0)"
        strAjax += vbNewLine & " {this.load();}"
        strAjax += vbNewLine & " else"
        strAjax += vbNewLine & " {this.persist(oSelect);}"
        strAjax += vbNewLine & " if(oSelect.attachEvent)"
        strAjax += vbNewLine & " {oSelect.attachEvent('onchange',notify);}"
        strAjax += vbNewLine & " else if(oSelect.addEventListener)"
        strAjax += vbNewLine & " {oSelect.addEventListener('change',notify,false);}"
        strAjax += vbNewLine & " else"
        strAjax += vbNewLine & " {oSelect.onchange=notify;}}}"
        strAjax += vbNewLine & " function persist(oSelect)"
        strAjax += vbNewLine & " {var content='';for(var i=0;i<oSelect.options.length;i++)"
        strAjax += vbNewLine & " {content+=oSelect.options[i].text+self.delimiter+oSelect.options[i].value+self.delimiter;}"
        strAjax += vbNewLine & " if(content.substr(content.length-1,1)==self.delimiter)"
        strAjax += vbNewLine & " {content=content.substr(0,content.length-1);}"
        strAjax += vbNewLine & " if((hidden=document.getElementById(self.hiddenId)))"
        strAjax += vbNewLine & " {hidden.value=content;}}}"
        strAjax += vbNewLine & " </script>" & vbNewLine

        sb.Append(strAjax)
        Return sb.ToString()
    End Function
End Class
