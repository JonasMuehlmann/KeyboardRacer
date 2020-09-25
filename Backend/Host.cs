#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

#endregion


namespace Backend
{
    /// <summary>
    ///     A network-host who runs a race
    /// </summary>
    public class Host
    {
        #region Properties

        /// <summary>
        ///     Contains a received message
        /// </summary>
        public byte[] Buffer { get; set; }

        /// <summary>
        ///     Contains the sockets of connected clients
        /// </summary>
        public List<Socket> ClientSockets { get; set; }

        /// <summary>
        ///     The Hosts on socket
        /// </summary>
        public Socket ServerSocket { get; set; }

        #endregion

        #region Constructors

        public Host()
        {
            ServerSocket  = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientSockets = new List<Socket>();
            Buffer        = new byte[Network.BufferSize];
        }

        #endregion


        /// <summary>
        ///     Setup server and start accepting connections
        /// </summary>
        private void Setup()
        {
            // FOR_DEBUGGING
            Console.WriteLine("Setting up server...");
            ServerSocket.Bind(new IPEndPoint(IPAddress.Any, Network.Port));
            ServerSocket.Listen(0);
            ServerSocket.BeginAccept(AcceptConnection, null);
            // FOR_DEBUGGING
            Console.WriteLine("Server setup complete");
        }


        /// <summary>
        ///     Request all connected clients to close their connection to the server
        /// </summary>
        private void CloseAllSockets()
        {
            foreach (var socket in ClientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            ServerSocket.Close();
        }


        /// <summary>
        ///     Accept the given connection attempt
        /// </summary>
        /// <param name="asyncRequest">
        ///     The request representing the connection attempt
        /// </param>
        private void AcceptConnection(IAsyncResult asyncRequest)
        {
            Socket requesterSocket;

            try
            {
                requesterSocket = ServerSocket.EndAccept(asyncRequest);
            }
            // FIX: Always occurs when closing connections
            catch (ObjectDisposedException)
            {
                return;
            }

            ClientSockets.Add(requesterSocket);

            requesterSocket.BeginReceive(Buffer,
                                         0,
                                         Network.BufferSize,
                                         SocketFlags.None,
                                         ReceiveMessage,
                                         requesterSocket
                                        );

            // FOR_DEBUGGING
            Console.WriteLine("Client has connected, waiting for their request...");
            ServerSocket.BeginAccept(AcceptConnection, null);
        }


        /// <summary>
        ///     Start receiving messages from the client sending the asyncRequest and save it to this.Buffer
        ///     Closes connection to client if he sends 'exit'
        /// </summary>
        /// <param name="asyncRequest">
        ///     A request representing the transmission of a message
        /// </param>
        private void ReceiveMessage(IAsyncResult asyncRequest)
        {
            var currentClient = (Socket) asyncRequest.AsyncState;
            int receivedBytes;

            try
            {
                receivedBytes = currentClient.EndReceive(asyncRequest);
            }
            catch (SocketException)
            {
                // FOR_DEBUGGING
                Console.WriteLine("Client ungracefully disconnected");
                currentClient.Close();
                ClientSockets.Remove(currentClient);

                return;
            }

            var receivedBuffer = new byte[receivedBytes];
            Array.Copy(Buffer, receivedBuffer, receivedBytes);
            var message = Encoding.ASCII.GetString(receivedBuffer);
            // FOR_DEBUGGING
            Console.WriteLine($"Received message: {message}");

            // Client has requested graceful disconnect
            if (message.ToLower() == "exit")
            {
                DisconnectClient(currentClient);

                return;
            }

            currentClient.BeginReceive(Buffer,
                                       0,
                                       Network.BufferSize,
                                       SocketFlags.None,
                                       ReceiveMessage,
                                       currentClient
                                      );
        }


        /// <summary>
        ///     Gracefully disconnect client
        /// </summary>
        /// <param name="current"></param>
        private void DisconnectClient(Socket current)
        {
            current.Shutdown(SocketShutdown.Both);
            current.Close();
            ClientSockets.Remove(current);
            // FOR_DEBUGGING
            Console.WriteLine("Client has disconnected");
        }
    }
}