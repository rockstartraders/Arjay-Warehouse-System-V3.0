Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '




Public Class Dispatch_Self_Help_Reset_Password
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Dispatch_Self_Help_Reset_Password_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '< --- Use this to display text from previous from to this new instance 

        Me.TextBox1.Text = Dispatch_Panel.Label1.Text
        TextBox2.Select()
        Button1.Enabled = False
        Button3.Enabled = False

       





    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim username As String
        Dim newpassword As String


        username = TextBox1.Text
        newpassword = TextBox2.Text



        con.Open()
        query = "select * from `dispatch access` where `userid`='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If rd.HasRows Then

            con.Close()
            con.Open()
            query = "Update `dispatch access` set `password` = '" & TextBox2.Text & "' where `userid` ='" & TextBox1.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader



            Dim ahaaaa As New Dispatch_Login   ' -- I need to create a new dim to avoid same instance and avoid instance error 

            Dim a As DialogResult = MsgBox("Password Has Been Change But for Security Reason you Need to Logout and Log Back in Using your New Password ", 0 + 64)
            If a = DialogResult.OK Then

                TextBox2.Text = ""

                Me.Cursor = Cursors.Default  ' < -- Return to default Cursor -->


                con.Close()


                Me.Dispose()
                Me.Close()
                Dispatch_Panel.Dispose()
                Dispatch_Panel.Close()
                ahaaaa.ShowDialog()



            End If




        End If


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged


        If TextBox2.TextLength >= 8 Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False

        End If


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged



    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        ' <-- Form validation -->

        Dim newpassword As String

        newpassword = TextBox2.Text

        con.Open()
        query = "select * from `admin access` where `password`='" & TextBox2.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If rd.HasRows Then
            MsgBox("Sorry This Password is Not Acceptable , Please Enter a more Complex Password.", 0 + 64)
            TextBox2.Text = ""
            'InitializeComponent() 'load all the controls again
            'Admin_Self_Help_Password_Reset_Load(e, e) 'Load everything in your form load event again

            Me.Cursor = Cursors.Default

        Else

            MsgBox("Password is Good To Go.", 0 + 64)
            Button1.Enabled = True

            Me.Cursor = Cursors.Default

        End If

        con.Close()



    End Sub
End Class
