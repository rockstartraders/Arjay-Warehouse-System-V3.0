Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '


Public Class Dispatch_Login
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Dispatch_Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown



    End Sub

    Private Sub Dispatch_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Button1.Enabled = False   ' Form Load function --> 
        TextBox1.Select()    ' < -- focus function --> 


        ' for entry log

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim username As String
        Dim password As String


        username = TextBox1.Text
        password = TextBox2.Text

        con.Open()

        query = "SELECT * FROM `dispatch access` WHERE `userid`='" & TextBox1.Text & "' and `password`= '" & TextBox2.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If rd.HasRows Then


          
            ' <-- This is needed to show the username automatically inside VB form
            rd.Read()
            Dispatch_Panel.Label1.Text = rd("userid")
            Dispatch_Panel.Label3.Text = rd("f_name")
            Dispatch_Panel.Label4.Text = rd("l_name")

            con.Close()

            '< -- Logging Purposes -->

            con.Open()
            query = "INSERT INTO `entry log`(`time_stamp`, `username`, `pcname`, `ipaddress`, `access type`, `outcome`) values ('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Label4.Text & "','" & TextBox6.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()


            Me.Hide()
            Dispatch_Panel.ShowDialog()
            Me.Close()
            
           

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



            'Me.Dispose()
            'Me.Close()





            Dim ae As New Login_As    ' -- I need to create a new dim to avoid same instance and avoid instance error 

            Me.Hide()
            ae.ShowDialog()
            End


        End If


    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        '< -- Enter State --> 

        If e.KeyCode = Keys.Enter Then
            TextBox2.Select()

        End If


    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged



    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown

        '< -- Enter State --> 

        If e.KeyCode = Keys.Enter Then
            Button1.Select()

        End If


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        ' < -- Validation amigo --> 

        If TextBox2.Text <> "" Then
            Button1.Enabled = True

        Else
            Button1.Enabled = False

        End If




    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown


        '< -- Enter State --> 

        If e.KeyCode = Keys.Enter Then
            Dim username As String
            Dim password As String


            username = TextBox1.Text
            password = TextBox2.Text

            con.Open()

            query = "SELECT * FROM `dispatch access` WHERE `userid`='" & TextBox1.Text & "' and `password`= '" & TextBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader

            If rd.HasRows Then



                ' <-- This is needed to show the username automatically inside VB form
                rd.Read()
                Dispatch_Panel.Label1.Text = rd("userid")
                Dispatch_Panel.Label3.Text = rd("f_name")
                Dispatch_Panel.Label4.Text = rd("l_name")

                con.Close()

                '< -- Logging Purposes -->

                con.Open()
                query = "INSERT INTO `entry log`(`time_stamp`, `username`, `pcname`, `ipaddress`, `access type`, `outcome`) values ('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Label4.Text & "','" & TextBox6.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()


                Me.Hide()
                Dispatch_Panel.ShowDialog()
                Me.Close()



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

        '< -- Enter State --> 

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