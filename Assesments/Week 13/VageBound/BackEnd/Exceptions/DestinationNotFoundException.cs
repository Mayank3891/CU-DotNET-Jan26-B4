namespace BackEnd.Exceptions
{
    public class DestinationNotFoundException : Exception
    {
        public DestinationNotFoundException(int id)
            : base($"Destination with ID {id} was not found.") { }
    }
}
