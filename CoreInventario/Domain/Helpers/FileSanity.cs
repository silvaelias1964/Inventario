using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Helpers
{
    public class FileSanity
    {
        public String RemoveSpecialCharacters(String stringNombre, String filename)
        {
            String texto = stringNombre.Trim().ToLower();
            String extension = filename.Substring(filename.LastIndexOf("."));
            texto = Regex.Replace(stringNombre, "[^a-zA-Z]+", "", RegexOptions.Compiled);

            texto = texto + extension;
            return texto;
        }
    }
}
