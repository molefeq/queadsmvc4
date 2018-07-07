using QueAdsMvc4.Presentation.ServiceHandlers.Classes;
using QueAdsMvc4.Presentation.ServiceHandlers.Interfaces;

namespace QueAdsMvc4.Presentation.Factories
{
    public class ServiceHandlers
    {
        public static ICategoryHandler CategoryHandler
        {
            get
            {
                return new CategoryServiceHandler();
            }
        }

        public static IPolicyHandler PolicyHandler
        {
            get
            {
                return new PolicyServiceHandler();
            }
        }

        public static IUserHandler UserHandler
        {
            get
            {
                return new UserServiceHandler();
            }
        }

        public static IProvinceHandler ProvinceHandler
        {
            get
            {
                return new ProvinceServiceHandler();
            }
        }

        public static IListHandler ListHandler
        {
            get
            {
                return new ListServiceHandler();
            }
        }

        public static IContactUsHandler ContactUsHandler
        {
            get
            {
                return new ContactUsServiceHandler();
            }
        }

        public static ISystemExceptionLogHandler SystemExceptionLogHandler
        {
            get
            {
                return new SystemExceptionLogHandler();
            }
        }
    }
}
