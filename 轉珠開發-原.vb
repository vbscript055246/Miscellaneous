Public Class Form1
    Dim CL(30) As Integer
    Dim CLR(30) As Integer
    Dim AT As Integer = 0
    Dim SCT1, SCT2, SCT3, SCT4, SCT5, SCT6 As Integer
    Dim M As Point
    Dim tmp As Point
    Dim x As Point
    Dim Otmp
    Dim TM = 15
    Dim i
    Dim tmp1, ch1, ch2 As Integer
    Dim PB(30) As Integer
    Dim j(30)
    Dim NB As Integer
    Dim fl1 As Integer = 0
    Dim fl2 As Integer = 0
    Dim fl3 As Integer = 0
    Dim DX, DY As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer4.Enabled = True
        If fl1 = 0 Then
            x.X = Me.Cursor.Position.X.ToString
            x.Y = Me.Cursor.Position.Y.ToString
            DY = x.Y - i.Top + i.Height / 2
            DX = x.X - i.Left + i.Width / 2
            fl1 = 1
        End If
        x.X = Me.Cursor.Position.X.ToString
        x.Y = Me.Cursor.Position.Y.ToString
        i.Top = i.Height / 2 + x.Y - DY
        i.Left = i.Width / 2 + x.X - DX
        If (i.Top + i.Height) >= Me.Size.Height Then
            i.Top = Me.Size.Height - i.Height
        End If
        If (i.Left + i.Width) >= Me.Size.Width Then
            i.Left = Me.Size.Width - i.Width
        End If
        If i.Top <= 0 Then
            i.Top = 0
        End If
        If i.Left <= 0 Then
            i.Left = 0
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If ((Math.Abs(i.top - M.Y)) ^ 2 + (Math.Abs(i.left - M.X) ^ 2)) ^ (1 / 2) > 25 Then
            If (M.X + 10) < i.left And (M.Y + 10) < i.top Then '右下 +7
                If NB = 6 Or NB = 12 Or NB = 18 Or NB = 24 Or NB = 29 Or NB = 30 Or NB = 28 Or NB = 27 Or NB = 26 Or NB = 25 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB + 7 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB + 7).left
                M.Y = j(NB + 7).top
                j(NB + 7).top = tmp.Y
                j(NB + 7).left = tmp.X
                Otmp = j(NB + 7)
                j(NB + 7) = j(NB)
                j(NB) = Otmp
                NB = NB + 7
                Timer2.Enabled = False
                Timer3.Enabled = True
            ElseIf (M.X - 10) > i.left And (M.Y - 10) > i.top Then '左上 -7
                If NB = 7 Or NB = 13 Or NB = 6 Or NB = 1 Or NB = 2 Or NB = 3 Or NB = 4 Or NB = 5 Or NB = 19 Or NB = 25 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB - 7 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB - 7).left
                M.Y = j(NB - 7).top
                j(NB - 7).top = tmp.Y
                j(NB - 7).left = tmp.X
                Otmp = j(NB - 7)
                j(NB - 7) = j(NB)
                j(NB) = Otmp
                NB = NB - 7
                Timer2.Enabled = False
                Timer3.Enabled = True
            ElseIf (M.X + 10) < i.left And (M.Y - 10) > i.top Then '右上 -5
                If NB = 6 Or NB = 12 Or NB = 18 Or NB = 1 Or NB = 2 Or NB = 3 Or NB = 4 Or NB = 5 Or NB = 24 Or NB = 30 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB - 5 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB - 5).left
                M.Y = j(NB - 5).top
                j(NB - 5).top = tmp.Y
                j(NB - 5).left = tmp.X
                Otmp = j(NB - 5)
                j(NB - 5) = j(NB)
                j(NB) = Otmp
                NB = NB - 5
                Timer2.Enabled = False
                Timer3.Enabled = True
            ElseIf (M.X - 10) > i.left And (M.Y + 10) < i.top Then '左下 +5
                If NB = 1 Or NB = 27 Or NB = 7 Or NB = 28 Or NB = 13 Or NB = 19 Or NB = 29 Or NB = 25 Or NB = 26 Or NB = 27 Or NB = 30 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB + 5 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB + 5).left
                M.Y = j(NB + 5).top
                j(NB + 5).top = tmp.Y
                j(NB + 5).left = tmp.X
                Otmp = j(NB + 5)
                j(NB + 5) = j(NB)
                j(NB) = Otmp
                NB = NB + 5
                Timer2.Enabled = False
                Timer3.Enabled = True
            ElseIf (M.X + 10) < i.left Then '右 +1
                If NB = 6 Or NB = 12 Or NB = 18 Or NB = 24 Or NB = 30 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB + 1 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB + 1).left
                M.Y = j(NB + 1).top
                j(NB + 1).top = tmp.Y
                j(NB + 1).left = tmp.X
                Otmp = j(NB + 1)
                j(NB + 1) = j(NB)
                j(NB) = Otmp
                NB = NB + 1
                Timer2.Enabled = False
                Timer3.Enabled = True
            ElseIf (M.Y + 10) < i.top Then '下 +6
                If NB = 28 Or NB = 30 Or NB = 25 Or NB = 29 Or NB = 26 Or NB = 27 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB + 6 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB + 6).left
                M.Y = j(NB + 6).top
                j(NB + 6).top = tmp.Y
                j(NB + 6).left = tmp.X
                Otmp = j(NB + 6)
                j(NB + 6) = j(NB)
                j(NB) = Otmp
                NB = NB + 6
                Timer2.Enabled = False
                Timer3.Enabled = True
            ElseIf (M.X - 10) > i.left Then '左 -1
                If NB = 13 Or NB = 1 Or NB = 7 Or NB = 19 Or NB = 25 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB - 1 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB - 1).left
                M.Y = j(NB - 1).top
                j(NB - 1).top = tmp.Y
                j(NB - 1).left = tmp.X
                Otmp = j(NB - 1)
                j(NB - 1) = j(NB)
                j(NB) = Otmp
                NB = NB - 1
                Timer2.Enabled = False
                Timer3.Enabled = True
            ElseIf (M.Y - 10) > i.top Then '上 -6
                If NB = 6 Or NB = 2 Or NB = 1 Or NB = 3 Or NB = 4 Or NB = 5 Then
                    GoTo out
                End If
                For Sc As Integer = 1 To 30
                    If PB(Sc) = NB Then
                        ch1 = Sc
                    ElseIf PB(Sc) = NB - 6 Then
                        ch2 = Sc
                    End If
                Next
                tmp1 = PB(ch1)
                PB(ch1) = PB(ch2)
                PB(ch2) = tmp1
                tmp.X = M.X
                tmp.Y = M.Y
                M.X = j(NB - 6).left
                M.Y = j(NB - 6).top
                j(NB - 6).top = tmp.Y
                j(NB - 6).left = tmp.X
                Otmp = j(NB - 6)
                j(NB - 6) = j(NB)
                j(NB) = Otmp
                NB = NB - 6
                Timer2.Enabled = False
                Timer3.Enabled = True
            End If
        End If
out:
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Timer2.Enabled = True
        Timer3.Enabled = False
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer4.Enabled = False
        Timer1.Interval = 100
        Timer2.Interval = 75
        Timer3.Interval = 75
        Timer4.Interval = 1000
        j(1) = PictureBox1
        j(2) = PictureBox2
        j(3) = PictureBox3
        j(4) = PictureBox4
        j(5) = PictureBox5
        j(6) = PictureBox6
        j(7) = PictureBox7
        j(8) = PictureBox8
        j(9) = PictureBox9
        j(10) = PictureBox10
        j(11) = PictureBox11
        j(12) = PictureBox12
        j(13) = PictureBox13
        j(14) = PictureBox14
        j(15) = PictureBox15
        j(16) = PictureBox16
        j(17) = PictureBox17
        j(18) = PictureBox18
        j(19) = PictureBox19
        j(20) = PictureBox20
        j(21) = PictureBox21
        j(22) = PictureBox22
        j(23) = PictureBox23
        j(24) = PictureBox24
        j(25) = PictureBox25
        j(26) = PictureBox26
        j(27) = PictureBox27
        j(28) = PictureBox28
        j(29) = PictureBox29
        j(30) = PictureBox30
        PB(1) = 1
        PB(2) = 2
        PB(3) = 3
        PB(4) = 4
        PB(5) = 5
        PB(6) = 6
        PB(7) = 7
        PB(8) = 8
        PB(9) = 9
        PB(10) = 10
        PB(11) = 11
        PB(12) = 12
        PB(13) = 13
        PB(14) = 14
        PB(15) = 15
        PB(16) = 16
        PB(17) = 17
        PB(18) = 18
        PB(19) = 19
        PB(20) = 20
        PB(21) = 21
        PB(22) = 22
        PB(23) = 23
        PB(24) = 24
        PB(25) = 25
        PB(26) = 26
        PB(27) = 27
        PB(28) = 28
        PB(29) = 29
        PB(30) = 30
        For PBC As Integer = 1 To 30
            Randomize()
            Select Case (Int(Rnd() * (6 - 1 + 1) + 1)) '(b = 1,r = 2,l = 3,g = 4,p = 5,d = 6)
                Case 1
                    j(PBC).image = My.Resources.b
                    CL(PBC) = 1
                Case 2
                    j(PBC).image = My.Resources.r
                    CL(PBC) = 2
                Case 3
                    j(PBC).image = My.Resources.l
                    CL(PBC) = 3
                Case 4
                    j(PBC).image = My.Resources.g
                    CL(PBC) = 4
                Case 5
                    j(PBC).image = My.Resources.p
                    CL(PBC) = 5
                Case 6
                    j(PBC).image = My.Resources.d
                    CL(PBC) = 6
            End Select
        Next
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseDown
        If fl2 = 0 Then
            i = PictureBox1
            M.Y = i.top
            M.X = i.left
            NB = 1
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox1
        M.Y = i.top
        M.X = i.left
        NB = PB(1)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox2_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseDown
        If fl2 = 0 Then
            i = PictureBox2
            M.Y = i.top
            M.X = i.left
            NB = 2
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox2
        M.Y = i.top
        M.X = i.left
        NB = PB(2)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox3_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseDown
        If fl2 = 0 Then
            i = PictureBox3
            M.Y = i.top
            M.X = i.left
            NB = 3
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox3
        M.Y = i.top
        M.X = i.left
        NB = PB(3)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseDown
        If fl2 = 0 Then
            i = PictureBox4
            M.Y = i.top
            M.X = i.left
            NB = 4
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox4
        M.Y = i.top
        M.X = i.left
        NB = PB(4)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox5_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseDown
        If fl2 = 0 Then
            i = PictureBox5
            M.Y = i.top
            M.X = i.left
            NB = 5
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox5
        M.Y = i.top
        M.X = i.left
        NB = PB(5)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox6_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseDown
        If fl2 = 0 Then
            i = PictureBox6
            M.Y = i.top
            M.X = i.left
            NB = 6
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox6
        M.Y = i.top
        M.X = i.left
        NB = PB(6)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox7_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseDown
        If fl2 = 0 Then
            i = PictureBox7
            M.Y = i.top
            M.X = i.left
            NB = 7
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox7
        M.Y = i.top
        M.X = i.left
        NB = PB(7)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox8_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseDown
        If fl2 = 0 Then
            i = PictureBox8
            M.Y = i.top
            M.X = i.left
            NB = 8
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox8
        M.Y = i.top
        M.X = i.left
        NB = PB(8)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox9_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseDown
        If fl2 = 0 Then
            i = PictureBox9
            M.Y = i.top
            M.X = i.left
            NB = 9
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox9
        M.Y = i.top
        M.X = i.left
        NB = PB(9)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox10_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseDown
        If fl2 = 0 Then
            i = PictureBox10
            M.Y = i.top
            M.X = i.left
            NB = 10
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox10
        M.Y = i.top
        M.X = i.left
        NB = PB(10)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox11_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseDown
        If fl2 = 0 Then
            i = PictureBox11
            M.Y = i.top
            M.X = i.left
            NB = 11
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox11
        M.Y = i.top
        M.X = i.left
        NB = PB(11)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox12_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseDown
        If fl2 = 0 Then
            i = PictureBox12
            M.Y = i.top
            M.X = i.left
            NB = 12
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox12
        M.Y = i.top
        M.X = i.left
        NB = PB(12)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox13_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseDown
        If fl2 = 0 Then
            i = PictureBox13
            M.Y = i.top
            M.X = i.left
            NB = 13
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox13
        M.Y = i.top
        M.X = i.left
        NB = PB(13)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox14_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseDown
        If fl2 = 0 Then
            i = PictureBox14
            M.Y = i.top
            M.X = i.left
            NB = 14
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox14
        M.Y = i.top
        M.X = i.left
        NB = PB(14)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox15_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseDown
        If fl2 = 0 Then
            i = PictureBox15
            M.Y = i.top
            M.X = i.left
            NB = 15
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox15
        M.Y = i.top
        M.X = i.left
        NB = PB(15)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox16_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseDown
        If fl2 = 0 Then
            i = PictureBox16
            M.Y = i.top
            M.X = i.left
            NB = 16
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox16
        M.Y = i.top
        M.X = i.left
        NB = PB(16)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox17_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.MouseDown
        If fl2 = 0 Then
            i = PictureBox17
            M.Y = i.top
            M.X = i.left
            NB = 17
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox17
        M.Y = i.top
        M.X = i.left
        NB = PB(17)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox18_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.MouseDown
        If fl2 = 0 Then
            i = PictureBox18
            M.Y = i.top
            M.X = i.left
            NB = 18
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox18
        M.Y = i.top
        M.X = i.left
        NB = PB(18)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox19_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.MouseDown
        If fl2 = 0 Then
            i = PictureBox19
            M.Y = i.top
            M.X = i.left
            NB = 19
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox19
        M.Y = i.top
        M.X = i.left
        NB = PB(19)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox20_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.MouseDown
        If fl2 = 0 Then
            i = PictureBox20
            M.Y = i.top
            M.X = i.left
            NB = 20
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox20
        M.Y = i.top
        M.X = i.left
        NB = PB(20)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox21_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox21.MouseDown
        If fl2 = 0 Then
            i = PictureBox21
            M.Y = i.top
            M.X = i.left
            NB = 21
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox21
        M.Y = i.top
        M.X = i.left
        NB = PB(21)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox22_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox22.MouseDown
        If fl2 = 0 Then
            i = PictureBox22
            M.Y = i.top
            M.X = i.left
            NB = 22
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox22
        M.Y = i.top
        M.X = i.left
        NB = PB(22)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox23_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox23.MouseDown
        If fl2 = 0 Then
            i = PictureBox23
            M.Y = i.top
            M.X = i.left
            NB = 23
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox23
        M.Y = i.top
        M.X = i.left
        NB = PB(23)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox24_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox24.MouseDown
        If fl2 = 0 Then
            i = PictureBox24
            M.Y = i.top
            M.X = i.left
            NB = 24
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox24
        M.Y = i.top
        M.X = i.left
        NB = PB(24)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox25_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox25.MouseDown
        If fl2 = 0 Then
            i = PictureBox25
            M.Y = i.top
            M.X = i.left
            NB = 25
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox25
        M.Y = i.top
        M.X = i.left
        NB = PB(25)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox26_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox26.MouseDown
        If fl2 = 0 Then
            i = PictureBox26
            M.Y = i.top
            M.X = i.left
            NB = 26
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox26
        M.Y = i.top
        M.X = i.left
        NB = PB(26)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox27_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox27.MouseDown
        If fl2 = 0 Then
            i = PictureBox27
            M.Y = i.top
            M.X = i.left
            NB = 27
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox27
        M.Y = i.top
        M.X = i.left
        NB = PB(27)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox28_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox28.MouseDown
        If fl2 = 0 Then
            i = PictureBox28
            M.Y = i.top
            M.X = i.left
            NB = 28
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox28
        M.Y = i.top
        M.X = i.left
        NB = PB(28)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox29_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox29.MouseDown
        If fl2 = 0 Then
            i = PictureBox29
            M.Y = i.top
            M.X = i.left
            NB = 29
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox29
        M.Y = i.top
        M.X = i.left
        NB = PB(29)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox30_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox30.MouseDown
        If fl2 = 0 Then
            i = PictureBox30
            M.Y = i.top
            M.X = i.left
            NB = 30
            Timer1.Enabled = True
            Timer2.Enabled = True
            fl2 = 1
        End If
        i = PictureBox30
        M.Y = i.top
        M.X = i.left
        NB = PB(30)
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox8.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox9_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox9.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox10_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox10.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox11_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox11.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox12_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox12.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox13_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox13.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox14_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox14.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox15_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox15.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox16_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox16.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox17_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox17.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox18_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox18.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox19_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox19.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox20_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox20.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox21_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox21.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox22_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox22.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox23_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox23.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox24_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox24.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox25_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox25.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox26_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox26.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox27_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox27.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox28_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox28.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox29_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox29.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub PictureBox30_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox30.MouseUp
        Timer1.Enabled = False
        TM = 15
        ProgressBar1.Value = TM
        Timer5.Enabled = True
        Timer4.Enabled = False
        i.top = M.Y
        i.left = M.X
    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        ProgressBar1.Value = TM
        TM = TM - 1
        If TM = 0 Then
            Timer1.Enabled = False
            i.top = M.Y
            i.left = M.X
            TM = 15
            Timer4.Enabled = False
        End If
    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
ag:
        For SCTMP As Integer = 1 To 25 Step 6
            For Sc As Integer = 1 To 30
                If PB(Sc) = SCTMP Then
                    SCT1 = Sc
                ElseIf PB(Sc) = (SCTMP + 1) Then
                    SCT2 = Sc
                ElseIf PB(Sc) = (SCTMP + 2) Then
                    SCT3 = Sc
                ElseIf PB(Sc) = (SCTMP + 3) Then
                    SCT4 = Sc
                ElseIf PB(Sc) = (SCTMP + 4) Then
                    SCT5 = Sc
                ElseIf PB(Sc) = (SCTMP + 5) Then
                    SCT6 = Sc
                End If
            Next
            If CL(SCT1) = CL(SCT2) And CL(SCT2) = CL(SCT3) Then
                If CLR(SCT1) = 0 Then
                    AT += 1
                End If
                If CLR(SCT2) = 0 Then
                    AT += 1
                End If
                If CLR(SCT3) = 0 Then
                    AT += 1
                End If
                CLR(SCT1) = 1
                CLR(SCT2) = 1
                CLR(SCT3) = 1
                If CL(SCT3) = CL(SCT4) Then
                    If CLR(SCT4) = 0 Then
                        AT += 1
                    End If
                    CLR(SCT4) = 1
                    If CL(SCT5) = CL(SCT4) Then
                        If CLR(SCT5) = 0 Then
                            AT += 1
                        End If
                        CLR(SCT5) = 1
                        If CL(SCT6) = CL(SCT5) Then
                            If CLR(SCT6) = 0 Then
                                AT += 1
                            End If
                            CLR(SCT6) = 1
                        End If
                    End If
                End If
            ElseIf CL(SCT2) = CL(SCT3) And CL(SCT3) = CL(SCT4) Then
                If CLR(SCT2) = 0 Then
                    AT += 1
                End If
                If CLR(SCT3) = 0 Then
                    AT += 1
                End If
                If CLR(SCT4) = 0 Then
                    AT += 1
                End If
                CLR(SCT2) = 1
                CLR(SCT3) = 1
                CLR(SCT4) = 1
                If CL(SCT4) = CL(SCT5) Then
                    If CLR(SCT5) = 0 Then
                        AT += 1
                    End If
                    CLR(SCT5) = 1
                    If CL(SCT5) = CL(SCT6) Then
                        If CLR(SCT6) = 0 Then
                            AT += 1
                        End If
                        CLR(SCT6) = 1
                    End If
                End If
            ElseIf CL(SCT3) = CL(SCT4) And CL(SCT4) = CL(SCT5) Then
                If CLR(SCT3) = 0 Then
                    AT += 1
                End If
                If CLR(SCT4) = 0 Then
                    AT += 1
                End If
                If CLR(SCT5) = 0 Then
                    AT += 1
                End If
                CLR(SCT3) = 1
                CLR(SCT4) = 1
                CLR(SCT5) = 1
                If CL(SCT5) = CL(SCT6) Then
                    If CLR(SCT6) = 0 Then
                        AT += 1
                    End If
                    CLR(SCT6) = 1
                End If
            ElseIf CL(SCT4) = CL(SCT5) And CL(SCT5) = CL(SCT6) Then
                If CLR(SCT4) = 0 Then
                    AT += 1
                End If
                If CLR(SCT5) = 0 Then
                    AT += 1
                End If
                If CLR(SCT6) = 0 Then
                    AT += 1
                End If
                CLR(SCT4) = 1
                CLR(SCT5) = 1
                CLR(SCT6) = 1
            End If
        Next
        For SCTMP As Integer = 1 To 6
            For Sc As Integer = 1 To 30
                If PB(Sc) = SCTMP Then
                    SCT1 = Sc
                ElseIf PB(Sc) = (SCTMP + 6) Then
                    SCT2 = Sc
                ElseIf PB(Sc) = (SCTMP + 12) Then
                    SCT3 = Sc
                ElseIf PB(Sc) = (SCTMP + 18) Then
                    SCT4 = Sc
                ElseIf PB(Sc) = (SCTMP + 24) Then
                    SCT5 = Sc
                End If
            Next
            If CL(SCT1) = CL(SCT2) And CL(SCT2) = CL(SCT3) Then
                If CLR(SCT1) = 0 Then
                    AT += 1
                End If
                If CLR(SCT2) = 0 Then
                    AT += 1
                End If
                If CLR(SCT3) = 0 Then
                    AT += 1
                End If
                CLR(SCT1) = 1
                CLR(SCT2) = 1
                CLR(SCT3) = 1
                If CL(SCT3) = CL(SCT4) Then
                    If CLR(SCT4) = 0 Then
                        AT += 1
                    End If
                    CLR(SCT4) = 1
                    If CL(SCT5) = CL(SCT4) Then
                        If CLR(SCT5) = 0 Then
                            AT += 1
                        End If
                        CLR(SCT5) = 1
                    End If
                End If
            ElseIf CL(SCT2) = CL(SCT3) And CL(SCT3) = CL(SCT4) Then
                If CLR(SCT2) = 0 Then
                    AT += 1
                End If
                If CLR(SCT3) = 0 Then
                    AT += 1
                End If
                If CLR(SCT4) = 0 Then
                    AT += 1
                End If
                CLR(SCT2) = 1
                CLR(SCT3) = 1
                CLR(SCT4) = 1
                If CL(SCT4) = CL(SCT5) Then
                    If CLR(SCT5) = 0 Then
                        AT += 1
                    End If
                    CLR(SCT5) = 1
                End If
            ElseIf CL(SCT3) = CL(SCT4) And CL(SCT4) = CL(SCT5) Then
                If CLR(SCT3) = 0 Then
                    AT += 1
                End If
                If CLR(SCT4) = 0 Then
                    AT += 1
                End If
                If CLR(SCT5) = 0 Then
                    AT += 1
                End If
                CLR(SCT3) = 1
                CLR(SCT4) = 1
                CLR(SCT5) = 1
            End If
        Next
        If fl3 = 0 Then
            Label1.Text = AT
        End If
        For SCCR As Integer = 1 To 30
            fl3 = 1
            If CLR(SCCR) = 1 Then
                For sc As Integer = 1 To 30
                    If PB(SCCR) = sc Then
                        Randomize()
                        Select Case (Int(Rnd() * (6 - 1 + 1) + 1)) '(b = 1,r = 2,l = 3,g = 4,p = 5,d = 6)
                            Case 1
                                j(sc).image = My.Resources.b
                                CL(SCCR) = 1
                            Case 2
                                j(sc).image = My.Resources.r
                                CL(SCCR) = 2
                            Case 3
                                j(sc).image = My.Resources.l
                                CL(SCCR) = 3
                            Case 4
                                j(sc).image = My.Resources.g
                                CL(SCCR) = 4
                            Case 5
                                j(sc).image = My.Resources.p
                                CL(SCCR) = 5
                            Case 6
                                j(sc).image = My.Resources.d
                                CL(SCCR) = 6
                        End Select
                    End If
                Next
            End If
        Next
        For EA As Integer = 1 To 30
            CLR(EA) = 0
        Next
        If AT = 0 Then
            fl3 = 0
        End If
        If fl3 = 1 And AT <> 0 Then
            AT = 0
            GoTo ag
        End If
        AT = 0
        Timer5.Enabled = False
    End Sub

   
End Class
