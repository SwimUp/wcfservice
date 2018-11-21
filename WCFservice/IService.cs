using System.ServiceModel;
using System.IO;

namespace WCFservice
{
    [ServiceContract(Namespace = "WCFservice")]
    public interface IService
    {
        [OperationContract]
        Stream DownloadFile(string fileName);

        [OperationContract]
        bool GetStatus();

        [OperationContract(IsOneWay = true)]
        void UploadFile(FileTransferRequest request);
    }


    [MessageContract()]
    public class FileTransferRequest
    {
        [MessageHeader(MustUnderstand = true)]
        public string fileName;

        [MessageBodyMember(Order = 1)]
        public Stream Data;
    }
}
