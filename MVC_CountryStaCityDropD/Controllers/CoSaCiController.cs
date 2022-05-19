using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CountryStaCityDropD.Models;

namespace MVC_CountryStaCityDropD.Controllers
{
    public class CoSaCiController : Controller
    {
        // GET: CoSaCi
        public ActionResult Index()
        {
            My_TableEntities sd = new My_TableEntities();
            ViewBag.countrylist = new SelectList(GetCountryList(),"CId","CName");
            return View();
        }
        public List<Country> GetCountryList()
        {
            My_TableEntities sd = new My_TableEntities();
            List<Country> countries = sd.Countries.ToList();
            return countries;
        }

        public ActionResult GetStateList(int CId)
        {
            My_TableEntities sd = new My_TableEntities();
            List<State> selectlist = sd.States.Where(a => a.CId == CId).ToList();
            ViewBag.Slist = new SelectList(selectlist, "SId", "SName");
            return PartialView("DisplayStates");
        }

        public ActionResult GetCityList(int SId)
        {
            My_TableEntities sd = new My_TableEntities();
            List<City> selectlist = sd.Cities.Where(a => a.Sid == SId).ToList();
            ViewBag.Citylist = new SelectList(selectlist, "CityId", "CityName");
            return PartialView("DisplayCities");
        }
    }
}