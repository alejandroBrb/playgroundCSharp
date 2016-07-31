using System;

namespace Playground {

  class ManagmentDates {

    private string Fecha(){
      DateTime dt = DateTime.Now;
      string fecha;
      string aaaa;
      string mm;
      string dd;

      aaaa = dt.Year.ToString();
      mm = dt.Month.ToString();
      dd = dt.Day.ToString();

      if (mm.Length < 2)
        mm = "0" + mm;
      if (dd.Length < 2)
        dd = "0" + dd;

      return fecha = aaaa + "-" + dd + "-" + mm;
    }

   }//Class

}//Namespace
