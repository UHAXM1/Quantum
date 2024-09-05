Imports System.ComponentModel

Public Class GroupBoxEx
    Inherits GroupBox
    Private GB_Text As String = ""
    Public Sub New()
        'set the base text to empty 
        'base class will draw empty string
        'in such way we see only text what we draw
        MyBase.Text = ""
    End Sub
    'create a new property a
    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue("GroupBoxText")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overloads Property Text As String
        Get

            Return GB_Text
        End Get
        Set(value As String)

            GB_Text = value
            Me.Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        'first let the base class to draw the control 
        MyBase.OnPaint(e)
        'create a brush with fore color
        Dim colorBrush As SolidBrush = New SolidBrush(Me.ForeColor)
        'create a brush with back color
        Dim backColor = New SolidBrush(SystemColors.Control)
        'measure the text size
        Dim size = TextRenderer.MeasureText(Text, Me.Font)
        ' evaluate the postiong of text from left;
        Dim left As Integer = (Me.Width - size.Width) / 2
        'draw a fill rectangle in order to remove the border
        e.Graphics.FillRectangle(backColor, New Rectangle(left, 0, size.Width, size.Height))
        'draw the text Now
        e.Graphics.DrawString(Text, Me.Font, colorBrush, New PointF(left, 0))

    End Sub
End Class