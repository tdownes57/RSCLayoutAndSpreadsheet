''
''Added 10/21/2019 td
''

Public Interface InterfaceQRCode
    ''
    ''Added 10/21/2019 td
    ''
    '**See ** above.**objPMgr.Cfg = gCurCfg.lCfgID
    '**See ** above.**objPMgr.CfgFile = GlobalCfg.sCfgFile
    '**See ** above.**objPMgr.PrintDataFile = GlobalCfg.sLayoutFile
    '**See ** above.**objPMgr.QRCodesEnabled = gCurCfg.bEnableQRCodes
    '**See ** above.**objPMgr.QRCodesFolder = GlobalCfg.sTempFilesFolder '' C:\CI Solutions\CI Badge\Data\TempFiles  ... Has QR01_12346.jpg, for example.
    '**See ** above.**objPMgr.PrinterName = strPrinter

    ''
    '' Oops! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Property Cfg As Integer

    Property CfgFile As String

    Property PrintDataFile As String

    Property QRCodesEnabled As Boolean

    Property QRCodesFolder As String

    Property PrinterName As String

End Interface ''ENd of "Public Interface InterfaceQRCode"
