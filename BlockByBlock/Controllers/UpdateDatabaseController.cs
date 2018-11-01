using BlockByBlock.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlockByBlock.Controllers
{
    public class UpdateDatabaseController : Controller
    {
        ApplicationDbContext _data = new ApplicationDbContext();

        
        public ActionResult Mtc_Activity()
        {
            List<Mtc_Activity> Data = new List<Mtc_Activity>();

            var reader = new StreamReader(@"E:\ASP.net\BlockByBlock\New_Data\Activity_MUCNW_example_SW7x24.csv");
            int i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (i != 0)
                {

                    Mtc_Activity single = new Mtc_Activity
                    {
                        Zone_act = Int32.Parse(values[0]),
                        Count_act = Int32.Parse(values[3]),
                        Hours_act = Int32.Parse(values[1])

                    };
                                        

                    if (values[2] == "MON")
                        single.Day_act = 1;
                    else if (values[2] == "TUE")
                        single.Day_act = 2;
                    else if (values[2] == "WED")
                        single.Day_act = 3;
                    else if (values[2] == "THU")
                        single.Day_act = 4;
                    else if (values[2] == "FRI")
                        single.Day_act = 5;
                    else if (values[2] == "SAT")
                        single.Day_act = 6;
                    else if (values[2] == "SUN")
                        single.Day_act = 7;

                    Data.Add(single);

                }
                i++;
            }

            _data.Mtc_Activities.AddRange(Data);
            _data.SaveChanges();

            return View();
        }


        public ActionResult Mtc_Homezone()
        {
            List<Mtc_Homezone> Data = new List<Mtc_Homezone>();

            var reader = new StreamReader(@"E:\ASP.net\BlockByBlock\Activity_MUCNW_example_homezone (1).csv");
            int i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                if (i != 0)
                {

                    Mtc_Homezone single = new Mtc_Homezone
                    {
                        Zone_hz = Int32.Parse(values[0]),
                        Home_hz = Int32.Parse(values[1])                        

                    };

                    string Shared= values[3].Replace(",", ".");
                    single.Shared_hz = Convert.ToDouble(Shared);
                    if (values[2] == "MON")
                        single.Day_hz = 1;
                    else if (values[2] == "TUE-THU")
                        single.Day_hz = 2;
                    else if (values[2] == "FRI")
                        single.Day_hz = 3;
                    else if (values[2] == "SAT")
                        single.Day_hz = 4;
                    else if (values[2] == "SUN")
                        single.Day_hz = 5;

                    Data.Add(single);

                }
                i++;
            }

            _data.Mtc_Homezones.AddRange(Data);
            _data.SaveChanges();

            return View();
        }



        public ActionResult Mtc()
        {
            List<Mtc> Data = new List<Mtc>();

            var reader = new StreamReader(@"E:\ASP.net\BlockByBlock\mtc(csv)");
            int i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                if (i != 0)
                {

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

            _data.Mtcs.AddRange(Data);
            _data.SaveChanges();

            return View();
        }

    }
}