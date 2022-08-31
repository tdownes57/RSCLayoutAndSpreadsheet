Option Explicit On ''Added 8/30/2022
Option Strict On ''Added 8/30/2022

Imports ciBadgeInterfaces ''Added 8/30/2022
''
''Added 8/30/2022
''
Public Class RSCColorFlowPanel
    ''
    ''Added 8/30/2022
    ''
    Private mod_listMSColors_NotUsed As New List(Of Drawing.Color)

    Public Sub AddColors_AllPossibleColors(Optional pbOmitUIRelatedColors As Boolean = True)
        ''
        ''Added 8/30/2022 td 
        ''
        Dim arrayOfColorNames As String()
        Dim each_colorMS As Drawing.Color
        Dim intNumberOfColors As Integer ''Added 8/30/2022
        Dim boolOmitUI As Boolean

        boolOmitUI = pbOmitUIRelatedColors

        With FlowLayoutPanel1.Controls

            arrayOfColorNames = [Enum].GetNames(GetType(System.Drawing.KnownColor))
            intNumberOfColors = arrayOfColorNames.Length ''Added 8/30/2022

            ''
            ''Loop through the colors. 
            ''
            For Each each_colorName As String In arrayOfColorNames

                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "ControlLight") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "ControlDark") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For


                each_colorMS = Drawing.Color.FromName(each_colorName)

                Dim newLabel As New RSCColorDisplayLabel
                newLabel.BackColor = each_colorMS
                newLabel.Text = each_colorMS.Name
                newLabel.Visible = True
                AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click
                .Add(newLabel) ''Added 8/30/2022 

            Next each_colorName


        End With ''End of ""With FlowLayoutPanel1.Controls""

    End Sub ''Endof ""Public Sub AddColors_AllPossibleColors()""


    Public Sub AddColors_BlackAndWhite()
        ''
        ''Added 8/30/2022 td 
        ''
        Dim newLabel_Black As New RSCColorDisplayLabel
        Dim newLabel_White As New RSCColorDisplayLabel
        Dim colorMS_Black As Drawing.Color
        Dim colorMS_White As Drawing.Color

        colorMS_Black = Drawing.Color.Black
        colorMS_White = Drawing.Color.White

        With FlowLayoutPanel1.Controls

            ''Black 
            newLabel_Black.BackColor = colorMS_Black
            newLabel_Black.Text = colorMS_Black.Name
            newLabel_Black.Visible = True
            AddHandler newLabel_Black.ColorClick, AddressOf NetDrawingColor_Click
            .Add(newLabel_Black) ''Added 8/30/2022 
            newLabel_Black.Visible = True

            ''White 
            newLabel_White.BackColor = colorMS_White
            newLabel_White.Text = colorMS_White.Name
            newLabel_White.Visible = True
            AddHandler newLabel_White.ColorClick, AddressOf NetDrawingColor_Click
            .Add(newLabel_White) ''Added 8/30/2022 
            newLabel_White.Visible = True

        End With ''End of ""With FlowLayoutPanel1.Controls""

    End Sub ''End of ""Public Sub AddColors_BlackAndWhite()""


    Public Sub LoadListOfColors_Obselete()
        ''
        '' Added 3/4/2022 thomas downes
        ''
        If (mod_listMSColors_NotUsed Is Nothing) Then
            mod_listMSColors_NotUsed = New List(Of Drawing.Color)
        End If ''If (mod_listMSColors Is Nothing) Then

        With mod_listMSColors_NotUsed

            .Add(Drawing.Color.AliceBlue)
            .Add(Drawing.Color.AntiqueWhite)
            .Add(Drawing.Color.Aqua)
            .Add(Drawing.Color.Aquamarine)
            .Add(Drawing.Color.Azure)

            .Add(Drawing.Color.Beige)
            .Add(Drawing.Color.Bisque)
            .Add(Drawing.Color.Black)
            .Add(Drawing.Color.BlanchedAlmond)
            .Add(Drawing.Color.Blue)
            .Add(Drawing.Color.BlueViolet)
            .Add(Drawing.Color.Brown)
            .Add(Drawing.Color.BurlyWood)

            ''Added 8/7/2022
            .Add(Drawing.Color.CadetBlue)
            .Add(Drawing.Color.Chartreuse)
            .Add(Drawing.Color.Chocolate)
            .Add(Drawing.Color.Coral)
            .Add(Drawing.Color.CornflowerBlue)
            .Add(Drawing.Color.Cornsilk)

            ''Added 8/8/2022
            .Add(Drawing.Color.Crimson)
            .Add(Drawing.Color.Cyan)
            .Add(Drawing.Color.DarkBlue)
            .Add(Drawing.Color.DarkCyan)
            .Add(Drawing.Color.DarkGoldenrod)
            .Add(Drawing.Color.DarkGray)
            .Add(Drawing.Color.DarkGreen)
            .Add(Drawing.Color.DarkKhaki)
            .Add(Drawing.Color.DarkMagenta)
            .Add(Drawing.Color.DarkOliveGreen)
            .Add(Drawing.Color.DarkOrange)
            .Add(Drawing.Color.DarkOrchid)
            .Add(Drawing.Color.DarkRed)
            .Add(Drawing.Color.DarkSalmon)
            .Add(Drawing.Color.DarkSeaGreen)
            .Add(Drawing.Color.DarkSlateBlue)
            .Add(Drawing.Color.DarkSlateGray)

            ''Added 8/8/2022
            .Add(Drawing.Color.Firebrick)
            .Add(Drawing.Color.FloralWhite)
            .Add(Drawing.Color.ForestGreen)
            .Add(Drawing.Color.Fuchsia)


        End With ''ENd of ""With mod_listMSColors_NotUsed""

        ''mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.

        FlowLayoutPanel1.Controls.Clear()

        For Each each_color In mod_listMSColors_NotUsed ''List(Of Drawing.Color)

            Dim newLabel As New RSCColorDisplayLabel
            newLabel.BackColor = each_color
            newLabel.Text = each_color.Name
            newLabel.Visible = True
            AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click

            ''newLabel.ToolTip
            ''Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
            Me.ToolTip1.SetToolTip(newLabel, each_color.Name)

            FlowLayoutPanel1.Controls.Add(newLabel)

        Next each_color


    End Sub ''End of ""Public Sub LoadListOfColors_Obselete()""




    Public Sub AddLinkLabelForAddingColors()
        ''
        ''Added 8/30/2022 td 
        ''
        Dim bMissingFromFlowLayout As Boolean
        LinkLabelAddColor1.Visible = True
        With FlowLayoutPanel1.Controls
            bMissingFromFlowLayout = (Not .Contains(LinkLabelAddColor1))
            If (bMissingFromFlowLayout) Then
                .Add(LinkLabelAddColor1)
            End If ''End of ""If (bMissingFromFlowLayout) Then""
        End With ''End of ""With FlowLayoutPanel1.Controls""

    End Sub ''Endof ""Public Sub AddLinkLabelForAddingColors()""


    Private Sub NetDrawingColor_Click(sender As Object, e As EventArgs)
        ''
        ''8/22/2022 thomas downes
        ''
        Dim objFormToShow As __RSCWindowsControlLibrary.FormRSCColorConfirm
        Dim strColorName As String
        Dim controlRSCColorLabel As RSCColorDisplayLabel
        Static controlRSCColorLabel_Prior As RSCColorDisplayLabel
        Dim mscolorSelected As Drawing.Color
        Dim rscColorSelected As RSCColor

        controlRSCColorLabel = CType(sender, RSCColorDisplayLabel)
        strColorName = controlRSCColorLabel.Text
        mscolorSelected = controlRSCColorLabel.BackColor

        objFormToShow = New FormRSCColorConfirm(mscolorSelected, strColorName)

        With objFormToShow

            ''Show the modal UI to the user. 
            .ShowDialog()

            If (Not .Output_Cancelled) Then

                rscColorSelected = .Output_RSCColor
                ''8/30/2022 rscLabelDisplayColorSelected.RSCDisplayColor = rscColorSelected
                ''8/30/2022 rscLabelDisplayColorSelected.Visible = True ''Added 8/28/2022 
                controlRSCColorLabel.BorderStyle = BorderStyle.FixedSingle ''Added 8/30/2022

                ''Clear the Border Style from the previous label control. ---8/30/2022
                If (controlRSCColorLabel_Prior IsNot Nothing) Then
                    ''Clear the Border Style from the previous label control. 
                    controlRSCColorLabel_Prior.BorderStyle = BorderStyle.None
                End If ''End of ""If (controlRSCColorLabel_Prior IsNot Nothing) Then""


            End If ''End of ""If (Not .Output_Cancelled) Then""  

        End With ''End of ""With objFormToShow""


        ''---End If ''End of ""If (Not objFormToShow.Output_Cancelled) Then""

ExitHandler:
        ''Prepare for next execution of this procedure. ---8/30/2022
        controlRSCColorLabel_Prior = controlRSCColorLabel

    End Sub ''End of ""Private Sub NetDrawingColor_Click(sender As Object, e As EventArgs)""


End Class
