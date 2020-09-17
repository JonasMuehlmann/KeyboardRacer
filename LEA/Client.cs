using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace LEA
{
    /// <summary>
    /// A network-client that connects to the host and lets his player participate in the hosts game
    /// </summary>
    class Client
    {
        // Max Progress digits: 3
        // Separators:          3
        // Max Color chars:     7
        // Max Name chars:      20
        // Total:               33
        private readonly Socket           _clientSocket;
        private          List<Competitor> competitors;

        #region Properties

        /// <summary>
        /// The client's socket used for connecting to the host
        /// </summary>
        public Socket ClientSocket
        {
            get { return _clientSocket; }
        }

        #endregion


        public Client()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }


        /// <summary>
        /// Attempt to establish connecting to the server at 200ms Intervalls for max 20 Attempts.
        /// <para>Returns:</para>
        /// When the connection has been established
        /// </summary>
        /// <exception cref="SocketException">
        /// The connection could not be established after 20 attempts
        /// </exception>
        private void ConnectToServer(string ipAddress)
        {
            int attemptsLeft = 20;

            while (!_clientSocket.Connected)
            {
                try
                {
                    --attemptsLeft;

                    // FOR_DEBUGGING
                    Console.WriteLine($"Connection could not be established, "
                                    + $"trying again in 200ms, attempts left: {attemptsLeft}"
                                     );

                    _clientSocket.Connect(System.Net.IPAddress.Parse(ipAddress), Network.Port);
                    Thread.Sleep(200);
                }
                catch (SocketException)
                {
                    if (attemptsLeft == 0)
                    {
                        throw;
                    }

                    Console.Clear();
                }
            }

            // FOR_DEBUGGING
            Console.Clear();
            Console.WriteLine("Connected");
        }


        /// <summary>
        /// Close the socket and exit.
        /// </summary>
        private void Exit()
        {
            // Request the server to exit
            SendMessage("exit");
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }


        /// <summary>
        /// Decodes message and sends it to the server
        /// </summary>
        /// <param name="message">
        /// An ASCII encoded message
        /// </param>
        private void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            _clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }


        /// <summary>
        /// <para>Returns:</para>
        /// The received message, or an empty string if the number of received bytes is 0
        /// </summary>
        /// <returns>
        /// The received message, or an empty string if the number of received bytes is 0
        /// </returns>
        private string ReceiveResponse()
        {
            var buffer        = new byte[Network.BufferSize];
            int receivedBytes = _clientSocket.Receive(buffer, SocketFlags.None);

            if (receivedBytes == 0)
            {
                return "";
            }

            var data = new byte[receivedBytes];
            Array.Copy(buffer, data, receivedBytes);

            return Encoding.ASCII.GetString(data);
        }
    }
}