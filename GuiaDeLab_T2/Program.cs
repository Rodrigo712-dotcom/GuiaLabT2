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
static void Main()
{
    Console.WriteLine("Prueba de asignación de prioridad");

    Console.WriteLine("Pagos: " + AsignarPrioridad("Pagos"));
    Console.WriteLine("Plataforma: " + AsignarPrioridad("Plataforma"));
    Console.WriteLine("Matrícula: " + AsignarPrioridad("Matrícula"));
    Console.WriteLine("Constancia: " + AsignarPrioridad("Constancia"));
    Console.WriteLine("Otro: " + AsignarPrioridad("Otro"));
}
}