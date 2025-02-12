namespace VerificaCPF.Model
{
    public class Cpf
    {
        public string? CpfCompleto { get; set; }
        public int[]? DigitosBase { get; set; }
        public int[]? DigitosVerificadores { get; set; }
        public int[]? DigitosVerificadoresCorretos { get; set; }
        public bool Valido { get; set; }

        static int[] CalculaDigitos(int[] CpfDigitos)
        {
            int[] SequenciaNumeros = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            if (CpfDigitos.Length > 9) { SequenciaNumeros = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2]; }

            /* loop para calcular o digito verificador */
            int Soma = 0;
            int Contagem = 0;
            foreach (var Digito in CpfDigitos)
            {
                Soma += Digito * SequenciaNumeros[Contagem];
                Contagem++;
            }
            int NovoDigito = 11 - (Soma % 11);
            if (NovoDigito > 9)
            {
                NovoDigito = 0;
            }

            /*reajuste de tamanho do array*/
            Array.Resize(ref CpfDigitos, CpfDigitos.Length + 1);
            CpfDigitos[CpfDigitos.Length - 1] = NovoDigito;

            /*verifica se ja foram calculados os dois digitos*/
            if (CpfDigitos.Length > 10)
            {
                int[] DigitosVerificadoresCorretos = { CpfDigitos[CpfDigitos.Length - 2], CpfDigitos[CpfDigitos.Length - 1] };
                return DigitosVerificadoresCorretos;
            }
            else
            {
                return CalculaDigitos(CpfDigitos);
            }
        }
        public Cpf(string? StringCpf)
        {
            CpfCompleto = StringCpf;

            if (CpfCompleto is null || CpfCompleto.Length != 11 || CpfCompleto.All(char.IsDigit) == false)
            {
                Valido = false;
            }
            else
            {
                DigitosBase = Array.ConvertAll(CpfCompleto.Substring(0, 9).ToCharArray(), c => c - '0');
                DigitosVerificadores = Array.ConvertAll(CpfCompleto.Substring(9, 2).ToCharArray(), c => c - '0');

                DigitosVerificadoresCorretos = CalculaDigitos(DigitosBase);

                if (Enumerable.SequenceEqual(DigitosVerificadores, DigitosVerificadoresCorretos))
                {
                    Valido = true;
                }
                else
                {
                    Valido = false;
                }
            }
        }

    }

}
