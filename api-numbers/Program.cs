using api_numbers.api;
using api_numbers.model;
using System.Text.Json;

// A classe 'Program' é o contêiner padrão para o código do seu aplicativo de console.
Console.WriteLine("Bem-vindo ao Buscador de Ofertas!");

// Criando uma instância do serviço
var apiService = new ApiService();

Console.WriteLine("Buscando ofertas na API, aguarde...");


// Lista de ofertas pronta para ser utilizada
List<Oferta>? ofertas = await apiService.BuscarOfertasAsync();
// Verifica se a lista de ofertas não é nula e contém elementos
if (ofertas != null && ofertas.Any())
{
    Console.WriteLine("\n --- Ofertas Disponíveis ---");
    foreach (var oferta in ofertas)
    {
        Console.WriteLine(oferta.ToString());
    }
}
else
{
    Console.WriteLine("\nNenhuma oferta foi encontrada ou ocorreu um erro.");
}

// --- PARTE 2: CRIANDO UM JSON (SERIALIZAÇÃO) ---
// Este bloco é executado independentemente do sucesso ou falha da Parte 1.
Console.WriteLine("\n======================================");
Console.WriteLine("Agora, vamos testar o serviço de serialização localmente...");

// 1. Criar uma oferta para serializar

var ofertaExemplo = new Oferta
{
    Id = "12345",
    Title = "Super Game Deal",
    PrecoVendaString = "29.99",
    PrecoOriginalString = "59.99",
    DescontoString = "30.00"
};

// 2. Serializar a oferta com a classe utilitária

var jsonFormatado = SerializerService.SerializarOferta(ofertaExemplo);
// 3. A Program.cs é responsável por exibir o resultado
Console.WriteLine("\n--- Exemplo de uma Oferta Serializada ---");
Console.WriteLine(jsonFormatado);

// Salvar o arquivo json na pasta
try
{
    // Definindo a porta de saída
    string diretorioSaida = "output";

    Directory.CreateDirectory(diretorioSaida); // Cria o diretório se não existir

    // Monta o caminho completo do arquivo
    string caminhoArquivo = Path.Combine(diretorioSaida, "oferta_exemplo.json");

    // Escreve a string json no arquivo de forma assíncrona

    await File.WriteAllTextAsync(caminhoArquivo, jsonFormatado);

    // Da um feedback ao usuário
    Console.WriteLine($"\nOferta serializada e salva em: {Path.GetFullPath(caminhoArquivo)}");
}
catch (Exception ex)
{
    // Captura possíveis erros de I/O (ex: falta de permissão para escrever na pasta).
    Console.WriteLine($"\nOcorreu um erro ao salvar o arquivo: {ex.Message}");
}


Console.WriteLine("\n======================================");
Console.WriteLine("Programa finalizado. Pressione qualquer tecla para sair.");
Console.ReadKey();