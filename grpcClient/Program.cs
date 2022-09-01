using Grpc.Net.Client;
using grpcClient;
using grpcMessageClient;

var channel = GrpcChannel.ForAddress("https://localhost:7133");
var messageClient = new Message.MessageClient(channel);

//Unary
//MessageResponse response = await messageClient.SendMessageAsync(new MessageRequest
//{
//    Message = "Merhaba",
//    Name = "Samed"
//});
//System.Console.WriteLine(response.Message);


//Server Streaming
//var response = messageClient.SendMessage(new MessageRequest
//{
//    Message = "Merhaba",
//    Name = "Samed"
//});

//CancellationTokenSource cancellationTokenSource = new();
//while (await response.ResponseStream.MoveNext(cancellationTokenSource.Token))
//{
//    System.Console.WriteLine(response.ResponseStream.Current.Message);
//}

//Client Streaming
var request = messageClient.SendMessage();
for (int i = 0; i < 10; i++)
{
    await Task.Delay(100);
    await request.RequestStream.WriteAsync(new MessageRequest
    {
        Name = "Samed",
        Message = "Merhabalar " + i
    });
}

//Stream datanın sonlandığını ifade eder.
await request.RequestStream.CompleteAsync();

Console.WriteLine((await request.ResponseAsync).Message);


//var greeterClient = new Greeter.GreeterClient(channel);

//HelloReply result = await greeterClient.SayHelloAsync(new HelloRequest
//{
//    Name = "Sa"
//});

//System.Console.WriteLine(result.Message);