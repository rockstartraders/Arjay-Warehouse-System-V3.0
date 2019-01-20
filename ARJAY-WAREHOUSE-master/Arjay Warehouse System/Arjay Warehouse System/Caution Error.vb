Public Class Caution_Error

    Private Sub Caution_Error_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim consignorkagebunshintimes2 As New Consignor_Modification   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        consignorkagebunshintimes2.Show()
        Me.Dispose()
        Me.Close()

    End Sub
End Class