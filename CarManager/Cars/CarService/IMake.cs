using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMake" in both code and config file together.
    [ServiceContract]
    public interface IMake
    {
        [OperationContract]
        string Message();

        [OperationContract]
        List<MakeDto> GetMakes();

        [OperationContract]
        MakeDto GetMakeById(int id);

        [OperationContract]
        string PostMake(MakeDto makeDto);

        [OperationContract]
        string PutMake(MakeDto makeDto);

        [OperationContract]
        string DeleteMake(int id);
    }
}
