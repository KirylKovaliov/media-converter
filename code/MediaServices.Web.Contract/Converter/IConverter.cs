using System.ServiceModel;

namespace MediaServices.Web.Contract.Converter
{
    [ServiceContract]
    public interface IConverter
    {
        [OperationContract]
        void DoWork();
    }
}
