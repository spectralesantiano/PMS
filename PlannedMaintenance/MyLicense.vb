'============================ License Object ================================
Public Class MyLicense
    Private _LID As String
    Private _LAppName As String
    Private _LType As String
    Private _LExp As String
    Private _LHID As String
    Private _LImo As String
    Private _LSKey As String
    Private _LGPeriod As String
    Private _LNum As String
    Private _LValid As String
    Private _LGen As String
    Private _LStat As String
    Private _LMsg As String
    Private _LRem As String
    Private _LDateUpdated As String
    Private _LPath As String

#Region "Properties"

    Public Property LID() As String
        Get
            Return _LID
        End Get
        Set(ByVal value As String)
            If (Me._LID <> value) Then
                Me._LID = value
            End If
        End Set
    End Property

    Public Property LAppName() As String
        Get
            Return _LAppName
        End Get
        Set(ByVal value As String)
            If (Me._LAppName <> value) Then
                Me._LAppName = value
            End If
        End Set
    End Property

    Public Property LType() As String
        Get
            Return _LType
        End Get
        Set(ByVal value As String)
            If (Me._LType <> value) Then
                Me._LType = value
            End If
        End Set
    End Property

    Public Property LExp() As String
        Get
            Return _LExp
        End Get
        Set(ByVal value As String)
            If (Me._LExp <> value) Then
                Me._LExp = value
            End If
        End Set
    End Property

    Public Property LHID() As String
        Get
            Return _LHID
        End Get
        Set(ByVal value As String)
            If (Me._LHID <> value) Then
                Me._LHID = value
            End If
        End Set
    End Property

    Public Property LImo() As String
        Get
            Return _LImo
        End Get
        Set(ByVal value As String)
            If (Me._LImo <> value) Then
                Me._LImo = value
            End If
        End Set
    End Property


    Public Property LSKey() As String
        Get
            Return _LSKey
        End Get
        Set(ByVal value As String)
            If (Me._LSKey <> value) Then
                Me._LSKey = value
            End If
        End Set
    End Property

    Public Property LGPeriod() As String
        Get
            Return _LGPeriod
        End Get
        Set(ByVal value As String)
            If (Me._LGPeriod <> value) Then
                Me._LGPeriod = value
            End If
        End Set
    End Property

    Public Property LNum() As String
        Get
            Return _LNum
        End Get
        Set(ByVal value As String)
            If (Me._LNum <> value) Then
                Me._LNum = value
            End If
        End Set
    End Property

    Public Property LValid() As String
        Get
            Return _LValid
        End Get
        Set(ByVal value As String)
            If (Me._LValid <> value) Then
                Me._LValid = value
            End If
        End Set
    End Property

    Public Property LGen() As String
        Get
            Return _LGen
        End Get
        Set(ByVal value As String)
            If (Me._LGen <> value) Then
                Me._LGen = value
            End If
        End Set
    End Property

    Public Property LStat() As String
        Get
            Return _LStat
        End Get
        Set(ByVal value As String)
            If (Me._LStat <> value) Then
                Me._LStat = value
            End If
        End Set
    End Property

    Public Property LMsg() As String
        Get
            Return _LMsg
        End Get
        Set(ByVal value As String)
            If (Me._LMsg <> value) Then
                Me._LMsg = value
            End If
        End Set
    End Property

    Public Property LRem() As String
        Get
            Return _LRem
        End Get
        Set(ByVal value As String)
            If (Me._LRem <> value) Then
                Me._LRem = value
            End If
        End Set
    End Property

    Public Property LDateUpdated() As String
        Get
            Return _LDateUpdated
        End Get
        Set(ByVal value As String)
            If (Me._LDateUpdated <> value) Then
                Me._LDateUpdated = value
            End If
        End Set
    End Property

    Public Property LPath() As String
        Get
            Return _LPath
        End Get
        Set(ByVal value As String)
            If (Me._LPath <> value) Then
                Me._LPath = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New(Optional ByVal xLID As String = "", Optional ByVal xLAppName As String = "", Optional ByVal xLType As String = "", Optional ByVal xLExp As String = "", Optional ByVal xLHID As String = "", Optional ByVal xLImo As String = "", Optional ByVal xLSKey As String = "", Optional ByVal xLGPeriod As String = "", Optional ByVal xLNum As String = "", Optional ByVal xLValid As String = "", Optional ByVal xLGen As String = "", Optional ByVal xLStat As String = "", Optional ByVal xLMsg As String = "", Optional ByVal xLRem As String = "", Optional ByVal xLDateUpdated As String = "", Optional ByVal xLPath As String = "", Optional ByVal isValuesEncrypted As Boolean = True)

        If isValuesEncrypted Then 'decrypt the values before setting it to its respective variable.
            Me._LID = xLID
            Me._LAppName = sysMpsUserPassword("DECRYPT", xLAppName)
            Me._LType = sysMpsUserPassword("DECRYPT", xLType)
            Me._LExp = sysMpsUserPassword("DECRYPT", xLExp)
            Me._LHID = sysMpsUserPassword("DECRYPT", xLHID)
            Me._LImo = sysMpsUserPassword("DECRYPT", xLImo)
            Me._LSKey = sysMpsUserPassword("DECRYPT", xLSKey)
            Me._LGPeriod = sysMpsUserPassword("DECRYPT", xLGPeriod)
            Me._LNum = sysMpsUserPassword("DECRYPT", xLNum)
            Me._LValid = sysMpsUserPassword("DECRYPT", xLValid)
            Me._LGen = sysMpsUserPassword("DECRYPT", xLGen)
            Me._LStat = sysMpsUserPassword("DECRYPT", xLStat)
            Me._LMsg = sysMpsUserPassword("DECRYPT", xLMsg)
            Me._LRem = sysMpsUserPassword("DECRYPT", xLRem)
            Me._LDateUpdated = xLDateUpdated
            Me._LPath = xLPath
        Else
            Me._LID = xLID
            Me._LAppName = xLAppName
            Me._LType = xLType
            Me._LExp = xLExp
            Me._LHID = xLHID
            Me._LImo = xLImo
            Me._LSKey = xLSKey
            Me._LGPeriod = xLGPeriod
            Me._LNum = xLNum
            Me._LValid = xLValid
            Me._LGen = xLGen
            Me._LStat = xLStat
            Me._LMsg = xLMsg
            Me._LRem = xLRem
            Me._LDateUpdated = xLDateUpdated
            Me._LPath = xLPath
        End If

    End Sub

#End Region

End Class


'=============================License Status Class======================================
Public Class MyLicenseStatus
    Private _LicenseType As String
    Private _ExpDays As Integer
    Private _StrLicenseMsg As String
    Private _ErrMsg As String

#Region "Properties"

    Public Property LicenseType()
        Get
            Return Me._LicenseType
        End Get
        Set(ByVal value)
            If (Me._LicenseType <> value) Then
                Me._LicenseType = value
            End If
        End Set
    End Property

    Public Property ExpDays()
        Get
            Return Me._ExpDays
        End Get
        Set(ByVal value)
            If (Me._ExpDays <> value) Then
                Me._ExpDays = value
            End If
        End Set
    End Property

    Public Property StrLicenseMsg()
        Get
            Return Me._StrLicenseMsg
        End Get
        Set(ByVal value)
            If (Me._StrLicenseMsg <> value) Then
                Me._StrLicenseMsg = value
            End If
        End Set
    End Property

    Public Property ErrMsg()
        Get
            Return Me._ErrMsg
        End Get
        Set(ByVal value)
            If (Me._ErrMsg <> value) Then
                Me._ErrMsg = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New(Optional ByVal xLicenseType As String = "", Optional ByVal xExpDays As Integer = 0, Optional ByVal xStrLicenseMsg As String = "", Optional ByVal xErrMsg As String = "")
        Me._LicenseType = xLicenseType
        Me._ExpDays = xExpDays
        Me._StrLicenseMsg = xStrLicenseMsg
        Me._ErrMsg = xErrMsg
    End Sub

#End Region

End Class

'=============================App Class======================================


Public Class Working_App
    Private _App_Name As String
    Private _App_DbName As String
    Private _App_LogFolder As String
    Private _App_LicensePath As String
    Private _App_BackRegGPeriod As String

#Region "App_Properties"
    Public Property App_Name()
        Get
            Return Me._App_Name
        End Get
        Set(ByVal value)
            If (Me._App_Name <> value) Then
                Me._App_Name = value
            End If
        End Set
    End Property

    Public Property App_DbName()
        Get
            Return Me._App_DbName
        End Get
        Set(ByVal value)
            If (Me._App_DbName <> value) Then
                Me._App_DbName = value
            End If
        End Set
    End Property

    Public Property App_LogFolder()
        Get
            Return Me._App_LogFolder
        End Get
        Set(ByVal value)
            If (Me._App_LogFolder <> value) Then
                Me._App_LogFolder = value
            End If
        End Set
    End Property

    Public Property App_LicensePath()
        Get
            Return Me._App_LicensePath
        End Get
        Set(ByVal value)
            If (Me._App_LicensePath <> value) Then
                Me._App_LicensePath = value
            End If
        End Set
    End Property

    Public Property App_BackRegGPeriod()
        Get
            Return Me._App_BackRegGPeriod
        End Get
        Set(ByVal value)
            If (Me._App_BackRegGPeriod <> value) Then
                Me._App_BackRegGPeriod = value
            End If
        End Set
    End Property

#End Region

#Region "App_Methods"

    Public Sub New(Optional ByVal xApp_Name As String = "", Optional ByVal xApp_DbName As String = "", Optional ByVal xApp_LogFolder As String = "", Optional ByVal xApp_LicensePath As String = "", Optional ByVal xApp_BackRegGPeriod As String = "")
        Me._App_Name = xApp_Name
        Me._App_DbName = xApp_DbName
        Me._App_LogFolder = xApp_LogFolder
        Me._App_LicensePath = xApp_LicensePath
        Me._App_BackRegGPeriod = xApp_BackRegGPeriod
    End Sub

#End Region

End Class
