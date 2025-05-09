using reactBacked.Repository;

AlumnoDao alumnoDao = new AlumnoDao();
var alumnos = alumnoDao.SelectAll();

foreach (var item in alumnos)
{
    Console.WriteLine(item.Nombre);
}

