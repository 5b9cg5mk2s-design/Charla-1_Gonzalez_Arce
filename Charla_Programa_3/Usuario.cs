namespace Charla_Programa_3
{
    public class Usuario
    {
        public string Nombre { get; private set; }

        public int Edad { get; private set; }

        public string Correo { get; private set; }

        public string Rol { get; private set; }


        public Usuario(string nombre, int edad, string correo, string rol)
        {
            Nombre = nombre;
            Edad = edad;
            Correo = correo;
            Rol = rol;
        }


        public bool EsAdministrador()
        {
            return Rol == "Administrador";
        }
    }
}