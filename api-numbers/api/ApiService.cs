using api_numbers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace api_numbers.api;


// Tornamos a classe 'public' para que ela possa ser usada em outras partes do programa, como na Program.cs.
public class ApiService
{
    // 1. O HttpClient agora pertence a este serviço.
    //    A lógica de ser 'static' e 'readonly' continua a mesma,
    //    garantindo que reutilizaremos a mesma instância.
    private static readonly HttpClient cliente = new HttpClient();

    // 2. Criamos um método público e assíncrono.
    //    - 'public': Para ser chamado de fora da classe.
    //    - 'async': Porque usaremos 'await' dentro dele.
    //    - 'Task<List<Oferta>?>': Ele retorna uma "promessa" de que, no futuro,
    //      entregará uma lista de ofertas ou null se algo der errado.
    //      O '?' indica que o retorno pode ser nulo.
    public async Task<List<Oferta>?> BuscarOfertasAsync()
    {
        Console.WriteLine("Iniciando busca de ofertas na API...");

        // 3. O bloco 'try-catch' está DENTRO do método Main.
        try
        {
            var url = "https://www.cheapshark.com/api/1.0/deals";

            // Lê o corpo da resposta como uma string.
            string jsonResponse = await cliente.GetStringAsync(url);

            var ofertas = JsonSerializer.Deserialize<List<Oferta>>(jsonResponse);

            return ofertas;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro na requisição HTTP: {e.Message}");
            return null;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Erro ao processar o JSON: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");
            return null;
        }

        Console.WriteLine("\nPressione qualquer tecla para sair.");
        Console.ReadKey();
        return null;
    }

}
        
    
