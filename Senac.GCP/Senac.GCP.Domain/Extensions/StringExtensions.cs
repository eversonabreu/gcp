using Senac.GCP.Domain.Exceptions;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string GetFileName(this string fileName)
        {
            if (fileName is null)
                throw new ArgumentNullException(nameof(fileName));

            if (fileName.Contains('.'))
            {
                string name = Reverse(fileName);
                int indexExtension = name.IndexOf('.') + 1;
                name = name.Substring(indexExtension);
                return Reverse(name);
            }

            return fileName;
        }

        public static string GetFileExtension(this string fileName)
        {
            if (fileName is null)
                throw new ArgumentNullException(nameof(fileName));

            if (fileName.Contains('.'))
            {
                string name = Reverse(fileName);
                name = name.Split('.').First();
                if (string.IsNullOrWhiteSpace(name))
                    throw new BusinessException("O arquivo não possui extensão");

                return Reverse(name);
            }

            throw new BusinessException("O arquivo não possui extensão");
        }

        public static string Reverse(this string value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            var arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}