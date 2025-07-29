using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Globalization;

namespace api_numbers.model;

public class Oferta
{
    // PROPRIEDADES SEMPRE COM PascalCase
    // Propriedades que recebem o JSON como STRING
    [JsonPropertyName("dealId")]
    public string? Id { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("salePrice")]
    public string? PrecoVendaString { get; set; }

    [JsonPropertyName("normalPrice")]
    public string? PrecoOriginalString { get; set; }

    [JsonPropertyName("savings")]
    public string? DescontoString { get; set; }

    // --- CORREÇÃO APLICADA AQUI ---
    // Se a string for nula, usamos "0" como padrão antes de fazer o Parse.
    [JsonIgnore]
    public decimal PrecoVenda => decimal.Parse(PrecoVendaString ?? "0", CultureInfo.InvariantCulture);

    [JsonIgnore]
    public decimal PrecoOriginal => decimal.Parse(PrecoOriginalString ?? "0", CultureInfo.InvariantCulture);

    [JsonIgnore]
    public decimal Desconto => decimal.Parse(DescontoString ?? "0", CultureInfo.InvariantCulture);



    public override String ToString() 
    {
        return $"""
            -- Info da Oferta --
            ID: {Id}
            Título: {Title}
            Preço de Venda: {PrecoVenda:C}
            Preço Original: {PrecoOriginal:C}
            Desconto: {Math.Round(Desconto)}
            """;
        }

}

