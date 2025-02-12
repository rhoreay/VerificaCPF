# VerificaCPF

Uma Rest API feita em ASP.NET Core.
Funciona como um verificador de validade de cpf.
```bash
https://localhost:7185/api/Cpf?CpfCompleto=<cpf>
```
O algoritmo de validação funciona com um método da Classe Cpf que recebe os dígitos base como parâmetro e é chamado
recusrivamente para calcular os dois dígitos verificadores.

#Response

A API retorna o objeto CPF, que possui as seguintes propriedades:
```C#
public class Cpf
{
    public string? CpfCompleto { get; set; }
    public int[]? DigitosBase { get; set; }
    public int[]? DigitosVerificadores { get; set; }
    public int[]? DigitosVerificadoresCorretos { get; set; }
    public bool Valido { get; set; }
}
```
Se os dígitos verificadores calculados forem iguais aos dígitos verificadores enviados pelo request, a proriedade 'Valido' é definida como true.
