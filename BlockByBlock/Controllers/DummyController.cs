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

        // GET: Dummy
        public ActionResult Index()
        {
            List<Mtc_Activity> Data = new List<Mtc_Activity>();
            
var reader = new StreamReader(@"D:\Repositories\BlockByBlock-Resources\Data\Activity_MUCNW_example_SW5x24(1).csv");
            int i = 0;
            while (!reader.EndOfStream)
            { var line = reader.ReadLine();
                var values = line.Split(';');

                if (i!=0)
                {

                    Mtc_Activity single = new Mtc_Activity
                    {
                        Zone_act = Int32.Parse(values[0]),
                        Count_act = Int32.Parse(values[1])
                    };
                    if (values[2] == "0+1")
                        values[2] = "0";
                    else if (values[2] == "1+1")
                        values[2] = "1";

                    //        single.Hours_act= Int32.Parse(values[2]);
                    //    single.Days_act = values[3];

                    //    Data.Add(single);

                    //    }
                    //   i++;
                    //}

                    single.Hours_act = Int32.Parse(values[2]);
                    //single.Days_act = values[3];

                    if (values[3] == "MON")
                        single.Day_act = 6;
                    else if (values[3] == "TUE-THU")
                        single.Day_act = 2;
                    else if (values[3] == "FRI")
                        single.Day_act = 3;
                    else if (values[3] == "SAT")
                        single.Day_act = 4;
                    else if (values[3] == "SUN")
                        single.Day_act = 5;

                    Data.Add(single);

                }
                i++;
            }




            _data.Mtc_Activities.AddRange(Data);
            _data.SaveChanges();

            return View();
        }
    }
}