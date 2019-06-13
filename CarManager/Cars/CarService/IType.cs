using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IType" in both code and config file together.
    [ServiceContract]
    public interface IType
    {
        [OperationContract]
        string Message();

        [OperationContract]
        List<TypeDto> GetTypes();

        [OperationContract]
        TypeDto GetTypeById(int id);

        [OperationContract]
        string PostType(TypeDto typeDto);

        [OperationContract]
        string PutType(TypeDto typeDto);

        [OperationContract]
        string DeleteType(int id);
    }
}
