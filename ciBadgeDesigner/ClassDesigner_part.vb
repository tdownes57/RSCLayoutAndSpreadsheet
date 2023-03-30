''
''Added 8/26/2022
''
Imports __RSCWindowsControlLibrary ''Added 8/26/2022
Imports System.Drawing ''Added 8/26/2022
Imports ciBadgeInterfaces
Imports ciBadgeElements

Partial Public Class ClassDesigner
    ''
    ''Added 8/26/2022
    ''
    Public Sub Edit_Elements_with_Multiple_Dialogs_TE4400(par_controlRSC As RSCMoveableControlVB,
                                           par_listCtlElemsRSC As List(Of RSCMoveableControlVB))
        ''
        ''Added overload 3/28/2023 thomas downes 
        ''
        Dim imageOfBadgeSansElement As Image = Nothing ''Added 8/1/2022 td
        Dim objSideLayoutV1 As ClassBadgeSideLayoutV1 ''Added 8/1/2022 td
        Dim enumCurrentSide As ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard
        Dim strPathToBackgroundImage As String ''Added 8/02/2022 td
        Dim enum_backside As ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard
        Dim enum_frontside As ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard
        Dim tempLayoutfunctions As ciBadgeInterfaces.ILayoutFunctions = Nothing ''Added 8/6/2022
        Dim list_FontFamilyNames As HashSet(Of String) ''Added 8/10/2022
        Dim list_RSCColors As HashSet(Of RSCColor) ''Added 8/10/2022
        Dim objFormToShow As Dialog_BaseEditElement = Nothing
        Dim controlFieldOrTextV4 As CtlGraphicFieldOrTextV4 ''Added 8/26/2022 td
        Dim list_elementsToEdit As New List(Of ClassElementBase) ''Added 3/28/2023 thomas

        ''Added 3/28/2023
        ''   Build a list of elements, rather than the list of element //controls//
        ''   we've been given.  ---3/2023 thomas downes 
        ''
        For Each each_ctl As RSCMoveableControlVB In par_listCtlElemsRSC
            ''The elements (base class)
            list_elementsToEdit.Add(each_ctl.ElementBase)
        Next each_ctl

        ''
        ''Give the list of elements to the base editing dialog.
        ''
        Try
            ''Added 8/26/2022 
            ''3/2023 controlFieldOrTextV4 = CType(par_controlRSC, CtlGraphicFieldOrTextV4)

            ''Added 8/1/2022 
            enumCurrentSide = EnumSideOfCard_Current ''---Me.Designer.EnumSideOfCard_Current
            With ElementsCache_UseEdits ''---Me.ElementsCacheManager.CacheForEditing
                objSideLayoutV1 = .GetAllBadgeSideLayoutElementsV1(enumCurrentSide,
                        DesignerForm_Interface.BadgeLayout) ''---Me.Designer.DesignerForm_Interface.BadgeLayout)
                enum_backside = ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard.EnumBackside
                enum_frontside = ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard.EnumFrontside

                If (enumCurrentSide = enum_backside) Then
                    strPathToBackgroundImage = .BackgroundImage_Backside_Path
                Else
                    strPathToBackgroundImage = .BackgroundImage_Front_Path
                End If

                ''Added 8/10/2022 td
                list_FontFamilyNames = .ListOfFontFamilyNames ''Added 8/10/2022 td
                list_RSCColors = .ListOfRSCColors ''Added 8/10/2022 td

            End With ''End of ""With Me.ElementsCacheManager.CacheForEditing""

            Try
                ''Added 8/01/2022 Thomas d
                BackgroundEditImage.CheckBackgroundImageSize(objSideLayoutV1.BackgroundImage,
                                                             Me.DesignerForm_Interface.BadgeLayout,
                                                             strPathToBackgroundImage)
                ''                   ''--Me.Designer.DesignerForm_Interface.BadgeLayout,
                ''                   ''--strPathToBackgroundImage)
            Catch ex_rr45 As Exception
                ''Added 8/17/2022 Thomas d
                System.Diagnostics.Debugger.Break()
            End Try

            Try
                imageOfBadgeSansElement =
                     Me.GetBadgeImage_EitherSide(enumCurrentSide,
                     objSideLayoutV1, Nothing, Nothing,
                     Dialog_Base.GetBadgeLayoutClass(), list_elementsToEdit)

            Catch ex_rr46 As Exception
                ''Added 8/17/2022 Thomas d
                System.Diagnostics.Debugger.Break()
            End Try

            tempLayoutfunctions = par_controlRSC.LayoutFunctions

            ''Added 8/26/2022 
            controlFieldOrTextV4 = CType(par_controlRSC, CtlGraphicFieldOrTextV4)

            objFormToShow = New Dialog_BaseEditElement(controlFieldOrTextV4,
                                                       ElementsCache_UseEdits,
                                       par_controlRSC.ElementBase,
                                       par_controlRSC.ElementInfo_Base,
                                       Me, Me.GroupMoveEvents,
                                       imageOfBadgeSansElement,
                                       par_listCtlElemsRSC)

        Catch ex_edit As Exception
            ''
            ''Added 8/02/2022 thomas downes  
            ''
            System.Diagnostics.Debugger.Break()

        End Try

        ''
        ''Open the dialog for editing the element.
        ''
        Try
            If (objFormToShow IsNot Nothing) Then
                objFormToShow.ShowDialog()
            End If ''End of ""If (objFormToShow IsNot Nothing) Then""

        Catch ex_show As Exception
            ''
            ''Added 8/26/2022 thomas downes  
            ''
            System.Diagnostics.Debugger.Break()

        End Try

ExitHandler:
        ''
        ''Return the control-element to the parent form. 
        ''
        Me.DesignerForm.Controls.Add(par_controlRSC)
        par_controlRSC.BringToFront()
        par_controlRSC.Visible = True

        ''Restore the prior LayoutFunctions (Designer).
        If (tempLayoutfunctions Is Nothing) Then
            ''Aug26 2022 ''Me.CtlCurrentFieldOrTextV4.LayoutFunctions = Me.Designer
            par_controlRSC.LayoutFunctions = Me ''---.Designer
        Else
            ''Aug26 2022 ''Me.CtlCurrentFieldOrTextV4.LayoutFunctions = tempLayoutfunctions
            par_controlRSC.LayoutFunctions = tempLayoutfunctions
        End If ''End of ""If (tempLayoutfunctions Is Nothing) Then... Else...""

        ''Added 9/02/2022
        Dim intElementLeft As Integer ''Added 9/02/2022
        Dim intElementTop As Integer ''Added 9/02/2022
        Dim intControlLeft As Integer ''Added 9/02/2022
        Dim intControlTop As Integer ''Added 9/02/2022

        With par_controlRSC.LayoutFunctions
            intElementLeft = par_controlRSC.ElementBase.LeftEdge_Pixels
            intElementTop = par_controlRSC.ElementBase.TopEdge_Pixels
            intControlLeft = .Layout_Margin_Left_Add(intElementLeft)
            intControlTop = .Layout_Margin_Top_Add(intElementTop)
            par_controlRSC.Left = intControlLeft
            par_controlRSC.Top = intControlTop
        End With ''End of ""With par_controlRSC.LayoutFunctions""

        Me.AutoPreview_IfChecked()

    End Sub ''End of ""Public Sub Edit_Element_with_Multiple_Dialogs_TE9400""


    Public Sub Edit_Element_with_Multiple_Dialogs_TE9400(par_controlRSC As RSCMoveableControlVB)
        ''
        ''Added 5/31/2022 thomas downes 
        ''
        ''8/01/2022 Dim objFormToShow As New Dialog_BaseEditElement(Me.CtlCurrentFieldOrTextV4)

        Dim imageOfBadgeSansElement As Image = Nothing ''Added 8/1/2022 td
        Dim objSideLayoutV1 As ClassBadgeSideLayoutV1 ''Added 8/1/2022 td
        Dim enumCurrentSide As ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard
        Dim strPathToBackgroundImage As String ''Added 8/02/2022 td
        Dim enum_backside As ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard
        Dim enum_frontside As ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard
        Dim tempLayoutfunctions As ciBadgeInterfaces.ILayoutFunctions = Nothing ''Added 8/6/2022
        Dim list_FontFamilyNames As HashSet(Of String) ''Added 8/10/2022
        Dim list_RSCColors As HashSet(Of RSCColor) ''Added 8/10/2022
        Dim objFormToShow As Dialog_BaseEditElement = Nothing
        Dim controlFieldOrTextV4 As CtlGraphicFieldOrTextV4 ''Added 8/26/2022 td

        Try
            ''Added 8/26/2022 
            controlFieldOrTextV4 = CType(par_controlRSC, CtlGraphicFieldOrTextV4)

            ''Added 8/1/2022 
            enumCurrentSide = EnumSideOfCard_Current ''---Me.Designer.EnumSideOfCard_Current
            With ElementsCache_UseEdits ''---Me.ElementsCacheManager.CacheForEditing
                objSideLayoutV1 = .GetAllBadgeSideLayoutElementsV1(enumCurrentSide,
                        DesignerForm_Interface.BadgeLayout) ''---Me.Designer.DesignerForm_Interface.BadgeLayout)
                enum_backside = ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard.EnumBackside
                enum_frontside = ciBadgeInterfaces.ModEnumsAndStructs.EnumWhichSideOfCard.EnumFrontside
                If (enumCurrentSide = enum_backside) Then
                    strPathToBackgroundImage = .BackgroundImage_Backside_Path
                Else
                    strPathToBackgroundImage = .BackgroundImage_Front_Path
                End If

                ''Added 8/10/2022 td
                list_FontFamilyNames = .ListOfFontFamilyNames ''Added 8/10/2022 td
                list_RSCColors = .ListOfRSCColors ''Added 8/10/2022 td

            End With ''End of ""With Me.ElementsCacheManager.CacheForEditing""

            Try
                ''Added 8/01/2022 Thomas d
                BackgroundEditImage.CheckBackgroundImageSize(objSideLayoutV1.BackgroundImage,
                                                             Me.DesignerForm_Interface.BadgeLayout,
                                                             strPathToBackgroundImage)
                ''                   ''--Me.Designer.DesignerForm_Interface.BadgeLayout,
                ''                   ''--strPathToBackgroundImage)
            Catch ex_rr45 As Exception
                ''Added 8/17/2022 Thomas d
                System.Diagnostics.Debugger.Break()
            End Try

            Try
                ''Aug01 2022 ''imageOfBadgeSansElement = MyBase.Designer.GetBadgeSideSansElement(Me.ElementObject_Base)
                imageOfBadgeSansElement =
                     Me.GetBadgeImage_EitherSide(enumCurrentSide,
                     objSideLayoutV1, Nothing, par_controlRSC.ElementBase,
                     Dialog_Base.GetBadgeLayoutClass())

            Catch ex_rr46 As Exception
                ''Added 8/17/2022 Thomas d
                System.Diagnostics.Debugger.Break()
            End Try

            ''Added 8/6/2022
            ''8/26/2022 tempLayoutfunctions = Me.CtlCurrentFieldOrTextV4.LayoutFunctions
            tempLayoutfunctions = par_controlRSC.LayoutFunctions

            ''8/17/2022 Dim objFormToShow As New Dialog_BaseEditElement
            ''10/24/2022 objFormToShow = New Dialog_BaseEditElement(controlFieldOrTextV4,
            ''                                                list_FontFamilyNames,
            ''                                                list_RSCColors,
            ''                           par_controlRSC.ElementBase,
            ''                           par_controlRSC.ElementInfo_Base,
            ''                           Me, Me.GroupMoveEvents,
            ''                           imageOfBadgeSansElement)
            objFormToShow = New Dialog_BaseEditElement(controlFieldOrTextV4,
                                                       ElementsCache_UseEdits,
                                       par_controlRSC.ElementBase,
                                       par_controlRSC.ElementInfo_Base,
                                       Me, Me.GroupMoveEvents,
                                       imageOfBadgeSansElement)

        Catch ex_edit As Exception
            ''
            ''Added 8/02/2022 thomas downes  
            ''
            System.Diagnostics.Debugger.Break()

        End Try

        ''
        ''Open the dialog for editing the element.
        ''
        Try
            If (objFormToShow IsNot Nothing) Then
                objFormToShow.ShowDialog()
            End If ''End of ""If (objFormToShow IsNot Nothing) Then""

        Catch ex_show As Exception
            ''
            ''Added 8/26/2022 thomas downes  
            ''
            System.Diagnostics.Debugger.Break()

        End Try

ExitHandler:
        ''
        ''Return the control-element to the parent form. 
        ''
        ''Aug26 2022 ''MyBase.CtlCurrentForm.Controls.Add(Me.CtlCurrentFieldOrTextV4)
        ''Aug26 2022 ''Me.CtlCurrentFieldOrTextV4.BringToFront()
        ''Aug26 2022 ''Me.CtlCurrentFieldOrTextV4.Visible = True
        Me.DesignerForm.Controls.Add(par_controlRSC)
        par_controlRSC.BringToFront()
        par_controlRSC.Visible = True

        ''Restore the prior LayoutFunctions (Designer).
        If (tempLayoutfunctions Is Nothing) Then
            ''Aug26 2022 ''Me.CtlCurrentFieldOrTextV4.LayoutFunctions = Me.Designer
            par_controlRSC.LayoutFunctions = Me ''---.Designer
        Else
            ''Aug26 2022 ''Me.CtlCurrentFieldOrTextV4.LayoutFunctions = tempLayoutfunctions
            par_controlRSC.LayoutFunctions = tempLayoutfunctions
        End If ''End of ""If (tempLayoutfunctions Is Nothing) Then... Else...""

        ''Added 9/02/2022
        Dim intElementLeft As Integer ''Added 9/02/2022
        Dim intElementTop As Integer ''Added 9/02/2022
        Dim intControlLeft As Integer ''Added 9/02/2022
        Dim intControlTop As Integer ''Added 9/02/2022

        With par_controlRSC.LayoutFunctions
            ''9/5/2022 intElementLeft = par_controlRSC.ElementBase.LeftEdge_bPixels
            ''9/5/2022 intElementTop = par_controlRSC.ElementBase.TopEdge_bPixels
            intElementLeft = par_controlRSC.ElementBase.LeftEdge_Pixels
            intElementTop = par_controlRSC.ElementBase.TopEdge_Pixels
            intControlLeft = .Layout_Margin_Left_Add(intElementLeft)
            intControlTop = .Layout_Margin_Top_Add(intElementTop)
            par_controlRSC.Left = intControlLeft
            par_controlRSC.Top = intControlTop
        End With ''End of ""With par_controlRSC.LayoutFunctions""

        ''Added 8/25/2022
        ''8/26/2022 td''Me.LayoutFunctions.AutoPreview_IfChecked()
        Me.AutoPreview_IfChecked()


    End Sub ''End of ""Public Sub Edit_Element_With_Multiple_Dialogs_TE9400()"


    Public Sub RefreshBackgroundArrows()
        ''
        ''Added 3/16/2023 thomas downes
        ''
        If (True) Then

        End If

    End Sub ''ENd of ""Public Sub RefreshBackgroundArrows()""


End Class
