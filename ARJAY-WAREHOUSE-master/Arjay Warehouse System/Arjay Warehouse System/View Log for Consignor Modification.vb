Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO


' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '


Public Class View_Log_for_Consignor_Modification

    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub View_Log_for_Consignor_Modification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' < -- Load Event for List View --> 

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `Admin_Consignor Data Logs`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("modification_made").ToString())
            lv.SubItems.Add(rd("date_and_time").ToString())
            lv.SubItems.Add(rd("con_id").ToString())
            lv.SubItems.Add(rd("con_name").ToString())
            lv.SubItems.Add(rd("processed_by").ToString())
            lv.SubItems.Add(rd("notes").ToString())


            '<-- Warning came here -->

            ListView1.FullRowSelect = True
           



        End While



        con.Close()

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click

    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        '< -- Mouse Click Event --> 

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `Admin_Consignor Data Logs`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader




        Dim modification_made As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim date_and_time As String = ListView1.SelectedItems(0).SubItems(1).Text()
        Dim con_id As String = ListView1.SelectedItems(0).SubItems(2).Text()
        Dim con_name As String = ListView1.SelectedItems(0).SubItems(3).Text()
        Dim processed_by As String = ListView1.SelectedItems(0).SubItems(4).Text()
        Dim notes As String = ListView1.SelectedItems(0).SubItems(5).Text()
       
        TextBox6.Text = modification_made
        TextBox11.Text = date_and_time
        TextBox8.Text = con_id
        TextBox9.Text = con_name
        TextBox1.Text = processed_by
        TextBox7.Text = notes



        '<-- EOL for this Function -- > 


        Me.Cursor = Cursors.Default ' < -- Return cursor to default / added 1/13/2019 --> 




    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub View_Log_for_Consignor_Modification_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then




            Me.Dispose()
            Me.Close()

        End If


    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        ' <-- export to excel function -->

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ExcelApp As Object, ExcelBook As Object
            Dim ExcelSheet As Object
            Dim i As Integer
            Dim j As Integer
            'create object of excel
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            With ExcelSheet
                For i = 1 To Me.ListView1.Items.Count
                    .cells(i, 1) = Me.ListView1.Items(i - 1).Text
                    For j = 1 To ListView1.Columns.Count - 1
                        .cells(i, j + 1) = Me.ListView1.Items(i - 1).SubItems(j).Text
                    Next
                Next
            End With
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub
End Class