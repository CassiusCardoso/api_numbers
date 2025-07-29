using api_numbers.model;
using System.Text.Json; 

namespace api_numbers.api;

public class SerializerService
{
	public static string SerializarOferta(Oferta oferta)
	{

		// Serializando com formata��o
		var options = new JsonSerializerOptions{
			WriteIndented = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

		string jsonFormatado = JsonSerializer.Serialize(oferta, options);
		Console.WriteLine("Oferta serializada com formata��o:");
		return jsonFormatado;
	}

}