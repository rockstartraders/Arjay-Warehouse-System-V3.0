Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '




Public Class Inventory_Modification

    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Inventory_Modification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' < -- Load Event --> 
        Dim random As New Random
        Dim password As New System.Text.StringBuilder
        For i As Int32 = 0 To 3
            password.Append(Chr(random.Next(48, 57)))
        Next
        TextBox3.Text = "INV" + "-" + "ARJ" + "-" + "00115" + password.ToString

        Dim D As Date = Now()  ' this is date and time 
        Me.Label2.Text = D


        ' < -- Disable on first load event --> 

        TextBox16.ReadOnly = True
        TextBox17.ReadOnly = True
        TextBox18.ReadOnly = True
        TextBox19.ReadOnly = True
        TextBox20.ReadOnly = True
        TextBox21.ReadOnly = True
        TextBox22.ReadOnly = True
        TextBox23.ReadOnly = True

        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button3.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button8.Enabled = False
        Button7.Enabled = False
        Button10.Enabled = False
        Button9.Enabled = False
        Button12.Enabled = False
        Button11.Enabled = False
        Button14.Enabled = False
        Button13.Enabled = False
        Button16.Enabled = False
        Button15.Enabled = False


        ' < --End of this so called kalokohan --> 

        ' < --Start of Another Kalokohan  --> 

        Button2.Enabled = False
        Button3.Enabled = False
        Button5.Enabled = False
        Button7.Enabled = False
        Button9.Enabled = False
        Button11.Enabled = False
        Button13.Enabled = False
        Button15.Enabled = False

        Button1.Enabled = False
        Button4.Enabled = False
        Button6.Enabled = False
        Button8.Enabled = False
        Button10.Enabled = False
        Button12.Enabled = False
        Button14.Enabled = False
        Button16.Enabled = False


        ' < --End of this so called kalokohan --> 




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

        ' <-- For Modif part --> 

        TextBox23.Text = ""
        TextBox22.Text = ""
        TextBox21.Text = ""
        TextBox20.Text = ""
        TextBox19.Text = ""
        TextBox18.Text = ""
        TextBox17.Text = ""
        TextBox16.Text = ""

        ' < -- END for Clear Event -->

        ' < -- String Parsing --> 

        Me.TextBox8.Text = Admin_Panel.Label1.Text


        ' < -- Append Valuer --> 

        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("##### System Generated Memo #####" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("New Session has been Created by:" + vbTab + TextBox8.Text + vbNewLine)
        TextBox1.AppendText("Time of Access:  " + vbTab + Label2.Text + vbNewLine)
        TextBox1.AppendText("System Generated Correction ID for this Session is:" + vbTab + TextBox3.Text + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)








       

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub ComboBox2_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDownClosed


    End Sub

    Private Sub ComboBox2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox2.MouseClick


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

                ' < -- for modif --> 

                TextBox23.Text = rd.Item("Prod_Camote")
                TextBox22.Text = rd.Item("Prod_Chili")
                TextBox21.Text = rd.Item("Prod_Coffee_Beans")
                TextBox20.Text = rd.Item("Prod_Corn")
                TextBox19.Text = rd.Item("Prod_Potatoes")
                TextBox18.Text = rd.Item("Prod_Rice")
                TextBox17.Text = rd.Item("Prod_Tobacco")
                TextBox16.Text = rd.Item("Prod_Tomatoes")


                '< -- End of Autofill -->

                ' < -- Enable Event dated 1 / 6 / 2019 Happy New Year--> 


                Button1.Enabled = True
                Button4.Enabled = True
                Button6.Enabled = True
                Button8.Enabled = True
                Button10.Enabled = True
                Button12.Enabled = True
                Button14.Enabled = True
                Button16.Enabled = True

                ' < -- End of Enable Event --> 

                ' < -- Since It's a Parsing game better to make it transparent -- > 


                TextBox7.ReadOnly = True
                TextBox7.ForeColor = Color.Green
                TextBox7.BackColor = TextBox7.BackColor


                TextBox9.ReadOnly = True
                TextBox9.ForeColor = Color.Green
                TextBox9.BackColor = TextBox9.BackColor

                TextBox10.ReadOnly = True
                TextBox10.ForeColor = Color.Green
                TextBox10.BackColor = TextBox10.BackColor

                TextBox11.ReadOnly = True
                TextBox11.ForeColor = Color.Green
                TextBox11.BackColor = TextBox11.BackColor

                TextBox12.ReadOnly = True
                TextBox12.ForeColor = Color.Green
                TextBox12.BackColor = TextBox12.BackColor

                TextBox13.ReadOnly = True
                TextBox13.ForeColor = Color.Green
                TextBox13.BackColor = TextBox13.BackColor

                TextBox14.ReadOnly = True
                TextBox14.ForeColor = Color.Green
                TextBox14.BackColor = TextBox14.BackColor

                TextBox15.ReadOnly = True
                TextBox15.ForeColor = Color.Green
                TextBox15.BackColor = TextBox15.BackColor

                ' < -- Since It's a Parsing game better to make it transparent -- > 

                TextBox23.ReadOnly = True
                TextBox23.ForeColor = Color.Transparent
                TextBox23.BackColor = TextBox23.BackColor


                TextBox22.ReadOnly = True
                TextBox22.ForeColor = Color.Transparent
                TextBox22.BackColor = TextBox22.BackColor

                TextBox21.ReadOnly = True
                TextBox21.ForeColor = Color.Transparent
                TextBox21.BackColor = TextBox21.BackColor

                TextBox20.ReadOnly = True
                TextBox20.ForeColor = Color.Transparent
                TextBox20.BackColor = TextBox20.BackColor

                TextBox19.ReadOnly = True
                TextBox19.ForeColor = Color.Transparent
                TextBox19.BackColor = TextBox19.BackColor

                TextBox18.ReadOnly = True
                TextBox18.ForeColor = Color.Transparent
                TextBox18.BackColor = TextBox18.BackColor

                TextBox17.ReadOnly = True
                TextBox17.ForeColor = Color.Transparent
                TextBox17.BackColor = TextBox17.BackColor

                TextBox16.ReadOnly = True
                TextBox16.ForeColor = Color.Transparent
                TextBox16.BackColor = TextBox16.BackColor

                ' < -- End of madness for transparent shit -->


                

            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

       




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

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged



  
    End Sub

    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label29.Click

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub TextBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox22.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox22.TextChanged

    End Sub

    Private Sub TextBox23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox23.Click


    End Sub

    Private Sub TextBox23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox23.KeyPress

        ' < -- Key Press Event For digit and not String -->

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub

    Private Sub TextBox23_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox23.TextChanged


      

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button2.Enabled = False

        Else
            Button2.Enabled = True

            ' <-- Append Function --> 

            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Camote " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox7.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 


            ' < -- Button Function -- > 

            Button2.Enabled = True
            Button1.Enabled = False
            TextBox23.ReadOnly = False
            TextBox23.ForeColor = Color.Red
            TextBox23.Text = ""
            TextBox23.Select()


            ' <-- Disable function --> 

            ' Button1.Enabled = False
            ' Button2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button8.Enabled = False
            Button7.Enabled = False
            Button10.Enabled = False
            Button9.Enabled = False
            Button12.Enabled = False
            Button11.Enabled = False
            Button14.Enabled = False
            Button13.Enabled = False
            Button16.Enabled = False
            Button15.Enabled = False

            ' < -- EOL -- > 

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button3.Enabled = False

        Else
            Button3.Enabled = True



            ' <-- Append Function --> 

            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Red Chili " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox9.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 





            ' < -- Button Function -- > 

            Button3.Enabled = True
            Button4.Enabled = False
            TextBox22.ReadOnly = False
            TextBox22.ForeColor = Color.Red
            TextBox22.Text = ""
            TextBox22.Select()

            ' <-- Disable function --> 

            Button1.Enabled = False
            Button2.Enabled = False
            'Button4.Enabled = False
            'Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button8.Enabled = False
            Button7.Enabled = False
            Button10.Enabled = False
            Button9.Enabled = False
            Button12.Enabled = False
            Button11.Enabled = False
            Button14.Enabled = False
            Button13.Enabled = False
            Button16.Enabled = False
            Button15.Enabled = False

            ' < -- EOL -- > 

        End If


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click


        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button5.Enabled = False

        Else
            Button5.Enabled = True

            ' <-- Append Function --> 

            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Coffee Beans " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox10.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 



            ' < -- Button Function -- > 

            Button5.Enabled = True
            Button6.Enabled = False
            TextBox21.ReadOnly = False
            TextBox21.ForeColor = Color.Red
            TextBox21.Text = ""
            TextBox21.Select()

            ' <-- Disable function --> 

            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            'Button5.Enabled = False
            'Button6.Enabled = False
            Button8.Enabled = False
            Button7.Enabled = False
            Button10.Enabled = False
            Button9.Enabled = False
            Button12.Enabled = False
            Button11.Enabled = False
            Button14.Enabled = False
            Button13.Enabled = False
            Button16.Enabled = False
            Button15.Enabled = False

            ' < -- EOL -- > 
        End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button7.Enabled = False

        Else
            Button7.Enabled = True



            ' <-- Append Function --> 

            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Corn " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox11.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 


            ' < -- Button Function -- > 

            Button7.Enabled = True
            Button8.Enabled = False
            TextBox20.ReadOnly = False
            TextBox20.ForeColor = Color.Red
            TextBox20.Text = ""
            TextBox20.Select()

            ' <-- Disable function --> 

            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            ' Button8.Enabled = False
            ' Button7.Enabled = False
            Button10.Enabled = False
            Button9.Enabled = False
            Button12.Enabled = False
            Button11.Enabled = False
            Button14.Enabled = False
            Button13.Enabled = False
            Button16.Enabled = False
            Button15.Enabled = False

            ' < -- EOL -- > 

        End If


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click


        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button9.Enabled = False

        Else
            Button9.Enabled = True


            ' <-- Append Function --> 

            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Potatoes " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox12.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 


            ' < -- Button Function -- > 

            Button9.Enabled = True
            Button10.Enabled = False
            TextBox19.ReadOnly = False
            TextBox19.ForeColor = Color.Red
            TextBox19.Text = ""
            TextBox19.Select()

            ' <-- Disable function --> 

            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button8.Enabled = False
            Button7.Enabled = False
            ' Button10.Enabled = False
            ' Button9.Enabled = False
            Button12.Enabled = False
            Button11.Enabled = False
            Button14.Enabled = False
            Button13.Enabled = False
            Button16.Enabled = False
            Button15.Enabled = False

            ' < -- EOL -- > 

        End If

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click


        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button11.Enabled = False

        Else
            Button11.Enabled = True



            ' <-- Append Function --> 
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Rice " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox13.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 


            ' < -- Button Function -- > 

            Button11.Enabled = True
            Button12.Enabled = False
            TextBox18.ReadOnly = False
            TextBox18.ForeColor = Color.Red
            TextBox18.Text = ""
            TextBox18.Select()

            ' <-- Disable function --> 

            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button8.Enabled = False
            Button7.Enabled = False
            Button10.Enabled = False
            Button9.Enabled = False
            'Button12.Enabled = False
            'Button11.Enabled = False
            Button14.Enabled = False
            Button13.Enabled = False
            Button16.Enabled = False
            Button15.Enabled = False

            ' < -- EOL -- > 

        End If

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click


        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button13.Enabled = False

        Else
            Button13.Enabled = True



            ' <-- Append Function --> 
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Tobacco " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox14.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 


            ' < -- Button Function -- > 

            Button13.Enabled = True
            Button14.Enabled = False
            TextBox17.ReadOnly = False
            TextBox17.ForeColor = Color.Red
            TextBox17.Text = ""
            TextBox17.Select()

            ' <-- Disable function --> 

            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button8.Enabled = False
            Button7.Enabled = False
            Button10.Enabled = False
            Button9.Enabled = False
            Button12.Enabled = False
            Button11.Enabled = False
            'Button14.Enabled = False
            'Button13.Enabled = False
            Button16.Enabled = False
            Button15.Enabled = False

            ' < -- EOL -- > 

        End If


    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click


        ' < -- Condition -->

        If ComboBox3.Text = "" Then
            MsgBox("Please Choose A Consignor Record From The Dropdown List.", 0 + 64)
            Button15.Enabled = False

        Else
            Button15.Enabled = True

            ' <-- Append Function --> 

            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Click the Modify button for Product named Tomatoes " + vbNewLine)
            TextBox1.AppendText("Current Value for this Product is:" + vbTab + TextBox15.Text + vbNewLine)
            TextBox1.AppendText("This Changes will affect Consignor ID: " + vbTab + ComboBox2.Text + vbNewLine)
            TextBox1.AppendText("Consignor Name is: " + vbTab + ComboBox3.Text + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

            ' <-- End Append Function --> 


            ' < -- Button Function -- > 

            Button15.Enabled = True
            Button16.Enabled = False
            TextBox16.ReadOnly = False
            TextBox16.ForeColor = Color.Red
            TextBox16.Text = ""
            TextBox16.Select()

            ' <-- Disable function --> 

            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button8.Enabled = False
            Button7.Enabled = False
            Button10.Enabled = False
            Button9.Enabled = False
            Button12.Enabled = False
            Button11.Enabled = False
            Button14.Enabled = False
            Button13.Enabled = False
            'Button16.Enabled = False
            'Button15.Enabled = False

            ' < -- EOL -- > 

        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        ' < -- Start of Append Function -->
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox23.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Camote" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)

        ' < -- End of Append Function --> 

        

        ' <-- Condition --> 

        If TextBox23.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Camote" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else


            ' <-- Disable function --> 

            Button2.Enabled = False
            TextBox23.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click




        ' < -- Start of Append Function --> 
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name : " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox22.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Red Chili" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)

        ' < -- End of Append Function --> 



        If TextBox22.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Red Chili" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else

            ' <-- Disable function --> 

            Button3.Enabled = False
            Button2.Enabled = False
            TextBox22.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 

        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click


        ' < -- Start of Append Function --> 
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox21.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Coffee Beans" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)

        ' < -- End of Append Function --> 


        ' <-- Condition --> 

        If TextBox21.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Coffee Beans" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else


            ' <-- Disable function --> 

            Button5.Enabled = False
            Button3.Enabled = False
            Button2.Enabled = False

            TextBox21.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 

        End If


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click


        ' < -- Start of Append Function --> 
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox20.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Corn" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)

        ' < -- End of Append Function --> 



        ' <-- Condition --> 

        If TextBox20.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Corn" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else

            ' <-- Disable function --> 

            Button7.Enabled = False
            Button5.Enabled = False
            Button3.Enabled = False
            Button2.Enabled = False

            TextBox20.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 

        End If

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click


        ' < -- Start of Append Function --> 
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox19.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Potatoes" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)

        ' < -- End of Append Function --> 



        ' <-- Condition --> 

        If TextBox19.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Potatoes" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else

            ' <-- Disable function --> 

            Button9.Enabled = False
            Button7.Enabled = False
            Button5.Enabled = False
            Button3.Enabled = False
            Button2.Enabled = False

            TextBox19.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 

        End If


    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click


        ' < -- Start of Append Function --> 
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox18.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Rice" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)

        ' < -- End of Append Function --> 


        ' <-- Condition --> 

        If TextBox18.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Rice" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else



            ' <-- Disable function --> 

            Button11.Enabled = False
            Button9.Enabled = False
            Button7.Enabled = False
            Button5.Enabled = False
            Button3.Enabled = False
            Button2.Enabled = False

            TextBox18.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 

        End If


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click


        ' < -- Start of Append Function --> 
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox17.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Tobacco" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("======================================")
        TextBox1.AppendText(vbNewLine)

        ' < -- End of Append Function --> 


        ' <-- Condition --> 

        If TextBox17.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Tobacco" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else


            ' <-- Disable function --> 

            Button13.Enabled = False
            Button11.Enabled = False
            Button9.Enabled = False
            Button7.Enabled = False
            Button5.Enabled = False
            Button3.Enabled = False
            Button2.Enabled = False

            TextBox17.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 

        End If



    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click


        ' < -- Start of Append Function --> 
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("Admin Saved The Changes :" + vbNewLine)
        TextBox1.AppendText("Consignor Name: " + vbTab + ComboBox3.Text + vbNewLine)
        TextBox1.AppendText("Ending Value is" + vbTab + TextBox16.Text + vbNewLine)
        TextBox1.AppendText("For Product named: Tomatoes" + vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)



        ' < -- End of Append Function --> 



        ' <-- Condition --> 

        If TextBox16.Text = "" Then
            MsgBox("Sorry ! This Value Cannot Be Set To Empty.", 0 + 64)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Admin Placed an Empty Value to for Product named Tomatoes" + vbNewLine)
            TextBox1.AppendText("System Advised to Enter a correct Value or Else Transaction wont go through" + vbNewLine)
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("======================================")
            TextBox1.AppendText(vbNewLine)

        Else

            ' <-- Disable function --> 

            Button15.Enabled = False
            Button13.Enabled = False
            Button11.Enabled = False
            Button9.Enabled = False
            Button7.Enabled = False
            Button5.Enabled = False
            Button3.Enabled = False
            Button2.Enabled = False

            TextBox16.ReadOnly = True
            Button1.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
            Button8.Enabled = True
            Button10.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True

            ' < -- EOL -- > 

        End If



    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged



    End Sub

    Private Sub ComboBox2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedValueChanged



    End Sub

    Private Sub ComboBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.TextChanged


       

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(" Submit Button Has been Clicked" + vbNewLine)


        If TextBox24.Text = "" Then
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("=======================================")
            TextBox1.AppendText(vbNewLine)
            TextBox1.AppendText("Submit Button Has been Clicked" + vbNewLine)
            TextBox1.AppendText("But ADMIN Didnt Indicate the changes and reason" + vbNewLine)
            TextBox1.AppendText("Error Message Has Been Given due to This Instance" + vbNewLine)
            MsgBox("Please Specify The Changes That You Made And Make Sure That You Indicate all the Necessary Details.", 0 + 64)

        Else

            Dim axa As DialogResult = MsgBox("Are You Sure You Want to Save this Changes ?", 4 + 32)

            If axa = DialogResult.Yes Then

                con.Open()
                query = "INSERT INTO `Admin Inventory Modification`(`Correction_ID`, `time_and_date`, `Action_made`, `Processed_by`, `Admin_notes`, `Sys_log`) Values ('" & TextBox3.Text & "','" & Label2.Text & "','" & Label32.Text & "','" & TextBox8.Text & "','" & TextBox24.Text & "','" & TextBox1.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()

                rd.Close() ' < -- Reader close to avoid stack -->
                con.Close()

                ' < -- New Listings --> 

                con.Open()
                query = "INSERT INTO `Admin_Consignor Data Logs`(`modification_made`, `date_and_time`, `con_id`, `con_name`, `processed_by`, `notes`) values ('" & Label32.Text & "','" & Label2.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox8.Text & "','" & Label34.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()

                rd.Close() ' < -- Reader close to avoid stack -->
                con.Close()

                con.Open()
                query = "UPDATE `Inventory` SET `Con_ID`='" & ComboBox2.Text & "',`Prod_Camote`='" & TextBox23.Text & "',`Prod_Chili`='" & TextBox22.Text & "',`Prod_Coffee_Beans`='" & TextBox21.Text & "',`Prod_Corn`='" & TextBox20.Text & "',`Prod_Potatoes`='" & TextBox19.Text & "',`Prod_Rice`='" & TextBox18.Text & "',`Prod_Tobacco`='" & TextBox17.Text & "', `Prod_Tomatoes`='" & TextBox16.Text & "' where `Con_ID`='" & ComboBox2.Text & "'"
                cmd = New MySqlCommand(query, con)
                rd = cmd.ExecuteReader()
                MsgBox("Consignor Record Has Been Altered Successfully.")

                Me.Cursor = Cursors.Default ' < -- Return cursor to default / added 1/13/2019  --> 



                Dim bimbi3 As DialogResult = MsgBox("Do You Want to Do another Transaction ?", 4 + 32)
                If bimbi3 = DialogResult.Yes Then

                    '< -- Reboot Form --> 

                    Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

                    Me.Controls.Clear() 'removes all the controls on the form
                    InitializeComponent() 'load all the controls again
                    Inventory_Modification_Load(e, e) 'Load everything in your form load event again hahaha in tagalog ulit

                    Me.Cursor = Cursors.Default ' < -- Return cursor to default / added 1/13/2019--> 
                Else
                    Me.Dispose()
                    Me.Close()

                End If

                con.Close()


            End If

        End If


    End Sub

    Private Sub TextBox24_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox24.TextChanged


    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click

        ' < -- Sys Log Details after Exit --> 

        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText("=======================================")
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(vbNewLine)
        TextBox1.AppendText(" Exit Button Has been Clicked" + vbNewLine)

        Dim axa69 As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If axa69 = DialogResult.Yes Then

            TextBox1.AppendText(" Exit Time: " + vbTab + Label2.Text + vbNewLine)

            If axa69 = DialogResult.Yes Then

                con.Open()
                query = "INSERT INTO `Admin Inventory Modification`(`Correction_ID`, `time_and_date`, `Action_made`, `Processed_by`, `Admin_notes`, `Sys_log`) Values ('" & TextBox3.Text & "','" & Label2.Text & "','" & Label33.Text & "','" & TextBox8.Text & "','" & TextBox25.Text & "','" & TextBox1.Text & "')"
                cmd = New MySqlCommand(query, con)
                cmd.CommandTimeout = 240  'for time out errors
                rd = cmd.ExecuteReader()

                rd.Close() ' < -- Reader close to avoid stack -->
                con.Close()

                Me.Dispose()
                Me.Close()

            End If
        End If


    End Sub
End Class