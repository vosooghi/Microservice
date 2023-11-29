using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TestSamples.Consumer.Dtos;
using TestSamples.Consumer.Shared;

string url = "http://localhost:5143";
Console.WriteLine("Enter Person id: ");
string id = Console.ReadLine();
var result = APICaller.Call(url,id).Result.Content.ReadAsStringAsync().Result;
PersonResponseDto dto = JsonConvert.DeserializeObject<PersonResponseDto>(result);
Console.WriteLine($"FirstName: {dto.FirstName}, LastName: {dto.LastName}");
Console.ReadKey();