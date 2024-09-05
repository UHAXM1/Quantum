Imports System.ComponentModel

<DefaultEvent("CheckedChanged")>
Public Class ToggleButtonEx

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    Public Overrides Property Text As String
        Get
            Return LBL_MainLabel.Text
        End Get
        Set(ByVal value As String)
            LBL_MainLabel.Text = value
        End Set
    End Property

    Public Event CheckedChanged(sender As Object, e As EventArgs)
    Private Sub tbToggle_CheckedChanged(sender As Object, e As EventArgs) Handles TB_Toggle.CheckedChanged
        Me.Invalidate()
        RaiseEvent CheckedChanged(sender, e)
    End Sub

    Public Shadows Property Enabled() As Boolean
        Get
            Return TB_Toggle.Enabled
        End Get
        Set(ByVal value As Boolean)
            TB_Toggle.Enabled = value
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return TB_Toggle.Checked
        End Get
        Set(value As Boolean)
            TB_Toggle.Checked = value
        End Set
    End Property
    Public Sub SetToolTip(toolTip As ToolTip)
        Dim text As String = toolTip.GetToolTip(Me)
        toolTip.SetToolTip(Me, text)
        toolTip.SetToolTip(TB_Toggle, text)
        toolTip.SetToolTip(LBL_MainLabel, text)
        toolTip.SetToolTip(LBL_Null, text)
    End Sub

    Private Sub lblMainLabel_Click(sender As Object, e As EventArgs) Handles LBL_MainLabel.Click
        If TB_Toggle.Checked Then
            TB_Toggle.Checked = False
        Else
            TB_Toggle.Checked = True
        End If
    End Sub
End Class
