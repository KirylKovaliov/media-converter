using System.IO;
using System.Runtime.Serialization;

namespace MediaServices.Web.Contract.Model
{
    [DataContract]
    public class RemoteFile
    {
        [DataMember]
        public Stream Stream { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string MD5 { get; set; }
    }
}
