Imports System.Net.Sockets
Imports System.Text

Public Class chatclient

    Dim clientsocket As New System.Net.Sockets.TcpClient()
    Dim serverstream As NetworkStream
    Dim readdata As String
    Dim infinitecounter As Integer


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(TextBox3.Text + "$")
        serverstream.Write(outStream, 0, outStream.Length)
        serverstream.Flush()
    End Sub

    Private Sub msg()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf msg))
        Else
            TextBox2.Text = TextBox1.Text + Environment.NewLine + " >> " + readdata
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        readdata = "Conected to Chat Server ..."
        Button1.Text = readdata
        msg()
        clientsocket.Connect("127.0.0.1", 8888)
        TextBox2.Text = "Client Socket Program - Server Connected ..."
        serverstream = clientsocket.GetStream()

        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(TextBox3.Text + "$")
        serverstream.Write(outStream, 0, outStream.Length)
        serverstream.Flush()

        Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMessage)
        ctThread.Start()
    End Sub

    Private Sub getMessage()
        For Me.infinitecounter = 1 To 2
            infinitecounter = 1
            serverstream = clientsocket.GetStream()
            Dim buffSize As Integer
            Dim inStream(10024) As Byte
            buffSize = clientsocket.ReceiveBufferSize
            serverstream.Read(inStream, 0, buffSize)
            Dim returndata As String = System.Text.Encoding.ASCII.GetString(inStream)
            readdata = "" + Environment.NewLine + returndata
            msg()
        Next
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class