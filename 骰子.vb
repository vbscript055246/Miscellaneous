Imports System.Threading '別忘了打這行 (要把整個程式碼"清空"在複製貼上)
'"清空"意思是指全部刪除一個字也不留
Public Class LBC
    Dim col(3)
    Public L As Label
    Sub LD(ByVal Q, ByVal W, ByVal H, ByVal T, ByVal LF, ByRef F) 'form4 下行"4"按照你現在寫的改
        L = New Label With {.[Parent] = Form4,
                            .[Font] = F,
                            .[Width] = W,
                            .[Height] = H,
                            .[Top] = T,
                            .[Left] = LF}
        col(1) = Color.Red
        col(2) = Color.Blue
        col(3) = Color.Black
    End Sub
    Sub U()
        L.Text = Val(L.Text) + 1
    End Sub
    Sub CL(ByVal q)
        If q Then L.Text = 0
        C(3)
    End Sub
    Sub C(ByVal q)
        L.ForeColor = col(q)
    End Sub
End Class

Public Class Form4 'form4 這個"4"按照你現在寫的改
    Const PT = 35
    Const S = 20
    Dim A = 0
    Dim L(9), Y(6) As LBC
    Dim FT = New Font(Font.SystemFontName, 18, Font.Style)
    Dim B(3) As Button

    Sub U()
        For i = 1 To 6
            L(i).CL(1)
            Y(i).CL(0)
        Next
    End Sub

    Sub FD() Handles MyBase.Load
        Me.Width = 575
        Me.Height = 475
        For i = 1 To 9
            L(i) = New LBC
            If i <= 6 Then
                Y(i) = New LBC
                With Y(i)
                    .LD(i, 215, PT, (89 + (i - 1) * 45), 5, FT)
                    .L.Text = i & " 點出現總次數為 : "
                End With
                With L(i)
                    .LD(i, 50, PT, (89 + (i - 1) * 45), 220, FT)
                    .CL(1)
                End With
            ElseIf i = 7 Then
                With L(i)
                    .LD(i, 175, PT, 29, 100, FT)
                    .L.Text = "本次點數為: "
                End With
            ElseIf i = 8 Then
                With L(i)
                    .LD(i, 100, PT, 29, 275, FT)
                    .L.Text = "0點"
                End With
            ElseIf i = 9 Then
                With L(i)
                    .LD(i, 250, PT, 370, 130, FT)
                End With
            End If
        Next

        For i = 1 To 3
            B(i) = New Button With {
                                    .[Parent] = Me,
                                    .[Top] = 244 + (i - 1) * 58,
                                    .[Left] = 463,
                                    .[Height] = 52,
                                    .[Width] = 76}


            Select Case i
                Case 1
                    B(i).Text = "開始"
                    AddHandler B(i).Click, AddressOf B1C
                Case 2
                    B(i).Text = "重新"
                    B(i).Enabled = 0
                    AddHandler B(i).Click, AddressOf B2C
                Case 3
                    B(i).Text = "結束"
                    AddHandler B(i).Click, AddressOf B3C
            End Select
        Next
        L(8).C(2)
        L(9).L.Text = "總共玩了 : " & A & "次"
        U()
        L(9).C(2)
    End Sub

    Sub B1C()
        L(9).C(2)
        L(7).L.Text = "本次點數為: "
        L(8).L.Visible = 1
        B(1).Enabled = 0
        B(2).Enabled = 0
        B(1).Text = "下一次"
        Dim P
        For i = 0 To 30
            Thread.Sleep(100)
            Application.DoEvents()
            Randomize()
            P = Int(Rnd() * (6 - 1 + 1) + 1)
            L(8).L.Text = P & "點"
        Next
        Y(P).C(1)
        L(P).C(1)
        L(8).C(1)
        L(P).U()
        A += 1
        L(9).L.Text = "總共玩了 : " & A & "次"
        For i = 0 To S - 10
            L(8).L.Visible = (i Mod 2 = 0)
            Application.DoEvents()
            Thread.Sleep(100)
        Next
        B(1).ForeColor = Color.Blue
        B(1).Enabled = 1
        B(2).Enabled = 1
    End Sub

    Sub B2C()
        L(9).C(2)
        B(1).ForeColor = Color.Black
        B(1).Text = "開始"
        B(2).Enabled = 0
        L(8).L.Visible = 0
        L(7).L.Text = "重新開始"
        A = 0
        L(9).L.Text = "總共玩了 : " & A & "次"
        U()
    End Sub

    Sub B3C()
        Me.Close()
    End Sub

End Class
