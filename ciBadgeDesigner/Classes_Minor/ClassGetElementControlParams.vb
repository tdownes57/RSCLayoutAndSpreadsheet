Option Explicit On ''Added 1/17/2022 thomas d
Option Strict On ''Added 1/17/2022 thomas d

Imports System.Windows.Forms ''Added 12/17/2021 td 
Imports ciBadgeInterfaces
Imports ciBadgeCachePersonality
Imports ciBadgeElements

Public Class ClassGetElementControlParams
    Implements IGetElementControlParameters
    ''
    ''Added 1/17/2022 thomas downes  
    ''

    Public Property ElementObject As ClassElementBase Implements IGetElementControlParameters.ElementObject
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementBase)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ElementsCacheManager As ClassCacheManagement Implements IGetElementControlParameters.CacheManager
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassCacheManagement)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property DesignerClass As ClassDesigner Implements IGetElementControlParameters.DesignerClass
    Public Property DesignerForm As Form Implements IGetElementControlParameters.DesignerForm
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Form)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property NameOfControl As String Implements IGetElementControlParameters.NameOfControl
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property iLayoutFunctions As ILayoutFunctions Implements IGetElementControlParameters.iLayoutFunctions
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ILayoutFunctions)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property iRefreshPreview As IRefreshPreview Implements IGetElementControlParameters.iRefreshPreview
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As IRefreshPreview)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property iControlLastTouched As __RSCWindowsControlLibrary.ILastControlTouched Implements IGetElementControlParameters.iControlLastTouched

    Public Property iControlLastTouchedRSC As ILastControlTouchedRSC Implements IGetElementControlParameters.iControlLastTouchedRSC
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ILastControlTouchedRSC)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property oMoveEventsGroupedControls As GroupMoveEvents_Singleton Implements IGetElementControlParameters.oMoveEventsGroupedControls
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As GroupMoveEvents_Singleton)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property sPathToGraphicsFile_IfNeeded As String Implements IGetElementControlParameters.sPathToGraphicsFile_IfNeeded
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property



End Class
