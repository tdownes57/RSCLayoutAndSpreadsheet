<ComClass(ComClass1.ClassId, ComClass1.InterfaceId, ComClass1.EventsId)> _
Public Class ComClass1

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "2b3087fa-f7a3-48dd-b2cd-e2e194e2045f"
    Public Const InterfaceId As String = "d9e29f6a-5000-41fb-89a6-68f08ee45a16"
    Public Const EventsId As String = "d1e66961-9fea-4c58-8227-1f8846faa954"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

End Class


