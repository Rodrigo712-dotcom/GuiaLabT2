using System;
class Program
{
    static bool ValidarCodigo(string codigo)
{
    if (string.IsNullOrWhiteSpace(codigo))
    {
        return false;
    }
    if (codigo.Length < 6)
    {
        return false;
    }
    foreach (char caracter in codigo)
    {
        if (!char.IsDigit(caracter))
        {
            return false;
        }
    }
    return true;
}
static bool ValidarTexto(string texto)
{
    return !string.IsNullOrWhiteSpace(texto);
}
static bool ValidarTipoConsulta(string tipo)
{
    tipo = tipo.ToLower().Trim();
    if (tipo == "matrícula" ||
        tipo == "pagos" ||
        tipo == "constancia" ||
        tipo == "plataforma" ||
        tipo == "otro")
    {
        return true;
    }
    return false;
}
static string AsignarPrioridad(string tipo)
{
    tipo = tipo.ToLower().Trim();

    if (tipo == "pagos" || tipo == "plataforma")
    {
        return "Alta";
    }

    if (tipo == "matrícula")
    {
        return "Media";
    }

    return "Baja";
}
static void MostrarResumen(
    string codigo,
    string nombre,
    string tipo,
    string descripcion,
    string prioridad)
{
    Console.WriteLine();
    Console.WriteLine("=================================");
    Console.WriteLine("      RESUMEN DE SOLICITUD");
    Console.WriteLine("=================================");

    Console.WriteLine("Código: " + codigo);
    Console.WriteLine("Nombre: " + nombre);
    Console.WriteLine("Tipo de consulta: " + tipo);
    Console.WriteLine("Descripción: " + descripcion);
    Console.WriteLine("Prioridad: " + prioridad);

    Console.WriteLine("=================================");
}
static void RegistrarSolicitud()
{
    Console.WriteLine();
    Console.WriteLine("--- REGISTRO DE SOLICITUD ---");

    // Solicitar código.
    Console.Write("Ingrese el código de estudiante: ");
    string codigo = Console.ReadLine() ?? "";

    // Validar código.
    if (!ValidarCodigo(codigo))
    {
        Console.WriteLine("Código inválido.");
        return;
    }

    // Solicitar nombre.
    Console.Write("Ingrese el nombre: ");
    string nombre = Console.ReadLine() ?? "";

    // Validar nombre.
    if (!ValidarTexto(nombre))
    {
        Console.WriteLine("El nombre no puede estar vacío.");
        return;
    }

    // Solicitar tipo de consulta.
    Console.Write("Ingrese el tipo de consulta: ");
    string tipo = Console.ReadLine() ?? "";

    // Validar tipo de consulta.
    if (!ValidarTipoConsulta(tipo))
    {
        Console.WriteLine("Tipo de consulta inválido.");
        return;
    }

    // Solicitar descripción.
    Console.Write("Ingrese una descripción: ");
    string descripcion = Console.ReadLine() ?? "";

    // Validar descripción.
    if (!ValidarTexto(descripcion))
    {
        Console.WriteLine("La descripción no puede estar vacía.");
        return;
    }

    // Asignar prioridad.
    string prioridad = AsignarPrioridad(tipo);

    // Mostrar resumen.
    MostrarResumen(
        codigo,
        nombre,
        tipo,
        descripcion,
        prioridad
    );
}
static void Main()
    {
        RegistrarSolicitud();
    }
}