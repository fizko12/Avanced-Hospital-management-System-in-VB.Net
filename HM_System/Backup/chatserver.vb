Imports System.Net.Sockets
Imports System.Text
Public Class chatserver
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim clientsList As New Hashtable

        Dim serverSocket As New TcpListener(TextBox1.Text)
        Dim clientSocket As TcpClient
        Dim counter As Integer

        serverSocket.Start()
        msg("Chat Server Started ....")
        counter = 0
        While (True)
            counter += 1
            clientSocket = serverSocket.AcceptTcpClient()

            Dim bytesFrom(10024) As Byte
            Dim dataFromClient As String

            Dim networkStream As NetworkStream = _
            clientSocket.GetStream()
            networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
            dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
            dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"))

            clientsList(dataFromClient) = clientSocket

            broadcast(dataFromClient + " Joined ", dataFromClient, False)

            msg(dataFromClient + " Joined chat room ")
            Dim client As New handleClinet
            client.startClient(clientSocket, dataFromClient, clientsList)
        End While

        clientSocket.Close()
        serverSocket.Stop()
        msg("exit")
        Console.ReadLine()
    End Sub

    Sub msg(ByVal mesg As String)
        mesg.Trim()
        Console.WriteLine(" >> " + mesg)
    End Sub
    Public Sub broadcast(ByVal msg As String, ByVal uName As String, ByVal flag As Boolean)
        Dim Item As DictionaryEntry
        Dim clientsList As Hashtable
        For Each Item In clientsList
            Dim broadcastSocket As TcpClient
            broadcastSocket = CType(Item.Value, TcpClient)
            Dim broadcastStream As NetworkStream = broadcastSocket.GetStream()
            Dim broadcastBytes As [Byte]()

            If flag = True Then
                broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg)
            Else
                broadcastBytes = Encoding.ASCII.GetBytes(msg)
            End If

            broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length)
            broadcastStream.Flush()
        Next
    End Sub

    Public Class handleClinet
        Dim clientSocket As TcpClient
        Dim clNo As String
        Dim clientsList As Hashtable
        Dim dataFromClient1 As String



        Public Sub startClient(ByVal inClientSocket As TcpClient, ByVal clineNo As String, ByVal cList As Hashtable)
            Me.clientSocket = inClientSocket
            Me.clNo = clineNo
            Me.clientsList = cList
            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf doChat)
            ctThread.Start()
        End Sub

        Private Sub doChat()
            'Dim infiniteCounter As Integer
            Dim requestCount As Integer
            Dim bytesFrom(10024) As Byte


            Dim sendBytes As [Byte]()
            Dim serverResponse As String
            Dim rCount As String
            requestCount = 0

            While (True)
                Try
                    requestCount = requestCount + 1
                    Dim networkStream As NetworkStream = clientSocket.GetStream()
                    networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                    dataFromClient1 = System.Text.Encoding.ASCII.GetString(bytesFrom)
                    dataFromClient1 = dataFromClient1.Substring(0, dataFromClient1.IndexOf("$"))


                    'Me.msg("From client - " + Me.clNo + " : " + Me.dataFromClient1)

                    rCount = Convert.ToString(requestCount)

                    'Me.broadcast(Me.dataFromClient1, Me.clNo, True)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End While
        End Sub

    End Class


End Class
