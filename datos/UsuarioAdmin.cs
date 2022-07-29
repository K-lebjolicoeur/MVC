using MVCyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCyEF.datos
{
    public class UsuarioAdmin
    {
        public IEnumerable<usuario> Consultar()
        {
            using (Database1MCVyEFEntities contexto = new Database1MCVyEFEntities())
                return contexto.usuario.AsNoTracking().ToList();
            
        }
        public void Guardar(usuario usuario)
        {
            using (Database1MCVyEFEntities contexto = new Database1MCVyEFEntities())
            {
                contexto.usuario.Add(usuario);
                contexto.SaveChanges();

            } 
        }
        // COpnsultar Usuario
        public  usuario Consultar(int id)
        {
            using(Database1MCVyEFEntities contexto = new Database1MCVyEFEntities())
            {
                return contexto.usuario.FirstOrDefault(u => u.Id == id);
            }
            
        }
        // Modificae datos usuario

        public void Modificar( usuario usuario)
        {
            using (Database1MCVyEFEntities contexto = new Database1MCVyEFEntities())
            {
                contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }  
        }
        // Eliminacion de Usuario
        public void Eliminar(usuario usuario)
        {
            using (Database1MCVyEFEntities contexto =new Database1MCVyEFEntities())
            {
                contexto.Entry(usuario).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}