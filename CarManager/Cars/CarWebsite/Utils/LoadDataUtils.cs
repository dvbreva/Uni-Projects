using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CarWebsite.Utils
{
    public class LoadDataUtils
    {
        public static SelectList LoadTypesData()
        {
            using (TypeServiceReference.TypeClient typeService = new TypeServiceReference.TypeClient())
            {
                SelectList selectListItems = new SelectList(typeService.GetTypes(), "Id", "Name");
                return selectListItems;
            }
        }

        public static SelectList LoadMakesData()
        {
            using (MakeServiceReference.MakeClient makeService = new MakeServiceReference.MakeClient())
            {
                SelectList selectListItems = new SelectList(makeService.GetMakes(), "Id", "Name");
                return selectListItems;
            }
        }

    }
}