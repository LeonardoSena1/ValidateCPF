namespace ValidateCPF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite um número de CPF (apenas dígitos): ");
            string cpf = Console.ReadLine();

            if (ValidarCPF(cpf))            
                Console.WriteLine("CPF válido!");            
            else            
                Console.WriteLine("CPF inválido!");            
        }

        static bool ValidarCPF(string cpf)
        {
            // Remover caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
            {
                return false;
            }

            // Verificar se todos os dígitos são iguais (CPF inválido)
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Calcular o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }
            int primeiroDigito = (soma * 10) % 11;
            if (primeiroDigito == 10)
            {
                primeiroDigito = 0;
            }

            // Calcular o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }
            int segundoDigito = (soma * 10) % 11;
            if (segundoDigito == 10)
            {
                segundoDigito = 0;
            }

            // Verificar se os dígitos verificadores calculados coincidem com os dígitos do CPF
            return (cpf[9] - '0' == primeiroDigito) && (cpf[10] - '0' == segundoDigito);
        }
    }
}