Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Image

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Delete_Consignor_Records
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Delete_Consignor_Records_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' <-- Form Load Event --> 

        Dim D As Date = Now()  ' this is date and time 
        Me.Label14.Text = D

        DateTimePicker1.Enabled = False


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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ' < -- Exit Function --> 

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If




    End Sub

    Private Sub ComboBox2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox2.DrawItem


      
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '<-- Delete Function --> 

        If TextBox7.Text = "" Then
            MsgBox("Sorry But You Need To Indicate The Reason For Terminating A Consignors Information And Please Make Sure to Add all The Details Required.", 0 + 64)

        Else

            con.Open()
            query = "DELETE FROM `Consignor Record` WHERE `Con_ID` ='" + ComboBox2.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader()

            rd.Close() ' < -- Reader close to avoid stack -->


            ' <-- For Logging of Record -->

            query = "INSERT INTO `Admin_Consignor Data Logs`(`modification_made`, `date_and_time`, `con_id`, `con_name`, `processed_by`, `notes`) values ('" & Label13.Text & "','" & Label14.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox9.Text & "','" & TextBox7.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()

            rd.Close() ' < -- Reader close to avoid stack -->

            query = "DELETE FROM `Inventory` WHERE `Con_ID` ='" + ComboBox2.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader()
            MsgBox(" Consignor Record has Been Terminated Completely From ARJAY's System.")
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


        End If





    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_StyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.StyleChanged

    End Sub
End Class