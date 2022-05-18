using SQLiteLibros.Model;
using SQLiteLibros.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteLibros.ViewModel
{
    public class InicioViewModel : BaseViewModel
    {
        private LibroRespository LibrosDB = new LibroRespository();
        public ObservableCollection<Libro> Libros { get; set; }

        public ICommand cmdAgregaLibro { get; set; }
        public ICommand cmdModifcaLibro { get; set; }

        public InicioViewModel()
        {
            Libros = new ObservableCollection<Libro>();
            cmdAgregaLibro = new Command(() => cmdAgregaLibroMetodo());
            cmdModifcaLibro= new Command<Libro>((item) => cmdModificaLibroMetodo(item));

        }

        private void cmdModificaLibroMetodo(Libro libro)
        {
            //App.Current.MainPage.Navigation.PushAsync(new MattoContacto(contacto));
        }

        private void cmdAgregaLibroMetodo()
        {

            Libro libro = new Libro() { Autor = "Mishub", Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ", Editorial = "Lorem ipsum", Titulo = "Advanced Python Programming", FechaPublicacion = "17/05/2022" };
                //.RuleFor(c => c.Avatar, f => f.Person.Avatar)
                //.RuleFor(c => c.Nombre, f => f.Name.FirstName())
                //.RuleFor(c => c.ApellidoPaterno, f => f.Name.LastName())
                //.RuleFor(c => c.ApellidoMaterno, f => f.Name.LastName())
                //.RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nombre, c.ApellidoPaterno)).Generate();

            LibrosDB.InsertOrUpdate(libro);
            OnPropertyChanged();
            this.Libros.Add(libro);


            //App.Current.MainPage.Navigation.PushAsync(new MattoContacto(contacto));

        }

        public void GetAll()

        {
            if (Libros != null)
            {
                Libros.Clear();
                LibrosDB.GetAll().ForEach(item => Libros.Add(item));
            }
            else
            {
                Libros = new ObservableCollection<Libro>(LibrosDB.GetAll());
            }
            OnPropertyChanged();
        }


    }
}
