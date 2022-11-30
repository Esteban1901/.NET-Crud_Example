using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace BLL
{
    public class CategoriaBLL
    {
        TareasPendientesEntities tp = new TareasPendientesEntities();

        public void Add(string nombre)
        {

            if (Get(nombre) == null)
            {
                Categoría nueva = new Categoría();
                nueva.Nombre = nombre;

                tp.Categoría.Add(nueva);
                tp.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Categoría ya existe");
            }

            
        }

        public Categoría Get(string nombre)
        {
            Categoría categoria = tp.Categoría.Where(c => c.Nombre == nombre).FirstOrDefault();

            return categoria;
        }

        public List<Categoría> GetAll()
        {
            return tp.Categoría.ToList();
        }

        public void Delete(string nombre)
        {
            Categoría c = Get(nombre);

            if (c != null)
            {
                tp.Categoría.Remove(c);
                tp.SaveChanges();
            }
        }
    }
}
