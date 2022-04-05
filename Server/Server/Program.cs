namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataBase dataBase = new SqlDataBase();
            RequestHandlerFactory requestHandlerFactory = new RequestHandlerFactory(ref dataBase);
            Communicator communicator = new Communicator(ref requestHandlerFactory);

            communicator.Run();
        }
    }
}
