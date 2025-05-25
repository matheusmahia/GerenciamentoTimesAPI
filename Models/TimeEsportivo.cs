using System.ComponentModel.DataAnnotations;

public class TimeEsportivo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Modalidade { get; set; }

    [Range(1, 100)]
    public int NumeroDeJogadores { get; set; }

    public DateTime DataFundacao { get; set; }
}