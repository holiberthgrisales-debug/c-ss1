
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
        Console.WriteLine($"Mascota: {Nombre}, especie: {Especie}, edad: {Edad} Fichas");
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

class Temperatura
{
    public double Celsius
    {
        get;
        set
        {
            if (value < -273.15)
                throw new ArgumentOutOfRangeException(nameof(value));
            field = value;
        }
    }

    public double Fahrenheit => Celsius * 9 / 5 + 32;
}

class CuentaBancaria
{
    public string Titular
    {
        get;
        set => field = value?.Trim() ?? "";
    } = "";

    public decimal Saldo { get; private set; }

    public void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentException("El monto debe ser positivo");
        Saldo += monto;
    }

    public bool Retirar(decimal monto)
    {
        if (monto <= 0 || monto > Saldo) return false;
        Saldo -= monto;
        return true;
    }
}

class Persona{ 
    public string Nombre { get; set; } = "";
    public int Edad { get; set; }
    

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;

        Console.WriteLine($"Persona creada: {Nombre}, edad: {Edad}");
    }
}

class Empleado : Persona
{
    public string Puesto { get; set; } = "";

    public Empleado(string nombre, int edad, string puesto) : base(nombre, edad)
    {
        Puesto = puesto;
        Console.WriteLine($"Empleado creado: {Nombre}, edad: {Edad}, puesto: {Puesto}");
    }
}

class Vehiculo ( string placa)
{
    protected string Placa { get; } = placa;
    public string Describir()
    {
        return $"Vehículo: {Placa}";
    }
}

class Auto (string placa, int puertas) : Vehiculo(placa)
{
   public string Detalle()
    {
        return $"Auto: {Describir()}, puertas: {puertas}";
    }
}

class Moto (string placa, bool tieneCasco) : Vehiculo(placa)
{
    public string Detalle()
    {
        return $"Moto: {Describir()}, tiene casco: {tieneCasco}";
    }
}

class Persona1
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Documento { get; set; }

    public Persona1(string nombre, string apellido, int documento)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Documento = documento;
    }

    public virtual  void Presentarse()
    {
        Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}");
    }
}

class Aprendiz : Persona1
{
    public string programadeformacion { get; set; }
    public int Ficha { get; set; }

    public Aprendiz(string nombre,string apellido,int documento,string programadeformacion,
        int ficha) : base(nombre, apellido, documento)
    {
        this.programadeformacion = programadeformacion;
        this.Ficha = ficha;
    }
    public override void Presentarse()
    {
        Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, Programa de formación: {programadeformacion}, Ficha: {Ficha}");
    }
}

class Polimorfismo { public static string Describir(object? o) => o 
switch { 
    int n => $"entero {n}", 
    string s => $"texto {s}", 
    null => "nada", 
    _ => "otro" }; }

class Producto(string nombre, decimal precio)
{
    public override string ToString() => $"{nombre} - {precio}";
}

abstract class Notificador
{
    protected abstract string Canal { get; }
    protected abstract void Enviar(string mensaje);

    public void Notificar(string mensaje)
    {
        Console.WriteLine($"[LOG] Enviando por {Canal}");
        Enviar(mensaje);
    }
}

class Email(string direccion) : Notificador
{
    protected override string Canal => "Email";
    protected override void Enviar(string mensaje) =>
        Console.WriteLine($"Email a {direccion}: {mensaje}");
}

class Sms(string numero) : Notificador
{
    protected override string Canal => "Sms";
    protected override void Enviar(string mensaje) =>
        Console.WriteLine($"Sms a {numero}: {mensaje}");
}

interface IDescontable
{
    decimal Precio { get; }
    decimal PrecioConDescuento(decimal pct) => Precio - Precio * pct / 100;
}

class Camiseta(decimal precio) : IDescontable
{
    public decimal Precio { get; } = precio;
}

interface IMovible { void Mover(); }
interface IHablante { void Hablar(); }

class Robot : IMovible, IHablante
{
    public void Mover() => Console.WriteLine("Avanzo");
    public void Hablar() => Console.WriteLine("Hola, soy Robot");
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
        EjemploConstructores objeto1 = new EjemploConstructores("yared y jennefifer", 1);
        EjemploConstructores objeto2 = new EjemploConstructores("Cuaderno");
        EjemploConstructores objeto3 = new EjemploConstructores("Lápiz", 12);
        objeto1.MostrarDatos();
        objeto2.MostrarDatos();
        objeto3.MostrarDatos();
        Console.WriteLine("");
        Console.WriteLine("parte de encalsulamiento de propiedades");
        var t = new Temperatura { Celsius = 100 };
        Console.WriteLine(t.Fahrenheit);
        Console.WriteLine("parte de encalsulamiento de propiedades con el ejemplo de cuenta bancaria");
        var cuenta = new CuentaBancaria { Titular = "  Laura Gómez  " };
        cuenta.Depositar(500_000m);
        bool ok = cuenta.Retirar(700_000m);
        Console.WriteLine($"{cuenta.Titular}|{cuenta.Saldo}|{ok}");
        cuenta.Retirar(200_000m);
        Console.WriteLine(cuenta.Saldo);
        Console.WriteLine("");
        Console.WriteLine("parte de herencia 1");
        var persona = new Persona("Juan", 30);
        var empleado = new Empleado("Ana", 28, "Ingeniera");
        Console.WriteLine("");
        Console.WriteLine("parte de herencia 2");
        var auto = new Auto("ABC123", 4);
        var moto = new Moto("XYZ789", true);
        Console.WriteLine(auto.Detalle());
        Console.WriteLine(moto.Detalle());
        Console.WriteLine("");
        Console.WriteLine("parte de herencia 3");
        var Persona1 = new Persona1("Juan", "Pérez", 12345678);
        var Aprendiz = new Aprendiz("Maria", "Gómez", 87654321, "Ingenieria  de promts", 12345);
        Persona1.Presentarse();
        Aprendiz.Presentarse(); 
         Console.WriteLine("");
        Console.WriteLine("parte de Polimosrfismo");
        Console.WriteLine(Polimorfismo.Describir(42));
        Console.WriteLine(Polimorfismo.Describir("Hola"));
        Console.WriteLine(Polimorfismo.Describir(null));
        Console.WriteLine(Polimorfismo.Describir(3.14));
        Console.WriteLine("");
        Console.WriteLine("parte de Polimosrfismo con el ejemplo de producto");
        Console.WriteLine(new Producto("Café", 4500));
        Console.WriteLine("");
        Console.WriteLine("parte de abstracción con el ejemplo de notificador");
        Notificador[] canales = [new Email("ana@mail.com"), new Sms("3001234567")];
        foreach (var c in canales)
        c.Notificar("Tu pedido salió");
        Console.WriteLine("");
        Console.WriteLine("parte de interfaz con el ejemplo de camiseta");
        IDescontable item = new Camiseta(50_000m);
        Console.WriteLine(item.PrecioConDescuento(20));
        Console.WriteLine("");
        var r = new Robot();
        r.Mover();
        r.Hablar();
    }   

}