Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '
' used this as reference for combobox index changed https://stackoverflow.com/questions/27882682/vb-net-filling-textbox-on-combobox-selected-index-changed-with-sql-database '



Public Class Create_Receiving_Personnel_Account
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Create_Receiving_Personnel_Account_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address` FROM `employee record`", con)
        Dim table As New DataTable()

        Dim D As Date = Now()  ' this is date and time 
        Me.Label10.Text = D

        '<--  Generate random password to AVOID the ADMIN to do the hula hula which is masagwa -->
        '< -- URL : http://www.vbforums.com/showthread.php?637315-RESOLVED-Random-Password-Generator 

        Dim random As New Random
        Dim password As New System.Text.StringBuilder
        For i As Int32 = 0 To 3
            password.Append(Chr(random.Next(65, 90)))
            password.Append(Chr(random.Next(48, 57)))


        Next
        TextBox6.Text = password.ToString


        ComboBox1.Text = ""

        '< -- Done with password generate -->


        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "emp_no"
        ComboBox1.DisplayMember = "emp_no"

        ' <-- Will clear all fields on form load but allow drop down function 

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        'TextBox6.Text = ""

        Me.TextBox7.Text = Admin_Panel.Label1.Text

    End Sub

    Private Sub ComboBox1_Format(ByVal sender As Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles ComboBox1.Format

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address` FROM `employee record`", con)
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader

        Try
            con.Open()
            Dim query As String
            query = "select * from  `employee record` where `emp_no` ='" + ComboBox1.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader
            While rd.Read
                TextBox2.Text = rd.Item("f_name")
                TextBox3.Text = rd.Item("m_name")
                TextBox4.Text = rd.Item("l_name")
                TextBox1.Text = rd.Item("dept")
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' used this as reference for combobox index changed https://stackoverflow.com/questions/27882682/vb-net-filling-textbox-on-combobox-selected-index-changed-with-sql-database '


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")

        con.Open()
        Dim query As String
        query = "Insert Into `receiving access`(`emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `userid`, `password`) values ('" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()
        MsgBox(" New Access has Been Created for A Receiving Personnel ")
        con.Close()

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & Label1.Text & "','" & Label10.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox1.Text & "','" & TextBox7.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()

        con.Close()

        ' < -- Reload form but ensure its empty but dropdown should not 

        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address` FROM `employee record`", con)
        Dim table As New DataTable()

        Dim D As Date = Now()  ' this is date and time 
        Me.Label10.Text = D

        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "emp_no"
        ComboBox1.DisplayMember = "emp_no"

        ' <-- Will clear all fields on form load but allow drop down function 

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""


    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub
End Class