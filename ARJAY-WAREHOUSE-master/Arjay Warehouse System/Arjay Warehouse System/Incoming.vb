Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Printing

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '



Public Class Incoming
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Incoming_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

       

        ' < -- Default Load message --> 

        TextBox31.Text = " Waiting for Commit "
        TextBox31.Text = " Waiting for Commit "
        TextBox30.Text = " Waiting for Commit "
        TextBox29.Text = " Waiting for Commit "
        TextBox28.Text = " Waiting for Commit "
        TextBox27.Text = " Waiting for Commit "
        TextBox26.Text = " Waiting for Commit "
        TextBox25.Text = " Waiting for Commit "
        TextBox24.Text = " Waiting for Commit "

        ' <-- End na ng kalokohan -->


        Dim random As New Random
        Dim password As New System.Text.StringBuilder
        For i As Int32 = 0 To 3
            password.Append(Chr(random.Next(48, 57)))
        Next
        TextBox3.Text = "REC" + "-" + "ARJ" + "-" + "0011" + password.ToString

        Dim D As Date = Now()  ' this is date and time 
        Me.Label23.Text = D

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False


        '< -- Fill Event --> 


        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim adapter As New MySqlDataAdapter("SELECT `Con_ID`, `Con_Name`, `Con_address`, `Con_landline_no`, `Con_mobile_no`, `Con_email`, `Con_sign_up_date`, `Storage_location`, `con_contact_person`, `Prod_Camote`, `Prod_Chili`, `Prod_Coffee_Beans`, `Prod_Corn`, `Prod_Potatoes`, `Prod_Rice`, `Prod_Tobacco`, `Prod_Tomatoes` FROM `Inventory`", con)
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
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox2.Text = ""

        ' < -- Auto Clear Product -->

        TextBox7.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""

        ' < -- END for Clear Event -->



        ' String Parsing -->

        Me.TextBox8.Text = Receiving_Panel.Label1.Text
        Me.TextBox32.Text = Receiving_Panel.Label3.Text
        Me.TextBox33.Text = Receiving_Panel.Label4.Text

        '<-- Resibo -->

        TextBox1.AppendText("      #########   ARJAY TRADING    #########     " + vbNewLine)
        TextBox1.AppendText("Welcome To Our Warehousing Solution     " + vbNewLine)
        TextBox1.AppendText("ARJAY TRADING SOLUTIONS, ISABELA PHILIPPINES    " + vbNewLine)
        TextBox1.AppendText("TIN REG. NO." + vbTab + "___________________________________" + vbNewLine)
        TextBox1.AppendText("BUSINESS PERMIT NO." + vbTab + "_____________________________" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Date And Time : " + vbTab + Label23.Text + vbNewLine)
        TextBox1.AppendText("INVOICE NO. : " + vbTab + TextBox3.Text + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Transaction Type : " + vbTab + Label34.Text + vbNewLine)
        TextBox1.AppendText("==================================================================" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Processed By:" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("User ID:" + vbTab + TextBox8.Text + vbTab + "Employees First Name :" + vbTab + TextBox32.Text + vbTab + "Employees Last Name:" + vbTab + TextBox33.Text + vbNewLine)
        TextBox1.AppendText("==================================================================" + vbNewLine)
        ' < end of line --> 





    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

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
            query = "SELECT * FROM `Inventory` WHERE `Con_ID` ='" + ComboBox2.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader

            While rd.Read
                ComboBox3.Text = rd.Item("Con_name")
                TextBox6.Text = rd.Item("Con_email")
                TextBox4.Text = rd.Item("Con_landline_no")
                TextBox5.Text = rd.Item("Con_mobile_no")
                TextBox2.Text = rd.Item("Storage_location")

                '<-- for Product fill  --> 

                TextBox7.Text = rd.Item("Prod_Camote")
                TextBox9.Text = rd.Item("Prod_Chili")
                TextBox10.Text = rd.Item("Prod_Coffee_Beans")
                TextBox11.Text = rd.Item("Prod_Corn")
                TextBox12.Text = rd.Item("Prod_Potatoes")
                TextBox13.Text = rd.Item("Prod_Rice")
                TextBox14.Text = rd.Item("Prod_Tobacco")
                TextBox15.Text = rd.Item("Prod_Tomatoes")

                '< -- End of Autofill -->


            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try





    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged



        ' < -- Auto Fill Event ComboBox2 -->

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        Dim table As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter
        Dim rd As MySqlDataReader

        Try

            con.Open()
            Dim query As String
            query = "SELECT * FROM `Inventory` WHERE `Con_name`='" + ComboBox3.Text + "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader


            While rd.Read
                ComboBox2.Text = rd.Item("Con_ID")
                TextBox6.Text = rd.Item("Con_email")
                TextBox4.Text = rd.Item("Con_landline_no")
                TextBox5.Text = rd.Item("Con_mobile_no")
                TextBox2.Text = rd.Item("Storage_location")

                '<-- for Product fill  --> 

                TextBox7.Text = rd.Item("Prod_Camote")
                TextBox9.Text = rd.Item("Prod_Chili")
                TextBox10.Text = rd.Item("Prod_Coffee_Beans")
                TextBox11.Text = rd.Item("Prod_Corn")
                TextBox12.Text = rd.Item("Prod_Potatoes")
                TextBox13.Text = rd.Item("Prod_Rice")
                TextBox14.Text = rd.Item("Prod_Tobacco")
                TextBox15.Text = rd.Item("Prod_Tomatoes")

                '< -- End of Autofill -->

            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub TextBox32_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label31_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click

    End Sub

    Private Sub Label32_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label32.Click

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub TextBox31_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox31.TextChanged


    End Sub

    Private Sub TextBox23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox23.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox23_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox23.MouseClick

    End Sub

    Private Sub TextBox23_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox23.TextChanged



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


       
        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        '< -- Add Function / Commit Button -->

        TextBox31.Text = Val(TextBox7.Text) + Val(TextBox23.Text)
        TextBox30.Text = Val(TextBox9.Text) + Val(TextBox22.Text)
        TextBox29.Text = Val(TextBox10.Text) + Val(TextBox21.Text)
        TextBox28.Text = Val(TextBox11.Text) + Val(TextBox20.Text)
        TextBox27.Text = Val(TextBox12.Text) + Val(TextBox19.Text)
        TextBox26.Text = Val(TextBox13.Text) + Val(TextBox18.Text)
        TextBox25.Text = Val(TextBox14.Text) + Val(TextBox17.Text)
        TextBox24.Text = Val(TextBox15.Text) + Val(TextBox16.Text)


        ' < -- Resibo Ulit --> 

       
        TextBox1.AppendText("Consignor Information" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Consignor ID: " + vbTab + ComboBox2.Text + vbTab + " Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("==================================================================" + vbNewLine)
        TextBox1.AppendText("Product Information" + vbNewLine)
        TextBox1.AppendText("Current Stock Prior to Adding Stocks" + vbNewLine)
        TextBox1.AppendText("Camote " + vbTab + TextBox7.Text + vbTab + Label2.Text + vbNewLine)
        TextBox1.AppendText("Red Chili " + vbTab + TextBox9.Text + vbTab + Label4.Text + vbNewLine)
        TextBox1.AppendText("Coffee Beans " + vbTab + TextBox10.Text + vbTab + Label9.Text + vbNewLine)
        TextBox1.AppendText("Corn " + vbTab + vbTab + TextBox11.Text + vbTab + Label24.Text + vbNewLine)
        TextBox1.AppendText("Potatoes " + vbTab + TextBox12.Text + vbTab + Label25.Text + vbNewLine)
        TextBox1.AppendText("Rice " + vbTab + vbTab + TextBox13.Text + vbTab + Label26.Text + vbNewLine)
        TextBox1.AppendText("Tobacco " + vbTab + TextBox14.Text + vbTab + Label27.Text + vbNewLine)
        TextBox1.AppendText("Tomatoes " + vbTab + TextBox15.Text + vbTab + Label28.Text + vbNewLine)
        TextBox1.AppendText("==================================================================" + vbNewLine)
        TextBox1.AppendText("Stock Received" + vbNewLine)
        TextBox1.AppendText("Camote " + vbTab + TextBox23.Text + vbTab + Label2.Text + vbNewLine)
        TextBox1.AppendText("Red Chili " + vbTab + TextBox22.Text + vbTab + Label4.Text + vbNewLine)
        TextBox1.AppendText("Coffee Beans " + vbTab + TextBox21.Text + vbTab + Label9.Text + vbNewLine)
        TextBox1.AppendText("Corn " + vbTab + vbTab + TextBox20.Text + vbTab + Label24.Text + vbNewLine)
        TextBox1.AppendText("Potatoes " + vbTab + TextBox19.Text + vbTab + Label25.Text + vbNewLine)
        TextBox1.AppendText("Rice " + vbTab + vbTab + TextBox18.Text + vbTab + Label26.Text + vbNewLine)
        TextBox1.AppendText("Tobacco " + vbTab + TextBox17.Text + vbTab + Label27.Text + vbNewLine)
        TextBox1.AppendText("Tomatoes " + vbTab + TextBox16.Text + vbTab + Label28.Text + vbNewLine)
        TextBox1.AppendText("==================================================================" + vbNewLine)
        TextBox1.AppendText("Total After Commit" + vbNewLine)
        TextBox1.AppendText("Camote " + vbTab + TextBox31.Text + vbTab + Label2.Text + vbNewLine)
        TextBox1.AppendText("Red Chili " + vbTab + TextBox30.Text + vbTab + Label4.Text + vbNewLine)
        TextBox1.AppendText("Coffee Beans " + vbTab + TextBox29.Text + vbTab + Label9.Text + vbNewLine)
        TextBox1.AppendText("Corn " + vbTab + vbTab + TextBox28.Text + vbTab + Label24.Text + vbNewLine)
        TextBox1.AppendText("Potatoes " + vbTab + TextBox27.Text + vbTab + Label25.Text + vbNewLine)
        TextBox1.AppendText("Rice " + vbTab + vbTab + TextBox26.Text + vbTab + Label26.Text + vbNewLine)
        TextBox1.AppendText("Tobacco " + vbTab + TextBox25.Text + vbTab + Label27.Text + vbNewLine)
        TextBox1.AppendText("Tomatoes " + vbTab + TextBox24.Text + vbTab + Label28.Text + vbNewLine)
        TextBox1.AppendText("==================================================================" + vbNewLine)
        TextBox1.AppendText("            #########   THANK YOU    #########     " + vbNewLine)
        TextBox1.AppendText("           For Trusting ARJAY TRADING SOLUTIONS     " + vbNewLine)
        TextBox1.AppendText("==================================================================" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("RELEASED and INSPECTED BY: ________________________________" + vbTab + vbNewLine)
        TextBox1.AppendText("Signature Over Printed Name" + vbNewLine)

        ' < -- End ng Resibo --> 


        Button3.Enabled = True


        ' < -- Another Condition --> 
        TextBox23.Enabled = False
        TextBox22.Enabled = False
        TextBox21.Enabled = False
        TextBox20.Enabled = False
        TextBox19.Enabled = False
        TextBox18.Enabled = False
        TextBox17.Enabled = False
        TextBox16.Enabled = False
        Button1.Enabled = False

        ' < -- End of Condition --> 


        Me.Cursor = Cursors.Default ' < -- Return cursor to default / added 1 / 13 / 2019--> 



    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub TextBox24_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox24.TextChanged

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub TextBox30_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox30.TextChanged

    End Sub

    Private Sub TextBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox22.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox22.TextChanged

    End Sub

    Private Sub TextBox21_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox21.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox21_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox21.TextChanged

    End Sub

    Private Sub TextBox20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox20.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged



    End Sub

    Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged

    End Sub

    Private Sub TextBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged

    End Sub

    Private Sub TextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox17.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged



    End Sub

    Private Sub TextBox16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox16.KeyPress


        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        '< -- Validation -- > 

        If TextBox2.Text = "" Then
            Button1.Enabled = False
            Button2.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click




        ' < -- Reset po ito --> 

        Dim kamotengfrog As DialogResult = MsgBox("Are You Sure You Want to Do A Reset? All Changes Will Be Revert When That Happened.", 4 + 32, )
        If kamotengfrog = DialogResult.Yes Then

            Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

            Me.Controls.Clear() 'removes all the controls on the form
            InitializeComponent() 'load all the controls again
            Incoming_Load(e, e) 'Load everything in your form load event again hahaha in tagalog ulit


            Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

        End If



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If a = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()

        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Save this Changes? This Cannot be Undone, Please Check It Thoroughly Prior To Saving.", 4 + 32)

        If a = DialogResult.Yes Then
            ' <-- Submit Function --> 
            Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
            Dim cmd As MySqlCommand
            Dim rd As MySqlDataReader
            Dim query As String


            ' <-- Print Function --> 
            PrintDocument1.Print()


            con.Open()
            query = "UPDATE `Inventory` SET `Con_ID`='" & ComboBox2.Text & "',`Prod_Camote`='" & TextBox31.Text & "',`Prod_Chili`='" & TextBox30.Text & "',`Prod_Coffee_Beans`='" & TextBox29.Text & "',`Prod_Corn`='" & TextBox28.Text & "',`Prod_Potatoes`='" & TextBox27.Text & "',`Prod_Rice`='" & TextBox26.Text & "',`Prod_Tobacco`='" & TextBox25.Text & "', `Prod_Tomatoes`='" & TextBox24.Text & "' where `Con_ID`='" & ComboBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader()

            rd.Close() ' < -- Reader close to avoid stack -->
            con.Close()


            con.Open()
            query = "INSERT INTO `Invoice_copy`(`Invoice_no`, `date_and_time`, `transaction`, `invoice_main`) Values ('" & TextBox3.Text & "','" & Label23.Text & "','" & Label34.Text & "','" & TextBox1.Text & "')"
            cmd = New MySqlCommand(query, con)
            cmd.CommandTimeout = 240  'for time out errors
            rd = cmd.ExecuteReader()
            MsgBox("Product Has Been Received from Consignor." + "  " + ComboBox2.Text + "   " + "Thank You.")

            Me.Cursor = Cursors.Default ' < -- Return cursor to default -->  

            Dim bimbi As DialogResult = MsgBox("Do You Want to Do another Transaction ?", 4 + 32)
            If bimbi = DialogResult.Yes Then

                '< -- Reboot Form --> 

                Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

                Me.Controls.Clear() 'removes all the controls on the form

                InitializeComponent() 'load all the controls again
                Incoming_Load(e, e) 'Load everything in your form load event again hahaha in tagalog ulit

                Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 
                con.Close()

            Else
                Me.Dispose()
                Me.Close()

            End If

        End If






    End Sub

    Private Sub TextBox32_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox32.TextChanged

    End Sub

    Private Sub TextBox33_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox33.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        '< -- Print Preview --> 

        PrintPreviewDialog1.ShowDialog()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        

        ' < -- Format --> 


        Dim font As New Font("Arial", 8, FontStyle.Regular)
        e.Graphics.DrawString(TextBox1.Text, TextBox1.Font, Brushes.Black, 100, 100)



    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load




    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox3_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class