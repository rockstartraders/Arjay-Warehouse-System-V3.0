Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Password_Reset_for_Receiving_Personnel
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Password_Reset_for_Receiving_Personnel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ComboBox1.Select()
        Button3.Enabled = False
        Dim D As Date = Now()  ' this is date and time 
        Me.Label3.Text = D

        Button1.Enabled = False


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `userid`, `password` FROM `receiving access`", con)
        Dim table As New DataTable()

        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "userid"
        ComboBox1.DisplayMember = "userid"

        ' < -- Clear fields on form load events 


        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        Me.TextBox8.Text = Admin_Panel.Label1.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        'Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `f_name`, `m_name`, `l_name`, `dept` FROM `employee record`", con)
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader

        Try


            con.Open()
            Dim query As String
            query = "SELECT * FROM `receiving access` WHERE `userid` ='" + ComboBox1.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader
            While rd.Read
                TextBox2.Text = rd.Item("emp_no")
                TextBox3.Text = rd.Item("f_name")
                TextBox4.Text = rd.Item("m_name")
                TextBox5.Text = rd.Item("l_name")
                TextBox6.Text = rd.Item("dept")


            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader
        Dim query As String

        Dim employee_no As String
        Dim new_password As String

        employee_no = TextBox2.Text
        new_password = TextBox7.Text




        con.Open()
        query = "UPDATE `receiving access` SET `password` ='" & TextBox7.Text & "' WHERE `emp_no` = '" & TextBox2.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        MsgBox("Password Has Been Change")

        con.Close()

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & Label1.Text & "','" & Label3.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox8.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()

        con.Close()

        ' <-- Clear fields and empty combo box for another form load event 


        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `userid`, `password` FROM `receiving access`", con)

        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "userid"
        ComboBox1.DisplayMember = "userid"

        ' < -- Clear fields on form load events 


        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Button1.Enabled = False




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )


        Dim d As New Password_Reset_Admin_Panel   ' -- I need to create a new dim to avoid same instance 

        If a = DialogResult.Yes Then



           
            Me.Dispose()
            Me.Close()


        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        ' <-- Form validation -->

        Dim newpassword As String

        newpassword = TextBox7.Text

        con.Open()
        query = "select * from `admin access` where `password`='" & TextBox7.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If rd.HasRows Then
            MsgBox("Sorry This Password is Not Acceptable , Please Enter a more Complex Password.", 0 + 64)
            TextBox7.Text = ""
            'InitializeComponent() 'load all the controls again
            'Admin_Self_Help_Password_Reset_Load(e, e) 'Load everything in your form load event again


        Else

            MsgBox("Password is Good To Go.", 0 + 64)
            Button1.Enabled = True


        End If

        con.Close()


    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged


        If TextBox7.TextLength >= 8 Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False

        End If



    End Sub
End Class