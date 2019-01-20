Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Image

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Update_Consignor_Record

    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        '<-- Update Function --> 

        If TextBox7.Text = "" Then
            MsgBox("Sorry But You Need To Indicate The Changes Made Onto The Consignors Information And Please Make It Detailed.", 0 + 64)
            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        Else

            con.Open()
            query = "Update `Consignor Record` SET `Con_ID`='" & ComboBox2.Text & "',`Con_name`='" & ComboBox3.Text & "',`Con_address`='" & TextBox3.Text & "',`Con_landline_no`='" & TextBox4.Text & "',`Con_mobile_no`='" & TextBox5.Text & "',`Con_email`='" & TextBox6.Text & "',`Con_sign_up_date`='" & DateTimePicker1.Text & "',`Storage_location`='" & ComboBox1.Text & "', `con_contact_person`='" & TextBox8.Text & "',`Processed_by`='" & TextBox9.Text & "'where `Con_ID`='" & ComboBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader()

            rd.Close() ' < -- Reader close to avoid stack -->


            ' <-- For Logging of Record -->

            query = "INSERT INTO `Admin_Consignor Data Logs`(`modification_made`, `date_and_time`, `con_id`, `con_name`, `processed_by`, `notes`) values ('" & Label13.Text & "','" & Label14.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox9.Text & "','" & TextBox7.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()

            rd.Close() ' < -- Reader close to avoid stack -->

            query = "Update `Inventory` SET `Con_ID`='" & ComboBox2.Text & "',`Con_name`='" & ComboBox3.Text & "',`Con_address`='" & TextBox3.Text & "',`Con_landline_no`='" & TextBox4.Text & "',`Con_mobile_no`='" & TextBox5.Text & "',`Con_email`='" & TextBox6.Text & "',`Con_sign_up_date`='" & DateTimePicker1.Text & "',`Storage_location`='" & ComboBox1.Text & "', `con_contact_person`='" & TextBox8.Text & "'where `Con_ID`='" & ComboBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader()
            MsgBox(" Consignor Record has Been Modified.")
            con.Close()

            ComboBox2.Text = ""
            ComboBox3.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            ComboBox1.Text = ""
            TextBox8.Text = ""
            TextBox7.Text = ""

            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        End If




    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        ' <-- Exit --> 

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If





    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub
    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub
    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub
    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub Update_Consignor_Record_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' <-- Form Load Event --> 

        Dim D As Date = Now()  ' this is date and time 
        Me.Label14.Text = D

        '< -- Fill Event --> 

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT `Con_ID`, `Con_name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Processed_by` FROM `Consignor Record`", con)
        Dim table As New DataTable()

        adapter.Fill(table)
        ComboBox2.DataSource = table
        ComboBox2.ValueMember = "Con_ID"
        ComboBox2.DisplayMember = "Con_ID"

        ComboBox3.DataSource = table
        ComboBox3.ValueMember = "Con_name"
        ComboBox3.DisplayMember = "Con_name"

        ' < -- Clear Event -->

        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        TextBox8.Text = ""
        TextBox7.Text = ""

        ' < -- END for Clear Event -->

        ' < -- String Parsing --> 

        Me.TextBox9.Text = Admin_Panel.Label1.Text

        



    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        ' < -- Auto Fill Event ComboBox2 -->

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader

        Try

            con.Open()
            Dim query As String
            query = "SELECT * FROM `Consignor Record` WHERE `Con_ID` ='" + ComboBox2.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader


            While rd.Read
                DateTimePicker1.Text = rd.Item("Con_sign_up_date")
                ComboBox3.Text = rd.Item("Con_name")
                TextBox3.Text = rd.Item("Con_address")
                TextBox4.Text = rd.Item("Con_landline_no")
                TextBox5.Text = rd.Item("Con_mobile_no")
                TextBox6.Text = rd.Item("Con_email")
                ComboBox1.Text = rd.Item("Storage_location")
                TextBox8.Text = rd.Item("con_contact_person")


            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try





    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged


        ' < -- Auto Fill Event ComboBox3 -->

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader

        Try

            con.Open()
            Dim query As String
            query = "SELECT * FROM `Consignor Record` WHERE `Con_name` ='" + ComboBox3.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader


            While rd.Read
                DateTimePicker1.Text = rd.Item("Con_sign_up_date")
                ComboBox2.Text = rd.Item("Con_ID")
                TextBox3.Text = rd.Item("Con_address")
                TextBox4.Text = rd.Item("Con_landline_no")
                TextBox5.Text = rd.Item("Con_mobile_no")
                TextBox6.Text = rd.Item("Con_email")
                ComboBox1.Text = rd.Item("Storage_location")
                TextBox8.Text = rd.Item("con_contact_person")


            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub
End Class