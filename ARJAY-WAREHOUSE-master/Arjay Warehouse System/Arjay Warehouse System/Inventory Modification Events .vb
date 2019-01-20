Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Printing

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '


Public Class Inventory_Modification_Events
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Inventory_Modification_Events_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        ' < -- Load Event for List View --> 

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `Admin Inventory Modification`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("Correction_ID").ToString())
            lv.SubItems.Add(rd("time_and_date").ToString())
            lv.SubItems.Add(rd("Action_made").ToString())
            lv.SubItems.Add(rd("Processed_by").ToString())
            lv.SubItems.Add(rd("Admin_notes").ToString())
            lv.SubItems.Add(rd("Sys_log").ToString())

            '<-- Warning came here -->

            ListView1.FullRowSelect = True



        End While

        con.Close()

    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->


        '< -- Mouse Click Event --> 

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `Admin Inventory Modification`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        Dim Correction_ID As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim time_and_date As String = ListView1.SelectedItems(0).SubItems(1).Text()
        Dim Action_made As String = ListView1.SelectedItems(0).SubItems(2).Text()
        Dim Processed_by As String = ListView1.SelectedItems(0).SubItems(3).Text()
        Dim Admin_notes As String = ListView1.SelectedItems(0).SubItems(4).Text()
        Dim Sys_log As String = ListView1.SelectedItems(0).SubItems(5).Text()




        TextBox2.Text = Admin_notes
        TextBox4.Text = time_and_date
        TextBox3.Text = Correction_ID
        TextBox1.Text = Sys_log
        TextBox5.Text = Processed_by



        '<-- EOL for this Function -- > 

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 



        con.Close()





    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then


            Me.Dispose()
            Me.Close()



        End If

    End Sub
End Class