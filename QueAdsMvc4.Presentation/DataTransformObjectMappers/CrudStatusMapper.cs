using QueAds.Common.Utilities;
using QueAdsMvc4.Presentation.Utility;

namespace QueAdsMvc4.Presentation.DataTransformObjectMappers
{
    public class CrudStatusMapper
    {
        public static CrudOperation MapFromEnum(CrudStatus crudStatus)
        {
            switch (crudStatus)
            {
                case CrudStatus.UPDATE:
                    return CrudOperation.UPDATE;
                case CrudStatus.DELETE:
                    return CrudOperation.DELETE;
                case CrudStatus.READ:
                    return CrudOperation.READ;
                default:
                    return CrudOperation.CREATE;
            }
        }

        public static CrudStatus MapToEnum(CrudOperation crudOperation)
        {
            switch (crudOperation)
            {
                case CrudOperation.UPDATE:
                    return CrudStatus.UPDATE;
                case CrudOperation.DELETE:
                    return CrudStatus.DELETE;
                case CrudOperation.READ:
                    return CrudStatus.READ;
                default:
                    return CrudStatus.CREATE;
            }
        }
    }
}
