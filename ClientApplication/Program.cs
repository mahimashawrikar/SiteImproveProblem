// See https://aka.ms/new-console-template for more information
HttpClient clientCall = new HttpClient();
using (var client = new HttpClient())
{
    var response = await clientCall.GetAsync("https://localhost:44317/getNumbers/GetAllNumbers");
    response.EnsureSuccessStatusCode();
    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine("response error code", response.StatusCode);
    }
    else
    {
        string message = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Result of pattern match: {0}", message);
    }
}

Console.ReadKey();
Console.Clear();
