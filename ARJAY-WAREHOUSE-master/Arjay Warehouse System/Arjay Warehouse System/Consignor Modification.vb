Public Class Consignor_Modification

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim consignorupdate As New Update_Consignor_Record    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        consignorupdate.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim consignorterminate As New Delete_Consignor_Records    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        consignorterminate.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Consignor_Modification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class