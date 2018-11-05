using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockByBlock.Models;
using System.IO;


namespace BlockByBlock.Controllers
{
    public class DummyController : Controller
    {

        ApplicationDbContext _data = new ApplicationDbContext();

        public ActionResult Nicklas()
        {
            List<Nicklas_View_Model> Nicklas = new List<Nicklas_View_Model>();

            try
            {

                //var Homezone = _data.Mtc_Homezones.Where(x=>x.Zone_hz==145 && x.Day_hz==5).ToList();
                //var Mtc = _data.Mtcs.ToList();
                //var MtcPoint = _data.Mtc_Points.ToList();

                var Mtc_acttivity_Count = _data.Mtc_Activities.Where(x => x.Zone_act == 145 && x.Day_act == 5).Select(i => new { i.Count_act}).ToList();

                int total = 0;
                foreach (var item in Mtc_acttivity_Count)
                {
                    total = total+ item.Count_act;
                }
                return View(Nicklas);
            }
            catch
            {
                return View(Nicklas);
            }

            

            
        }



        //public ActionResult Mtc_Activity()
        //{
        //    List<Mtc_Activity> Data = new List<Mtc_Activity>();

        //    var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data\Activity_MUCNW_example_SW5x24(1).csv");
        //    int i = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(';');

        //        if (i != 0)
        //        {

        //            if (values[2] == "0+1")
        //                values[2] = "0";
        //            else if (values[2] == "1+1")
        //                values[2] = "1";

        //            Mtc_Activity single = new Mtc_Activity
        //            {
        //                Zone_act = Int32.Parse(values[0]),
        //                Count_act = Int32.Parse(values[1]),
        //                Hours_act = Int32.Parse(values[2])
        //            };


        //            if (values[3] == "MON")
        //                single.Day_act = 6;
        //            else if (values[3] == "TUE-THU")
        //                single.Day_act = 2;
        //            else if (values[3] == "FRI")
        //                single.Day_act = 3;
        //            else if (values[3] == "SAT")
        //                single.Day_act = 4;
        //            else if (values[3] == "SUN")
        //                single.Day_act = 5;

        //            Data.Add(single);

        //        }
        //        i++;
        //    }




        //    //_data.Mtc_Activities.AddRange(Data);
        //    //_data.SaveChanges();

        //    return View(Data);
        //}


        //public ActionResult Mtc_Homezone()
        //{
        //    List<Mtc_Homezone> Data = new List<Mtc_Homezone>();

        //    var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data\Activity_MUCNW_example_homezone(1).csv");

        //    int i = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(';');

        //        if (i != 0)
        //        {
        //            int days;
        //            switch (values[2])
        //            {
        //                case "MON":
        //                    days=1;
        //                    break;
        //                case "SAT":
        //                    days = 6;
        //                    break;
        //                case "SUN":
        //                    days = 7;
        //                    break;
        //                case "FRI":
        //                    days = 5;
        //                    break;
        //                default:
        //                    days = 2;
        //                    break;
        //            }

        //            Mtc_Homezone single = new Mtc_Homezone
        //            {

        //                Zone_hz = Int32.Parse(values[0]),
        //                Home_hz = Int32.Parse(values[1]),
        //                Day_hz = days,
        //                Shared_hz= Convert.ToDouble(values[3])
        //        };


        //            Data.Add(single);

        //        }
        //        i++;
        //    }




        //    //_data.Mtc_Homezones.AddRange(Data);
        //    //_data.SaveChanges();

        //    return View(Data);
        //}

        public ActionResult Mtc()
        {
            List<Mtc> Data = new List<Mtc>();

            //var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data_source_for_Tables\mtc.xls");
            var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data_Source_from_Tables\Phase1\mtc(csv)");


            int i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                //var line = reader.ReadLine();

                //string Seperator = "\t";
                //var values = line.Split(Seperator.ToCharArray());


                //var x = values[0];
                //var y = values[1];
                //string x1 = x;
                //var y1 = y.GetType().Name;
                //bool isNumeric = int.TryParse(y, out int n);
                //int y2 = Int32.Parse(y);
                //int p = n;


                if (i != 0)
                {

                    // values[2] = values[2].Replace(",", ".");
                    values[4] = values[4].Replace("\"", string.Empty);
                    values[3] = values[3].Replace("\"", string.Empty);

                    Mtc single = new Mtc
                    {
                        Gid = Int32.Parse(values[0]),
                        Id = Int32.Parse(values[1]),
                        Groesse = Convert.ToDouble(values[2]),
                        Geom = values[3],
                        Area = Convert.ToDouble(values[4])

                    };

                    Data.Add(single);

                }
                i++;
            }




            //_data.Mtc_Activities.AddRange(Data);
            //_data.SaveChanges();

            return View(Data);
        }


    }
}
