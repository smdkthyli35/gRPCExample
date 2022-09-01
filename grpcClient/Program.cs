using Grpc.Net.Client;
using grpcClient;

var channel = GrpcChannel.ForAddress("https://localhost:7133");
var greeterClient = new Greeter.GreeterClient(channel);

HelloReply result = await greeterClient.SayHelloAsync(new HelloRequest
{
    Name = "Sa"
});

System.Console.WriteLine(result.Message);