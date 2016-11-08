using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestArchivos
    {
        [TestMethod]
        public void TestTexto()
        {
            Gimnasio gim1 = new Gimnasio();
            gim1 += new Alumno(1, "Juan", "Perez", "36598485", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion);
            gim1 += new Alumno(2, "Jorge", "Lopez", "35598485", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates);
            gim1 += new Alumno(3, "Jose", "Fernandez", "34598485", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
            gim1 += new Alumno(4, "Martin", "Asd", "95666333", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Yoga);
            Instructor i1 = new Instructor(1, "Carlos", "Ramirez", "20000000", Persona.ENacionalidad.Argentino);
            gim1 += i1;
            try
            {
                gim1 += Gimnasio.EClases.Pilates;
                goto End;
            }
            catch (SinInstructorException e)
            {
                
            }

            try
            {
                gim1 += Gimnasio.EClases.Natacion;
                goto End;
            }
            catch (SinInstructorException e)
            {
                
            }

            try
            {
                gim1 += Gimnasio.EClases.CrossFit;
                goto End;
            }
            catch (SinInstructorException e)
            {
                
            }

            try
            {
                gim1 += Gimnasio.EClases.Yoga;
                goto End;
            }
            catch (SinInstructorException e)
            {

            }

        End:
            Jornada.Guardar(gim1[0]);
            string aux;
            if (Jornada.Leer(out aux))
            {
                Assert.AreEqual(gim1[0].ToString(), aux);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}
