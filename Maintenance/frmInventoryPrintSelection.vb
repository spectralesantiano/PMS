Public Class frmInventoryPrintSelection
    Public bPreview_Clicked As Boolean = False

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        bPreview_Clicked = True
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub


    Private Sub chkSpare_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSpare.CheckedChanged
        chkDeliveryCon.Checked = Not chkSpare.Checked
        chkAddressToVendor.Enabled = chkSpare.Checked
        chkOffice.Enabled = chkSpare.Checked
        cboVendorCode.Enabled = chkAddressToVendor.Checked And chkSpare.Checked
        txtOfficeAddress.Enabled = Not chkAddressToVendor.Checked And chkSpare.Checked
    End Sub

    Private Sub chkDeliveryCon_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDeliveryCon.CheckedChanged
        chkSpare.Checked = Not chkDeliveryCon.Checked
        chkAddressToVendor.Enabled = chkSpare.Checked
        chkOffice.Enabled = chkSpare.Checked
        cboVendorCode.Enabled = chkAddressToVendor.Checked And chkSpare.Checked
        txtOfficeAddress.Enabled = Not chkAddressToVendor.Checked And chkSpare.Checked
    End Sub

    Private Sub chkAddressToVendor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAddressToVendor.CheckedChanged
        chkOffice.Checked = Not chkAddressToVendor.Checked
        cboVendorCode.Enabled = chkAddressToVendor.Checked
        txtOfficeAddress.Enabled = Not chkAddressToVendor.Checked
    End Sub

    Private Sub chkOffice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOffice.CheckedChanged
        chkAddressToVendor.Checked = Not chkOffice.Checked
        cboVendorCode.Enabled = chkAddressToVendor.Checked
        txtOfficeAddress.Enabled = Not chkAddressToVendor.Checked
    End Sub

    Private Sub frmInventoryPrintSelection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        
    End Sub
End Class