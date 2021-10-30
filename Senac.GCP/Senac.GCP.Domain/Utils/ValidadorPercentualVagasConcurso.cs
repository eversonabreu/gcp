namespace Senac.GCP.Domain.Utils
{
    public static class ValidadorPercentualVagasConcurso
    {
        public static bool Validar(int percentual, out int percentualValido)
        {
            percentualValido = 100;
            return true;
        }
    }
}