Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Form1

    Const port As Integer = 10912
    Dim IP As String = "127.0.0.1"
    Private TCP As TcpClient
    Dim ALLHIT As Integer

    Public LMAX As Integer
    Public life As Integer
    Dim MS(2, 3) As Integer '血條放(?,0)
    Dim MSW As Short = 0

    Dim BUF(6) As Integer
    Public hit As Integer
    Public AT(6) As Integer
    Dim FAT As Integer = 0

    Dim wait As Integer = 0
    Dim DY, DX As Integer
    Public T2 As Integer
    Public M As Point
    Public Pic(30) As P
    Dim fl1 As Integer
    Public FR(6) As Integer
    Dim TM As Integer
    Public pio As Point
    Public q As Point

    Public FRS As Boolean = True

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case main.flag
            Case 1
                BUF(1) = 100 '水
                BUF(2) = 500 '火
                BUF(3) = 100 '光
                BUF(4) = 100 '草
                BUF(5) = 100 '心
                BUF(6) = 100 '暗
                ProgressBar1.Maximum = 1000
                life = 1000
                LMAX = 1000
                ProgressBar1.Value = 1000
            Case 2
                BUF(1) = 100
                BUF(2) = 100
                BUF(3) = 100
                BUF(4) = 100
                BUF(5) = 500
                BUF(6) = 100
                ProgressBar1.Maximum = 1500
                life = 1500
                LMAX = 1500
                ProgressBar1.Value = 1500
            Case 3
                BUF(1) = 200
                BUF(2) = 200
                BUF(3) = 200
                BUF(4) = 200
                BUF(5) = 200
                BUF(6) = 200
                ProgressBar1.Maximum = 2500
                life = 2500
                LMAX = 2500
                ProgressBar1.Value = 2500
            Case 4
                BUF(1) = 1000
                BUF(2) = 1000
                BUF(3) = 1000
                BUF(4) = 1000
                BUF(5) = 1000
                BUF(6) = 1000
                ProgressBar1.Maximum = 10000
                life = 10000
                LMAX = 10000
                ProgressBar1.Value = 10000
        End Select

        MS(0, 0) = 1000
        MS(1, 0) = 1000
        MS(2, 0) = 10000

        MS(0, 1) = 100
        MS(0, 2) = 50
        MS(0, 3) = 150

        MS(1, 1) = 250
        MS(1, 2) = 100
        MS(1, 3) = 350

        MS(2, 1) = 500
        MS(2, 2) = 350
        MS(2, 3) = 450

        Me.Text = "神" & Chr(34) & "麼" & Chr(34) & "之塔"
        Me.Width = 710
        Me.Height = 700
        ProgressBar1.Top = 90
        ProgressBar1.Left = 0
        ProgressBar1.Width = Me.Width
        ProgressBar1.Height = 20
        ProgressBar2.Maximum = 1000
        ProgressBar2.Value = ProgressBar2.Maximum
        ProgressBar2.Left = Me.Width / 2 - 50
        ProgressBar2.Top = 70
        ProgressBar2.Width = 100
        ProgressBar2.Height = 5
        PictureBox1.Left = Me.Width / 2 - (PictureBox1.Width / 2)

        Dim TPN As Integer = 1
        Timer1.Enabled = False
        Timer3.Enabled = False
        Timer1.Interval = 1
        Timer2.Interval = 250
        Timer3.Interval = 250
        Timer4.Interval = 1000
        Timer5.Interval = 100
        Pic(0) = New P
        For TPA As Integer = 0 To 4
            For TPB As Integer = 0 To 5
                Randomize()
                Pic(TPN) = New P
                Pic(TPN).mark = 0
                Pic(TPN).NB = TPN
                Pic(TPN).make((120 + 110 * TPA), (20 + 110 * TPB), Int(Rnd() * (6 - 1 + 1) + 1))
                TPN += 1
            Next
        Next

        For i As Integer = 0 To 5
            FR(i) = 1
        Next
        PictureBox1.Image = My.Resources.地精
        Label1.Visible = False
        Call Ccleaner()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.ShowInTaskbar = True
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    '========================================
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer4.Enabled = True
        Dim i As Object = Pic(T2).PB
        If (Cursor.Position.X - q.X <> 0 Or Cursor.Position.Y - q.Y <> 0) Then
            i.Left += (Cursor.Position.X - Me.Location.X - 10 - i.Width / 2 - pio.X)
            i.Top += (Cursor.Position.Y - Me.Location.Y - 30 - i.Height / 2 - pio.Y)
            pio.X = i.Left
            pio.Y = i.Top
        Else

        End If
        q.X = Cursor.Position.X
        q.Y = Cursor.Position.Y
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
        Dim Top As Integer = Pic(T2).PB.Top
        Dim Left As Integer = Pic(T2).PB.Left
        Dim deg As Single = Math.Atan2(Top - M.Y, Left - M.X) * (180 / Math.PI) * (-1)
        'Label2.Text = deg
        If ((Math.Abs(Top - M.Y)) ^ 2 + (Math.Abs(Left - M.X) ^ 2)) ^ (1 / 2) > 25 Then
            If -22.5 > deg AndAlso deg > -67.5 Then  '右下 +7
                If T2 = 6 Or T2 = 12 Or T2 = 18 Or T2 = 24 Or T2 = 29 Or T2 = 30 Or T2 = 28 Or T2 = 27 Or T2 = 26 Or T2 = 25 Then
                    GoTo out
                End If
                CG(7)
            ElseIf 112.5 < deg AndAlso deg < 157.5 Then '左上 -7
                If T2 = 7 Or T2 = 13 Or T2 = 6 Or T2 = 1 Or T2 = 2 Or T2 = 3 Or T2 = 4 Or T2 = 5 Or T2 = 19 Or T2 = 25 Then
                    GoTo out
                End If
                CG(-7)
            ElseIf 67.5 > deg AndAlso deg > 22.5 Then '右上 -5
                If T2 = 6 Or T2 = 12 Or T2 = 18 Or T2 = 1 Or T2 = 2 Or T2 = 3 Or T2 = 4 Or T2 = 5 Or T2 = 24 Or T2 = 30 Then
                    GoTo out
                End If
                CG(-5)
            ElseIf -112.5 > deg AndAlso deg > -157.5 Then '左下 +5
                If T2 = 1 Or T2 = 27 Or T2 = 7 Or T2 = 28 Or T2 = 13 Or T2 = 19 Or T2 = 29 Or T2 = 25 Or T2 = 26 Or T2 = 27 Or T2 = 30 Then
                    GoTo out
                End If
                CG(5)
            ElseIf 22.5 > deg AndAlso deg > -22.5 Then '右 +1
                If T2 = 6 Or T2 = 12 Or T2 = 18 Or T2 = 24 Or T2 = 30 Then
                    GoTo out
                End If
                CG(1)
            ElseIf -67.5 > deg AndAlso deg > -112.5 Then '下 +6
                If T2 = 28 Or T2 = 30 Or T2 = 25 Or T2 = 29 Or T2 = 26 Or T2 = 27 Then
                    GoTo out
                End If
                CG(6)
            ElseIf (157.5 < deg AndAlso deg <= 180) Or (-180 <= deg AndAlso deg < -157.5) Then '左 -1
                If T2 = 13 Or T2 = 1 Or T2 = 7 Or T2 = 19 Or T2 = 25 Then
                    GoTo out
                End If
                CG(-1)
            ElseIf 67.5 < deg AndAlso deg < 112 Then '上 -6
                If T2 = 6 Or T2 = 2 Or T2 = 1 Or T2 = 3 Or T2 = 4 Or T2 = 5 Then
                    GoTo out
                End If
                CG(-6)
            End If
        End If
out:
    End Sub

    Sub CG(ByVal q)
        Dim ttmp As Image = Pic(T2).PB.Image
        Pic(T2).PB.Image = Pic(T2 + q).PB.Image
        Pic(T2 + q).PB.Image = ttmp

        Dim tmp As Integer = Pic(T2).color
        Pic(T2).color = Pic(T2 + q).color
        Pic(T2 + q).color = tmp

        Dim tttmp As Point
        tttmp.X = Pic(T2 + q).PB.Left
        tttmp.Y = Pic(T2 + q).PB.Top
        Pic(T2).PB.Top = M.Y
        Pic(T2).PB.Left = M.X
        Pic(T2 + q).PB.Top = Pic(T2).PB.Top
        Pic(T2 + q).PB.Left = Pic(T2).PB.Left
        M.Y = tttmp.Y
        M.X = tttmp.X
        T2 = T2 + q

        Timer2.Enabled = False
        System.Threading.Thread.Sleep(50)
        Timer2.Enabled = True

    End Sub
    '========================================


    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        ProgressBar1.Value -= 1
        If ProgressBar1.Value = 0 Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            Pic(T2).PB.Top = M.Y
            Pic(T2).PB.Left = M.X
            ProgressBar1.Maximum = LMAX
            Try
                ProgressBar1.Value = life
            Catch ex As Exception
                ProgressBar1.Value = ProgressBar1.Maximum
            End Try
            Timer4.Enabled = False
            Call Ccleaner()
        End If
    End Sub


    '========================================
    Sub Ccleaner()
        For i As Integer = 0 To 1
            If i = 0 Then
                For j As Integer = 1 To 25 Step 6
                    Fcleaner(Pic(j).color, j, 1, j + 5)
                Next
            Else
                For j As Integer = 1 To 6
                    Fcleaner(Pic(j).color, j, 6, j + 24)
                Next
            End If
        Next
        Call Dcleaner()
    End Sub

    Sub Fcleaner(ByVal col, ByVal st, ByVal d, ByVal sp)
        Dim tmp As Integer = st
        Dim good As Integer = 0
        While tmp <= sp

            If col = 0 Then
                MsgBox("例外")
                End
            End If

            If Pic(tmp).color = col Then
                good += 1
                'MsgBox(good)
                If good = 3 Then
                    For k As Integer = tmp To tmp - 2 * d Step -d

                        If Pic(k).mark = 0 Then
                            AT(Pic(tmp).color) += 1
                            'MsgBox(k & "AT(" & Pic(tmp).color)
                            Pic(k).mark = 1
                        End If
                    Next
                ElseIf good > 3 Then
                    'MsgBox(Pic(tmp).mark & " over 3")
                    If Pic(tmp).mark = 0 Then
                        AT(Pic(tmp).color) += 1
                        'MsgBox(tmp & "AT(" & Pic(tmp).color)
                        Pic(tmp).mark = 1
                    End If
                End If
            Else
                'MsgBox(tmp & " CG")
                col = Pic(tmp).color
                good = 1
            End If
            tmp += d
        End While
    End Sub

    Sub Dcleaner()
        For i As Integer = 30 To 1 Step -1
            'MsgBox(Pic(i).mark & " 第" & i)
            Pic(i).droper()
        Next
        For i As Integer = 30 To 1 Step -1
            Pic(i).PB.Enabled = False
        Next
        TM = 10
        Timer5.Enabled = True
    End Sub
    '========================================


    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        If TM = 0 Then
            Timer5.Enabled = False
            For i As Integer = 0 To 5
                FR(i) = 1
            Next
            For i As Integer = 1 To 30
                Pic(i).px = 0
                Pic(i).PB.Enabled = True
                Pic(i).mark = 0
            Next
            If FRS Then

            Else
                For n = 1 To 6
                    If n = 5 Then
                        life += AT(n) * BUF(n)
                    Else
                        hit += AT(n) * BUF(n)
                    End If
                Next
            End If

            For n = 1 To 6
                AT(0) += AT(n)
                AT(n) = 0
                'MsgBox(AT(n))
            Next


            If AT(0) <> FAT Then
                FAT = AT(0)
                Call Ccleaner()
            Else

                If FRS Then
                    FRS = False
                Else
                    FAT = 0
                    '===========================================================================
                    life -= MSH(MSW)
                    'Label1.Text = hit & " PL  " & ProgressBar2.Value & " MS"
                    ALLHIT += hit
                    ProgressBar1.Maximum = LMAX
                    Try
                        ProgressBar1.Value = life
                    Catch ex As Exception
                        If life > ProgressBar1.Maximum Then
                            life = ProgressBar1.Maximum
                        Else
                            MsgBox("你輸ㄌ")
                            main.Close()
                            End
                        End If
                    End Try
                    '===========================================================================
                    Try
                        ProgressBar2.Value -= hit
                    Catch ex As Exception
                        MSW += 1
                        If MSW = 3 Then
                            MsgBox("上傳分數")
                            '=============================================================

AG:
                            IP = InputBox("請輸入上傳伺服IP", "上傳分數", IP)
                            Dim myIPEndPoint As New IPEndPoint(IPAddress.Any, 0)
                            TCP = New TcpClient(myIPEndPoint)
                            Dim ServerIpAddress As IPAddress

                            Try
                                ServerIpAddress = IPAddress.Parse(IP)

                            Catch r As Exception
                                MsgBox("未輸入IP")
                                GoTo AG
                            End Try


                            Dim RIP As New IPEndPoint(ServerIpAddress, port)
                            Try
                                TCP.Connect(RIP)
                                Do
                                    If TCP.Connected = True Then
                                        MsgBox("連線成功")
                                        Call send()

                                        Exit Do
                                    End If
                                Loop
                            Catch w As Exception
                                Dim x As Short = MsgBox("無法連線", MsgBoxStyle.RetryCancel)
                                If x = 4 Then
                                    GoTo AG
                                Else
                                    End
                                End If

                            End Try
                            '=============================================================
                            'End

                        Else

                            ProgressBar2.Maximum = MS(MSW, 0)
                            ProgressBar2.Value = MS(MSW, 0)
                            MsgBox("MSGG CG IM  =>" & MSW)
                            Select Case MSW
                                Case 1
                                    PictureBox1.Image = My.Resources.大直馬
                                Case 2
                                    PictureBox1.Image = My.Resources.淑媛
                            End Select
                        End If

                    End Try
                End If

            End If
        End If
        For i As Integer = 1 To 30
            Pic(i).mover()
        Next
        TM -= 1
    End Sub


    '========================================
    Function MSH(ByVal q As Short)
        Randomize()
        Dim s = MS(q, Int(Rnd() * (3 - 1 + 1) + 1))
        'MsgBox(s)
        Return s
    End Function

    Private Sub send()
        Dim ServerIpAddress As IPAddress

        ServerIpAddress = IPAddress.Parse(IP)

        Dim NS As NetworkStream
        Dim BTS As Byte()
        BTS = Encoding.GetEncoding(950).GetBytes(Trim(CType(ALLHIT, String).Trim))

        NS = TCP.GetStream()
        NS.Write(BTS, 0, BTS.Length)
        Call shutdown()

    End Sub

    Private Sub shutdown()
        TCP.Close()
        MsgBox("上傳完成")
        End
    End Sub
    '========================================
End Class

Public Class P
    Public PB As PictureBox = New PictureBox
    Public NB As Integer
    Public color As Integer
    Public mark As Integer
    Public px As Single = 0

    Sub make(ByVal t, ByVal l, ByVal IM)
        PB.Parent = Form1
        PB.Width = 105
        PB.Height = 105
        PB.SizeMode = PictureBoxSizeMode.CenterImage
        PB.Top = t
        PB.Left = l
        color = IM
        Select Case IM
            Case 1
                PB.Image = My.Resources.b
            Case 2
                PB.Image = My.Resources.r
            Case 3
                PB.Image = My.Resources.l
            Case 4
                PB.Image = My.Resources.g
            Case 5
                PB.Image = My.Resources.p
            Case 6
                PB.Image = My.Resources.d
        End Select
        AddHandler PB.MouseDown, AddressOf MD
        AddHandler PB.MouseUp, AddressOf MP
    End Sub

    Sub MD(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        For n = 0 To 6
            Form1.AT(n) = 0
        Next
        Form1.M.Y = PB.Top
        Form1.M.X = PB.Left
        Form1.T2 = NB
        Form1.Timer1.Enabled = True
        Form1.Timer2.Enabled = True
        Form1.ProgressBar1.Maximum = 10
        Form1.ProgressBar1.Value = 10
        Form1.Timer4.Enabled = True
        Form1.pio.X = e.X
        Form1.pio.Y = e.Y
        Form1.q.X = Cursor.Position.X
        Form1.q.Y = Cursor.Position.Y
    End Sub

    Sub MP()
        Form1.Timer1.Enabled = False
        Form1.Timer2.Enabled = False
        Form1.Timer4.Enabled = False
        Form1.ProgressBar1.Maximum = Form1.LMAX
        Try
            Form1.ProgressBar1.Value = Form1.life
        Catch ex As Exception
            Form1.ProgressBar1.Value = Form1.ProgressBar1.Maximum
        End Try
        Form1.Pic(Form1.T2).PB.Top = Form1.M.Y
        Form1.Pic(Form1.T2).PB.Left = Form1.M.X
        Form1.hit = 0
        Call Form1.Ccleaner()
    End Sub

    Sub droper()
        If Form1.FRS And mark = 1 Then
            Randomize()
            Select Case Int(Rnd() * (6 - 1 + 1) + 1)
                Case 1
                    Form1.Pic(NB).PB.Image = My.Resources.b '水
                    Form1.Pic(NB).color = 1
                Case 2
                    Form1.Pic(NB).PB.Image = My.Resources.r '火
                    Form1.Pic(NB).color = 2
                Case 3
                    Form1.Pic(NB).PB.Image = My.Resources.l '光
                    Form1.Pic(NB).color = 3
                Case 4
                    Form1.Pic(NB).PB.Image = My.Resources.g '草
                    Form1.Pic(NB).color = 4
                Case 5
                    Form1.Pic(NB).PB.Image = My.Resources.p '心
                    Form1.Pic(NB).color = 5
                Case 6
                    Form1.Pic(NB).PB.Image = My.Resources.d '暗
                    Form1.Pic(NB).color = 6
            End Select
        Else
            If mark = 1 Then

                'MsgBox("位置:" & NB)
                Dim tmp As Integer = NB

                While tmp > 6

                    If Form1.Pic(tmp - 6).mark = 0 Then

                        px = (PB.Top - Form1.Pic(tmp - 6).PB.Top) / 10 ' 0.1秒
                        PB.Top = Form1.Pic(tmp - 6).PB.Top

                        color = Form1.Pic(tmp - 6).color
                        PB.Image = Form1.Pic(tmp - 6).PB.Image
                        'MsgBox("!!! " & NB & "拿 " & tmp)
                        Form1.Pic(tmp - 6).PB.Image = My.Resources.rest
                        Form1.Pic(tmp - 6).color = 0
                        Form1.Pic(tmp - 6).mark = 1
                        mark = 0
                        Exit While

                    Else

                        tmp -= 6

                    End If

                End While
                tmp = NB
                If mark = 1 Then

                    'MsgBox("位置:" & NB & " / " & "找:" & tmp)
                    While tmp > 0
                        'MsgBox("位置:" & tmp & "重製")
                        Randomize()
                        Select Case Int(Rnd() * (6 - 1 + 1) + 1)
                            Case 1
                                Form1.Pic(tmp).PB.Image = My.Resources.b '水
                                Form1.Pic(tmp).color = 1
                            Case 2
                                Form1.Pic(tmp).PB.Image = My.Resources.r '火
                                Form1.Pic(tmp).color = 2
                            Case 3
                                Form1.Pic(tmp).PB.Image = My.Resources.l '光
                                Form1.Pic(tmp).color = 3
                            Case 4
                                Form1.Pic(tmp).PB.Image = My.Resources.g '草
                                Form1.Pic(tmp).color = 4
                            Case 5
                                Form1.Pic(tmp).PB.Image = My.Resources.p '心
                                Form1.Pic(tmp).color = 5
                            Case 6
                                Form1.Pic(tmp).PB.Image = My.Resources.d '暗
                                Form1.Pic(tmp).color = 6
                        End Select

                        Form1.Pic(tmp).mark = 0
                        Form1.Pic(tmp).px = (Form1.Pic(tmp).PB.Top - Form1.FR(NB Mod 6) * (-1) * 110) / 10 ' 0.1秒
                        Form1.Pic(tmp).PB.Top = Form1.FR(NB Mod 6) * (-1) * 110
                        Form1.FR(NB Mod 6) += 1
                        tmp -= 6

                    End While

                End If

            Else
                'MsgBox("位置:" & NB & "略過")
            End If
        End If



    End Sub

    Sub mover()
        PB.Top += px
    End Sub

End Class


