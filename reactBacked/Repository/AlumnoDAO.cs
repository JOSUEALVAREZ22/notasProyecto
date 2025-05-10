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
            alumnoUpdate.Edad = actualizar.Edad;
            alumnoUpdate.Nombre = actualizar.Nombre;
            alumnoUpdate.Email = actualizar.Email;

            contexto.Alumnos.Update(alumnoUpdate);
            contexto.SaveChanges();
            return true;
        }
        #region Delete
        public bool deleteAlumno(int id)
        {
            var borrar = GetById(id);
            try
            {
                if (borrar == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(borrar);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

    }
    #endregion
}






