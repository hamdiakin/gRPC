using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server()
                {
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine($"Server is listening for the port {Port}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server stopped" + ex.ToString());
                throw;
            }
            finally
            {
                if (server != null)
                {
                    server.ShutdownAsync().Wait();
                }
            }
        } 
    }
}
