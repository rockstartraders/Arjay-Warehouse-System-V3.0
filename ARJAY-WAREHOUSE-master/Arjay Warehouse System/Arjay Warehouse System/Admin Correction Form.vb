Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO


' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '


Public Class Admin_Correction_Form
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Admin_Correction_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim D As Date = Now()  ' this is date and time 
        Me.Label13.Text = D

        Me.TextBox16.Text = Admin_Panel.Label1.Text
        Button4.Enabled = False

        If TextBox1.Text = "" Then
            Button1.Enabled = False

        Else
            Button1.Enabled = True
        End If

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `correction request`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("Incident_no").ToString())
            lv.SubItems.Add(rd("status").ToString())
            lv.SubItems.Add(rd("date_submitted").ToString())
            lv.SubItems.Add(rd("emp_no").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("correction_type").ToString())
            lv.SubItems.Add(rd("prob_des").ToString())


            '<-- Warning came here -->

            ListView1.FullRowSelect = True
            lv.UseItemStyleForSubItems = False


            If lv.SubItems(1).Text = "Open" Then
                lv.SubItems(0).BackColor = Color.Red  'later ito
                lv.SubItems(1).BackColor = Color.Red  'later ito
                lv.SubItems(2).BackColor = Color.Red  'later ito
                lv.SubItems(3).BackColor = Color.Red  'later ito
                lv.SubItems(4).BackColor = Color.Red  'later ito
                lv.SubItems(5).BackColor = Color.Red  'later ito
                lv.SubItems(6).BackColor = Color.Red  'later ito
                lv.SubItems(7).BackColor = Color.Red  'later ito
                lv.SubItems(8).BackColor = Color.Red  'later ito
                lv.SubItems(9).BackColor = Color.Red  'later ito


            End If

        End While

       

        con.Close()





    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `correction request`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader




        Dim Incident_no As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim status As String = ListView1.SelectedItems(0).SubItems(1).Text()
        Dim date_submitted As String = ListView1.SelectedItems(0).SubItems(2).Text()
        Dim emp_no As String = ListView1.SelectedItems(0).SubItems(3).Text()
        Dim f_name As String = ListView1.SelectedItems(0).SubItems(4).Text()
        Dim m_name As String = ListView1.SelectedItems(0).SubItems(5).Text()
        Dim l_name As String = ListView1.SelectedItems(0).SubItems(6).Text()
        Dim dept As String = ListView1.SelectedItems(0).SubItems(7).Text()
        Dim correction_type As String = ListView1.SelectedItems(0).SubItems(8).Text()
        Dim prob_des As String = ListView1.SelectedItems(0).SubItems(9).Text()


        TextBox1.Text = Incident_no
        TextBox2.Text = emp_no
        Label3.Text = date_submitted
        TextBox3.Text = f_name
        TextBox4.Text = m_name
        TextBox5.Text = l_name
        TextBox6.Text = dept
        ComboBox1.Text = status
        ComboBox2.Text = correction_type
        TextBox7.Text = prob_des


        '< -- Validation -- >

        If ComboBox1.Text = "Resolved" Then
            ComboBox1.Enabled = False
            Button1.Enabled = False
            Button4.Enabled = True

        Else
            ComboBox1.Enabled = True
            Button1.Enabled = True
            Button4.Enabled = False

        End If

        con.Close()


    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

       

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        Dim Incident_no As String
        Incident_no = TextBox1.Text
        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "UPDATE `correction request` SET `Incident_no`='" & TextBox1.Text & "',`date_submitted`='" & Label3.Text & "',`emp_no`='" & TextBox2.Text & "',`f_name`='" & TextBox3.Text & "',`m_name`='" & TextBox4.Text & "',`l_name`='" & TextBox5.Text & "',`dept`='" & TextBox6.Text & "',`status`='" & ComboBox1.Text & "',`correction_type`='" & ComboBox2.Text & "',`prob_des`='" & TextBox7.Text & "',`resolution`='" & TextBox8.Text & "',`resolved_date`='" & Label13.Text & "',`Processed By`='" & TextBox16.Text & "' WHERE `Incident_no`='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("Incident_no").ToString())
            lv.SubItems.Add(rd("status").ToString())
            lv.SubItems.Add(rd("date_submitted").ToString())
            lv.SubItems.Add(rd("emp_no").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("correction_type").ToString())
            lv.SubItems.Add(rd("prob_des").ToString())


            '<-- Warning came here -->

            ListView1.FullRowSelect = True
            lv.UseItemStyleForSubItems = False

            If lv.SubItems(1).Text = "Open" Then
                lv.SubItems(0).BackColor = Color.Red  'later ito
                lv.SubItems(1).BackColor = Color.Red  'later ito
                lv.SubItems(2).BackColor = Color.Red  'later ito
                lv.SubItems(3).BackColor = Color.Red  'later ito
                lv.SubItems(4).BackColor = Color.Red  'later ito
                lv.SubItems(5).BackColor = Color.Red  'later ito
                lv.SubItems(6).BackColor = Color.Red  'later ito
                lv.SubItems(7).BackColor = Color.Red  'later ito
                lv.SubItems(8).BackColor = Color.Red  'later ito
                lv.SubItems(9).BackColor = Color.Red  'later ito


            End If


        End While

        ' <-- Close reader and connection before opening it again to avoid stack -->

        con.Close()
        rd.Close()

        ' <-- For Logging --> 

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & TextBox10.Text & "','" & Label13.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox16.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()

        con.Close()


        ' <-- Validation na walang katapusan -->

        If ComboBox1.Text = "Open" Then
            MsgBox("Please Make Sure To Change The Status To Resolved Before Clicking The Update Button.")
            Button1.Enabled = False
        else

            MsgBox("Correction Request Has Been Resolved")
            Button1.Enabled = False

            '<< -- EOL for this validation --> 

        End If



        ' <<----------------- Clear Function ------------------>>
        TextBox1.Text = ""
        TextBox2.Text = ""
        Label3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

        con.Close()


        '----------------------- Update List View After ---------------------


        con.Open()
        query = "SELECT * FROM `correction request`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("Incident_no").ToString())
            lv.SubItems.Add(rd("status").ToString())
            lv.SubItems.Add(rd("date_submitted").ToString())
            lv.SubItems.Add(rd("emp_no").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("correction_type").ToString())
            lv.SubItems.Add(rd("prob_des").ToString())


            '<-- Warning came here -->

            ListView1.FullRowSelect = True
            lv.UseItemStyleForSubItems = False

            If lv.SubItems(1).Text = "Open" Then
                lv.SubItems(0).BackColor = Color.Red  'later ito
                lv.SubItems(1).BackColor = Color.Red  'later ito
                lv.SubItems(2).BackColor = Color.Red  'later ito
                lv.SubItems(3).BackColor = Color.Red  'later ito
                lv.SubItems(4).BackColor = Color.Red  'later ito
                lv.SubItems(5).BackColor = Color.Red  'later ito
                lv.SubItems(6).BackColor = Color.Red  'later ito
                lv.SubItems(7).BackColor = Color.Red  'later ito
                lv.SubItems(8).BackColor = Color.Red  'later ito
                lv.SubItems(9).BackColor = Color.Red  'later ito


            End If





        End While
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If

       


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

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




    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        ' For Logging --> 

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & TextBox9.Text & "','" & Label13.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox16.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()

        con.Close()

        ' <-- As usual validation ulit

        ComboBox1.Enabled = True
        ComboBox1.Text = "Open"  '<-- mababago content from Resolved to Open
        Button4.Enabled = False
        Button1.Enabled = True

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub
End Class