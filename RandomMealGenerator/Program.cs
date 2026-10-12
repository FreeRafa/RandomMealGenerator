var urlRefeicaoAleatoria = "https://www.themealdb.com/api/json/v1/1/random.php";

using var httpClient = new HttpClient();

var json = await httpClient.GetStringAsync(urlRefeicaoAleatoria);

Console.WriteLine(json);
