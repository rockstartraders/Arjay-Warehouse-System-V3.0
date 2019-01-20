Imports System.IO
Imports System.Net
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Admin_Login
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    ' for entry log 

    Private Sub Admin_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button1.Enabled = False  ' < -- disable button on fired state
        TextBox1.Select()  ' <-- Select Index --> 

        Dim D As Date = Now()  ' this is date and time 
        Me.TextBox3.Text = D

        Me.TextBox4.Text = My.Computer.Name


        For Each address As System.Net.IPAddress In System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList
            If address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                TextBox5.Text = address.ToString()

                Exit For
            End If
        Next

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        

            Dim username As String
            Dim password As String


            username = TextBox1.Text
            password = TextBox2.Text


            con.Open()

            query = "SELECT * FROM `admin access` WHERE `userid`='" & TextBox1.Text & "' and `password`= '" & TextBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader

            If rd.HasRows Then

                rd.Read()

                ' <-- This is needed to show the username automatically inside VB form
                rd.Read()
                Admin_Panel.Label1.Text = rd("userid")


                con.Close()

                con.Open()
                query = "INSERT INTO `entry log`(`time_stamp`, `username`, `pcname`, `ipaddress`, `access type`, `outcome`) values ('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Label4.Text & "','" & TextBox6.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()


                Me.Hide()

                Admin_Panel.ShowDialog()
                Me.Dispose()
                Me.Close()



                '< -- Here the block for close connection needs to be declared to avoid 2 open instance for reader -->

            Else
                con.Close()
                rd.Close()

                MsgBox("Invalid User Name and Password !", 0 + 64)

                '<-- Logging for invalid Instance -->
                con.Open()
                query = "INSERT INTO `entry log`(`time_stamp`, `username`, `pcname`, `ipaddress`, `access type`, `outcome`) values ('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Label4.Text & "','" & TextBox7.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()




                TextBox1.Text = ""
                TextBox2.Text = ""

                con.Close()

            End If







    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then

            




            Dim ae As New Login_As    ' -- I need to create a new dim to avoid same instance and avoid instance error 

            Me.Hide()
            ae.ShowDialog()
            Me.Dispose()
            Me.Close()

        End If

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        ' < -- Enter Button --> 

        If e.KeyCode = Keys.Enter Then
            TextBox2.Select()

        End If



    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown


        ' < -- Enter Button --> 

        If e.KeyCode = Keys.Enter Then
            Button1.Select()

        End If


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text <> "" Then
            Button1.Enabled = True

        Else
            Button1.Enabled = False

        End If

    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown

        If e.KeyCode = Keys.Enter Then


            Dim username As String
            Dim password As String


            username = TextBox1.Text
            password = TextBox2.Text


            con.Open()

            query = "SELECT * FROM `admin access` WHERE `userid`='" & TextBox1.Text & "' and `password`= '" & TextBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader

            If rd.HasRows Then

                rd.Read()

                ' <-- This is needed to show the username automatically inside VB form
                rd.Read()
                Admin_Panel.Label1.Text = rd("userid")


                con.Close()

                con.Open()
                query = "INSERT INTO `entry log`(`time_stamp`, `username`, `pcname`, `ipaddress`, `access type`, `outcome`) values ('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Label4.Text & "','" & TextBox6.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()


                Me.Hide()

                Admin_Panel.ShowDialog()
                Me.Dispose()
                Me.Close()



                '< -- Here the block for close connection needs to be declared to avoid 2 open instance for reader -->

            Else
                con.Close()
                rd.Close()

                MsgBox("Invalid User Name and Password !", 0 + 64)

                '<-- Logging for invalid Instance -->
                con.Open()
                query = "INSERT INTO `entry log`(`time_stamp`, `username`, `pcname`, `ipaddress`, `access type`, `outcome`) values ('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Label4.Text & "','" & TextBox7.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()




                TextBox1.Text = ""
                TextBox2.Text = ""

                con.Close()



            End If

        End If



    End Sub

    Private Sub Button2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button2.KeyDown


        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

            If a = DialogResult.Yes Then






                Dim ae As New Login_As    ' -- I need to create a new dim to avoid same instance and avoid instance error 

                Me.Hide()
                ae.ShowDialog()
                Me.Dispose()
                Me.Close()

            End If

        End If


    End Sub
End Class


