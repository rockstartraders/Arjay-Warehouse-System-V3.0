Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Image

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Consignors_Address_Book


    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String


    Private Sub Consignors_Address_Book_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' < -- Auto Generate info on form load event -->


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT `Con_ID`, `Con_name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Processed_by` FROM `Consignor Record`", con)
        Dim table As New DataTable()


        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.ValueMember = "Con_name"
        ComboBox1.DisplayMember = "Con_name"

        '< -- Clear fields on form load events -->

        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox6.Text = ""
        TextBox2.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""



    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If




    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        ' <-- This will fetch the information from the database -->

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT `Con_ID`, `Con_name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Processed_by` FROM `Consignor Record`", con)
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader


        Try

            con.Open()
            Dim query As String
            query = "select * from  `Consignor Record` where `Con_name` ='" + ComboBox1.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader
            While rd.Read

                TextBox1.Text = rd.Item("Con_ID")
                TextBox3.Text = rd.Item("Con_sign_up_date")
                TextBox4.Text = rd.Item("Con_landline_no")
                TextBox5.Text = rd.Item("Con_mobile_no")
                TextBox7.Text = rd.Item("Con_address")
                TextBox6.Text = rd.Item("Con_email")
                TextBox2.Text = rd.Item("Storage_location")
                TextBox8.Text = rd.Item("con_contact_person")
                TextBox9.Text = rd.Item("Processed_by")


            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        ' < -- END of Line -->

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class