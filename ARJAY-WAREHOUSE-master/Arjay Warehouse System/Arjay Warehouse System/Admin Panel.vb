Imports System.IO
Imports System.Net
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Admin_Panel
    Dim con As New MySqlConnection("Server=db4free.net;port=3306;userid=arjaywarehouse;password=Hulinghulingproject;database=arjay_warehouse;old guids=true;Connection Timeout=240;")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim aaa As New Password_Reset_Admin_Panel    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaa.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim aai As New Admin_Create_Account_Landing_Page    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aai.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim aaaa As New Admin_Correction_Form    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaa.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 




    End Sub

    Private Sub Admin_Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


       


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim aaaab As New Employee_Registration_Form    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaab.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim aaaad As New Entry_Log_Viewer    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaad.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->


        Dim aaaak As New Employee_database    ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaak.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim aaaaka As New Admin_Self_Help_Password_Reset    ' -- I need to create a new dim to avoid same instance and avoid instance error 

        aaaaka.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 



    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click



    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim aaaakab As New View_ADMIN_Actions_for_Account_Modifications   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        
        aaaakab.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim aaaakaba As New Delete_Access_Admin_Panel   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        aaaakaba.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim bakanaman As New Consignor_Registration_Form   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        bakanaman.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim locker As New Locker_Registration_Form   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        locker.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->


        Dim consignorkagebunshin As New Caution_Error   ' -- I need to create a new dim to avoid same instance and avoid instance error 

        consignorkagebunshin.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->

        Dim consignorkagebunshinreadonly As New View_Log_for_Consignor_Modification   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        consignorkagebunshinreadonly.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim consignorkagebunshinreadonlyone As New Inventory_Modification   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        consignorkagebunshinreadonlyone.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

        ' < -- This is needed to Avoid Modal Error -->

        Dim palabok As DialogResult = MsgBox("Are You Sure You Want to Sign Out From This Session ?", 4 + 32, )

        If palabok = DialogResult.Yes Then


           
            Dim consignorkagebunshinreadonlyonetwo As New Login_As   ' -- I need to create a new dim to avoid same instance and avoid instance error 


            Me.Hide()
            MsgBox("Goodbye", 0)
            Me.Dispose()
            Me.Close()


        End If

        
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click


        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim consignorkagebunshinreadonlyonetwothree As New Inventory_Modification_Events   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        consignorkagebunshinreadonlyonetwothree.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 


    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub






    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click

    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click

    End Sub

    Private Sub Label3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click

        Me.Cursor = Cursors.WaitCursor    ' < -- cursor wait function -->



        Dim marupok As New view_user_panel   ' -- I need to create a new dim to avoid same instance and avoid instance error 


        marupok.Show()

        Me.Cursor = Cursors.Default ' < -- Return cursor to default --> 



    End Sub

    Private Sub Label8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
End Class