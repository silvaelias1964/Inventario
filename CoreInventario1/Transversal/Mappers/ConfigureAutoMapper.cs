using AutoMapper;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Transversal.Mappers
{
    public class ConfigureAutoMapper : Profile
    {
        public ConfigureAutoMapper() 
            : this("MyProfile")
        { 
        }

        protected ConfigureAutoMapper(string profileName)
           : base(profileName)
        {
            CreateMap<Producto, ProductoModel>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();

            //CreateMap<Socios, SociosDTO>().ReverseMap()
            //.ForPath(x => x.Cedula, x => x.MapFrom(y => y.Cedula))
            //.ForPath(x => x.Nombre, x => x.MapFrom(y => y.Nombre))
            //.ForPath(x => x.Apellido, x => x.MapFrom(y => y.Apellido))
            //.ForPath(x => x.Estatus.Id, x => x.MapFrom(y => y.EstatusId))
            //.ForPath(x => x.Estatus.NombreEstatus, x => x.MapFrom(y => y.Estatus));

            //CreateMap<Socios, SociosModel>().ReverseMap()
            //.ForPath(x => x.Id, x => x.MapFrom(y => y.Id))
            //.ForPath(x => x.Cedula, x => x.MapFrom(y => y.Cedula))
            //.ForPath(x => x.Nombre, x => x.MapFrom(y => y.Nombre))
            //.ForPath(x => x.Apellido, x => x.MapFrom(y => y.Apellido))
            //.ForPath(x => x.Estatus.Id, x => x.MapFrom(y => y.EstatusId))
            //.ForPath(x => x.Direccion, x => x.MapFrom(y => y.Direccion))
            //.ForPath(x => x.EmailPrincipal, x => x.MapFrom(y => y.EmailPrincipal))
            //.ForPath(x => x.EmailSecundario, x => x.MapFrom(y => y.EmailSecundario))
            //.ForPath(x => x.TelefonoMovil, x => x.MapFrom(y => y.TelefonoMovil))
            //.ForPath(x => x.TelefonoFax, x => x.MapFrom(y => y.TelefonoFax))
            //.ForPath(x => x.TelefonoOficina, x => x.MapFrom(y => y.TelefonoOficina))
            //.ForPath(x => x.TelefonoPrivado, x => x.MapFrom(y => y.TelefonoPrivado))
            //.ForPath(x => x.EstadoId, x => x.MapFrom(y => y.EstadoId))
            //.ForPath(x => x.CiudadId, x => x.MapFrom(y => y.CiudadId))
            //.ForPath(x => x.MunicipioId, x => x.MapFrom(y => y.MunicipioId))
            //.ForPath(x => x.CargoId, x => x.MapFrom(y => y.CargoId))
            //.ForPath(x => x.CodigoPostal, x => x.MapFrom(y => y.CodigoPostal))
            //.ForPath(x => x.FotoURL, x => x.MapFrom(y => y.FotoURL))
            //.ForPath(x => x.UserName, x => x.MapFrom(y => y.UserName))
            //.ForPath(x => x.PassWord, x => x.MapFrom(y => y.PassWord))
            //.ForPath(x => x.Sexo, x => x.MapFrom(y => y.Sexo))
            //.ForPath(x => x.FechaNacimiento, x => x.MapFrom(y => y.FechaNacimiento))
            //.ForPath(x => x.RolId, x => x.MapFrom(y => y.RolId))
            //.ForPath(x => x.ProfesionId, x => x.MapFrom(y => y.ProfesionId))
            //.ForPath(x => x.FechaCreacion, x => x.MapFrom(y => y.FechaCreacion))
            //.ForPath(x => x.FechaActualizacion, x => x.MapFrom(y => y.FechaActualizacion))
            //.ForPath(x => x.CreadoPor, x => x.MapFrom(y => y.CreadoPor))
            //.ForPath(x => x.ActualizadoPor, x => x.MapFrom(y => y.ActualizadoPor));

            //CreateMap<Cronograma, CronogramaModel>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //CreateMap<CronogramaDetalle, CronogramaDetalleModel>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //CreateMap<CronogramaModel, Cronograma>();

            //CreateMap<Postulacion, PostulacionModel>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //CreateMap<PostulacionDetalle, PostulacionDetalleModel>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //CreateMap<PostulacionModel, Postulacion>();

            //CreateMap<Municipios, MunicipiosDTO>()
            // .ForPath(x => x.Id, x => x.MapFrom(y => y.Id))
            // .ForPath(x => x.NombreMunicipio, x => x.MapFrom(y => y.NombreMunicipio))
            // .ForPath(x => x.CiudadId, x => x.MapFrom(y => y.Ciudades.Id))
            // .ForPath(x => x.CiudadMunicipio, x => x.MapFrom(y => y.Ciudades.NombreCiudad));

            //CreateMap<Municipios, MunicipiosDTO>().ReverseMap()
            //.ForPath(x => x.Id, x => x.MapFrom(y => y.Id))
            //.ForPath(x => x.NombreMunicipio, x => x.MapFrom(y => y.NombreMunicipio))
            //.ForPath(x => x.Ciudades.Id, x => x.MapFrom(y => y.CiudadId))
            //.ForPath(x => x.Ciudades.NombreCiudad, x => x.MapFrom(y => y.CiudadMunicipio));

            //CreateMap<Urbanization, UrbanizationTableDTO>()
            //    .ForPath(x => x.CityId, x => x.MapFrom(y => y.Municipality.City.Id))
            //    .ForPath(x => x.CityName, x => x.MapFrom(y => y.Municipality.City.Name));

        }

    }
}
