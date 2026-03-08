using System;
using System.Collections.Generic;

namespace BibliotecaApp
{
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return $"ISBN: {ISBN} | Título: {Titulo} | Autor: {Autor} | Categoría: {Categoria}";
        }
    }

    public class Biblioteca
    {
        private Dictionary<string, Libro> catalogoLibros;
        private HashSet<string> categoriasUnicas;

        public Biblioteca()
        {
            catalogoLibros = new Dictionary<string, Libro>();
            categoriasUnicas = new HashSet<string>();
        }

        public void AgregarLibro(string isbn, string titulo, string autor, string categoria)
        {
            if (catalogoLibros.ContainsKey(isbn))
            {
                Console.WriteLine($"[Error] El libro con ISBN {isbn} ya está registrado.");
                return;
            }

            Libro nuevoLibro = new Libro { ISBN = isbn, Titulo = titulo, Autor = autor, Categoria = categoria };
            catalogoLibros.Add(isbn, nuevoLibro);
            categoriasUnicas.Add(categoria);
            Console.WriteLine($"[Éxito] Libro '{titulo}' agregado correctamente.");
        }

        public void MostrarTodosLosLibros()
        {
            Console.WriteLine("\n--- Catálogo Completo ---");
            foreach (var kvp in catalogoLibros)
            {
                Console.WriteLine(kvp.Value.ToString());
            }

            Console.WriteLine("\n--- Categorías Disponibles ---");
            foreach (var cat in categoriasUnicas)
            {
                Console.WriteLine($"- {cat}");
            }
        }

        public void ConsultarPorISBN(string isbn)
        {
            Console.WriteLine($"\n--- Consultando ISBN: {isbn} ---");
            if (catalogoLibros.TryGetValue(isbn, out Libro libroEncontrado))
            {
                Console.WriteLine(libroEncontrado.ToString());
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca miBiblioteca = new Biblioteca();
            miBiblioteca.AgregarLibro("978-3", "Redes de Computadoras", "Tanenbaum", "Tecnología");
            miBiblioteca.AgregarLibro("978-0", "Sistemas Operativos", "Tanenbaum", "Tecnología");
            miBiblioteca.AgregarLibro("978-8", "Metodología", "Sampieri", "Académico");
            
            miBiblioteca.MostrarTodosLosLibros();
            miBiblioteca.ConsultarPorISBN("978-0");
        }
    }
}