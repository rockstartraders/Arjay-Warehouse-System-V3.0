Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO

' Comments, Error and URL ' 
' Timeouts = https://www.grasshopper3d.com/group/slingshot/forum/topics/problem-with-connection '
' Out of range = https://stackoverflow.com/questions/14284494/mysql-error-1264-out-of-range-value-for-column '


Public Class chart
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub chart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
        con.Open()
        query = "SELECT * FROM `Inventory`"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("Con_Name").ToString())
            lv.SubItems.Add(rd("Prod_Camote").ToString())
            lv.SubItems.Add(rd("Prod_Chili").ToString())
            lv.SubItems.Add(rd("Prod_Coffee_Beans").ToString())
            lv.SubItems.Add(rd("Prod_Corn").ToString())
            lv.SubItems.Add(rd("Prod_Potatoes").ToString())
            lv.SubItems.Add(rd("Prod_Tobacco").ToString())
            lv.SubItems.Add(rd("Prod_Tomatoes").ToString())



            ListView1.FullRowSelect = True
            lv.UseItemStyleForSubItems = False


            


            ' <-- Graph Representation --> 

            Chart1.Series("Camote").Points.AddXY(rd.GetString("Con_Name"), rd.GetString("Prod_Camote"))
            Chart2.Series("Red Chili").Points.AddXY(rd.GetString("Con_Name"), rd.GetString("Prod_Chili"))
            Chart3.Series("Coffee Beans").Points.AddXY(rd.GetString("Con_Name"), rd.GetString("Prod_Coffee_Beans"))
            Chart4.Series("Corn").Points.AddXY(rd.GetString("Con_Name"), rd.GetString("Prod_Corn"))
            Chart5.Series("Potatoes").Points.AddXY(rd.GetString("Con_Name"), rd.GetString("Prod_Potatoes"))
            Chart6.Series("Tobacco").Points.AddXY(rd.GetString("Con_Name"), rd.GetString("Prod_Tobacco"))
            Chart7.Series("Tomatoes").Points.AddXY(rd.GetString("Con_Name"), rd.GetString("Prod_Tomatoes"))


            
        End While

        con.Close()

        ' <-- Total --> 

        Dim TotalSum As Double = 0
        Dim lvv As ListViewItem
        Dim TempDbl As Double
        For Each lvv In ListView1.Items
            If Double.TryParse(lvv.SubItems.Item(1).Text, TempDbl) Then
                TotalSum += TempDbl
            End If
        Next
        Label2.Text = TotalSum


        Dim TotalSuma As Double = 0
        Dim lvva As ListViewItem
        Dim TempDbla As Double
        For Each lvva In ListView1.Items
            If Double.TryParse(lvva.SubItems.Item(2).Text, TempDbla) Then
                TotalSuma += TempDbla
            End If
        Next
        Label3.Text = TotalSuma


        Dim TotalSumab As Double = 0
        Dim lvvab As ListViewItem
        Dim TempDblab As Double
        For Each lvvab In ListView1.Items
            If Double.TryParse(lvvab.SubItems.Item(3).Text, TempDblab) Then
                TotalSumab += TempDblab
            End If
        Next
        Label4.Text = TotalSumab


        Dim TotalSumabc As Double = 0
        Dim lvvabc As ListViewItem
        Dim TempDblabc As Double
        For Each lvvabc In ListView1.Items
            If Double.TryParse(lvvabc.SubItems.Item(4).Text, TempDblabc) Then
                TotalSumabc += TempDblabc
            End If
        Next
        Label5.Text = TotalSumabc

        Dim TotalSumabcd As Double = 0
        Dim lvvabcd As ListViewItem
        Dim TempDblabcd As Double
        For Each lvvabcd In ListView1.Items
            If Double.TryParse(lvvabcd.SubItems.Item(5).Text, TempDblabcd) Then
                TotalSumabcd += TempDblabcd
            End If
        Next
        Label6.Text = TotalSumabcd

        Dim TotalSumabcde As Double = 0
        Dim lvvabcde As ListViewItem
        Dim TempDblabcde As Double
        For Each lvvabcde In ListView1.Items
            If Double.TryParse(lvvabcde.SubItems.Item(6).Text, TempDblabcde) Then
                TotalSumabcde += TempDblabcde
            End If
        Next
        Label7.Text = TotalSumabcde


        Dim TotalSumabcdef As Double = 0
        Dim lvvabcdef As ListViewItem
        Dim TempDblabcdef As Double
        For Each lvvabcdef In ListView1.Items
            If Double.TryParse(lvvabcdef.SubItems.Item(7).Text, TempDblabcdef) Then
                TotalSumabcdef += TempDblabcdef
            End If
        Next
        Label8.Text = TotalSumabcdef


        ' < -- End ng Pagdurusa -->

    End Sub

    Private Sub Chart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Chart1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart1.Click

    End Sub

    Private Sub Chart3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart3.Click

    End Sub

    Private Sub Chart5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart5.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        chart_Load(e, e) 'Load everything in your form load event again hahaha in tagalog ulit


        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim pagod As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, )

        If pagod = DialogResult.Yes Then



            Me.Dispose()
            Me.Close()

        End If

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chart_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

        

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged



        


    End Sub
End Class