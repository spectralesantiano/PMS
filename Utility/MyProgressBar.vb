Public Class MyProgressBar
    Friend WithEvents _frm As New frmProgress
    Private _showoverall As Boolean, _OverAllMax As Integer = 100, _hidden As Boolean = False
    Public Event Hidden()

    Public Sub New(ByVal Text As String, ByVal ShowOverAllProgress As Boolean, ByVal ShowButtons As Boolean, ByVal MaxValue As Integer)
        _OverAllMax = MaxValue
        _showoverall = ShowOverAllProgress
        _frm.cmdHide.Top = IIf(_showoverall, 115, 75)
        _frm.cmdCancel.Top = IIf(_showoverall, 115, 75)
        _frm.Height = IIf(_showoverall, 175, 140) - IIf(ShowButtons, 0, 35)
        _frm.cmdCancel.Visible = ShowButtons
        _frm.cmdHide.Visible = ShowButtons
        _frm.Text = Text
        _frm.CurrentProgress.Properties.Maximum = _OverAllMax
        _frm.OverallProgress.Properties.Maximum = _OverAllMax
        _frm.CurrentProgress.EditValue = 0
        _frm.OverallProgress.EditValue = 0
        _frm.OverallProgress.Visible = _showoverall
        _frm.lblOverallText.Visible = _showoverall
        _frm.lblOverallPercent.Visible = _showoverall
        _frm.lblProgress.Text = IIf(_showoverall, "Current:", "Progress:")
        _frm.Show()
        AddHandler _frm.Hidden, AddressOf Hide
    End Sub

    Public Sub SetMaxValue(ByVal value As Integer)
        If _showoverall Then
            _frm.OverallProgress.Properties.Maximum = value
        Else
            _frm.CurrentProgress.Properties.Maximum = value
        End If
    End Sub

    Public Sub PerformStep()
        _frm.CurrentProgress.PerformStep()
        _frm.lblCurrentPercent.Text = Int((_frm.CurrentProgress.EditValue / _frm.CurrentProgress.Properties.Maximum) * 100) & "%"
        _frm.OverallProgress.PerformStep()
        _frm.lblOverallPercent.Text = Int((_frm.OverallProgress.EditValue / _frm.OverallProgress.Properties.Maximum) * 100) & "%"
        If Not _hidden Then
            _frm.Refresh()
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub PerformStep(ByVal StatusText As String)
        _frm.CurrentProgress.PerformStep()
        _frm.lblCurrentPercent.Text = Int((_frm.CurrentProgress.EditValue / _frm.CurrentProgress.Properties.Maximum) * 100) & "%"
        _frm.OverallProgress.PerformStep()
        _frm.lblOverallPercent.Text = Int((_frm.OverallProgress.EditValue / _frm.OverallProgress.Properties.Maximum) * 100) & "%"
        If Not _hidden Then
            _frm.lblStatus.Text = StatusText
            _frm.Refresh()
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub UpdateStatus(ByVal StatusText As String)
        If Not _hidden Then
            _frm.lblStatus.Text = StatusText
            _frm.Refresh()
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub UpdateStatus(ByVal CurrMax As Integer, ByVal StatusText As String)
        ResetCurrentProgress(CurrMax)
        If Not _hidden Then
            _frm.lblStatus.Text = StatusText
            _frm.Refresh()
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub ResetCurrentProgress(ByVal CurrMax As Integer)
        _frm.CurrentProgress.EditValue = 0
        _frm.CurrentProgress.Properties.Maximum = CurrMax
    End Sub


    Public Sub EndProgress()
        _frm.Close()
        _frm.Dispose()
    End Sub

    Private Sub Hide() Handles _frm.Hidden
        _frm.Hide()
        _hidden = True
    End Sub
End Class
