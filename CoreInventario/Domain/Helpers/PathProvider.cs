using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Helpers
{
    public enum Folders
    {
        Ejemplo1 = 0, Ejemplo2 = 1
    }

    public class PathProvider
    {
        IWebHostEnvironment environment;

        public PathProvider(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public String MapPath(string Filenombre, string carpetaDest)   //Folders folders
        {
            String carpeta = "";
            carpeta = carpetaDest;

            //if (folders == Folders.Ejemplo1)
            //{
            //    carpeta = "ejemplo1";
            //}
            //else if (folders == Folders.Ejemplo2)
            //{
            //    carpeta = "ejemplo2";
            //}

            String path = Path.Combine(this.environment.WebRootPath, carpeta, Filenombre);

            return path;

        }

        public String MapPath(Folders folders)
        {
            String carpeta = "";
            if (folders == Folders.Ejemplo1)
            {
                carpeta = "ejemplo1";
            }
            else if (folders == Folders.Ejemplo2)
            {
                carpeta = "ejemplo2";
            }

            String path = Path.Combine(this.environment.WebRootPath, carpeta);

            return path;

        }

    }
}
