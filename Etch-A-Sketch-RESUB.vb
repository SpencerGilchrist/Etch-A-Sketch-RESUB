'Spencer Gilchrist
'RCET 0265
'Etch-A-Sketch
'3/24/21
Option Explicit On
Option Strict On

Public Class Form1
    'Global feilds
    Dim MainPen As New Pen(Color.Black)
    Dim G As Graphics
    Sub MouseDraw(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Dim G As Graphics = PictureBox1.CreateGraphics
        'This handels the drawing of the lines
        G.DrawLine(Me.MainPen, x1, y1, x2, y2) 'Put me in if you want to use global
        'pen.Dispose()
        G.Dispose()
    End Sub
    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, PictureBox1.MouseMove
        Static Oldx As Integer
        Static Oldy As Integer
        'This is the main drawing program and allows the user to draw...
        'Using the left mouse button click
        Dim MyPoint As Point
        MyPoint.Y = 0
        MyPoint.X = 0

        Me.Text = $"({e.X},{e.Y}) Button: {e.Button.ToString} Color: {Me.MainPen.Color.ToString}"
        Select Case e.Button.ToString
            Case "Left"
                MouseDraw(Oldx, Oldy, e.X, e.Y)
            Case "Right"
                'This show the user what they can use when they click the set button on the mouse
            Case "Middle"
                ColorDialog.ShowDialog()
                Me.MainPen.Color = ColorDialog.Color
            Case "None"

            Case Else
                MsgBox("Problems are a foot.")
        End Select
        Oldx = e.X
        Oldy = e.Y
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click
        'Clear button
        Shake() 'this shakes the screen
        PictureBox1.BackColor = Color.White
        PictureBox1.Refresh()

    End Sub
    Sub Shake()
        Dim MoveAmount = 50
        'This shakes the screen when the clear button is pressed
        For i = 1 To 10
            Me.Top += MoveAmount
            Me.Left += MoveAmount
            System.Threading.Thread.Sleep(100)
            MoveAmount *= -1
        Next

    End Sub
    Private Sub ChangeColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click, ColorButton.Click
        'Tool strip menu change color
        ColorDialog.ShowDialog()
        Me.MainPen.Color = ColorDialog.Color
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This Program is a kind of paint clone, created for Tim Rossiter." & vbNewLine &
               "This program was created for Visual  Basic on 3/24/21.")
    End Sub

    Private Sub FillButton_Click(sender As Object, e As EventArgs) Handles FillButton.Click
        ColorDialog.ShowDialog() 'this changes the color of the background when the user selects a color
        PictureBox1.BackColor = ColorDialog.Color
    End Sub

End Class