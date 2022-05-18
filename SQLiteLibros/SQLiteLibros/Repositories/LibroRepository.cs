using SQLite;
using SQLiteLibros.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SQLiteLibros.Repositories
{
    public class LibroRespository
    {

        SQLiteConnection connection;
        public LibroRespository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Libro>();
        }

        public void InsertOrUpdate(Libro libro)
        {
            if (libro.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {libro.Id}");
                connection.Insert(libro);
                Debug.WriteLine($"Id despues de registrar {libro.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {libro.Id}");
                connection.Update(libro);
                Debug.WriteLine($"Id despues de actualizar {libro.Id}");
            }
        }

        public Libro GetById(int Id)
        {
            return connection.Table<Libro>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();
        }

        public List<Libro> GetAll()
        {

            return connection.Table<Libro>().ToList();
        }


        public void DeleteItem(int Id)
        {
            Libro libro = GetById(Id);
            connection.Delete(libro);
        }

    }
}
