namespace Senac.GCP.Domain.Utils
{
    public static class ValidadorCNPJ
    {
        public static bool Validar(string cnpj, out string CNPJValido)
        {
            try
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma, resto;
                string digito, tempCnpj;

                string CNPJAuxiliar = string.Empty;

                foreach (char ch in cnpj)
                    if (char.IsDigit(ch))
                        CNPJAuxiliar += ch;

                if (CNPJAuxiliar.Length != 14)
                    throw new System.Exception();

                tempCnpj = CNPJAuxiliar.Substring(0, 12);
                soma = 0;

                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();
                tempCnpj += digito;
                soma = 0;

                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito += resto.ToString();
                CNPJValido = CNPJAuxiliar;
                return CNPJAuxiliar.EndsWith(digito);
            }
            catch
            {
                CNPJValido = null;
                return false;
            }
        }
    }
}