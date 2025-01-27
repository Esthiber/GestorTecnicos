namespace GestorTecnicos.Components
{
    public static class Urls
    { // Referencias URL de las páginas de la aplicación
        public static string Home => "/";
        public static string TecnicosIndex => "/tecnicos"; // URL de la página de inicial de la lista de técnicos
        public static string TecnicosCrear => "/tecnicos/create";
        public static string TecnicosEditar => "/tecnicos/edit";

        public static string ClientesIndex => "/clientes"; // URL de la página de inicial de la lista de clientes
        public static string ClientesCrear => "/clientes/create";
        public static string ClientesEditar => "/clientes/edit";

        public static string CiudadesIndex => "/ciudades"; // URL de la página de inicial de la lista de ciudades
        public static string CiudadesCrear => "/ciudades/create";
        public static string CiudadesEditar => "/ciudades/edit";
    }
}
