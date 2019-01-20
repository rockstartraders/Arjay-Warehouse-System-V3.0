Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Image

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Consignor_Registration_Form

    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Consignor_Registration_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        TextBox2.Select()
        Button1.Enabled = False


        Dim random As New Random
        Dim password As New System.Text.StringBuilder
        For i As Int32 = 0 To 3
            password.Append(Chr(random.Next(48, 57)))
        Next
        TextBox1.Text = "ARJ" + "-" + "001" + password.ToString


        ' <-- For Admin ID to be captured -->

        Me.TextBox9.Text = Admin_Panel.Label1.Text


    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        Dim areglo As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If areglo = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()



        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click




        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")

        con.Open()
        Dim query As String
        query = "INSERT INTO `Consignor Record`(`Con_ID`, `Con_name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Processed_by`) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()
        ' MsgBox(" New Employee Account has Been Created ")
        con.Close()

        con.Open()
        query = "INSERT INTO `Inventory`(`Con_ID`, `Con_Name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Prod_Camote`, `Prod_Chili`, `Prod_Coffee_Beans`, `Prod_Corn`, `Prod_Potatoes`, `Prod_Rice`, `Prod_Tobacco`, `Prod_Tomatoes`) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox8.Text & "','" & TextBox7.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & TextBox16.Text & "')"
        cmd = New MySqlCommand(query, con)
        cmd.CommandTimeout = 240  'for time out errors
        rd = cmd.ExecuteReader()
        MsgBox(" New Consignor Record has Been Created ")
        con.Close()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        'DateTimePicker1.Text = ""
        ComboBox1.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""

        'InitializeComponent() 'load all the controls again
        Consignor_Registration_Form_Load(e, e) 'Load everything in your form load event again





    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

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

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress




    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown


        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox5.Select()

        End If


    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown


        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            TextBox6.Select()

        End If


    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If



    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            ComboBox1.Select()

        End If


    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged


        If ComboBox1.Text <> "" Then
            TextBox8.Select()

        End If
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown

        If e.KeyCode = Keys.Enter Then
            Button1.Select()

        End If


    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True

        End If


    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown


        If e.KeyCode = Keys.Enter Then
            Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")

            con.Open()
            Dim query As String
            query = "INSERT INTO `Consignor Record`(`Con_ID`, `Con_name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Processed_by`) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()
            ' MsgBox(" New Employee Account has Been Created ")
            con.Close()

            con.Open()
            query = "INSERT INTO `Inventory`(`Con_ID`, `Con_Name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Prod_Camote`, `Prod_Chili`, `Prod_Coffee_Beans`, `Prod_Corn`, `Prod_Potatoes`, `Prod_Rice`, `Prod_Tobacco`, `Prod_Tomatoes`) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox8.Text & "','" & TextBox7.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & TextBox16.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()
            MsgBox(" New Consignor Record has Been Created ")
            con.Close()

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            'DateTimePicker1.Text = ""
            ComboBox1.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""

            'InitializeComponent() 'load all the controls again
            Consignor_Registration_Form_Load(e, e) 'Load everything in your form load event again



        End If


    End Sub

    Private Sub Button2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button2.KeyDown

        ' < -- Enter Index --> 

        If e.KeyCode = Keys.Enter Then
            Dim areglo As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

            If areglo = DialogResult.Yes Then



                Me.Dispose()
                Me.Close()



            End If


        End If


    End Sub
End Class