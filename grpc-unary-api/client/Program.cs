using Calculator;
using Greet;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const string target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The client connected without a problem.");
                }
            });

            var client = new CalculatorService.CalculatorServiceClient(channel);

            var request = new SumRequest()
            {
                A = 1,
                B = 2
            };

            var response = client.Sum(request);

            Console.WriteLine(response.Result);
            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
