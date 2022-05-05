Option Explicit On ''Added 1/17/2022 thomas d
Option Strict On ''Added 1/17/2022 thomas d

Imports System.Windows.Forms ''Added 12/17/2021 td 
Imports ciBadgeInterfaces
Imports ciBadgeCachePersonality
Imports ciBadgeElements

Public Interface IGetElementControlParameters
    ''
    ''Added 1/17/2022 thomas downes  
    ''
    ''   par_elementSig As ClassElementSignature,
    ''   par_oParentForm As Form,
    ''   par_nameOfControl As String,
    ''   par_iLayoutFun As ILayoutFunctions,
    ''   par_bProportionSizing As Boolean,
    ''   par_iControlLastTouched As ILastControlTouched,
    ''   par_oMoveEventsGroupedControls As GroupMoveEvents_Singleton,
    ''   par_strPathToSigFile As String

    Property ElementObject As ClassElementBase ''Added 1/17/2022 td  

    Property ElementsCache As ClassElementsCache_Deprecated ''Added 5/5/2022 td
    Property ElementsCacheManager As ClassCacheManagement

    Property DesignerClass As ClassDesigner ''Added 1/17/2022
    Property DesignerForm As Form

    ''Probably not needed. Jan17 2022''Property Designer As ClassDesigner
    ''Probably not needed. Jan17 2022''Property bProportionalSizing As Boolean

    Property NameOfControl As String

    Property iLayoutFunctions As ILayoutFunctions
    Property iRefreshPreview As IRefreshCardPreview

    ''Jan17 2022''Property iControlLastTouched As ILastControlTouched_Deprecated
    Property iControlLastTouched As __RSCWindowsControlLibrary.ILastControlTouched
    Property iControlLastTouchedRSC As ILastControlTouchedRSC
    Property iRecordElemLastTouched As IRecordElementLastTouched ''Added 1/31/2022 td

    Property oMoveEventsGroupedControls As GroupMoveEvents_Singleton

    Property sPathToGraphicsFile_IfNeeded As String

End Interface
