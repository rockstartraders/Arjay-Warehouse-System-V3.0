Public Class Delete_Access_Admin_Panel

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim aaaakabb As New Delete_Access_for_an_ADMIN_admin   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaakabb.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->


        Dim aaaakabbb As New Delete_Access_for_Dispatch_Admin_function   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaakabbb.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->


        Dim aaaakabbbd As New Delete_Access_for_Receiving_admin_function   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaakabbbd.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Delete_Access_Admin_Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class