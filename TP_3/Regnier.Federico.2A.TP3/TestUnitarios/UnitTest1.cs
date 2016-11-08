using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGimnasio()
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
                Assert.IsTrue(i1.ToString().Contains("Pilates"));
                Assert.IsTrue(gim1.ToString().Contains("NOMBRE COMPLETO: Lopez, Jorge"));
            }
            catch (SinInstructorException e)
            {
                Assert.IsFalse(i1.ToString().Contains("Pilates"));
            }

            try
            {
                gim1 += Gimnasio.EClases.Natacion;
                Assert.IsTrue(i1.ToString().Contains("Natacion"));
                Assert.IsTrue(gim1.ToString().Contains("NOMBRE COMPLETO: Perez, Juan"));
            }
            catch (SinInstructorException e)
            {
                Assert.IsFalse(i1.ToString().Contains("Natacion"));
            }

            try
            {
                gim1 += Gimnasio.EClases.CrossFit;
                Assert.IsTrue(i1.ToString().Contains("CrossFit"));
                Assert.IsTrue(gim1.ToString().Contains("NOMBRE COMPLETO: Fernandez, Jose"));
            }
            catch (SinInstructorException e)
            {
                Assert.IsFalse(i1.ToString().Contains("CrossFit"));
            }

            try
            {
                gim1 += Gimnasio.EClases.Yoga;
                Assert.IsTrue(i1.ToString().Contains("Yoga"));
                Assert.IsTrue(gim1.ToString().Contains("NOMBRE COMPLETO: Asd, Martin"));
            }
            catch (SinInstructorException e)
            {
                Assert.IsFalse(i1.ToString().Contains("Yoga"));
            }

        }

        [TestMethod]
        public void TestAlumno()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "36000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates);
            
            Assert.IsNotNull(a1);
            Assert.AreEqual("Juan", a1.Nombre);
            Assert.AreEqual("Lopez", a1.Apellido);
            Assert.AreEqual(36000000, a1.DNI);
            Assert.AreEqual(Persona.ENacionalidad.Argentino, a1.Nacionalidad);

            Alumno a2 = new Alumno(1, "Juan", "Lopez", "36000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates);

            Assert.AreEqual<Alumno>(a2, a1);

        }

        [TestMethod]
        public void TestNacionalidad()
        {
            Alumno a1 = null;
            try
            {
                a1 = new Alumno(1, "Jose", "Perez", "25000000", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Yoga);
                Assert.Fail("El alumno no deberia crearse");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsNull(a1);
                Assert.AreEqual("La nacionalidad no se condice con el numero de DNI", e.Message);
            }

            try
            {
                a1 = new Alumno(1, "Jose", "Perez", "92000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Yoga);
                Assert.Fail("El alumno no deberia crearse");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsNull(a1);
                Assert.AreEqual("La nacionalidad no se condice con el numero de DNI", e.Message);
            }

        }

    }
}
