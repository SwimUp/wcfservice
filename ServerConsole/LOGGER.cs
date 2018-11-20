using log4net;
using log4net.Config;

namespace ServerConsole
{
    public static class LOGGER
    {
        public static ILog Log { get; private set; } = LogManager.GetLogger("LOGGER");

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
