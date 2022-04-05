namespace Server
{
    public interface IRequestHandler
    {
	    public Response HandleRequest(Request info);
	    public string GetUsername();
    }
}
