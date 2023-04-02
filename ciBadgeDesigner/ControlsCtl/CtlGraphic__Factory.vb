Imports System.ComponentModel
Imports System.Drawing
Imports __RSCWindowsControlLibrary
Imports ciBadgeElements ''Added 4/1/2023 thomas  
Imports ciBadgeInterfaces ''Added 4/1/2023 thomas

''' <summary>
''' This class is the parent of all of the Element Controls, or soon will be. 4/1/2023 td   
''' </summary>
Public Class CtlGraphic__Factory

    ''' <summary>
    ''' This is the factory function to create the CtlGraphic... controls. 
    ''' </summary>
    Public Shared Function GetControl(par_parametersGetElementControl As ClassGetElementControlParams,
            par_element As ClassElementBase,
            par_formParent As Form,
            par_nameOfControl As String,
            par_iLayoutFun As ILayoutFunctions,
            par_iSizeIfNeeded As Size,
            par_bProportionSizing As Boolean,
            par_iControlLastTouched As ILastControlTouched,
            par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton,
            Optional pbUseMonemProportionalityClass As Boolean = False) _
            As CtlGraphic__Factory
        ''
        ''Added 4/01/2023 Thomas Downes  
        ''
        Select Case True
            Case (TypeOf par_element Is ClassElementFieldV4)

                Dim objElementFieldV4 As ClassElementFieldV4
                objElementFieldV4 = CType(par_element, ClassElementFieldV4)
                With par_parametersGetElementControl
                    Return CtlGraphicFieldV4.GetFieldControl(objElementFieldV4,
                                                         par_formParent,
                                                         .DesignerClass,
                                                         par_nameOfControl,
                                                         par_iSizeIfNeeded)
                End With

            Case (TypeOf par_element Is ClassElementGraphic)

                Dim objElementGraphic As ClassElementGraphic
                objElementGraphic = CType(par_element, ClassElementGraphic)

                Return CtlGraphicStaticGraphic.GetStaticGraphic(par_parametersGetElementControl,
                        objElementGraphic,
                        par_parametersGetElementControl.oMoveEventsGroupedControls,
                        par_iSizeIfNeeded,
                        par_bProportionSizing,
                        pbUseMonemProportionalityClass)

            Case (TypeOf par_element Is ClassElementPortrait)

                Dim objElementPic As ClassElementPortrait
                objElementPic = CType(par_element, ClassElementPortrait)

                Return CtlGraphicPortrait.GetPortrait(par_parametersGetElementControl,
                    objElementPic,
                    par_parametersGetElementControl.DesignerForm,
                    par_parametersGetElementControl.NameOfControl,
                    par_parametersGetElementControl.iLayoutFunctions,
                    pbUseMonemProportionalityClass)


        End Select

        Return Nothing

    End Function ''Endof ""Public Shared Function GetControl(par_element As ClassElementBase""


    Public Shared Function GetControl(par_element As ClassElementBase,
                                           par_formParent As Form,
                                           par_oDesigner As ClassDesigner,
                                           par_nameOfControl As String,
                                           par_sizeNeeded As Size) As RSCMoveableControlVB
        ''
        ''Added 4/01/2023 Thomas Downes  
        ''
        Select Case True
            Case (TypeOf par_element Is ClassElementFieldV4)

                Dim objElementFieldV4 As ClassElementFieldV4
                objElementFieldV4 = CType(par_element, ClassElementFieldV4)
                Return CtlGraphicFieldV4.GetFieldControl(objElementFieldV4,
                                                         par_formParent,
                                                         par_oDesigner,
                                                         par_nameOfControl,
                                                         par_sizeNeeded)

            Case (TypeOf par_element Is ClassElementGraphic)

                Dim objElementGraphic As ClassElementGraphic
                objElementGraphic = CType(par_element, ClassElementGraphic)
                'Return CtlGraphicStaticGraphic.GetStaticGraphic(objElementGraphic,
                '                                         par_formParent,
                '                                         par_oDesigner,
                '                                         par_nameOfControl,
                '                                         par_sizeNeeded)

            Case (TypeOf par_element Is ClassElementPortrait)



        End Select

        Return Nothing

    End Function ''End of ""Public Shared Function GetControl""





End Class
