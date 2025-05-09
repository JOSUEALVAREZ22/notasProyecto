using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using reactBacked.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBacked.Repository
{
    public class AlumnoDAO
    {
        public RegistroAlumnoContext contexto = new RegistroAlumnoContext();

        public List<Alumno> SelectAll()
        {
            var alumnos = contexto.Alumnos.ToList();
            return alumnos;
        }

        public Alumno? GetById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }
        public bool insertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno
                {
                    Direccion = alumno.Direccion,
                    Edad = alumno.Edad,
                    Email = alumno.Email,
                    Dni = alumno.Dni
                };

                contexto.Alumnos.Add(alum);

                contexto.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
                public bool update(int id, Alumno actualizar)
        {
            var alumnoUpdate = GetById(id);

            if (alumnoUpdate == null)
            {
                Console.WriteLine("Alumno es null");
                return false;
            }

            alumnoUpdate.Direccion = actualizar.Direccion;
            alumnoUpdate.Dni = actualizar.Dni;
            alumnoUpdate.Nombre = actualizar.Nombre;
            alumnoUpdate.Email = actualizar.Email;

            contexto.Alumnos.Update(alumnoUpdate);
            contexto.SaveChanges();
            return true;

                var nuevoAlumno2 = new Alumno
            {
                Direccion = "Chalatenango, Barrio el centro",
                Dni = "1345",
                Edad = 30,
                Email = "5@email",
                Nombre = "Wiliams"
            };

            var resultado2 = alumnoDao.update(2, nuevoAlumno2);
            Console.WriteLine(resultado2);
        }
    }
            
        }

    


     


