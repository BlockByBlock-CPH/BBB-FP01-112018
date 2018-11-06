using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockByBlock.Models;
using System.IO;
using System.Drawing;

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

               var Homezone = _data.Mtc_Homezones.Where(x=>x.Zone_hz==145 && x.Day_hz==5).ToList();



                
                //////////////////////////


                List<Mtc> Mtc = new List<Mtc>();

                var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data_Source_from_Tables\Phase1\mtc(csv)");


                int i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');


                    if (i != 0)
                    {

                        values[2] = values[2].Replace(".", ",");
                        values[4] = values[4].Replace(".", ",");

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

                        Mtc.Add(single);

                    }
                    i++;
                }



                ///////////////////////////////////////
                ///


                List<L1> last1 = new List<L1>();
               
                foreach (var x in Homezone)
                {
                    foreach( var y in Mtc)
                    {
                        if(x.Home_hz==y.Gid || x.Zone_hz == y.Gid)
                        {

                            L1 LL1 = new L1
                            {
                                Gid = y.Gid,
                                Id = y.Id,
                                Groesse = y.Groesse,
                                Geom = y.Geom,
                                Area = y.Area,

                                Id_hz = x.Id_hz,
                                Zone_hz = x.Zone_hz,
                                Home_hz = x.Home_hz,
                                Day_hz = x.Day_hz,
                                Shared_hz = x.Shared_hz
                                
                                };
                            last1.Add(LL1);
                        }
                        

                    }
                }

                List<Mtc_Points> Points = new List<Mtc_Points>();
                foreach( var x in last1)
                {
                   var p = _data.Mtc_Points.Where(a=>a.MId==x.Gid).ToList();
                    Points.AddRange(p);

                }

                double[] gid = new double[2];
                double[] mid = new double[2];
                double xaxis = 0.0;
                double yaxis = 0.0;
                foreach (var g in last1)
                {

                    var po = Points.Where(x=>x.MId==g.Gid).ToList();
                    
                    foreach(var z in po)
                    {
                        xaxis = xaxis+z.X;
                        yaxis = yaxis+z.Y;
                       
                    }

                    gid[0] = xaxis / 4.0;
                    gid[1] = yaxis / 4.0;

                    

                    foreach (var y in last1)
                            {
                        var pon = Points.Where(x => x.MId == y.Gid).ToList();
                        foreach (var z in pon)
                        {
                            xaxis = xaxis + z.X;
                            yaxis = yaxis + z.Y;

                        }

                        mid[0] = xaxis / 4.0;
                        mid[1] = yaxis / 4.0;


                        y.Distance = (Math.Pow(gid[0] - mid[0], 2) + Math.Pow(gid[1] - mid[1], 2));

                    }

                   

                }



                

                var Mtc_acttivity_Count = _data.Mtc_Activities.Where(x => x.Zone_act == 145 && x.Day_act == 5).Select(s => new { s.Count_act}).ToList();

                int total = 0;
                foreach (var item in Mtc_acttivity_Count)
                {
                    total = total+ item.Count_act;
                }

                //return View("Nicklas_Test", last1);
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
