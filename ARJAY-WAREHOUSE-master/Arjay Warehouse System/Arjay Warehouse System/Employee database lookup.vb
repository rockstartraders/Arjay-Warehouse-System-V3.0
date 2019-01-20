Imports MySql.Data.MySqlClient

Public Class Employee_database
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Employee_database_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")

        Dim D As Date = Now()  ' this is date and time 
        Me.Label19.Text = D


        con.Open()
        query = "Select * from `employee record`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        'ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("emp_no").ToString())

            lv.SubItems.Add(rd("hire_date").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dob").ToString())
            lv.SubItems.Add(rd("gender").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contact_no").ToString())
            lv.SubItems.Add(rd("ssn").ToString())
            lv.SubItems.Add(rd("tin").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("emer_name").ToString())
            lv.SubItems.Add(rd("emer_contact").ToString())
            lv.SubItems.Add(rd("emer_rel").ToString())
            lv.SubItems.Add(rd("emer_address").ToString())

            ListView1.FullRowSelect = True

        End While
        con.Close()


        ' < -- Auto load Admin User ID 
        Me.TextBox16.Text = Admin_Panel.Label1.Text

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If




    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        TextBox1.Text = ""
        con.Open()
        query = "Select * from `employee record`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("emp_no").ToString())

            lv.SubItems.Add(rd("hire_date").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dob").ToString())
            lv.SubItems.Add(rd("gender").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contact_no").ToString())
            lv.SubItems.Add(rd("ssn").ToString())
            lv.SubItems.Add(rd("tin").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("emer_name").ToString())
            lv.SubItems.Add(rd("emer_contact").ToString())
            lv.SubItems.Add(rd("emer_rel").ToString())
            lv.SubItems.Add(rd("emer_address").ToString())


        End While
        con.Close()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        con.Open()
        query = "Select * from `employee record` Where `l_name`='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If TextBox1.Text = "" Then
            MsgBox(" Please Enter Employees Last Name", 0 + 64)

        Else

            ListView1.Items.Clear()

        End If

        ListView1.Items.Clear()


        While rd.Read

            Dim lv As ListViewItem = ListView1.Items.Add(rd("emp_no").ToString())

            lv.SubItems.Add(rd("hire_date").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dob").ToString())
            lv.SubItems.Add(rd("gender").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contact_no").ToString())
            lv.SubItems.Add(rd("ssn").ToString())
            lv.SubItems.Add(rd("tin").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("emer_name").ToString())
            lv.SubItems.Add(rd("emer_contact").ToString())
            lv.SubItems.Add(rd("emer_rel").ToString())
            lv.SubItems.Add(rd("emer_address").ToString())


        End While

        con.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        '<-- Export to Excel function 

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

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        ' <-- Function to load List View data to fields inside this form 


        Dim emp_no As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim hire_date As String = ListView1.SelectedItems(0).SubItems(1).Text()
        Dim f_name As String = ListView1.SelectedItems(0).SubItems(2).Text()
        Dim m_name As String = ListView1.SelectedItems(0).SubItems(3).Text()
        Dim l_name As String = ListView1.SelectedItems(0).SubItems(4).Text()
        Dim dob As String = ListView1.SelectedItems(0).SubItems(5).Text()
        Dim gender As String = ListView1.SelectedItems(0).SubItems(6).Text()

        Dim address As String = ListView1.SelectedItems(0).SubItems(7).Text()
        Dim contact_no As String = ListView1.SelectedItems(0).SubItems(8).Text()
        Dim ssn As String = ListView1.SelectedItems(0).SubItems(9).Text()

        Dim tin As String = ListView1.SelectedItems(0).SubItems(10).Text()
        Dim dept As String = ListView1.SelectedItems(0).SubItems(11).Text()
        Dim emer_name As String = ListView1.SelectedItems(0).SubItems(12).Text()

        Dim emer_contact As String = ListView1.SelectedItems(0).SubItems(13).Text()
        Dim emer_rel As String = ListView1.SelectedItems(0).SubItems(14).Text()
        Dim emer_address As String = ListView1.SelectedItems(0).SubItems(15).Text()



        ' < -- Declare Items per textBox and combo box


        TextBox15.Text = emp_no
        TextBox13.Text = hire_date
        TextBox2.Text = f_name
        TextBox3.Text = m_name
        TextBox4.Text = l_name
        TextBox14.Text = dob
        ComboBox1.Text = gender
        TextBox5.Text = address
        TextBox6.Text = contact_no
        TextBox7.Text = ssn
        TextBox8.Text = tin
        ComboBox2.Text = dept
        TextBox9.Text = emer_name
        TextBox10.Text = emer_contact
        TextBox11.Text = emer_rel
        TextBox12.Text = emer_address


        ' < -- End -- >

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 




    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        TextBox17.Text = "Update Employees Information"

        '<-- Update Function --> 

        con.Open()
        query = "Update  `employee record` set `emp_no`='" & TextBox15.Text & "',`hire_date`='" & TextBox13.Text & "',`f_name`='" & TextBox2.Text & "',`m_name`='" & TextBox3.Text & "',`l_name`='" & TextBox4.Text & "',`dob`='" & TextBox14.Text & "',`gender`='" & ComboBox1.Text & "',`address`='" & TextBox5.Text & "',`contact_no`='" & TextBox6.Text & "',`ssn`='" & TextBox7.Text & "',`tin`='" & TextBox8.Text & "',`dept`='" & ComboBox2.Text & "',`emer_name`='" & TextBox9.Text & "',`emer_contact`='" & TextBox10.Text & "',`emer_rel`='" & TextBox11.Text & "',`emer_address`='" & TextBox12.Text & "'  where `emp_no`='" & TextBox15.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()

        If TextBox15.Text = "" Then  ' if else for condition
            MsgBox("Please Choose a Profile to Modify", 0 + 64)

            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        Else

            MsgBox("Employee Profile Has Been Updated", 0 + 64)

            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        End If
        con.Close()

        '< -- Insert to activity log -->

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & TextBox17.Text & "','" & Label19.Text & "','" & TextBox15.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "','" & TextBox16.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()




        ' < -- Clear Fieldset 

        TextBox15.Text = ""
        TextBox13.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox14.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox2.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox17.Text = ""


        ' < -- Refresh ListView

        While rd.Read

            Dim lv As ListViewItem = ListView1.Items.Add(rd("emp_no").ToString())

            lv.SubItems.Add(rd("hire_date").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dob").ToString())
            lv.SubItems.Add(rd("gender").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contact_no").ToString())
            lv.SubItems.Add(rd("ssn").ToString())
            lv.SubItems.Add(rd("tin").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("emer_name").ToString())
            lv.SubItems.Add(rd("emer_contact").ToString())
            lv.SubItems.Add(rd("emer_rel").ToString())
            lv.SubItems.Add(rd("emer_address").ToString())


        End While

        con.Close()

        ' < -- Refresh ListView
        con.Open()
        query = "Select * from `employee record`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("emp_no").ToString())

            lv.SubItems.Add(rd("hire_date").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dob").ToString())
            lv.SubItems.Add(rd("gender").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contact_no").ToString())
            lv.SubItems.Add(rd("ssn").ToString())
            lv.SubItems.Add(rd("tin").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("emer_name").ToString())
            lv.SubItems.Add(rd("emer_contact").ToString())
            lv.SubItems.Add(rd("emer_rel").ToString())
            lv.SubItems.Add(rd("emer_address").ToString())


        End While
        con.Close()







    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        ' <-- This text that will show on the log --> 


        TextBox17.Text = "Deleted Employees Information"



        ' < -- Delete function -->

        con.Open()
        query = "Delete from `employee record` where `emp_no`='" & TextBox15.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        If TextBox15.Text = "" Then  ' if else for condition
            MsgBox("Please Choose a Profile to Delete.", 0 + 64)


            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


        Else
            MsgBox("Employee Profile Has Been Deleted", 0 + 64)

            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 
        End If

        con.Close()

        '< -- Insert to activity log -->

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & TextBox17.Text & "','" & Label19.Text & "','" & TextBox15.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "','" & TextBox16.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()


        ' < -- Clear Fieldset 

        TextBox15.Text = ""
        TextBox13.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox14.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox2.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox17.Text = ""

        ' < -- Refresh ListView

        While rd.Read

            Dim lv As ListViewItem = ListView1.Items.Add(rd("emp_no").ToString())

            lv.SubItems.Add(rd("hire_date").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dob").ToString())
            lv.SubItems.Add(rd("gender").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contact_no").ToString())
            lv.SubItems.Add(rd("ssn").ToString())
            lv.SubItems.Add(rd("tin").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("emer_name").ToString())
            lv.SubItems.Add(rd("emer_contact").ToString())
            lv.SubItems.Add(rd("emer_rel").ToString())
            lv.SubItems.Add(rd("emer_address").ToString())


        End While

        con.Close()

        ' < -- Refresh ListView
        con.Open()
        query = "Select * from `employee record`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("emp_no").ToString())

            lv.SubItems.Add(rd("hire_date").ToString())
            lv.SubItems.Add(rd("f_name").ToString())
            lv.SubItems.Add(rd("m_name").ToString())
            lv.SubItems.Add(rd("l_name").ToString())
            lv.SubItems.Add(rd("dob").ToString())
            lv.SubItems.Add(rd("gender").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contact_no").ToString())
            lv.SubItems.Add(rd("ssn").ToString())
            lv.SubItems.Add(rd("tin").ToString())
            lv.SubItems.Add(rd("dept").ToString())
            lv.SubItems.Add(rd("emer_name").ToString())
            lv.SubItems.Add(rd("emer_contact").ToString())
            lv.SubItems.Add(rd("emer_rel").ToString())
            lv.SubItems.Add(rd("emer_address").ToString())


        End While
        con.Close()


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        '< -- Clear All Field -- > 

        TextBox15.Text = ""
        TextBox13.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox14.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox2.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""



    End Sub

    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class