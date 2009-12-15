using SampleApplication.Core.Data;

namespace SampleApplication.Core
{
    public class Factory
    {
        public static UserGateway GetGateway()
        {
            return new UserGateway(new Configuration());
        }
    }
}
