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
// Valida que un texto obligatorio no esté vacío
// ni contenga únicamente espacios.
static bool ValidarTexto(string texto)
{
    return !string.IsNullOrWhiteSpace(texto);
}
// Valida que el tipo de consulta pertenezca
// a las categorías permitidas.
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
}