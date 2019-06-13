using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarService
{
    [ServiceContract]
    public interface ICar
    {
        [OperationContract]
        string Message();

        [OperationContract]
        List<CarDto> GetCars();

        [OperationContract]
        CarDto GetCarById(int id);

        [OperationContract]
        string PostCar(CarDto carDto);

        [OperationContract]
        string PutCar(CarDto carDto);

        [OperationContract]
        string DeleteCar(int id);
       
    }

}
