    Dim str(2)
    Sub FD() Handles MyBase.Load
        Label1.Text = "輸入您的身高:"
        Label2.Text = "輸入您的體重:"
        Label3.Text = "公分"
        Label4.Text = "公斤"
        Label5.Text = ""
        Button1.Text = "計算BMI值"
        Button2.Text = "離開"
        str(0) = "適中"
        str(1) = "過輕"
        str(2) = "過重"
    End Sub

    Sub B1C() Handles Button1.Click

        '下面這行未提供輸出細節 需可能須調整 
        '調整時注意只要不破壞成對的括弧和其中的東西 結果會是正確的
        ' EX: ( @@#$# ) & ( $&$#$%^& )
        '像是 ( @@#$# ) & ( $&$#$%^& ) & (%^&%^#)
        '或 ( @@#$# ) & " " & ( $&$#$%^& ) 皆會正確

        '但像 ( @@#$# $^*#) & ( $&$#$%^& )
        '或 ( @@#$#  & ( $&$#$%^& ) 皆會錯誤
        Label5.Text = (TextBox1.Text / TextBox2.Text ^ 2) & (" ") & (str((TextBox1.Text / TextBox2.Text ^ 2 < 24) - (TextBox1.Text / TextBox2.Text ^ 2 > 18) + 1))

    End Sub

    Sub B2C() Handles Button2.Click
        Me.Close()
    End Sub
