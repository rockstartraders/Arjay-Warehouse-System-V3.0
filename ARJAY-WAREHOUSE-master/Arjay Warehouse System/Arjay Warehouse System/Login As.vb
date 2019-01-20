Imports System.IO

Public Class Login_As

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Login_As_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

       



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


       


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        

    End Sub


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim ab As New Admin_Login    ' -- I need to create a new dim to avoid same instance and avoid instance error 

        Me.Hide()
        ab.ShowDialog()
        Me.Dispose()
        Me.Close()


    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim ac As New Dispatch_Login   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        Me.Hide()
        ac.ShowDialog()
        End


    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim ad As New Receiving_Login    ' -- I need to create a new dim to avoid same instance and avoid instance error 

        Me.Hide()
        ad.ShowDialog()
        End



    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim produkto As New chart   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        Me.Hide()
        produkto.ShowDialog()
        Me.Cursor = Cursors.Default    ' < -- cursor wait function -->
        Me.Dispose()
        Me.Close()



    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class