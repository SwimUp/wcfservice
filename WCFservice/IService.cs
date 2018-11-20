using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
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
        public string FileName;

        [MessageBodyMember(Order = 1)]
        public Stream Data;
    }
}
