<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToggleButtonEx
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TB_Toggle = New ToggleButton()
        LBL_MainLabel = New Label()
        TLP_Main = New TableLayoutPanel()
        TLP_Button = New TableLayoutPanel()
        LBL_Null = New Label()
        TLP_Main.SuspendLayout()
        TLP_Button.SuspendLayout()
        SuspendLayout()
        ' 
        ' TB_Toggle
        ' 
        TB_Toggle.Dock = DockStyle.Fill
        TB_Toggle.Location = New Point(0, 0)
        TB_Toggle.Margin = New Padding(0)
        TB_Toggle.MinimumSize = New Size(10, 10)
        TB_Toggle.Name = "TB_Toggle"
        TB_Toggle.OffBackColor = Color.Gray
        TB_Toggle.OffToggleColor = Color.Gainsboro
        TB_Toggle.OnBackColor = SystemColors.Highlight
        TB_Toggle.OnToggleColor = Color.WhiteSmoke
        TB_Toggle.Size = New Size(34, 17)
        TB_Toggle.SolidStyle = True
        TB_Toggle.TabIndex = 0
        TB_Toggle.UseVisualStyleBackColor = True
        ' 
        ' LBL_MainLabel
        ' 
        LBL_MainLabel.Location = New Point(40, 0)
        LBL_MainLabel.Margin = New Padding(0)
        LBL_MainLabel.Name = "LBL_MainLabel"
        LBL_MainLabel.Size = New Size(391, 25)
        LBL_MainLabel.TabIndex = 1
        LBL_MainLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TLP_Main
        ' 
        TLP_Main.ColumnCount = 3
        TLP_Main.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 40F))
        TLP_Main.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLP_Main.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 40F))
        TLP_Main.Controls.Add(LBL_MainLabel, 1, 0)
        TLP_Main.Controls.Add(TLP_Button, 0, 0)
        TLP_Main.Controls.Add(LBL_Null, 2, 0)
        TLP_Main.Dock = DockStyle.Fill
        TLP_Main.Location = New Point(0, 0)
        TLP_Main.Name = "TLP_Main"
        TLP_Main.RowCount = 1
        TLP_Main.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLP_Main.Size = New Size(491, 25)
        TLP_Main.TabIndex = 2
        ' 
        ' TLP_Button
        ' 
        TLP_Button.ColumnCount = 1
        TLP_Button.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLP_Button.Controls.Add(TB_Toggle, 0, 1)
        TLP_Button.Dock = DockStyle.Fill
        TLP_Button.Location = New Point(3, 3)
        TLP_Button.Name = "TLP_Button"
        TLP_Button.RowCount = 3
        TLP_Button.RowStyles.Add(New RowStyle(SizeType.Percent, 5F))
        TLP_Button.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TLP_Button.RowStyles.Add(New RowStyle(SizeType.Percent, 5F))
        TLP_Button.Size = New Size(34, 19)
        TLP_Button.TabIndex = 2
        ' 
        ' LBL_Null
        ' 
        LBL_Null.AutoSize = True
        LBL_Null.Dock = DockStyle.Fill
        LBL_Null.Location = New Point(454, 0)
        LBL_Null.Name = "LBL_Null"
        LBL_Null.Size = New Size(34, 25)
        LBL_Null.TabIndex = 2
        LBL_Null.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ToggleButtonEx
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        Controls.Add(TLP_Main)
        Margin = New Padding(4, 3, 4, 3)
        Name = "ToggleButtonEx"
        Size = New Size(491, 25)
        TLP_Main.ResumeLayout(False)
        TLP_Main.PerformLayout()
        TLP_Button.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Friend WithEvents TB_Toggle As ToggleButton
    Friend WithEvents LBL_MainLabel As Label
    Friend WithEvents TLP_Main As TableLayoutPanel
    Friend WithEvents TLP_Button As TableLayoutPanel
    Friend WithEvents LBL_Null As Label
End Class
