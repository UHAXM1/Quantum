Imports System.Drawing.Drawing2D

Public Class ProgressBarEx
    Inherits ProgressBar
    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        ' None... Helps control the flicker.
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Const inset = 2 ' A single inset value to control teh sizing of the inner rect.

        Using offscreenImage As Image = New Bitmap(Me.Width, Me.Height)
            Using offscreen As Graphics = Graphics.FromImage(offscreenImage)
                Dim rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)

                If ProgressBarRenderer.IsSupported Then ProgressBarRenderer.DrawHorizontalBar(offscreen, rect)

                rect.Inflate(New Size(-inset, -inset)) ' Deflate inner rect.
                rect.Width = CInt(rect.Width * (CDbl(Me.Value) / Me.Maximum))
                If rect.Width = 0 Then rect.Width = 1 ' Can't draw rec with width of 0.

                Dim brush As LinearGradientBrush = New LinearGradientBrush(rect, Me.BackColor, Me.ForeColor, LinearGradientMode.Vertical)
                offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height)

                e.Graphics.DrawImage(offscreenImage, 0, 0)
            End Using
        End Using
    End Sub
End Class
