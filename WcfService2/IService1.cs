using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2.objetos;

namespace WcfService2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //int InsertPerson(articulos p);

        //[OperationContract]
        //int UpdatePerson(articulos p);

        //[OperationContract]
        //int DeletePerson(articulos p);


        [WebGet(
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "/json")]
        List<articulos> GetAlliTEMS();

    }
}
