Option Explicit On ''Created 2/5/2018 Thomas DOWNES  
Option Strict On ''Created 2/5/2018 Thomas DOWNES  
''
''Created 2/5/2018 Thomas DOWNES  
''

Public Class FormSupportLogin
    ''
    ''Created 2/5/2018 Thomas DOWNES  
    ''
    Private Const CI_Badge_Default_Data_Folder As String = "C:\CI Solutions\CI Badge\Data\"
    Private Const CI_Verify_Default_Data_Folder As String = "C:\CI Solutions\CI Verify\"
    Private Const CI_Visitor_Default_Data_Folder As String = "C:\CI Solutions\CI Badge\Data\Visitor\"

    Private Const CI_Badge_Default_Config_File As String = "C:\CI Solutions\CI Badge\Data\CIBConfig83.mdb" ''Added 2/21/2018 Thomas DOWNES  
    Private Const CI_Badge_Default_Data_File As String = "C:\CI Solutions\CI Badge\Data\CIBData83.mdb"
    ''Private Const CI_Verify_Default_Data_File As String = "C:\CI Solutions\CI Verify\V_Data83.mdb"
    Private Const CI_Verify_Default_Data_File As String = "C:\CI Solutions\CI Verify\V_Config83.mdb"
    Private Const CI_Visitor_Default_Data_File As String = "C:\CI Solutions\CI Badge\Data\Visitor\CIBVisitorData83.mdb"

    Private _boolTechSupport As Boolean ''Added 2/21/2018 Thomas DOWNES   
    Private _strPathToSelectedMDB As String = "" ''Added 2/21/2018 Thomas DOWNES   

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 2/7/2018 Thomas DOWNES  
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub buttonOK_Click(sender As Object, e As EventArgs) Handles buttonOK.Click

        ''11/26/2018 td''Dim boolLeaveWindowOpenIfFails As Boolean ''Added 2/21/2018 Thomas D.
        Dim boolLoginCredentialIsValid As Boolean ''Added 2/26/2018 Thomas D.
        ''11/26/2018 td''Dim intPermssionsLevel As Integer ''Added 2/26/2018 Thomas D.

        ''Added 2/7/2018 Thomas DOWNES  

        ''11/26/2018 td''Me.DialogResult = DialogResult.OK
        Me.Visible = False

        ''Created 2/7/2018 Thomas DOWNES  
        ''2/26/2018 TD''If (CheckLoginCredential_Valid(boolLeaveWindowOpenIfFails)) Then ''Conditioned 2/7/2018 Thomas DOWNES 

        ''Created 2/26/2018 Thomas DOWNES  
        ''11/26/2018 td''boolLoginCredentialIsValid =
        ''    CheckLoginCredential_Valid(intPermssionsLevel, boolLeaveWindowOpenIfFails)

        ''11/26/2018 td''boolLoginCredentialIsValid = (textLoginName.Text.Equals("Support") And textPasscode.Text.Equals("362590720"))
        boolLoginCredentialIsValid = (textLoginName.Text.ToUpper().Equals("Support".ToUpper()) And
                  (textPasscode.Text.Equals("teal90720") Or
                  textPasscode.Text.Equals("362590720")))

        If (boolLoginCredentialIsValid) Then Me.DialogResult = DialogResult.OK
        If (Not boolLoginCredentialIsValid) Then Me.DialogResult = DialogResult.Cancel

        ''11/26/2018 td''If (boolLoginCredentialIsValid) Then ''Conditioned 2/7/2018 Thomas DOWNES 
        ''    ''
        ''    ''Great!  Run the application! 
        ''    ''
        ''    Dim objFormDataManager As New frmDataManager
        ''    ''2/26/2018 TD''[objFormDataManager.LoginByTechSupport = True ''Added 2/22/2018 Thomas D. 
        ''    objFormDataManager.LoginByTechSupport = _boolTechSupport ''2/26 TD''True ''Added 2/22/2018 Thomas D. 
        ''    objFormDataManager.AdvancedMode = chkExportAdvanced.Checked ''Added 2/26/2018 Thomas D. 
        ''    objFormDataManager.ShowDialog()
        ''    Me.Close()
        ''Else
        ''    MessageBox.Show("Sorry, your login is denied.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        ''    ''2/21/2018 TD''Me.Close()
        ''    ''2/21/2018 TD''If (_boolTechSupport) Then
        ''    If (_boolTechSupport) Then
        ''        ''Don't close the application. Leave the window open.   ---2/21/2018 Thomas D. 
        ''        Me.Visible = True
        ''    ElseIf (boolLeaveWindowOpenIfFails) Then
        ''        ''Don't close the application.  Leave the window open.   ---2/21/2018 Thomas D. 
        ''        Me.Visible = True
        ''    Else
        ''        Me.Close()
        ''    End If ''End of "If (_boolTechSupport) Then ... ElseIf ... Else ..."

        ''End If ''End of "If (boolLoginCredentialIsValid) Then ... Else ..."

    End Sub

    Private Sub imgCIS_Click(sender As Object, e As EventArgs) Handles imgCIS.Click

        ''Added 2/7/2018 Thomas DOWNES
        ''5/29/2019 td''System.Diagnostics.Process.Start("http:\\www.cisolutions.com")
        System.Diagnostics.Process.Start("https://www.cardintegrators.com/")

        ''Added 5/29/2019 td
        Static s_numberClicks As Integer
        s_numberClicks += 1
        If (s_numberClicks >= 3) Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If ''Enbd of "If (s_numberClicks > 5) Then"

    End Sub

    ''
    ''Created 2/5/2018 Thomas DOWNES  
    ''

    ''Public Function CheckLoginCredential_Valid(ByRef par_intPermissionLevel As Integer,
    ''                                           Optional par_boolKeepLoginWindowOpen As Boolean = False) As Boolean
    ''    ''  Public Function CheckLoginCredential_Valid(Optional par_boolKeepLoginWindowOpen As Boolean = False) As Boolean
    ''    ''
    ''    ''Added 2/7/2018 Thomas DOWNES 
    ''    ''
    ''    Dim objMSAccess As New clsOLEDB_MSAccess
    ''    ''Encapsulated 2/26/2018 TD''Dim objDataTable As System.Data.DataTable
    ''    ''Encapsulated 2/26/2018 TD''Dim boolDataFileIsFound As Boolean
    ''    Dim boolConfirmed As Boolean
    ''    Dim strLoginName As String
    ''    Dim strPassScrambled As String
    ''    Dim strLoginScrambled As String
    ''    Dim boolPresentlyTechSupport As Boolean ''Added 2/21/2018 Thomas DOWNES

    ''    objMSAccess.UserID = "Admin"
    ''    objMSAccess.DBPassword = ""

    ''    ''Added 2/7/2018 Thomas DOWNES 
    ''    strLoginName = textLoginName.Text ''Added 2/7/2018 Thomas DOWNES 

    ''    ''Added 2/21/2018 Thomas DOWNES 
    ''    ''#1 2/21/2018 TD''_boolTechSupport = ("supporT" = strLoginName) ''Added 2/21/2018 Thomas DOWNES
    ''    ''#1 2/21/2018 TD''_boolTechSupport = (("supporT" = strLoginName) Or _boolTechSupport) ''Once the Boolean value is True, 
    ''    ''   keep it True no matter how many attempts to log in are made.  ---2 / 21 / 2018 Thomas DOWNES

    ''    ''Added 2/21/2018 Thomas DOWNES 
    ''    boolPresentlyTechSupport = ("supporT" = strLoginName) Or
    ''             ("Support".ToUpper() = strLoginName.ToUpper() _
    ''             And ("teal90720" = textPasscode.Text))

    ''    _boolTechSupport = (boolPresentlyTechSupport Or _boolTechSupport) ''Once the Boolean value is True, keep it True 
    ''    ''   no matter how many attempts to log in are made.  ---2 / 21 / 2018 Thomas DOWNES

    ''    ''2/21/2018 TD''objMSAccess.GivePopupErrorMessages = ("supporT" = strLoginName) ''Added 2/7/2018 Thomas DOWNES 
    ''    ''2/21/2018 TD''If (strLoginName = "supporT") Then strLoginName = "Support" ''Added 2/7/2018 Thomas DOWNES 

    ''    linklabelSelectFileMDB.Visible = _boolTechSupport ''Added 2/21/2018 Thomas DOWNES 

    ''    objMSAccess.GivePopupErrorMessages = _boolTechSupport ''Modified 2/21/2018 Thomas DOWNES 

    ''    ''2/21/2018 TD''If (_boolTechSupport) Then strLoginName = "Support" ''Modified 2/21/2018 Thomas DOWNES 
    ''    If (strLoginName = "supporT") Then strLoginName = "Support" ''Modified 2/21/2018 Thomas DOWNES 

    ''    strPassScrambled = gScrambleString(textPasscode.Text)
    ''    strLoginScrambled = gScrambleString(strLoginName)

    ''    ''2/7/2018 TD''objMSAccess.SQLText = String.Format("SELECT chrUserName FROM tblUsers WHERE chrUserName='{0}' AND pw='{1}'; ", textLoginName.Text, strPassScrambled)
    ''    ''2/26/2018 TD''objMSAccess.SQLText = String.Format("SELECT chrUserName FROM tblUsers WHERE chrUserName='{0}' AND chrPassword='{1}' AND bytPermissions=8; ", strLoginScrambled, strPassScrambled)
    ''    Dim strSQLSelect_Template As String ''Added 2/26/2019 Thomas D. 

    ''    ''Select for values of bytPermissions equal or greater than 8.
    ''    ''
    ''    ''     (8 = Level of Administrators; 9 = Level of CI Solutions Tech Support)
    ''    ''
    ''    ''2/26/2018 TD''strSQLSelect_Template = "SELECT chrUserName FROM tblUsers WHERE chrUserName='{0}' AND chrPassword='{1}' AND bytPermissions=8; "
    ''    strSQLSelect_Template = ("SELECT chrUserName, bytPermissions " &
    ''                             " FROM tblUsers " &
    ''                             " WHERE chrUserName='{0}' AND chrPassword='{1}' AND bytPermissions >= 8; ")

    ''    objMSAccess.SQLText = String.Format(strSQLSelect_Template, strLoginScrambled, strPassScrambled)

    ''    ''
    ''    ''CI Badge -- Check among CI Badge's login credentials. 
    ''    ''
    ''    ''2/26/2018 TD''boolConfirmed = CheckLoginCredential_CheckMDBs(objMSAccess, strLoginName)
    ''    boolConfirmed = CheckLoginCredential_CheckMDBs(objMSAccess, strLoginName, par_intPermissionLevel)

    ''    ''Added 2/21/2018 Thomas DOWNES 
    ''    Dim dialog_result As DialogResult

    ''    '' 2/21/2018 TD''If (_boolTechSupport) Then ''Added 2/21/2018 Thomas DOWNES 
    ''    If (boolPresentlyTechSupport) Then ''Added 2/21/2018 Thomas DOWNES 
    ''        ''Added 2/21/2018 Thomas DOWNES 
    ''        ''
    ''        ''   If a Tech Support person hits the Cancel button, he can try other login names to see if they work. 
    ''        ''
    ''        dialog_result = MessageBox.Show("Welcome, CI Support Team.", "Data Manager", MessageBoxButtons.OKCancel,
    ''                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    ''        ''Check to see if Tech Support wants to try other Login names to see if they work. 
    ''        par_boolKeepLoginWindowOpen = (dialog_result = DialogResult.Cancel)
    ''        If (par_boolKeepLoginWindowOpen) Then chkExportAdvanced.Visible = _boolTechSupport ''Added 2/26/2018 TD
    ''        Return (dialog_result = DialogResult.OK)

    ''    End If ''End of "If (boolPresentlyTechSupport) Then"

    ''    ''2/26/2018 TD''Return False
    ''    Return boolConfirmed

    ''End Function ''End of "Public Function CheckLoginCredential_Valid() As Boolean"

    ''Private Function CheckLoginCredential_CheckMDBs(par_objMSAccess As clsOLEDB_MSAccess, par_strLoginID As String,
    ''                                                ByRef par_intPermissionLevel As Integer) As Boolean
    ''    ''
    ''    ''Encapsulated 2/26/2018 TD 
    ''    ''
    ''    ''
    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''Part 1 of 4.  CI Badge -- Check among CI Badge's login credentials. 
    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''
    ''    ''Parameterized. 2/26 TD''Dim objMSAccess As New clsOLEDB_MSAccess
    ''    Dim objDataTable As System.Data.DataTable
    ''    Dim boolDataFileIsFound As Boolean
    ''    Dim boolConfirmed As Boolean
    ''    ''Parameterized. 2/26 TD''Dim strLoginName As String
    ''    ''Parameterized. 2/26 TD''Dim strPassScrambled As String
    ''    ''Parameterized. 2/26 TD''Dim strLoginScrambled As String
    ''    ''Parameterized as par_bLoginIsTech. 2/26 TD''Dim boolPresentlyTechSupport As Boolean ''Added 2/21/2018 Thomas DOWNES

    ''    ''2/21/2018 TD''objMSAccess.MDBPathAndFile = CI_Badge_Default_Data_File
    ''    par_objMSAccess.MDBPathAndFile = CI_Badge_Default_Config_File
    ''    boolDataFileIsFound = (System.IO.File.Exists(par_objMSAccess.MDBPathAndFile))

    ''    ''Added 2/21/2018 Thomas downes 
    ''    ''   Let's account for the fact that there are any number of versions of CI Badge 
    ''    ''   which might be installed on the user's machine.  ---2/21/2018 TD
    ''    ''
    ''    If (Not boolDataFileIsFound) Then
    ''        If ("" <> _strPathToSelectedMDB.Trim()) Then
    ''            ''Let's use the selected MDB.  
    ''            par_objMSAccess.MDBPathAndFile = _strPathToSelectedMDB.Trim()
    ''            boolDataFileIsFound = (System.IO.File.Exists(par_objMSAccess.MDBPathAndFile))
    ''        Else
    ''            ''
    ''            ''Let's try to find various versions of CIBConfig99.mdb.
    ''            ''
    ''            par_objMSAccess.MDBPathAndFile = FindTheInstalledVersion_CIBConfig()

    ''            boolDataFileIsFound = (System.IO.File.Exists(par_objMSAccess.MDBPathAndFile))
    ''        End If ''End of "If ("" <> _strPathToSelectedMDB) Then ... Else ..."
    ''    End If ''End of "If (Not boolDataFileIsFound) Then"

    ''    If boolDataFileIsFound Then
    ''        ''2/7/2018 TD''objMSAccess.SQLText = String.Format("SELECT chrUserName FROM tblUsers WHERE chrUserName='{0}' AND chrPassword='{1}' AND bytPermissions=8; ", strLoginScrambled, strPassScrambled)
    ''        objDataTable = par_objMSAccess.GetTable()
    ''        ''Return (1 = objDataTable.Rows.Count)
    ''        boolConfirmed = (objDataTable IsNot Nothing AndAlso 1 = objDataTable.Rows.Count)

    ''        ''Added 2/26/2018 TD
    ''        ''  Get the Permissions Level.  (8 = Administrator, 9 = Tech Support)  
    ''        If (boolConfirmed) Then par_intPermissionLevel = CInt(objDataTable.Rows(0).Item("bytPermissions"))

    ''        If boolConfirmed Then Return True

    ''    ElseIf (_boolTechSupport) Then ''Added 2/21/2018 Thomas D. 

    ''        ''Added 2/21/2018 Thomas D.
    ''        ''
    ''        MsgBox("The following credential-data MDB was not found. (CI Badge)  " & vbNewLine & vbNewLine &
    ''                par_objMSAccess.MDBPathAndFile & vbNewLine & vbNewLine &
    ''               "Next, we will check CI Visitor's credential-data file.", vbExclamation)

    ''    End If ''end of "If boolDataFileIsFound Then ... ElseIf ..."

    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''End of "Part 1 of 4.  CI Badge"  
    ''    ''--------------------------------------------------------------------------------------------------------------------------

    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''Part 2 of 4.  CI Visitor -- Check among CI Visitor's login credentials. 
    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''
    ''    Const c_boolIsTableUsersInVisitorData As Boolean = False ''Added 2/21/2018 Thomas D.

    ''    If (c_boolIsTableUsersInVisitorData) Then ''Added 2/21/2018 Thomas D.
    ''        ''
    ''        ''Check in Data\Visitor\CIBVisitorData83.mdb for table tblUsers.  I just checked 
    ''        ''   and it's not there!!   Hence the Boolean constant above is False. 
    ''        ''    ----2/21/2018 Thomas DOWNES 
    ''        ''
    ''        par_objMSAccess.MDBPathAndFile = CI_Visitor_Default_Data_File
    ''        boolDataFileIsFound = (System.IO.File.Exists(par_objMSAccess.MDBPathAndFile))
    ''        If boolDataFileIsFound Then
    ''            ''2/7/2018 TD''objMSAccess.SQLText = String.Format("SELECT chrUserName FROM tblUsers WHERE chrUserName='{0}' AND chrPassword='{1}' AND bytPermissions=8; ", strLoginScrambled, strPassScrambled)
    ''            objDataTable = par_objMSAccess.GetTable()
    ''            ''Return (1 = objDataTable.Rows.Count)
    ''            boolConfirmed = (objDataTable IsNot Nothing AndAlso 1 = objDataTable.Rows.Count)

    ''            ''Added 2/26/2018 TD
    ''            ''  Get the Permissions Level.  (8 = Administrator, 9 = Tech Support)  
    ''            If (boolConfirmed) Then par_intPermissionLevel = CInt(objDataTable.Rows(0).Item("bytPermissions"))

    ''            If boolConfirmed Then Return True

    ''        ElseIf (_boolTechSupport) Then ''Added 2/21/2018 Thomas D. 

    ''            ''Added 2/21/2018 Thomas D. 
    ''            ''
    ''            MsgBox("The following credential-data MDB was not found. (CI Visitor)  " & vbNewLine & vbNewLine &
    ''                    CI_Visitor_Default_Data_File & vbNewLine & vbNewLine &
    ''                   "Next, we will check CI Visitor's credential-data file.", vbExclamation)

    ''        End If ''end of "If boolDataFileIsFound Then ... ElseIf ..."

    ''    End If ''End of "If (c_boolIsTableUsersInVisitorData) Then"

    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''End of "Part 2 of 4.  CI Visitor"  
    ''    ''--------------------------------------------------------------------------------------------------------------------------

    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''Part 3 of 4. CI Verify -- Check among CI Visitor's login credentials. 
    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''
    ''    par_objMSAccess.MDBPathAndFile = CI_Verify_Default_Data_File
    ''    boolDataFileIsFound = (System.IO.File.Exists(par_objMSAccess.MDBPathAndFile))

    ''    If (_boolTechSupport) Then
    ''        ''
    ''        ''Don't bother checking the CI Verify MDB if the user is Tech Support.  --2/27/2018 Thomas DOWNES
    ''        ''
    ''    ElseIf ("" <> _strPathToSelectedMDB.Trim()) Then
    ''        ''
    ''        ''Don't bother checking the CI Verify MDB if the user has selected another MDB. 
    ''        ''
    ''    ElseIf boolDataFileIsFound Then
    ''        ''2/7/2018 TD''objMSAccess.SQLText = String.Format("SELECT chrUserName FROM tblUsers WHERE chrUserName='{0}' AND chrPassword='{1}' AND bytPermissions=8; ", strLoginName, strScrambled)
    ''        objDataTable = par_objMSAccess.GetTable()
    ''        ''Return (1 = objDataTable.Rows.Count)
    ''        boolConfirmed = (objDataTable IsNot Nothing AndAlso 1 = objDataTable.Rows.Count)

    ''        ''Added 2/26/2018 TD
    ''        ''  Get the Permissions Level.  (8 = Administrator, 9 = Tech Support)  
    ''        If (boolConfirmed) Then par_intPermissionLevel = CInt(objDataTable.Rows(0).Item("bytPermissions"))

    ''        If boolConfirmed Then Return True

    ''    ElseIf (_boolTechSupport) Then ''Added 2/21/2018 Thomas D. 

    ''        ''Added 2/21/2018 Thomas D. 
    ''        ''
    ''        MsgBox("The following credential-data MDB was not found. (CI Verify)  " & vbNewLine & vbNewLine &
    ''                par_objMSAccess.MDBPathAndFile & vbNewLine & vbNewLine &
    ''               "Sorry!", vbExclamation)

    ''    End If ''end of "If ("" <> _strPathToSelectedMDB) Then ... ElseIf boolDataFileIsFound Then ... ElseIf ..."

    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''End of "Part 3 of 4. CI Verify"  
    ''    ''--------------------------------------------------------------------------------------------------------------------------

    ''    ''---------------------------------------------------------------------------------------------------------------------------
    ''    ''Part 4 of 4.  Browsing for a Config MDB file.
    ''    ''
    ''    ''If a constant Boolean is True then ...     [[As of 2/26/2018 per Sammi F. & Jayce P. this Boolean constant is False. ---TD]] 
    ''    ''    ...Let's prompt certain users (Tech Support or Admin) to browse for relevant MDB file, i.e. an MDB file with the table tblUsers. 
    ''    ''       Then check the login credentials. 
    ''    ''   ---2/21/2018 Thomas DOWNES 
    ''    ''---------------------------------------------------------------------------------------------------------------------------
    ''    ''
    ''    ''2/26/2018 TD''Const c_PromptTechOrAdminsToEnterPathToMDB As Boolean = True ''Retroactively added 2/26/2018 per 2/21/2018 work. -- Thomas D. 
    ''    Const c_PromptTechOrAdminsToEnterPathToMDB As Boolean = False ''False per Sammi F. & Jayce P. on 2/26. ---2/26/2018 Thomas D. 

    ''    If (c_PromptTechOrAdminsToEnterPathToMDB) Then ''Condition added 2/26/2018 TD

    ''        If (_boolTechSupport Or (par_strLoginID.ToUpper() = "Admin".ToUpper())) Then

    ''            Dim boolSelected As Boolean ''Added 2/21/2018 TD

    ''            ''Major call !!
    ''            If ("" = _strPathToSelectedMDB) Then AllowUserToSelectAnMDB(boolSelected)

    ''            If (boolSelected) Then

    ''                par_objMSAccess.MDBPathAndFile = _strPathToSelectedMDB
    ''                objDataTable = par_objMSAccess.GetTable()
    ''                boolConfirmed = (objDataTable IsNot Nothing AndAlso 1 = objDataTable.Rows.Count)

    ''                ''Added 2/26/2018 TD
    ''                ''  Get the Permissions Level.  (8 = Administrator, 9 = Tech Support)  
    ''                If (boolConfirmed) Then par_intPermissionLevel = CInt(objDataTable.Rows(0).Item("bytPermissions"))

    ''                If boolConfirmed Then Return True

    ''            End If ''eND OF "If (boolSelected) Then"

    ''        End If ''End of "If (_boolTechSupport Or (strLoginName = "Admin")) Then"

    ''    End If ''End of "If (c_PromptTechOrAdminsToEnterPathToMDB) Then"

    ''    ''--------------------------------------------------------------------------------------------------------------------------
    ''    ''End of "Part 4 of 4.  Browsing for a Config MDB file."  
    ''    ''--------------------------------------------------------------------------------------------------------------------------

    ''End Function ''eND OF "Private Function CheckLoginCredential_CheckMDBs()"

    ''Private Function gScrambleString(strStringToScramble As String) As String
    ''    ''
    ''    ''From C.I.B. 
    ''    ''
    ''    Dim strTemp As String
    ''    Dim intTemp As Integer
    ''    Dim strNumberSub(9) As String

    ''    strNumberSub(0) = ","
    ''    strNumberSub(1) = "$"
    ''    strNumberSub(2) = "/"
    ''    strNumberSub(3) = "("
    ''    strNumberSub(4) = "%"
    ''    strNumberSub(5) = "#"
    ''    strNumberSub(6) = "+"
    ''    strNumberSub(7) = "!"
    ''    strNumberSub(8) = "*"
    ''    strNumberSub(9) = ")"

    ''    gScrambleString = "" ''Initialize.   

    ''    For intCount = 1 To Len(strStringToScramble)
    ''        strTemp = Mid$(strStringToScramble, intCount, 1)
    ''        intTemp = Asc(strTemp)
    ''        If intTemp > 47 And intTemp < 58 Then '0 thru 9
    ''            '' 2/7/2018 TD''strTemp = strNumberSub(Val(strTemp))
    ''            strTemp = strNumberSub(Integer.Parse(strTemp))
    ''        Else
    ''            If intTemp Mod 2 = 1 Then
    ''                strTemp = Chr(intTemp - 4)
    ''            Else
    ''                strTemp = Chr(intTemp - 6)
    ''            End If
    ''        End If
    ''        gScrambleString = gScrambleString & strTemp
    ''    Next intCount

    ''End Function ''End of "Private Function gScrambleString"

    ''Private Function FindTheInstalledVersion_CIBConfig() As String
    ''    ''
    ''    ''Created 2/21/2018 Thomas DOWNES  
    ''    ''
    ''    Dim array_versions As String() ''Added 2/21/2018 Thomas D. 
    ''    Dim strPathToConfigFile As String = "" ''Added 2/21/2018 Thomas D. 
    ''    Dim boolHasBackslashAlready As Boolean ''Added 2/26/2018 Thomas D. 

    ''    ''2/26/2018 Thomas D.''array_versions = New String() {String.Empty, "71", "72", "81", "82", "83", "90", "91", "83"}
    ''    array_versions = New String() {"82", "83", "81", "71", "72", "90", "91", "92", String.Empty}

    ''    For Each strVersion99 As String In array_versions

    ''        ''Example, C:\CI Solutions\CI Badge\Data\CIBConfig83.mdb.
    ''        ''   ---2/21/2018 Thomas D. 
    ''        ''
    ''        ''2/21/2018 TD''strPathToConfigFile = (CI_Badge_Default_Data_Folder & "\CIBConfig" & strVersion99 & ".mdb")
    ''        ''2/26/2018 TD''strPathToConfigFile = (CI_Badge_Default_Data_Folder & "CIBConfig" & strVersion99 & ".mdb")

    ''        boolHasBackslashAlready = (CI_Badge_Default_Data_Folder.EndsWith("\")) ''Added 2/26/2018 TD

    ''        If boolHasBackslashAlready Then ''Added 2/26/2018 TD
    ''            strPathToConfigFile = (CI_Badge_Default_Data_Folder & ("CIBConfig" & strVersion99 & ".mdb"))
    ''        Else
    ''            strPathToConfigFile = (CI_Badge_Default_Data_Folder & "\" & ("CIBConfig" & strVersion99 & ".mdb"))
    ''        End If ''End of "boolHasBackslashAlready ... Else ..."

    ''        If (System.IO.File.Exists(strPathToConfigFile)) Then Exit For

    ''    Next strVersion99

    ''    Return strPathToConfigFile

    ''End Function ''End of "Private Function FindTheInstalledVersion_CIBConfig"

    ''Private Sub AllowUserToSelectAnMDB(Optional ByRef par_boolSelected As Boolean = False)
    ''    ''
    ''    ''Added 2/21/2018 Thomas DOWNES  
    ''    ''
    ''    ''   Let's allow the user to set the module-level variable _strPathToSelectedMDB. 
    ''    ''
    ''    Dim objFormToShow As New frmPointToMDB

    ''    '' 2/21/2018 TD''_strPathToSelectedMDB = ""

    ''    With objFormToShow

    ''        ''Added 2/26/2018 TD 
    ''        ''2/26 TD''.DefaultPathToMDB = CI_Badge_Default_Config_File
    ''        .PathToMDB_InitialDefault = CI_Badge_Default_Config_File

    ''        .ShowDialog()

    ''        ''Added 2/2/2018 Thomas DOWNES  
    ''        If ("" <> .PathToSelectedMDBFile) Then
    ''            _strPathToSelectedMDB = .PathToSelectedMDBFile
    ''            par_boolSelected = True
    ''        End If ''End of "If ("" <> .PathToSelectedMDBFile) Then"

    ''    End With ''End of "With objFormToShow"

    ''End Sub ''End of "Private Sub AllowUserToSelectAnMDB()"

    ''Private Sub textLoginName_Leave(sender As Object, e As EventArgs) Handles textLoginName.Leave

    ''    ''Put in the expected casing, such as "Thomas", not "THOMAS" or "thomas" or "tHoMaS".  
    ''    With textLoginName

    ''        If (String.IsNullOrWhiteSpace(.Text)) Then Exit Sub ''Added 2/14/2018 thomas downes 

    ''        ''Put in the expected casing, such as "Thomas", not "THOMAS" or "thomas" or "tHoMaS".  
    ''        .Text = UCase(.Text.Substring(0, 1)) & LCase(.Text.Substring(1))

    ''    End With

    ''End Sub

    ''Private Sub linklabelSelectFileMDB_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linklabelSelectFileMDB.LinkClicked

    ''    ''Created 2/2/2018 Thomas DOWNES  
    ''    AllowUserToSelectAnMDB()

    ''End Sub

    Private Sub FormLogin_v90_Load(sender As Object, e As EventArgs) Handles Me.Load

        ''Added 5/15/2019 td
        Dim boolUseCommandLineArg_Part1 As Boolean ''Added 5/15/2019 td  
        Dim boolUseCommandLineArg_2ndArg As Boolean ''Added 6/3/2019 td  

        ''Added 5/15/2019 td 
        boolUseCommandLineArg_Part1 = (My.Application.CommandLineArgs IsNot Nothing _
                                             AndAlso My.Application.CommandLineArgs.Count > 0)
        If (boolUseCommandLineArg_Part1) Then
            ''Added 6/3/2019 td 
            boolUseCommandLineArg_2ndArg = (2 <= My.Application.CommandLineArgs.Count)
            If (boolUseCommandLineArg_2ndArg) Then

                ''Added 6/4/2019 td 
                ''
                ''Close the form, the user doesn't have to enter his credentials.  
                ''
                Me.DialogResult = DialogResult.OK
                Me.Close()

            End If ''End of "If (boolUseCommandLineArg_2ndArg) Then"
        End If ''End of "If (boolUseCommandLineArg_Part1) Then"

        ''
        ''Prepare the form for use by the Support person. 
        ''
        ''Added 4/16/2018 Thomas DOWNES  
        textLoginName.Focus()

    End Sub

    Private Sub textLoginName_TextChanged(sender As Object, e As EventArgs) Handles textLoginName.TextChanged

        ''If the operator starts to type the Support password, then hide any additional characters.  
        If (textLoginName.Text.StartsWith("t")) Then textLoginName.PasswordChar = "*"c
        If (textLoginName.Text.StartsWith("3")) Then textLoginName.PasswordChar = "*"c

        ''I like the idea of hiding both the username and the password. 
        textLoginName.PasswordChar = "*"c

    End Sub
End Class