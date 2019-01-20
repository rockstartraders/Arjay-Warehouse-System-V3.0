Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Image

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '






Public Class Employee_Registration_Form
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        'this should be present always
        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")

        con.Open()
        Dim query As String
        query = "Insert Into `employee record`(`emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address`) values ('" & TextBox1.Text & "','" & TextBox13.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox14.Text & "','" & ComboBox1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & ComboBox2.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()
        MsgBox(" New Employee Account has Been Created ")

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 
        con.Close()


        ' <-- Insert to Activity log -- >

        con.Open()
        query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & Label18.Text & "','" & Label19.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "','" & TextBox16.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()



        TextBox1.Text = ""
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

        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Employee_Registration_Form_Load(e, e) 'Load everything in your form load event again hahaha in tagalog ulit

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        con.Close()


        ' < -- END -->


    End Sub





    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Employee_Registration_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button1.Enabled = False  ' < -- Validation --> 

        Dim rn As New Random
        TextBox1.Text = (rn.Next(113344, 9998855) + 8)

        Dim D As Date = Now()  ' this is date and time 
        Me.Label19.Text = D

        Me.TextBox16.Text = Admin_Panel.Label1.Text

        TextBox13.Select()  ' < -- Selected Index --> 

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If






    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.Click



    End Sub

    Private Sub TextBox13_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.Enter


    End Sub

    Private Sub TextBox13_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.GotFocus



    End Sub

    Private Sub TextBox13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox13.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox2.Select()

        End If


        

    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged





    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox3.Select()

        End If

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown


        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox4.Select()

        End If

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox14.Select()

        End If


    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged


    End Sub

    Private Sub TextBox14_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox14.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            ComboBox1.Select()

        End If


    End Sub

    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged




    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        ' < -- focus Index --> 

        If ComboBox1.Text <> "" Then
            TextBox5.Select()

        End If


    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox6.Select()

        End If


    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged



    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox7.Select()

        End If


    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox8.Select()

        End If



    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged




    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            ComboBox2.Select()

        End If


    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged



    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox2.Text <> "" Then
            TextBox9.Select()
        End If


    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox9.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox10.Select()

        End If


    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged


    End Sub

    Private Sub TextBox10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox11.Select()

        End If


    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TextBox11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox11.KeyDown
        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox12.Select()

        End If


    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged


    End Sub

    Private Sub TextBox12_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox12.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            Button1.Select()

        End If

    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged


        ' < -- Button Validation --> 

        If TextBox12.Text <> "" Then
            Button1.Enabled = True

        Else
            Button1.Enabled = False

        End If

    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown


        If e.KeyCode = Keys.Enter Then

            Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

            'this should be present always
            Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")

            con.Open()
            Dim query As String
            query = "Insert Into `employee record`(`emp_no`, `hire_date`, `f_name`, `m_name`, `l_name`, `dob`, `gender`, `address`, `contact_no`, `ssn`, `tin`, `dept`, `emer_name`, `emer_contact`, `emer_rel`, `emer_address`) values ('" & TextBox1.Text & "','" & TextBox13.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox14.Text & "','" & ComboBox1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & ComboBox2.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()
            MsgBox(" New Employee Account has Been Created ")

            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 
            con.Close()


            ' <-- Insert to Activity log -- >

            con.Open()
            query = "INSERT INTO `Admin changes log`(`action_made`, `date_process`, `emp_no`, `f_name`, `m_name`, `l_name`, `dept`, `done_by`) values ('" & Label18.Text & "','" & Label19.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "','" & TextBox16.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()



            TextBox1.Text = ""
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


            Me.Controls.Clear() 'removes all the controls on the form
            InitializeComponent() 'load all the controls again
            Employee_Registration_Form_Load(e, e) 'Load everything in your form load event again hahaha in tagalog ulit

            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

            con.Close()


            ' < -- END -->

        End If



    End Sub

    Private Sub Button1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Button1.KeyPress

        Button1.Enabled = True


    End Sub

    Private Sub Button2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button2.KeyDown

        If e.KeyCode = Keys.Enter Then

            Dim ahem As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

            If ahem = DialogResult.Yes Then



                Me.Dispose()
                Me.Close()



            End If

        End If

    End Sub
End Class