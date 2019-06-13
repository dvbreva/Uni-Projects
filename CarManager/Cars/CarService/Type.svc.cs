using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationServices.DTOs;
using ApplicationServices.Implementations;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Type" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Type.svc or Type.svc.cs at the Solution Explorer and start debugging.
    public class Type : IType
    {
        private TypeManagementService _context = new TypeManagementService();

        public string DeleteType(int id)
        {
            if (!_context.Delete(id))
                return "Type was not deleted.";

            return "Type was deleted.";
        }

        public TypeDto GetTypeById(int id)
        {
            return _context.GetById(id);
        }

        public List<TypeDto> GetTypes()
        {
            return _context.Get();
        }

        public string Message()
        {
            return "Type service is up!";
        }

        public string PostType(TypeDto typeDto)
        {
            if (!_context.Save(typeDto))
                return "Type is not inserted.";

            return "Type was inserted.";
        }

        public string PutType(TypeDto typeDto)
        {
            if (!_context.Save(typeDto))
                return "Type is not updated.";

            return "Type is updated.";
        }
    }
}
