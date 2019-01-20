Public Class Receiving_Panel

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->


        Dim bago As New Correction_Ticket    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        bago.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim agaa As New View_Correction_Request   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        agaa.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim ahaaazz As New Receiving_Self_Help_Password_Resetvb   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        ahaaazz.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Receiving_Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim no_more_brain As New Consignors_Address_Book   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        no_more_brain.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim no_more_brain_left As New Incoming   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        no_more_brain_left.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim no_more_brain_left_promise As New Invoice_Copy   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        no_more_brain_left_promise.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click


        Dim asube As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If asube = DialogResult.Yes Then

            Me.Hide()
            MsgBox("Goodbye")
            Me.Dispose()
            Me.Close()


        End If
    End Sub
End Class