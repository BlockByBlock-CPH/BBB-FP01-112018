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

        //    var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data_Source_from_Tables\Phase1\mtc_activity.csv");
        //    int i = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(',');

        //        if (i != 0)
        //        {

        //            values[1] = values[1].Replace("\"", string.Empty);
        //            values[2] = values[2].Replace("\"", string.Empty);
        //            values[5] = values[5].Replace("\"", string.Empty);
        //            values[5] = values[5].Replace(".", ",");
                   
        //            Mtc_Activity single = new Mtc_Activity
        //            {
        //                Id_act = Int32.Parse(values[0]),
        //                Zone_act = Int32.Parse(values[1]),
        //                Count_act = Int32.Parse(values[2]),
        //                Hours_act = Int32.Parse(values[3]),
        //                Day_act = Int32.Parse(values[4]),
        //                Density = Convert.ToDouble(values[5])


        //            };

                    
        //            Data.Add(single);

        //        }
        //        i++;
        //    }




        //    _data.Mtc_Activities.AddRange(Data);
        //    _data.SaveChanges();

        //    return View(Data);
        //}


        //public ActionResult Mtc_Homezone()
        //{
        //    List<Mtc_Homezone> Data = new List<Mtc_Homezone>();

        //    var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data_Source_from_Tables\Phase1\mtc_homezone.csv");

        //    int i = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(',');

        //        if (i != 0)
        //        {

        //            values[1] = values[1].Replace("\"", string.Empty);
        //            values[2] = values[2].Replace("\"", string.Empty);
        //            values[3] = values[3].Replace("\"", string.Empty);
        //            values[4] = values[4].Replace("\"", string.Empty);
        //            values[4] = values[4].Replace(".", ",");

        //            Mtc_Homezone single = new Mtc_Homezone
        //            {
        //                Id_hz = Int32.Parse(values[0]),
        //                Zone_hz = Int32.Parse(values[1]),
        //                Home_hz = Int32.Parse(values[2]),
        //                Day_hz = Int32.Parse(values[3]),
        //                Shared_hz = Convert.ToDouble(values[4])
        //            };
                     

        //Data.Add(single);

        //        }
        //        i++;
        //    }




        //    _data.Mtc_Homezones.AddRange(Data);
        //    _data.SaveChanges();

        //    return View(Data);
        //}

        //public ActionResult Mtc()
        //{
        //    List<Mtc> Data = new List<Mtc>();

        //    var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data_Source_from_Tables\Phase1\mtc(csv)");


        //    int i = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(';');
                

        //        if (i != 0)
        //        {

        //            values[2] = values[2].Replace(".", ",");
        //            values[4] = values[4].Replace(".", ",");

        //            values[4] = values[4].Replace("\"", string.Empty);
        //            values[3] = values[3].Replace("\"", string.Empty);

        //            Mtc single = new Mtc
        //            {
        //                Gid = Int32.Parse(values[0]),
        //                Id = Int32.Parse(values[1]),
        //                Groesse = Convert.ToDouble(values[2]),
        //                Geom = values[3],
        //                Area = Convert.ToDouble(values[4])

        //            };

        //            Data.Add(single);

        //        }
        //        i++;
        //    }




        //    _data.Mtcs.AddRange(Data);
        //    _data.SaveChanges();

        //    return View(Data);
        //}

        //public ActionResult Mtc_Points()
        //{
        //    List<Mtc_Points> Data = new List<Mtc_Points>();

        //    var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data_Source_from_Tables\Phase1\Mtc_Data_Backend.csv");
        //    int i = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(',');

        //        if (i != 0)
        //        {
        //            values[1] = values[1].Replace(".", ",");
        //            values[2] = values[2].Replace(".", ",");
        //            Mtc_Points single = new Mtc_Points
        //            {

        //                MId = Int32.Parse(values[0].Replace("\"", string.Empty)),
        //                X = Convert.ToDouble(values[1].Replace("\"", string.Empty)),
        //                Y = Convert.ToDouble(values[2].Replace("\"", string.Empty))
        //            };

        //            Data.Add(single);

        //        }
        //        i++;
        //    }

        //    _data.Mtc_Points.AddRange(Data);
        //    _data.SaveChanges();

        //    return View(Data);
        //}
    }
}
