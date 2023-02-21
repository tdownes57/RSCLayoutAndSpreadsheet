Module modQRCodes
    ''
    ''Module copied from CIBadge83.mdb, copied 10/21/2019 & originally created 7/18/2017 Thomas DOWNES
    ''
    ''
    ''VBA module originally created 7/18/2017 Thomas DOWNES
    ''

    Public Function gGenerateQRCodes() As Boolean
        ''
        ''Created 7/18/2017 Thomas DOWNES
        ''
        ''This function is based on programming code found in the following CIBadge82.mdb, Form_frmMain procedure:
        ''
        ''    Private Function pPrintCard(param_booNotPreview As Boolean, _
        ''                                Optional ByVal pboolSkipEnrollment As Boolean = False, _
        ''                                Optional ByVal pstrRawEnrollmentValue As String = "", _
        ''                                Optional ByRef pboolWaitingForKeyEmulation As Boolean = False)
        ''    ' Prints record showing on frmMain using layout listed in cboLayout.
        ''    ' If booNotPreview is true, print job goes to printer, not to screen.

        ''Not relevant to generating QR-code images. 7/18/2017 TD''Dim obj_rs As DAO.Recordset
        ''Not relevant to generating QR-code images. 7/18/2017 TD''Dim obj_rs2 As DAO.Recordset

        '**
        '**
        '** Don't implement here.  For Version 9.0 or 9.1.
        '**
        '**

        '**See ** above.**Dim objPMgr As ciPrintManager.clsPrtMgr

        'Invoke the print manager to handle various print related tasks before actually printing.

        '**See ** above.**Set objPMgr = New ciPrintManager.clsPrtMgr
        '**See ** above.**objPMgr.PrinterReadsCardNumber = False 'Until shown to be true.

        ''
        ''----DIFFICULT AND CONFUSING----
        ''    As of May 2016, programmer Thomas Downes has opted to _NOT_ use Rob Salgado's objPMgr (of type ciPrintManager.clsPrtMgr)
        ''    for capturing RFID values.  Instead, the program code for capturing RFID values is stored
        ''    in VBA module modSmartCards.bas (hence, property "..._UseInlineVBA" will be True).
        ''
        ''Not relevant to generating QR-code images. 7/18/2017 TD''objPMgr.PrinterReadsCardNumber = pobjEnroll.IfReadingRFID_UsePMgr ''Added 5/16/2016 Thomas Downes

        '**See ** above.**objPMgr.Cfg = gCurCfg.lCfgID
        '**See ** above.**objPMgr.CfgFile = GlobalCfg.sCfgFile
        '**See ** above.**objPMgr.PrintDataFile = GlobalCfg.sLayoutFile
        '**See ** above.**objPMgr.QRCodesEnabled = gCurCfg.bEnableQRCodes
        '**See ** above.**objPMgr.QRCodesFolder = GlobalCfg.sTempFilesFolder '' C:\CI Solutions\CI Badge\Data\TempFiles  ... Has QR01_12346.jpg, for example.
        '**See ** above.**objPMgr.PrinterName = strPrinter

        Dim booManagePrint As Boolean
        '**See ** above.**booManagePrint = objPMgr.ManagePrint

        gGenerateQRCodes = booManagePrint

        ''Not relevant to generating QR-code images. 7/18/2017 TD''''Version 8.20d.  Added by Rob Salgado.
        ''Not relevant to generating QR-code images. 7/18/2017 TD''strEnrollmentDataFromCard = objPMgr.CardNumber

        '5/16/2016 Thomas Downes'If Enroll.CIBEnrollMethod = 2 Then param_PMgr.PrinterReadsCardNumber = True
        ''Not relevant to generating QR-code images. 7/18/2017 TD''If (param_Enroll.CIBEnrollMethod = 2 And param_Enroll.IfReadingRFID_UsePMgr) Then param_PMgr.PrinterReadsCardNumber = True

ExitHandler:
        On Error Resume Next ''Okay, since we are closing.
        '**See ** above.**Set objPMgr = Nothing
    End Function ''End of "Public Function gGenerateQRCodes()"

    Public Function gDisplayQRCodes(ByVal strID As String, ByVal strRptName As String,
                                    ByVal strQRCLocation As String) As Boolean
        'Loop thru controls looking for "QRxx".
        '      Assign QR code bitmap from QR Code bitmap location to image control QRxx.
        '
        ' ----Copied from CI Badge Cards' database, CIBCards82.mdb
        '    ---      (Report_rptCardSample, Public Function gDisplayQRCodes)
        '
        ''10/21/2019 td''Dim rs As DAO.Recordset
        ''10/21/2019 td''Dim rpt As Report

        ''02/2023  Dim ctl As Control
        ''02/2023  Dim strQRNumber As String
        ''02/2023  Dim strQRCBitmap As String

        ''10/21/2019 td''On Local Error Resume Next

        gDisplayQRCodes = True

        ''---**------10/21/2019 td''
        ''---**-Set rpt = Reports(strRptName)
        ''---**-For Each ctl In rpt
        ''---**-    If Left$(ctl.Name, 5) = "imgQR" Then
        ''---**-        strQRNumber = Mid$(ctl.Name, 6)
        ''---**-        strQRCBitmap = strQRCLocation & "\QR" & strQRNumber & "_" & strID & ".jpg"
        ''---**-        rpt(ctl.Name).Picture = strQRCBitmap
        ''---**-        'will this work?? Kill strQRCBitmap
        ''---**-    End If
        ''---**-Next ctl

        ''---**-Set rpt = Nothing

    End Function ''End of "Public Function gDisplayQRCodes"


End Module
