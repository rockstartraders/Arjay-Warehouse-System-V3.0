Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Image
Imports System.IO.MemoryStream

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Delete_Access_for_Dispatch_Admin_function
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If
    End Sub

    Private Sub Delete_Access_for_Dispatch_Admin_function_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT  `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `userid`, `password` FROM `dispatch access`", con)
        Dim table As New DataTable()

        Dim D As Date = Now()  ' this is date and time 
        Me.Label10.Text = D

        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "emp_no"
        ComboBox1.DisplayMember = "emp_no"

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        Me.TextBox7.Text = Admin_Panel.Label1.Text




    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        '<-- Auto load form 

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT  `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `userid`, `password` FROM `dispatch access`", con)
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader




        Try


            con.Open()
            Dim query As String
            query = "select * from `dispatch access` where `emp_no` ='" + ComboBox1.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader
            While rd.Read
                TextBox2.Text = rd.Item("f_name")
                TextBox3.Text = rd.Item("m_name")
                TextBox4.Text = rd.Item("l_name")
                TextBox1.Text = rd.Item("dept")
                TextBox5.Text = rd.Item("userid")
                TextBox6.Text = rd.Item("password")

            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try






    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")


        con.Open()
        Dim query As String
        query = "DELETE FROM `dispatch access` WHERE `emp_no`='" & ComboBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()
        MsgBox(" Dispatch Access has Been Terminated ")
        con.Close()

        '<-- for logging purposes 

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & Label1.Text & "','" & Label10.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox1.Text & "','" & TextBox7.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()

        con.Close()

        '<-- Just added this to reload form 

        Dim adapter As New MySqlDataAdapter("SELECT  `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `userid`, `password` FROM `dispatch access`", con)
        Dim table As New DataTable()

       
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "emp_no"
        ComboBox1.DisplayMember = "emp_no"

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""



    End Sub
End Class