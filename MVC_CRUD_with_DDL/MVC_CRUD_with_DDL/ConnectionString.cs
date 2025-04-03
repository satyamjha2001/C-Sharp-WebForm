namespace MVC_CRUD_with_DDL
{
    public static class ConnectionString
    {
        private static string cs = "Server=.; Database=mvcdb; Integrated Security=True; TrustServerCertificate=True;";

        public static string dbcs { get => cs; }
    }
}
