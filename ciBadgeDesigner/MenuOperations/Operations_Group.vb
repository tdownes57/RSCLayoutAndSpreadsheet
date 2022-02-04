Option Explicit On
Option Strict On
Option Infer Off

''
''Added 10/17 & 10/1/2019 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements
Imports System.Windows.Forms ''Added 12/30/2021 td
Imports __RSCWindowsControlLibrary ''Added 1/12/2022 td

Public Class Operations_Group
    ''
    ''Added 10/17 & 10/1/2019 td
    ''
    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFieldV3 ''CtlGraphicFldLabel
    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    Private mod_fauxMenuEditSingleton As CtlGraphPopMenuEditSingle ''Added 10/3/2019 td 

    Private mod_strAlignmentTypeText As String ''Added 10/17/2019 tdhomas d

    Private Sub SwitchCtl__Up(sender As Object, e As EventArgs)
        ''
        ''Added 8/16/2019 thomas downes
        ''
        ''10/3/2019 td'Me.SelectingElements.SwitchControls___Up(Me)
        Me.SelectingElements.SwitchControls___Up(Me.CtlCurrentElement)

        ''Added 9/13/2019 td
        ''9/19/2019 td'' Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''End of "Private Sub SwitchCtl__Up(sender As Object, e As EventArgs)"

    Private Sub SwitchCtl_Down(sender As Object, e As EventArgs)
        ''
        ''Added 8/16/2019 thomas downes
        ''
        ''10/3/2019 td'Me.SelectingElements.SwitchControls_Down(Me)
        Me.SelectingElements.SwitchControls_Down(Me.CtlCurrentElement)

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''ENd of "Private Sub SwitchCtl_Down(sender As Object, e As EventArgs)"



    Private Sub GroupEditElement_Add(sender As Object, e As EventArgs)
        ''
        ''Added 8/2/2019 td  
        ''
        Static s_boolRunOnceMsg As Boolean ''Added 8/2/2019 td 
        If (Not s_boolRunOnceMsg) Then
            ''Added 8/2/2019 td  
            s_boolRunOnceMsg = True ''Added 8/3/2019 td  
            MessageBox.Show("You can press the CTRL key while you click the element, to select (or de-select)", "Use CTRL key",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If ''ENd of "If (Not s_boolRunOnceMsg) Then"

        GroupEditElement_Add()

    End Sub ''End of "Private Sub GroupEditElement_Add(sender As Object, e As EventArgs)"


    Private Sub GroupEditElement_Add()
        ''
        ''Added 8/2/2019 td  
        ''
        ''10/17/2019 td''mod_includedInGroupEdit = True
        ''10/17/2019 td''Me.CtlCurrentElement.GroupEdits.LabelsList_IsItemIncluded(Me.CtlCurrentElement)

        ''Jan11 2022 td''Me.SelectingElements.LabelsDesignList_Add(Me.CtlCurrentElement) ''Added 8/1/2019 td
        Me.SelectingElements.ElementsDesignList_Add(Me.CtlCurrentElement) ''Added 8/1/2019 td

        ''8/2/2019''Me.BackColor = Color.Yellow
        ''8/2/2019''pictureLabel.Top = 6
        ''8/2/2019''pictureLabel.Left = 6
        ''8/2/2019''pictureLabel.Width = Me.Width - 2 * 6
        ''8/2/2019''pictureLabel.Height = Me.Height - 2 * 6

        ''Added 8/2/2019 td 
        Me.CtlCurrentElement.ElementInfo_Base.SelectedHighlighting = True
        Me.CtlCurrentElement.Refresh_ImageV3(True)

    End Sub ''End of "Private Sub GroupEditElement_Add()"

    Private Sub GroupEditElement_Omit(sender As Object, e As EventArgs)
        ''
        ''Added 8/2/2019 td  
        ''
        GroupEditElement_Omit()

    End Sub ''End of "Private Sub GroupEditElement_Omit(sender As Object, e As EventArgs)"

    Private Sub GroupEditElement_Omit()
        ''
        ''Added 8/2/2019 td  
        ''
        ''Undo the selection. 
        ''
        ''10/17/2019 td''mod_includedInGroupEdit = False

        Me.SelectingElements.ElementsDesignList_Remove(Me.CtlCurrentElement) ''Added 8/1/2019 td

        ''Me.BackColor = Me.ElementInfo.BackColor
        ''pictureLabel.Top = 0
        ''pictureLabel.Left = 0
        ''pictureLabel.Width = Me.Width ''- 2 * 6
        ''pictureLabel.Height = Me.Height ''- 2 * 6

        With Me.CtlCurrentElement
            .SelectedHighlighting_Denigrated = False ''Added 8/3/2019 td  
            .ElementInfo_Base.SelectedHighlighting = False
            .Refresh_ImageV3(True)
        End With

    End Sub ''End of "Private Sub GroupEditElement_Omit( )"

    Private Sub Alignment_Master(sender As Object, e As EventArgs)
        ''
        ''Added 8/5/2019 thomas downes
        ''
        ''10/17/2019 thomas d''Dim objElements As List(Of CtlGraphicFldLabel)
        ''1/12/2022 td''Dim objElements As HashSet(Of CtlGraphicFldLabel)
        Dim objElements As HashSet(Of RSCMoveableControlVB)
        Dim sender_toolItem As ToolStripItem
        Dim strAlignmentTypeText As String ''Added 8/14/2019 thomas 
        Dim boolExitEarly As Boolean ''Added 8/13/2019 td
        Dim diag_answer As DialogResult ''Added 8/16/2019 thomas d. 

        ''Added 8/16/2019 td  
        Dim intAverage_Top As Int32 = 0
        Dim intAverage_Left As Int32 = 0
        Dim intAverage_Width As Int32 = 0
        Dim intAverage_Height As Int32 = 0

        If (Not modFonts.AskedAlignmentQuestion) Then
            ''Added 8/16/2019 td  
            diag_answer =
                MessageBox.Show("When aligning elements, how do you want to determine the alignment line? " &
                vbCrLf_Deux &
                "Yes = Line elements up with the element which was mouse-clicked. " & vbCrLf &
                "No = Line elements up using an average-line which includes all selected items." & vbCrLf_Deux &
                "(This is a one-time message.  It won't be asked again during this session.)",
                "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            ''Added 8/16/2019 td  
            modFonts.UseAverageLineForAlignment = (diag_answer = DialogResult.No)
            If (diag_answer = DialogResult.Cancel) Then Exit Sub
            modFonts.AskedAlignmentQuestion = True ''Ask only once.  
        End If ''End of "If (Not modFonts.AskedAlignmentQuestion) Then"

        ''10/17/2019 td''CreateVisibleButton_Master("Choose a background color", AddressOf Alignment_Master, boolExitEarly, True)
        ''Moved below.''If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        If (TypeOf sender Is ToolStripMenuItem) Then
            sender_toolItem = CType(sender, ToolStripMenuItem)
            ''Added 8/14/2019 thomas 
            strAlignmentTypeText = sender_toolItem.Text
            mod_strAlignmentTypeText = sender_toolItem.Text ''Added 8/14 td
        Else
            ''Exit Sub
            strAlignmentTypeText = mod_strAlignmentTypeText
        End If ''End of "If (TypeOf sender Is ToolStripMenuItem) Then ..... Else ..."

        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ''Jan11 2022 td''objElements = Me.SelectingElements.LabelsDesignList_AllItems
        objElements = Me.SelectingElements.ElementsDesignList_AllItems

        ''
        ''Added 8/16/2019 td  
        ''
        If (modFonts.UseAverageLineForAlignment) Then

            Dim intSumAll_Top As Int64 = 0
            Dim intSumAll_Left As Int64 = 0
            Dim intSumAll_Width As Int64 = 0
            Dim intSumAll_Height As Int64 = 0
            Dim intCountElements As Int64 = 0

            ''Added 8/16/2019 td  
            For Each each_ctl As CtlGraphicFieldV3 In objElements
                ''Added 8/16/2019 td  
                intSumAll_Left += each_ctl.Left
                intSumAll_Top += each_ctl.Top
                intSumAll_Width += each_ctl.Width
                intSumAll_Height += each_ctl.Height
                intCountElements += 1
            Next each_ctl

            ''Added 8/16/2019 td  
            intAverage_Top = CType(intSumAll_Top / intCountElements, Int32)
            intAverage_Left = CType(intSumAll_Left / intCountElements, Int32)
            intAverage_Width = CType(intSumAll_Width / intCountElements, Int32)
            intAverage_Height = CType(intSumAll_Height / intCountElements, Int32)

        End If ''End of "If (modFonts.UseAverageLineForAlignment) Then"

        For Each each_ctl As CtlGraphicFieldV3 In objElements
            ''
            ''Added 8/5/2019 td  
            ''
            Dim boolAverage As Boolean ''Added 8/16 td  
            boolAverage = modFonts.UseAverageLineForAlignment

            With each_ctl

                Select Case strAlignmentTypeText ''8/14/2019 td''(sender_toolItem.Text)

                    Case "Top" ''10/17/2019 td'' (_item_group_alignTop.Text)

                        ''Top 
                        each_ctl.Top = CInt(IIf(boolAverage, intAverage_Top, Me.CtlCurrentElement.Top)) ''8/16 Me.Top
                        ''8/29/2019 td''each_ctl.ElementInfo_Text.TopEdge_Pixels = each_ctl.Top ''8/16 Me.Top
                        each_ctl.ElementInfo_Base.TopEdge_Pixels = each_ctl.Top ''8/16 Me.Top

                    Case "Left"  ''10/17/2019 td'' (_item_group_alignLeft.Text)

                        ''Left
                        each_ctl.Left = CInt(IIf(boolAverage, intAverage_Left, Me.CtlCurrentElement.Left)) ''8/16 Me.Left
                        each_ctl.ElementInfo_Base.LeftEdge_Pixels = each_ctl.Left ''Me.Left

                    Case "Width"  ''10/17/2019 td'' (_item_group_alignWidth.Text)

                        ''Width
                        each_ctl.Width = CInt(IIf(boolAverage, intAverage_Width, Me.CtlCurrentElement.Width)) ''8/16 Me.Width
                        each_ctl.ElementInfo_Base.Width_Pixels = each_ctl.Width ''Me.Width

                    Case "Height"  ''10/17/2019 td'' (_item_group_alignHeight.Text)

                        ''Height  
                        each_ctl.Height = CInt(IIf(boolAverage, intAverage_Height, Me.CtlCurrentElement.Height)) ''8/16 Me.Height
                        each_ctl.ElementInfo_Base.Height_Pixels = each_ctl.Height ''Me.Height

                End Select ''End of "Select Case strAlignmentTypeText"

                ''Select Case True
                ''    Case (sender_toolItem Is item_group_alignTop) : each_ctl.Top = Me.Top
                ''    Case (sender_toolItem Is item_group_alignLeft) : each_ctl.Left = Me.Left
                ''    Case (sender_toolItem Is item_group_alignWidth)
                ''        each_ctl.Width = Me.Width
                ''        each_ctl.ElementInfo.Width_Pixels = Me.Width
                ''    Case (sender_toolItem Is item_group_alignHeight)
                ''        each_ctl.Height = Me.Height
                ''        each_ctl.ElementInfo.Height_Pixels = Me.Height
                ''End Select

            End With ''End of "With each_ctl"

        Next each_ctl

        ''Added 9/13/2019 td
        ''Denigrated. 9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub Alignment_Master()"


End Class ''End of Class Operations_EditGroup  
