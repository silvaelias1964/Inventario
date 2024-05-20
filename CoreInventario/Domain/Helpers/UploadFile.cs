using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Domain.Helpers
{
    public class UploadFile
    {
        PathProvider path;
        FileSanity sanity;

        public UploadFile(PathProvider path, FileSanity sanity)
        {
            this.path = path;
            this.sanity = sanity;
        }


        public async Task SubirFichero(IFormFile imagen, string destino)
        {

            String filename = "";
            String ruta = "";
            if (imagen != null)
            {
                filename = imagen.FileName;

                ruta = this.path.MapPath(filename, destino);  //Folders.Ejemplo1

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }
            }

        }

        public async Task SubirFichero(String nombre, IFormFile imagen, string destino)
        {

            String filename = "";
            String ruta = "";
            if (imagen != null)
            {
                filename = this.sanity.RemoveSpecialCharacters(nombre, imagen.FileName);

                ruta = this.path.MapPath(filename, destino);  //Folders.Ejemplo1

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }
            }

        }
        public void EliminarFichero(String fotosnombre, string folder) //Folders folder
        {
            String ruta = this.path.MapPath(fotosnombre, folder);
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
        }

    }
}
