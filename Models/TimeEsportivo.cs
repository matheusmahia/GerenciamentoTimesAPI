using System.ComponentModel.DataAnnotations;

public class TimeEsportivo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Modalidade { get; set; } = string.Empty;

    [Range(1, 100)]
    public int NumeroJogadores { get; set; }

    [Required]
    [Range(1800, 2100)]
    public int AnoFundacao { get; set; }
}