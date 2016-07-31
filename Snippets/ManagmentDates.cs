using System;

namespace Playground {

  class ManagmentDates {

    private static string getFormatDate(int y, int m, int a) {

      string aaaa = y.ToString();
      string mm = m.ToString();
      string dd = a.ToString();

      if (mm.Length < 2)
        mm = "0" + mm;
      if (dd.Length < 2)
        dd = "0" + dd;

      return aaaa + "-" + dd + "-" + mm;
    }

    public static string Today(){
      DateTime dt = DateTime.Now;
      return getFormatDate(dt.Year, dt.Month, dt.Day);
    }

    public static string Yesterday(string fecha) {
      //aaaa-dd-mm
      int aaaa = Int32.Parse(fecha.Substring(0,4));
      int mm = Int32.Parse(fecha.Substring(8, 2));
      int dd = Int32.Parse(fecha.Substring(5, 2));

      dd -= 1;

      //Febrero
      if (mm == 3 && dd < 1) {
        mm = 2;
        dd = 28;
      }

      else {
        if (dd < 1 && (mm == 5 || mm == 7 || mm == 10 || mm == 12)) {
          dd = 30;
          mm = mm - 1;
        }
        else {
          if (dd < 1) {
            dd = 31;
            mm = mm - 1;
            if (mm < 1) {
              mm = 12;
              aaaa = aaaa - 1;
            }
          }
        }
      }

      return getFormatDate(aaaa,mm,dd);
    }

    private static string Tomorrow(string fecha) {
      //aaaa-dd-mm
      int aaaa = Int32.Parse(fecha.Substring(0,4));
      int mm = Int32.Parse(fecha.Substring(8, 2));
      int dd = Int32.Parse(fecha.Substring(5, 2));

      dd += 1;

      //Febrero
      if (mm == 2 && dd > 28) {
        mm = 3;
        dd = 1;
      }
      else {

        if (dd > 30 && (mm != 1 && mm != 3 && mm != 5 && mm != 7 && mm != 8 && mm != 10 && mm != 12) ) {
          dd = 1;
          mm = mm + 1;
          if (mm > 12) {
            mm = 1;
            aaaa = aaaa + 1;
          }
        }
        else {
          if (dd > 31) {
            dd = 1;
            mm = mm + 1;
            if (mm > 12) {
              mm = 1;
              aaaa = aaaa + 1;
            }
          }
        }
      }
      return getFormatDate(aaaa,mm,dd);
    }

    private static void validateResult (string r, string a){
      if(String.Compare(r,a,true) == 0) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(r);
      } else{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(r + " Se esperaba: " + a);
      }
      Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Main(string[] args) {
       Console.WriteLine(Today());
       Console.WriteLine(Yesterday(Today()));
       Console.WriteLine(Tomorrow(Today()));
       Console.WriteLine("Test Yesterday");
       validateResult(Yesterday("2015-01-03"), "2015-28-02");
       validateResult(Yesterday("2015-01-12"), "2015-30-11");
       validateResult(Yesterday("2015-02-12"), "2015-01-12");
       validateResult(Yesterday("2015-01-10"), "2015-30-09");
       Console.WriteLine("Test Tomorrow");
       validateResult(Tomorrow("2015-30-03"), "2015-31-03");
       validateResult(Tomorrow("2015-30-12"), "2015-31-12");
       validateResult(Tomorrow("2015-29-12"), "2015-30-12");
       validateResult(Tomorrow("2015-29-10"), "2015-30-10");
    }

   }//Class

}//Namespace
