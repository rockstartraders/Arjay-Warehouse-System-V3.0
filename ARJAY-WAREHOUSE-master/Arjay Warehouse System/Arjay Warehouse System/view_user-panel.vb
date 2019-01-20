Public Class view_user_panel

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim alikabok As New user_admin    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        alikabok.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim balbas As New user_receiving  ' -- I need to create a new dim to avoid same instance and avoid instance error 


        balbas.Show()


        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim cocktail As New user_dispatch   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        cocktail.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        Dim aki As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If aki = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class