﻿''' <summary>
''' This will allow DLL_List_OfTControl_PLEASE_USE to communicate changes of endpoint. 12/2023 td
''' </summary>
Public Class RSCEndpointException
    Inherits Exception

    Public Sub New(pstrMessage As String)

        ''Must be called at start of constructor!!  Same as Java. 
        MyBase.New(pstrMessage)


    End Sub


End Class
