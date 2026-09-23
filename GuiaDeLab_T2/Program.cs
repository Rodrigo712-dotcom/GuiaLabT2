using System;

class Program
{
    // Valida que el código no esté vacío,
    // tenga como mínimo 6 caracteres
    // y contenga solamente números.
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

    // Valida que un texto obligatorio no esté vacío.
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

    // Asigna una prioridad dependiendo del tipo de consulta.
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

    // Muestra los datos de una solicitud registrada.
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

    // Solicita los datos de una solicitud,
    // realiza las validaciones y asigna la prioridad.
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

    // Muestra el menú principal.
    static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine("       SOPORTE ACADÉMICO");
        Console.WriteLine("=================================");
        Console.WriteLine("1. Registrar solicitud");
        Console.WriteLine("2. Salir");
        Console.WriteLine("=================================");
    }

    // Función principal del programa.
    static void Main()
    {
        int opcion = 0;

        while (opcion != 2)
        {
            MostrarMenu();

            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine() ?? "";

            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine("Debe ingresar una opción numérica.");
                continue;
            }

            if (opcion == 1)
            {
                RegistrarSolicitud();
            }
            else if (opcion == 2)
            {
                Console.WriteLine("Programa finalizado.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}
