Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Text
Imports System.IO
Imports System.Windows.Forms

Namespace ConnectDB

    Public Class MifareControl

#Region "API"
        Private Declare Function gethostbyname Lib "ws2_32.dll" (ByVal hostname$) As Integer
        Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByVal Destination As String, ByVal Source As String, ByVal length As Integer)
        Private Declare Function WSACleanup Lib "ws2_32.dll" () As Integer

        Private Declare Function SendARP Lib "iphlpapi" (ByVal dest As Integer, ByVal host As Integer, ByRef mac As String, ByRef length As Integer) As Integer
        Private Declare Function inet_addr Lib "ws2_32.dll" (ByVal cp As String) As Integer


        '   Public Declare Function Sleep Lip "kernel32.dll"(byval dwMilliseconds as Int32) as Int16
        '******************อจัถรม๎******************************************************************
        'ด๒ฟชดฎฟฺ int WINAPI rf_init_com(int port,long baud);
        Private Declare Function rf_init_com Lib "MasterRD.dll" (ByVal port As Int16, ByVal baud As Int16) As Int16
        Private Declare Function rf_ClosePort Lib "MasterRD.dll" () As Int16

        '******************************************MF1*****************************************
        'int WINAPI rf_request(unsigned short icdev, unsigned char model, unsigned short *TagType);
        Private Declare Function rf_request Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal model As Byte, _
                       ByRef TagType As UShort) As Int16

        'int WINAPI rf_anticoll(unsigned short icdev, unsigned char bcnt, unsigned char *ppSnr,
        'unsigned char* pRLength);
        Private Declare Function rf_anticoll Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal bcnt As Byte, _
                       ByRef ppsnr As Byte, ByRef pRLength As Byte) As Int16

        'int WINAPI rf_select(unsigned short icdev,unsigned char *pSnr,unsigned char srcLen,
        'unsigned char *Size);
        Private Declare Function rf_select Lib "MasterRD.dll" (ByVal icdev As Int16, ByRef pSnr As Byte, _
                       ByVal srclen As Byte, ByRef size As Byte) As Int16

        'int WINAPI rf_M1_authentication2(unsigned short icdev,unsigned char model,unsigned char block,
        'unsigned char *key);
        Private Declare Function rf_M1_authentication2 Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal model As Byte, _
                       ByVal block As Byte, ByRef key As Byte) As Int16

        'int WINAPI rf_M1_read(unsigned short icdev, unsigned char block, unsigned char *ppData,
        'unsigned char *pLen);
        Private Declare Function rf_M1_read Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal block As Byte, _
                       ByRef buff As Byte, ByRef pLen As Byte) As Int16

        'int WINAPI rf_M1_write(unsigned short icdev, unsigned char block, unsigned char *data);
        Private Declare Function rf_M1_write Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal block As Byte, _
                       ByRef buff As Byte) As Int16

        'int WINAPI rf_halt(unsigned short icdev);
        Private Declare Function rf_halt Lib "MasterRD.dll" (ByVal icdev As Int16) As Int16
        'int WINAPI rf_M1_Initval
        Private Declare Function rf_M1_initval Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal block As Byte, ByVal Value As Long) As Int16


        Private Declare Function rf_M1_readval Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal block As Byte, ByRef pValue As Byte) As Int16


        Private Declare Function rf_M1_increment Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal block As Byte, ByVal Value As Long) As Int16


        Private Declare Function rf_M1_decrement Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal block As Byte, ByVal Value As Long) As Int16

        Private Declare Function rf_beep Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal Value As Long) As Int16

        Private Declare Function rf_light Lib "MasterRD.dll" (ByVal icdev As Int16, ByVal color As Long) As Int16

        Private Declare Function rf_init_device_number Lib "MasterRD.dll" (ByVal iddev As Int16) As Int16

        Private Declare Function rf_get_device_number Lib "MasterRD.dll" (ByVal iddev As Int16) As Int16


        '////////////======== Function ISO14443B Function ================================

#End Region

        ''' <summary>
        ''' สั่ง Connect Mifare ถ้า Connect ได้ Return True ถ้าไม่ได้ Return False
        ''' </summary>
        Public Function Connect(ByVal Port As Int16, ByVal BaudRate As Int16) As Boolean
            Return rf_init_com(Port, BaudRate) = 0
        End Function

        ''' <summary>
        ''' สั่ง DisConnect Mifare ถ้า DisConnect ได้ Return True ถ้าไม่ได้ Return False
        ''' </summary>
        Public Function DisConnect() As Boolean
            Return rf_ClosePort = 0
        End Function

        Public Structure ActivityStatus
            Public Available As Boolean
            Public Result As String
        End Structure

        Public Enum AccessKey
            A
            B
        End Enum

        ''' <summary>
        ''' สั่งเชค Card ที่กำลัง Active หาก Available=False Result=สาเหตุที่อ่านไม่ได้ หาก Select ได้ Return เลข Card ID
        ''' </summary>
        Public Function SelectTag() As ActivityStatus

            Dim buf1(200) As Byte
            Dim b1 As Byte
            Dim s1 As String = ""
            Dim j As Int16

            Dim Result As ActivityStatus

            Dim i As Int16 = rf_request(0, &H52, j)
            If rf_request(0, &H52, j) <> 0 Then
                Result.Available = False
                Result.Result = "Request Fail"
                Return Result
            End If

            'Anticollision
            If rf_anticoll(0, 4, buf1(0), b1) <> 0 Then
                Result.Available = False
                Result.Result = "Anticollision Fail"
                Return Result
            End If

            For i = 0 To b1 - 1
                s1 = s1 & IIf(Hex(buf1(i)).Length < 2, "0", "") & Hex(buf1(i))
            Next i
            'Select card
            If rf_select(0, buf1(0), 4, b1) <> 0 Then
                Result.Available = False
                Result.Result = "Select card fail"
                Return Result
            Else
                rf_light(0, 2)
                rf_beep(0, 20)
                rf_light(0, 1)
                Result.Available = True
                Result.Result = s1
                Return Result
            End If
        End Function

        Public Function ReadTag(ByVal Sector As Integer, ByVal Block As Integer) As ActivityStatus
            Dim i As Int16
            Dim m As Int16
            Dim buf1(200) As Byte
            Dim buf2(200) As Byte
            Dim s1 As String
            'Dim b1 As Byte
            Dim b2 As Byte
            'Dim b3 As Byte

            Dim Result As ActivityStatus

            m = (Sector * 4) + Block

            If m = -1 Then
                Result.Available = False
                Result.Result = "Wrong Block"
                Return Result
            End If

            'Authentication
            Call Authentication(Sector, Block, "A")

            'Read card
            If rf_M1_read(0, CByte(m), buf2(0), b2) <> 0 Then
                Result.Available = False
                Result.Result = "Read Card Fail"
                Return Result
            End If

            s1 = ""

            For i = 0 To b2 - 1
                s1 = s1 & IIf(Hex(buf2(i)).Length < 2, "0", "") & Hex(buf2(i))
            Next i
            rf_light(0, 2)
            rf_beep(0, 20)
            rf_light(0, 1)

            Result.Available = True
            Result.Result = s1
            Return Result

        End Function

        Sub Authentication(ByVal Sector As Integer, ByVal Block As Integer, ByVal KeyType As Char)
            Dim i As Int16, m As Int16, buf1(200) As Byte, buf2(200) As Byte, s1 As String, b1 As Byte, b2 As Byte, b3 As Byte
            s1 = "FFFFFFFFFFFF"
            If (Len(s1) <> 12) Then
                'MessageBox.Show("Wrong Key Length!")
                'txtKey.Focus()
                Exit Sub
            End If
            For i = 0 To 5
                buf1(i) = Val("&H" & Mid(s1, i * 2 + 1, 2))
            Next i
            'm = cb_kh.ListIndex
            m = (Sector * 4) + Block
            If (m = -1) Then
                'MessageBox.Show("Select Block Please!")
                Exit Sub
            End If
            If KeyType = "A" Then
                b1 = &H60
            End If
            If KeyType = "B" Then
                b1 = &H61
            End If
            b3 = CByte(m)
            'Authentication
            i = rf_M1_authentication2(0, b1, b3, buf1(0))
            If (i <> 0) Then
                'MessageBox.Show("Authentication Failฃก")
                'txtRev.Text = ""
                Exit Sub
            End If
        End Sub

        Public Function WriteTag(ByVal Data As String, ByVal Sector As Integer, ByVal Block As Integer) As ActivityStatus
            Dim i As Int16
            Dim m As Int16
            Dim buf1(200) As Byte
            Dim buf2(200) As Byte
            Dim s1 As String
            'Dim b1 As Byte
            'Dim b2 As Byte
            'Dim b3 As Byte

            Dim Result As ActivityStatus

            m = (Sector * 4) + Block
            If m = -1 Then
                Result.Available = False
                Result.Result = "Wrong Block"
                Return Result
            End If


            s1 = Data
            If Len(s1) <> 32 Then
                Result.Available = False
                Result.Result = "Wrong Data length(32 bytes)"
                Return Result
            End If
            For i = 0 To 15
                buf2(i) = Val("&H" & Mid(s1, i * 2 + 1, 2))
            Next i

            Call Authentication(Sector, Block, "A")
            'Write card
            i = rf_M1_write(0, CByte(m), buf2(0))
            If i <> 0 Then
                Result.Available = False
                Result.Result = "Write Card Fail"
                Return Result
            End If

            Result.Available = True
            Result.Result = Data
            Return Result

        End Function

    End Class

End Namespace