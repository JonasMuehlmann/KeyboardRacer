using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace LEA
{
    class Client
    {
        private static readonly Socket ClientSocket =
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private const string IPAdress = "85.202.163.32";

        // Max Progress digits: 3
        // Separators:          3
        // Max Color chars:     7
        // Max Name chars:      20
        // Total:               33
        private const int BufferSize = 33;
        private const int Port       = 100;


        /// <summary>
        /// Attempt to establish connecting to the server at 200ms Intervalls for max 20 Attempts.
        /// Returns when the connection has been established
        /// </summary>
        /// <exception cref="SocketException">
        /// The connection could not be established after 20 attempts
        /// </exception>
        private static void ConnectToServer(string ipAdress)
        {
            int attemptsLeft = 20;

            while (!ClientSocket.Connected)
            {
                try
                {
                    --attemptsLeft;

                    // FOR_DEBUGGING
                    Console.WriteLine($"Connection could not be established, "
                                    + $"trying again in 200ms, attempts left: {attemptsLeft}"
                                     );

                    ClientSocket.Connect(IPAddress.Parse(ipAdress), Port);
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
        private static void Exit()
        {
            // Request the server to exit
            SendMessage("exit");
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }


        /// <param name="message">
        /// An ASCII encoded message
        /// </param>
        /// <summary>
        /// Decodes message and sends it to the server
        /// </summary>
        private static void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }


        /// <summary>
        /// Returns the received message, or an empty string if the number of received bytes is 0
        /// </summary>
        private static string ReceiveResponse()
        {
            var buffer        = new byte[BufferSize];
            int receivedBytes = ClientSocket.Receive(buffer, SocketFlags.None);

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