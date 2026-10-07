namespace Charla_Programa_3
{
    public static class Validaciones
    {
        public static bool NombreValido(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre);
        }

        public static bool EdadValida(string textoEdad, out int edad)
        {
            return int.TryParse(textoEdad, out edad)
                   && edad >= 18
                   && edad <= 100;
        }

        public static bool CorreoValido(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                return false;
            }

            correo = correo.Trim();

            int posicionArroba = correo.IndexOf('@');
            int posicionPunto = correo.LastIndexOf('.');

            return posicionArroba > 0
                   && posicionPunto > posicionArroba + 1
                   && posicionPunto < correo.Length - 1;
        }
    }
}