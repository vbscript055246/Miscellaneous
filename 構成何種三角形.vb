  Dim Str(3), a, b, c
    Sub FD() Handles MyBase.Load
        Label1.Text = "邊長a:"
        Label2.Text = "邊長b:"
        Label3.Text = "邊長c:"
        Button1.Text = "構成何種三角形"
        Button2.Text = "離開"
        Str(0) = "構成頓角"
        Str(1) = "構成銳角"
        Str(2) = "構成直角"
    End Sub

    Sub B1C() Handles Button1.Click
        a = TextBox1.Text
        b = TextBox2.Text
        c = TextBox3.Text
        Label4.Text = a & "," & b & "," & c & "三邊"
        Try
            Str((a >= (b + c) Or b >= (a + c) Or c >= (b + a) Or (a < 0) Or (b < 0) Or (b < 0)) * (-1) + 3) = ""
            Dim tmp = dot(a, b, c) + dot(b, c, a) + dot(c, a, b) + 1
            Label4.Text &= Str(tmp)
            a = 200 * (tmp <> 1 And tmp <> 0 And tmp <> 2) * (-1)
            b = 200 * (tmp <> 1 And tmp <> 0) * (-1)
            c = 200 * (tmp <> 1 And tmp <> 2) * (-1)
            Label4.ForeColor = Color.FromArgb(a, b, c)
        Catch ex As Exception
            Label4.Text &= "無法構成三角形"
            Label4.ForeColor = Color.Red
            Exit Sub
        End Try
        Label4.Text &= "三角形"
    End Sub

    Sub B2C() Handles Button2.Click
        Me.Close()
    End Sub

    Function dot(ByVal a, ByVal b, ByVal c)
        Return (a ^ 2 + b ^ 2 - c ^ 2 < 0) - (a ^ 2 + b ^ 2 - c ^ 2 = 0)
    End Function
