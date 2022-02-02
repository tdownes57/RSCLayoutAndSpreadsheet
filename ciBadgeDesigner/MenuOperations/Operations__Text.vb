''
''Added 12/30/2021 
''
Public MustInherit Class Operations__Text
    Inherits Operations__Base
    ''
    ''Added 12/30/2021 
    ''
    ''Added keyword "MustInherit" on 1/21/2022, so that I could have the 
    ''  Public Property Element_Type have the same keyword ("MustInherit")
    ''  (which in turn caused the Class itself to require the same keyword).
    ''   ----1/21/2022 td
    ''

    Public Sub Rotate90_Degrees_Clockwise_TE1001(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        Const c_counterclockwise As Boolean = False ''False, it's actually clockwise, not counter-clockwise. 
        Rotate90_Degrees(c_counterclockwise)

    End Sub

    Public Sub Rotate90_Degrees_Counterclockwise_TE1002(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        Const c_counterclockwise As Boolean = True ''True, counter-clockwise.
        Rotate90_Degrees(c_counterclockwise)

    End Sub


    Private Sub Rotate90_Degrees(Optional pbCounterclockwise As Boolean = False)
        ''Feb2 2022''Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''         ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''2/2/2022 ''With Me.CtlCurrentElementField.ElementInfo_Base
        With Me.CtlCurrentElement.ElementInfo_Base

            Select Case .OrientationToLayout
                Case "", " ", "P"
                    .OrientationToLayout = "L"
                Case "L"
                    .OrientationToLayout = "P"
                Case Else
                    .OrientationToLayout = "P"

            End Select ''End of "Select Case .OrientationToLayout"

            ''Added 8/12/2019 thomas downes 
            ''
            ''   Increment by 90 degrees.  
            ''    This will enable the badge to be printed with the element oriented
            ''   correctly (with one out of four choices of orientation). 
            ''
            ''Feb2 2022 td''.OrientationInDegrees += 90
            If (pbCounterclockwise) Then
                .OrientationInDegrees -= 90 ''Added 2/2/2022
            Else
                .OrientationInDegrees += 90 ''Added 2/2/2022
            End If ''End of "If (pbCounterclockwise) Then ... Else ..."

            ''Added 9/23/2019 td
            If (360 <= .OrientationInDegrees) Then
                ''Remove 360 degrees (the full circle) from the 
                ''    property value.   We don't want to have to 
                ''    do modulo arithmetic (divide by 360 & get 
                ''    the remainder).  ---9/23/2019 td 
                ''     
                .OrientationInDegrees = (.OrientationInDegrees - 360)
            End If ''End of "If (360 <= .OrientationInDegrees) Then"

        End With ''End of "With Me.ElementInfo_Base"

        '' 9/15 td''Refresh_Image()
        '' 9/23 td''Refresh_Image(True)
        '' 9/23 td''Me.Refresh()
        ''10/17/2019 td''Me.Refresh_Master()
        ''2/02/2022 td''Me.CtlCurrentElementField.Refresh_Master()
        Me.CtlCurrentElement.Refresh_Master()

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)"



End Class
