using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace LEA
{
    class Server
    {
        private static readonly Socket serverSocket =
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static readonly List<Socket> ClientSockets = new List<Socket>();
        private const           int          BufferSize    = 33;
        private const           int          Port          = 100;
        private static readonly byte[]       Buffer        = new byte[BufferSize];


        /// <summary>
        /// Setup server and start accepting connections
        /// </summary>
        private static void SetupServer()
        {
            // FOR_DEBUGGING
            Console.WriteLine("Setting up server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptConnection, null);
            // FOR_DEBUGGING
            Console.WriteLine("Server setup complete");
        }


        /// <summary>
        /// Request all connected clients to close their connection to the server
        /// </summary>
        private static void CloseAllSockets()
        {
            foreach (Socket socket in ClientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }


        private static void AcceptConnection(IAsyncResult asyncRequest)
        {
            Socket requesterSocket;

            try
            {
                requesterSocket = serverSocket.EndAccept(asyncRequest);
            }
            // FIX: Always occurs when closing connections
            catch (ObjectDisposedException)
            {
                return;
            }

            ClientSockets.Add(requesterSocket);

            requesterSocket.BeginReceive(Buffer,
                                         0,
                                         BufferSize,
                                         SocketFlags.None,
                                         ReceiveMessage,
                                         requesterSocket
                                        );

            // FOR_DEBUGGING
            Console.WriteLine("Client has connected, waiting for their request...");
            serverSocket.BeginAccept(AcceptConnection, null);
        }


        private static void ReceiveMessage(IAsyncResult asyncRequest)
        {
            Socket currentClient = (Socket) asyncRequest.AsyncState;
            int    receivedBytes;

            try
            {
                receivedBytes = currentClient.EndReceive(asyncRequest);
            }
            catch (SocketException)
            {
                // FOR_DEBUGGING
                Console.WriteLine("Client forcefully disconnected");
                currentClient.Close();
                ClientSockets.Remove(currentClient);

                return;
            }

            byte[] ReceivedBuffer = new byte[receivedBytes];
            Array.Copy(Buffer, ReceivedBuffer, receivedBytes);
            string message = Encoding.ASCII.GetString(ReceivedBuffer);
            // FOR_DEBUGGING
            Console.WriteLine($"Received message: {message}");

            // Client has requested exit
            if (message.ToLower() == "exit")
            {
                DisconnectClient(currentClient);

                return;
            }

            currentClient.BeginReceive(Buffer,
                                       0,
                                       BufferSize,
                                       SocketFlags.None,
                                       ReceiveMessage,
                                       currentClient
                                      );
        }


        /// <summary>
        /// Gracefully disconnect client
        /// </summary>
        /// <param name="current"></param>
        private static void DisconnectClient(Socket current)
        {
            current.Shutdown(SocketShutdown.Both);
            current.Close();
            ClientSockets.Remove(current);
            // FOR_DEBUGGING
            Console.WriteLine("Client has disconnected");
        }
    }
}