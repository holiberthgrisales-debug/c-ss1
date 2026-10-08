
class Mascota
{
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public int Edad { get; set; }

    public Mascota(string nombre, string especie, int edad)
    {
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Mascota: {Nombre}, especie: {Especie}, edad: {Edad} años");
    }
}

class Libro
{
    private string titulo, autor;
    private bool prestado;

    public Libro(string titulo, string autor)
    {
        this.titulo = titulo;
        this.autor = autor;
    }

    public Libro(string titulo) : this(titulo, "Anónimo")
    {
    }

    public void Prestar()
    {
        prestado = true;
    }

    public string Descripcion()
    {
        var estado = prestado ? "prestado" : "disponible";
        return $"{titulo} - {autor} [{estado}]";
    }
}

class EjemploConstructores
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }

    public EjemploConstructores()
    {
        Nombre = "Sin nombre";
        Cantidad = 0;
    }

    public EjemploConstructores(string nombre)
    {
        Nombre = nombre;
        Cantidad = 0;
    }

    public EjemploConstructores(string nombre, int cantidad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre: {Nombre}, cantidad: {Cantidad}");
    }
}

class Program
{
    static void Main()
    {
        Mascota miMascota = new Mascota("Luna", "Perro", 3);
        Libro miLibro = new Libro(
            "El Principito",
            "Antoine de Saint-Exupéry"
        );
        miMascota.MostrarDatos();
        Console.WriteLine(miLibro.Descripcion());
        miLibro.Prestar();
        Console.WriteLine(miLibro.Descripcion());
        Console.WriteLine("Los constructores de la clase EjemploConstructores");
        EjemploConstructores objeto1 = new EjemploConstructores();
        EjemploConstructores objeto2 = new EjemploConstructores("Cuaderno");
        EjemploConstructores objeto3 = new EjemploConstructores("Lápiz", 12);
        objeto1.MostrarDatos();
        objeto2.MostrarDatos();
        objeto3.MostrarDatos();
    }
}