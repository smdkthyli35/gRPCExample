using Grpc.Net.Client;
using grpcClient;
using grpcMessageClient;

var channel = GrpcChannel.ForAddress("https://localhost:7133");
var messageClient = new Message.MessageClient(channel);

MessageResponse response = await messageClient.SendMessageAsync(new MessageRequest
{
    Message = "Merhaba",
    Name = "Samed"
});

System.Console.WriteLine(response.Message);

//var greeterClient = new Greeter.GreeterClient(channel);

//HelloReply result = await greeterClient.SayHelloAsync(new HelloRequest
//{
//    Name = "Sa"
//});

//System.Console.WriteLine(result.Message);