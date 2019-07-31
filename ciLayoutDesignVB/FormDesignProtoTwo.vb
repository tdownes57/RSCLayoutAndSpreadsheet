Option Explicit On
Option Infer Off
Option Strict On
''
''Added 7/18/2019 Thomas DOWNES
''
Imports ControlManager

Public Class FormDesignProtoTwo
    ''
    ''Added 7/18/2019 Thomas DOWNES
    ''
    ''Private mod_generator As LayoutElementGenerator

    ''Private mod_Pic As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Logo As IElement ''Added 7/18/2019 thomas downes 

    ''Private mod_NameFull As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_RecipientID As IElement ''Added 7/18/2019 thomas downes 

    ''Private mod_Text1 As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Text2 As IElement
    ''Private mod_Text3 As IElement
    ''Private mod_Text4 As IElement
    ''Private mod_Text5 As IElement
    ''Private mod_Text6 As IElement
    ''Private mod_Text7 As IElement
    ''Private mod_Text8 As IElement

    ''Private mod_Date1 As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Date2 As IElement
    ''Private mod_Date3 As IElement

    Private vbCrLf_Deux As String = (vbCrLf & vbCrLf) ''Added 7/31/2019 td 

    Private Sub FormDesignProtoTwo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        LoadElementGenerator()

        Me.Controls.Remove(GraphicFieldLabel1)
        Me.Controls.Remove(GraphicFieldLabel2)
        Me.Controls.Remove(GraphicFieldLabel3)
        Me.Controls.Remove(GraphicFieldLabel4)
        Me.Controls.Remove(GraphicFieldLabel5)

        ''7/31/2019 td''Me.Controls.Remove(pictureboxPic) ''Added 7/31/2019 thomas d. 
        Me.Controls.Remove(CtlGraphicPortrait1) ''Added 7/31/2019 thomas d. 

        ''Encapsulated 7/31/2019 td
        Load_Form()

    End Sub

    Private Sub Load_Form()
        ''
        ''Encapsulated 7/31/2019 td
        ''
        ''7/31/2019 td''LoadElements()
        LoadElements_Fields()

        ''Added 7/31/2019 td  
        LoadElements_Picture()

        MakeElementsMoveable()

        ''Added 7/28/2019 td
        ''    Make sure that the Badge Background is in the background. 
        ''
        pictureBack.SendToBack()

    End Sub ''ENd of "Private Sub Load_Form()"

    Private Sub MakeElementsMoveable()
        ''
        ''Added 7/19/2019 thomas downes  
        ''

        ''
        ''Portrait
        ''
        ControlMoverOrResizer_TD.Init(CtlGraphicPortrait1.Picture_Box,
                      CtlGraphicPortrait1, 10, True) ''Added 7/31/2019 thomas downes

        ''
        ''Fields
        ''
        Dim each_graphicLabel As CtlGraphicFldLabel ''Added 7/19/2019 thomas downes  

        For Each each_control As Control In Me.Controls ''Added 7/19/2019 thomas downes  

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_graphicLabel = CType(each_control, CtlGraphicFldLabel)

                ''7/31/2019 td''ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
                ''                      each_control, 10) ''Added 7/28/2019 thomas downes

                Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td 

                ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
                                              each_control, 10, c_bRepaintAfterResize) ''Added 7/28/2019 thomas downes

            End If ''End of "If (TypeOf each_control Is GraphicFieldLabel) Then"

        Next each_control

    End Sub ''End of "Private Sub MakeElementsMoveable()"

    Private Sub LoadElements_Picture()
        ''
        ''Added 7/31/2019 thomas downes 
        ''
        ''7/31 td''Dim new_picControl As CtlGraphicPortrait ''Added 7/31/2019 td  

        If (ClassElementPic.ElementPicture Is Nothing) Then

            ClassElementPic.ElementPicture = New ClassElementPic

            With ClassElementPic.ElementPicture

                .Width = CtlGraphicPortrait1.Width
                .Height = CtlGraphicPortrait1.Height

                .TopEdge = CtlGraphicPortrait1.Top
                .LeftEdge = CtlGraphicPortrait1.Left

            End With ''End of "With field_standard.ElementInfo"

        End If ''End of "If (ClassElementPic.ElementPicture Is Nothing) Then"

        ''#1 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture)
        '' #2 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
        ''      CType(ClassElementPic.ElementPicture, IElementPic))
        '' #2 7/31/2019 td''Me.Controls.Add(new_picControl)

        ''
        ''DIFFICULT & CONFUSING.....  Let's regenerate the control referenced above.  
        ''
        CtlGraphicPortrait1 = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
                                                 CType(ClassElementPic.ElementPicture, IElementPic))

        Me.Controls.Add(CtlGraphicPortrait1)

        With CtlGraphicPortrait1

            .Top = ClassElementPic.ElementPicture.TopEdge
            .Left = ClassElementPic.ElementPicture.LeftEdge
            .Width = ClassElementPic.ElementPicture.Width
            .Height = ClassElementPic.ElementPicture.Height

        End With ''End of "With CtlGraphicPortrait1"

    End Sub ''Endo f " Private Sub LoadElements_Picture()"

    Private Sub LoadElements_Fields()
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        ''mod_Pic = New ClassElementPic(pictureboxPic)

        ''mod_RecipientID = mod_generator.GetRecipientID(GraphicFieldLabel1) ''New ClassElementText
        ''mod_NameFull = mod_generator.GetFullName(GraphicFieldLabel2) ''New ClassElementText

        ''mod_Text1 = mod_generator.GetTextField1(gr) ''New ClassElementText
        ''mod_Text2 = mod_generator.GetTextField2(PictureBox13) ''New ClassElementText
        ''mod_Text3 = mod_generator.GetTextField3(PictureBox14)

        ''mod_Date1 = mod_generator.GetDateField1(PictureBox15) ''New ClassElementText
        ''mod_Date2 = mod_generator.GetDateField2(PictureBox16) ''New ClassElementText

        Dim intNumControlsAlready_std As Integer ''Added 7/26/2019 td 
        Dim intNumControlsAlready_cust As Integer ''Added 7/26/2019 td 
        ''7/31 td''Dim intTopEdge_cust As Integer ''Added 7/28/2019 td
        Dim intTopEdge_std As Integer ''Added 7/28/2019 td

        ''
        ''Standard Fields 
        ''
        ClassFieldStandard.InitializeHardcodedList_Students(True)

        For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

            Dim new_label_control_std As CtlGraphicFldLabel

            ''Added 7/29
            If (field_standard.ElementInfo Is Nothing) Then

                field_standard.ElementInfo = New ClassElementText()
                new_label_control_std = New CtlGraphicFldLabel(field_standard)
                Me.Controls.Add(new_label_control_std)

                new_label_control_std.Width = CInt(pictureBack.Width / 3)

                With field_standard.ElementInfo

                    .Width_Pixels = new_label_control_std.Width
                    .Height_Pixels = new_label_control_std.Height

                    intTopEdge_std = (30 + 30 * intNumControlsAlready_std)
                    .TopEdge_Pixels = intTopEdge_std
                    .LeftEdge_Pixels = ((10 + intNumControlsAlready_std * .Width_Pixels) + 10)

                End With ''End of "With field_standard.ElementInfo"

            Else

                new_label_control_std = New CtlGraphicFldLabel(field_standard)
                Me.Controls.Add(new_label_control_std)

            End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

            new_label_control_std.Top = field_standard.ElementInfo.TopEdge_Pixels
            new_label_control_std.Left = field_standard.ElementInfo.LeftEdge_Pixels
            new_label_control_std.Width = field_standard.ElementInfo.Width_Pixels
            new_label_control_std.Height = field_standard.ElementInfo.Height_Pixels

            ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

            ''Moved up.''Me.Controls.Add(new_label_control_std)

            ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
            ''Inappropriate. 7/29 td''''new_label_control_std.Top = 10
            ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

            new_label_control_std.Visible = True
            intNumControlsAlready_std += 1

            new_label_control_std.Name = "StandardCtl" & CStr(intNumControlsAlready_std)
            new_label_control_std.BorderStyle = BorderStyle.FixedSingle

            ''
            ''Added 7/28/2019 thomas d.
            ''
            new_label_control_std.RefreshImage()

        Next field_standard

        ''
        ''Custom Fields 
        ''
        ClassFieldCustomized.InitializeHardcodedList_Students(True)

        For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            ''Added 7/29
            ''If (field_custom.ElementInfo Is Nothing) Then field_custom.ElementInfo = New ClassElementText()

            ''Dim new_label_control_cust As New GraphicFieldLabel(field_custom)

            ''intTopEdge_cust = (30 + 30 * intNumControlsAlready_cust)

            ''Me.Controls.Add(new_label_control_cust)
            ''new_label_control_cust.Left = ((intNumControlsAlready_cust * new_label_control_cust.Width) + 10)
            ''''7/28 td''new_label_control_cust.Top = (120 + new_label_control_cust.Height)
            ''new_label_control_cust.Top = intTopEdge_cust
            ''new_label_control_cust.Visible = True

            ''7/28/2019 td''ControlMoverOrResizer_TD.Init(new_label_control_cust, 20) ''Added 7/28/2019 thomas downes

            Dim new_label_control_cust As CtlGraphicFldLabel

            ''Added 7/29
            If (field_custom.ElementInfo Is Nothing) Then

                field_custom.ElementInfo = New ClassElementText()
                new_label_control_cust = New CtlGraphicFldLabel(field_custom)
                Me.Controls.Add(new_label_control_cust)

                new_label_control_cust.Width = CInt(pictureBack.Width / 3)

                With field_custom.ElementInfo

                    .Width_Pixels = new_label_control_cust.Width
                    .Height_Pixels = new_label_control_cust.Height

                    intTopEdge_std = (30 + 30 * intNumControlsAlready_std)
                    .TopEdge_Pixels = intTopEdge_std
                    .LeftEdge_Pixels = ((10 + intNumControlsAlready_std * .Width_Pixels) + 10)

                End With

            Else

                new_label_control_cust = New CtlGraphicFldLabel(field_custom)
                Me.Controls.Add(new_label_control_cust)

            End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

            new_label_control_cust.Top = field_custom.ElementInfo.TopEdge_Pixels
            new_label_control_cust.Left = field_custom.ElementInfo.LeftEdge_Pixels
            new_label_control_cust.Width = field_custom.ElementInfo.Width_Pixels
            new_label_control_cust.Height = field_custom.ElementInfo.Height_Pixels

            ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

            ''Moved up.''Me.Controls.Add(new_label_control_cust)

            ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
            ''Inappropriate. 7/29 td''''new_label_control_std.Top = 10
            ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

            intNumControlsAlready_cust += 1
            new_label_control_cust.Name = "CustCtl" & CStr(intNumControlsAlready_cust)
            new_label_control_cust.BorderStyle = BorderStyle.FixedSingle

            ''
            ''Added 7/28/2019 thomas d.
            ''
            new_label_control_cust.RefreshImage()

        Next field_custom

    End Sub ''End of ''Private Sub LoadElements_Fields()''

    Private Sub SaveLayout()
        ''
        ''Added 7/29/2019 td
        ''
        Dim each_graphicalLabel As CtlGraphicFldLabel

        For Each each_control As Control In Me.Controls

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_graphicalLabel = CType(each_control, CtlGraphicFldLabel)

                each_graphicalLabel.SaveToModel

            End If ''end of "If (TypeOf each_control Is GraphicFieldLabel) Then"

        Next each_control

    End Sub ''End of "PRivate Sub SaveLayout()"  

    Private Sub LoadElementGenerator()
        ''
        ''Added 7/18/2019 
        ''
        ''mod_generator = New LayoutElementGenerator



    End Sub

    Private Sub PictureboxPic_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GraphicFieldLabel1_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel1.Load



    End Sub

    Private Sub GraphicFieldLabel4_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel4.Load

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        ''
        ''Added 7/29/2019 td  
        ''
        SaveLayout

    End Sub

    Private Sub FormDesignProtoTwo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim dia_result As DialogResult
        Dim closing_reason As CloseReason

        closing_reason = e.CloseReason

        ''Added 7/31/2019 td  
        dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (dia_result = DialogResult.Cancel) Then e.Cancel = True
        If (dia_result = DialogResult.Yes) Then SaveLayout()

    End Sub

    Private Sub LinkSaveAndRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSaveAndRefresh.LinkClicked
        ''
        ''Added 7/31/2019 td
        ''
        ''
        ''Step 1 of 3.   Save the user's work. 
        ''
        SaveLayout()

        ''
        ''Step 2 of 3.   Remove the existing controls. 
        ''
        ''Added 7/31/2019 td
        For Each each_control As Control In Me.Controls
            If (TypeOf each_control Is CtlGraphicFldLabel) Then Me.Controls.Remove(each_control)
            If (TypeOf each_control Is CtlGraphicPortrait) Then Me.Controls.Remove(each_control)
        Next each_control

        ''
        ''Step 3 of 3.   Regenerate the form. 
        ''
        Load_Form()

    End Sub

End Class