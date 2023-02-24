namespace InventoryManagement.Application
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string errorMessage)
               : base(errorMessage)
        {
        }

        internal ApplicationException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
        }
    }
}
