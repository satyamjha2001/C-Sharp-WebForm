namespace MVC_CRUD_ADO_NET
{
    public static class ConnectionString
    {
        private static string cs = "Server=.; Database=mvcdb; Integrated Security=True; TrustServerCertificate=True;";

        public static string dbcs { get => cs; }
    }
}
