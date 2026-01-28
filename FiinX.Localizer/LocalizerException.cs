namespace FiinX.Localizer
{
    public class LocalizerException : Exception
    {
        public LocalizerException(string message, params object[] arguments)
            : base(message.ToLocalizer(arguments))
        {
        }

        public LocalizerException(Exception innerException, string message, params object[] arguments)
            : base(message.ToLocalizer(arguments), innerException)
        {
        }

        public static LocalizerException Exception(string message, params object[] arguments)
        {
            return new(message, arguments);
        }

        public static LocalizerException Exception(Exception innerException, string message, params object[] arguments)
        {
            return new(innerException, message, arguments);
        }
    }
}
