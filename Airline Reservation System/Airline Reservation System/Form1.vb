Imports System.Data.SqlClient

Public Class Form1
    Dim BusinessClass(20) As PictureBox
    Dim BusinessReservation(20) As RichTextBox
    Dim EconomyClass(100) As PictureBox
    Dim EconomyReservation(100) As RichTextBox
    Dim MyImageLocationPrefix As String = "C:\Users\User\source\VB_repos\Airline Reservation System\Airline Reservation System\bin\Debug\net6.0-windows\"
    Dim EmptySeatImg As String = "EmptySeat.png"
    Dim FullSeatImg As String = "SeatedSeat.png"
    Dim ClassLabel(2) As Label 'to separate business and economy classes on the form
    Dim names(2) As String
    'Database
    Dim ConnectionObj As SqlConnection ' connection object


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Database instantiate connection at the start of the form load
        ConnectionObj = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\User\source\VB_repos\Airline Reservation System\Airline Reservation System\Airline.mdf';Integrated Security=True")
        ConnectionObj.Open()
        '

        Dim xLocation As Integer = 10
        Dim yLocation As Integer = 50
        names(0) = "First Name"
        names(1) = "Last Name"

        ' Class Labels
        ClassLabel(0) = New Label() With {
            .Size = New Size(200, 50),
            .Location = New Point(xLocation + 350, yLocation),
            .Name = "BusClassLabel",
            .Text = "Business Class",
            .BackColor = Color.Yellow,
            .Visible = True,
            .Enabled = True
            }
        Me.Controls.Add(ClassLabel(0))

        yLocation = 1700
        ClassLabel(0) = New Label() With {
            .Size = New Size(200, 50),
            .Location = New Point(xLocation + 350, yLocation),
            .Name = "EconClassLabel",
            .Text = "Economy Class",
            .BackColor = Color.Yellow,
            .Visible = True,
            .Enabled = True
            }
        Me.Controls.Add(ClassLabel(0))

        ' Business Class and Economy Class picture and rich text boxes
        yLocation = 110
        For index = 0 To 99
            If index < 20 Then
                BusinessClass(index) = New PictureBox() With {
            .ImageLocation = MyImageLocationPrefix + EmptySeatImg,
            .Size = New Size(200, 200),
            .Location = New Point(xLocation, yLocation),
            .Name = "BusPicBox" + index.ToString(),
            .Visible = True,
            .Enabled = True,
            .Cursor = Cursors.Hand
}
                BusinessReservation(index) = New RichTextBox() With {
            .Size = New Size(200, 100),
            .Location = New Point(xLocation, yLocation + 200),
            .Name = "RichTextBox" + index.ToString(),
            .Visible = True,
            .Enabled = False, 'this turns off the option to type in the richtextbox when we run the program
            .Cursor = Cursors.Hand
}
                Me.Controls.Add(BusinessClass(index))
                Me.Controls.Add(BusinessReservation(index))

                xLocation += 210
                If (index + 1) Mod 4 = 0 Then
                    xLocation = 10
                    yLocation += 310
                End If

                AddHandler BusinessClass(index).Click, AddressOf PictureBoxClick
            Else
                EconomyClass(index) = New PictureBox() With {
            .ImageLocation = MyImageLocationPrefix + EmptySeatImg,
            .Size = New Size(200, 200),
            .Location = New Point(xLocation, yLocation + 100),
            .Name = "EcoPicBox" + index.ToString(),
            .Visible = True,
            .Enabled = True,
            .Cursor = Cursors.Hand
}
                EconomyReservation(index) = New RichTextBox() With {
            .Size = New Size(200, 100),
            .Location = New Point(xLocation, yLocation + 300),
            .Name = "RichTextBox" + index.ToString(),
            .Visible = True,
            .Enabled = False,
            .Cursor = Cursors.Hand
}
                Me.Controls.Add(EconomyClass(index))
                Me.Controls.Add(EconomyReservation(index))

                xLocation += 210
                If (index + 1) Mod 4 = 0 Then
                    xLocation = 10
                    yLocation += 310
                End If

                AddHandler EconomyClass(index).Click, AddressOf PictureBoxClick
            End If
        Next


        'Database data reader - insert all the database information into the program when run. Position in the form load after all the form objects are inserted

        Dim Cmd As New SqlCommand($"SELECT * FROM BusinessClass;", ConnectionObj)
        Dim reader As SqlDataReader
        reader = Cmd.ExecuteReader
        If reader.HasRows = False Then
            reader.Close()
            Return
        End If
        While reader.Read
            Dim seat As Integer = Convert.ToInt32(reader.GetValue(0))
            Dim FirstName As String = reader.GetValue(1).ToString
            Dim LastName As String = reader.GetValue(2).ToString
            BusinessClass(seat).ImageLocation = FullSeatImg
            BusinessReservation(seat).Text = $"{names(0)}: {FirstName} {vbCrLf}{names(1)}: {LastName}"
        End While
        reader.Close()

        Cmd = New SqlCommand($"SELECT * FROM EconomyClass;", ConnectionObj)
        reader = Cmd.ExecuteReader
        If reader.HasRows = False Then
            reader.Close()
            Return
        End If
        While reader.Read
            Dim seat As Integer = Convert.ToInt32(reader.GetValue(0))
            Dim FirstName As String = reader.GetValue(1).ToString
            Dim LastName As String = reader.GetValue(2).ToString
            EconomyClass(seat).ImageLocation = FullSeatImg
            EconomyReservation(seat).Text = $"{names(0)} {FirstName} {vbCrLf}{names(1)}: {LastName}"
        End While
        reader.Close()
        '

    End Sub
    Private Sub PictureBoxClick(sender As Object, e As EventArgs)

        'what happens when we click a picture box
        Dim pictureboxclick As PictureBox = sender
        Dim PBnumber As Integer = Convert.ToInt32(pictureboxclick.Name.Substring(9))
        Dim BusOrEco As String = pictureboxclick.Name.Substring(0, 3)
        TextBox4.Text = $"This is {pictureboxclick.Name}. The index={PBnumber}"

        If BusOrEco = "Bus" Then
            If BusinessReservation(PBnumber).Text = "" And (TextBox1.Text = "" Or TextBox2.Text = "") Then
                MessageBox.Show($"Please input your Name and Surname")
            ElseIf BusinessReservation(PBnumber).Text = "" And TextBox1.Text <> "" And TextBox2.Text <> "" Then
                BusinessReservation(PBnumber).Text = $"Name:{TextBox1.Text}{vbCrLf}Surname:{TextBox2.Text}"

                'Database ADD info to the BusinessClass table
                Dim queryString As String = $"INSERT INTO BusinessClass (Seat,FirstName,LastName) VALUES ({PBnumber}, '{TextBox1.Text}','{TextBox2.Text}');"
                Dim Cmd As New SqlCommand(queryString, ConnectionObj)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Record Added")
                '

                MessageBox.Show("Thank you for booking with us. Your seat in Business class is reserved")
                pictureboxclick.ImageLocation = "./SeatedSeat.png"
                TextBox1.Clear()
                TextBox2.Clear()
            ElseIf BusinessReservation(PBnumber).Text <> "" Then
                Dim YesNoCancel As DialogResult = MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButtons.YesNo) 'second "" is used for header to name the messagebox
                If YesNoCancel = DialogResult.Yes Then

                    'Database DELETE from the BusinessClass table
                    Dim Command As New SqlCommand($"DELETE FROM BusinessClass WHERE Seat = '{PBnumber}';", ConnectionObj)
                    Command.ExecuteNonQuery()
                    MessageBox.Show("Record Delete Successful!!")
                    '

                    pictureboxclick.ImageLocation = "./EmptySeat.png"
                    BusinessReservation(PBnumber).Clear()
                    MessageBox.Show("Your business reservation has been cancelled")
                Else
                    MessageBox.Show("Thank you for staying with us")
                End If
            End If
        Else
            If EconomyReservation(PBnumber).Text = "" And (TextBox1.Text = "" Or TextBox2.Text = "") Then
                MessageBox.Show("Please input your Name and Surname")
            ElseIf EconomyReservation(PBnumber).Text = "" And TextBox1.Text <> "" And TextBox2.Text <> "" Then
                EconomyReservation(PBnumber).Text = $"Name:{TextBox1.Text}{vbCrLf}Surname:{TextBox2.Text}"

                'Database ADD (EconomyClass table)
                Dim queryString As String = $"INSERT INTO EconomyClass (Seat,FirstName,LastName) VALUES ({PBnumber}, '{TextBox1.Text}','{TextBox2.Text}');"
                Dim Cmd As New SqlCommand(queryString, ConnectionObj)
                Cmd.ExecuteNonQuery()
                MessageBox.Show("Record Added")
                '

                MessageBox.Show("Thank you for booking with us. Your seat in Economy class is reserved")
                pictureboxclick.ImageLocation = "./SeatedSeat.png"
                TextBox1.Clear()
                TextBox2.Clear()
            ElseIf EconomyReservation(PBnumber).Text <> "" Then
                Dim YesNoCancel As DialogResult = MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButtons.YesNo) 'second "" is used as header to name the messagebox
                If YesNoCancel = DialogResult.Yes Then

                    'Database DELETE (EconomyClass table)
                    Dim Command As New SqlCommand($"DELETE FROM EconomyClass WHERE Seat = '{PBnumber}';", ConnectionObj)
                    Command.ExecuteNonQuery()
                    MessageBox.Show("Record Delete Successful!!")
                    '

                    pictureboxclick.ImageLocation = "./EmptySeat.png"
                    EconomyReservation(PBnumber).Clear()
                    MessageBox.Show("Your economy reservation has been cancelled")
                Else
                    MessageBox.Show("Thank you for staying with us")
                End If
            End If
        End If
    End Sub

End Class
