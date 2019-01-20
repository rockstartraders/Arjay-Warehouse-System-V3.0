Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Locker_Registration_Form
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        '<-- Mouse click Event -- >


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `Locker Registration`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader



        Dim locker_no As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim emp_no As String = ListView1.SelectedItems(0).SubItems(1).Text()
        Dim f_name As String = ListView1.SelectedItems(0).SubItems(2).Text()
        Dim m_name As String = ListView1.SelectedItems(0).SubItems(3).Text()
        Dim l_name As String = ListView1.SelectedItems(0).SubItems(4).Text()
        Dim dept As String = ListView1.SelectedItems(0).SubItems(5).Text()
        Dim Issued_by As String = ListView1.SelectedItems(0).SubItems(6).Text()

        '<-- Load event after -->

        TextBox1.Text = locker_no
        TextBox2.Text = f_name
        TextBox3.Text = m_name
        TextBox4.Text = l_name
        TextBox5.Text = dept
        TextBox6.Text = Issued_by
        ComboBox1.Text = emp_no

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        '<-- This is to disable the edit function if the form is loaded or data is present -->

        If ComboBox1.Text <> "" Then
            ComboBox1.Enabled = False

        Else
            ComboBox1.Enabled = True

        End If

        Me.TextBox6.Text = Admin_Panel.Label1.Text



        con.Close()






    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Locker_Registration_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim D As Date = Now()  ' this is date and time 
        Me.Label8.Text = D

        Me.TextBox6.Text = Admin_Panel.Label1.Text

        '<-- Listview when form loads -->


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `Locker Registration`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("locker_no").ToString())
            lv.SubItems.Add(rd("emp_no").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("Issued_by").ToString())


            ListView1.FullRowSelect = True
            

        End While

        Me.TextBox6.Text = Admin_Panel.Label1.Text

        con.Close()



        '< -- Load event for Combobox -->

        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address` FROM `employee record`", con)
        Dim table As New DataTable()

        '< -- Fill function 

        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "emp_no"
        ComboBox1.DisplayMember = "emp_no"

        '<-- Clear Function -->

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""

        '< -- End of function here -->

        Me.TextBox6.Text = Admin_Panel.Label1.Text

    End Sub

    Private Sub Locker_Registration_Form_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick

      


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        '< -- Auto Load after fill Reader -->

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
                TextBox5.Text = rd.Item("dept")

            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        '<-- Insert to Database -->

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")

        con.Open()
        Dim query As String
        query = "Update `Locker Registration` SET `locker_no`='" & TextBox1.Text & "',`emp_no`='" & ComboBox1.Text & "',`f_name`='" & TextBox2.Text & "',`m_name`='" & TextBox3.Text & "',`l_name`='" & TextBox4.Text & "',`dept`='" & TextBox5.Text & "',`Issued_by`='" & TextBox6.Text & "' where `locker_no`='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()
        MsgBox(" Locker Has Been Assigned. ")

        con.Close()


        '<-- for logging purposes 

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & TextBox7.Text & "','" & Label8.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()

        con.Close()

        '<-- Will Reload the Event in ComboBox -->

        '< -- Load event for Combobox -->

        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address` FROM `employee record`", con)
        Dim table As New DataTable()

        '< -- Fill function 

        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "emp_no"
        ComboBox1.DisplayMember = "emp_no"

        '<-- Clear Function -->

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""

        '< -- End of function here -->


        '<-- List View Reload Event -->


        con.Open()
        query = "SELECT * FROM `Locker Registration`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("locker_no").ToString())
            lv.SubItems.Add(rd("emp_no").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("Issued_by").ToString())


        End While

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        Me.TextBox6.Text = Admin_Panel.Label1.Text

        con.Close()


        '< -- Good Luck Sana Naunawaan Mo kasi nalito din Ako -->



    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        con.Open()
        Dim query As String
        query = "Update `Locker Registration` SET `locker_no`='" & TextBox1.Text & "',`emp_no`='" & TextBox9.Text & "',`f_name`='" & TextBox10.Text & "',`m_name`='" & TextBox11.Text & "',`l_name`='" & TextBox12.Text & "',`dept`='" & TextBox13.Text & "',`Issued_by`='" & TextBox14.Text & "' where `locker_no`='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()
        MsgBox(" Locker Has Been Unassigned. ")
        con.Close()


        '<-- for logging purposes 

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & TextBox8.Text & "','" & Label8.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()

        con.Close()

        '<-- Will Reload the Event in ComboBox -->

        '< -- Load event for Combobox -->

        Dim adapter As New MySqlDataAdapter("SELECT `emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address` FROM `employee record`", con)
        Dim table As New DataTable()

        '< -- Fill function 

        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "emp_no"
        ComboBox1.DisplayMember = "emp_no"

        '<-- Clear Function -->

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""

        '< -- End of function here -->


        '<-- List View Reload Event -->


        con.Open()
        query = "SELECT * FROM `Locker Registration`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("locker_no").ToString())
            lv.SubItems.Add(rd("emp_no").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("Issued_by").ToString())


        End While

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        Me.TextBox6.Text = Admin_Panel.Label1.Text

        con.Close()


        '< -- Good Luck Sana Naunawaan Mo kasi nalito din Ako -->


    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged

    End Sub
End Class