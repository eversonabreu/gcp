namespace Senac.GCP.Domain.Utils
{
    public static class ValidadorCPF
    {
        public static bool Validar(string cpf, out string CPFValido)
        {
            try
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf, digito;
                int soma, resto;

                string CPFAuxiliar = string.Empty;

                foreach (char ch in cpf)
                    if (char.IsDigit(ch))
                        CPFAuxiliar += ch;

                if (CPFAuxiliar.Length != 11)
                    throw new System.Exception();

                tempCpf = CPFAuxiliar.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();
                tempCpf += digito;
                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito += resto.ToString();
                CPFValido = CPFAuxiliar;
                return CPFAuxiliar.EndsWith(digito);
            }
            catch
            {
                CPFValido = null;
                return false;
            }
        }
    }
}