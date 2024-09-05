Imports System.Drawing.Drawing2D

Public Class ToggleButton
    Inherits CheckBox

    Private onBackColorValue As Color = SystemColors.Highlight
    Private onToggleColorValue As Color = Color.WhiteSmoke
    Private offBackColorValue As Color = Color.Gray
    Private offToggleColorValue As Color = Color.Gainsboro
    Private solidStyleValue As Boolean = True

    Public Property OnBackColor As Color
        Get
            Return onBackColorValue
        End Get
        Set(value As Color)
            onBackColorValue = value
            Me.Invalidate()
        End Set
    End Property

    Public Property OnToggleColor As Color
        Get
            Return onToggleColorValue
        End Get
        Set(value As Color)
            onToggleColorValue = value
            Me.Invalidate()
        End Set
    End Property

    Public Property OffBackColor As Color
        Get
            Return offBackColorValue
        End Get
        Set(value As Color)
            offBackColorValue = value
            Me.Invalidate()
        End Set
    End Property

    Public Property OffToggleColor As Color
        Get
            Return offToggleColorValue
        End Get
        Set(value As Color)
            offToggleColorValue = value
            Me.Invalidate()
        End Set
    End Property

    Public Property SolidStyle As Boolean
        Get
            Return solidStyleValue
        End Get
        Set(value As Boolean)
            solidStyleValue = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        Me.MinimumSize = New Size(10, 5)
    End Sub

    Private Function GetFigurePath() As GraphicsPath
        Dim arcSize As Integer = Me.Height - 1
        Dim leftArc As New Rectangle(0, 0, arcSize, arcSize)
        Dim rightArc As New Rectangle(Me.Width - arcSize - 2, 0, arcSize, arcSize)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(leftArc, 90, 180)
        path.AddArc(rightArc, 270, 180)
        path.CloseFigure()
        Return path
    End Function

    Protected Overrides Sub OnPaint(ByVal p_Event As PaintEventArgs)
        Dim toggleSize As Integer = Me.Height - 5
        p_Event.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        p_Event.Graphics.Clear(SystemColors.Control)

        If Me.Checked AndAlso Me.Enabled Then

            If SolidStyle Then
                p_Event.Graphics.FillPath(New SolidBrush(OnBackColor), GetFigurePath())
            Else
                p_Event.Graphics.DrawPath(New Pen(OnBackColor, 2), GetFigurePath())
            End If

            p_Event.Graphics.FillEllipse(New SolidBrush(OnToggleColor), New Rectangle(Me.Width - Me.Height + 1, 2, toggleSize, toggleSize))

        Else

            If SolidStyle Then
                p_Event.Graphics.FillPath(New SolidBrush(OffBackColor), GetFigurePath())
            Else
                p_Event.Graphics.DrawPath(New Pen(OffBackColor, 2), GetFigurePath())
            End If

            p_Event.Graphics.FillEllipse(New SolidBrush(OffToggleColor), New Rectangle(2, 2, toggleSize, toggleSize))
        End If

        If Me.Focused And Me.Enabled Then
            ControlPaint.DrawFocusRectangle(p_Event.Graphics, Me.ClientRectangle)
        End If
    End Sub

    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        Me.Refresh()
    End Sub

    Protected Overrides Sub OnLeave(e As EventArgs)
        MyBase.OnLeave(e)
        MyBase.Refresh()
    End Sub

    Private Sub ToggleButton_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If Me.Focused Then
            Me.Parent.Focus()
        End If
    End Sub
End Class