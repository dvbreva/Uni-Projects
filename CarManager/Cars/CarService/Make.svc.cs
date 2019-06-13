using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Make" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Make.svc or Make.svc.cs at the Solution Explorer and start debugging.
    public class Make : IMake
    {
        private MakeManagementService _context = new MakeManagementService();

        public string DeleteMake(int id)
        {
            if (!_context.Delete(id))
                return "Make was not deleted.";

            return "Make was deleted.";
        }

        public MakeDto GetMakeById(int id)
        {
            return _context.GetById(id);
        }

        public List<MakeDto> GetMakes()
        {
            return _context.Get();
        }

        public string Message()
        {
            return "Make service is up!!"; 
        }

        public string PostMake(MakeDto makeDto)
        {
            if (!_context.Save(makeDto))
                return "Make is not inserted.";

            return "Make is inserted.";
        }

        public string PutMake(MakeDto makeDto)
        {
            if (!_context.Save(makeDto))
                return "Make is not updated.";

            return "Make is updated.";
        }
    }
}
