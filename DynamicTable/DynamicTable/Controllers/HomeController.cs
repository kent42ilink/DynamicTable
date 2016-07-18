using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicTable.Models.ViewModel;

namespace DynamicTable.Controllers
{
    public class HomeController : Controller
    {
        public RowItem GetRowItem(bool IsDefault = false)
        {
            Random Random = new Random();
            var Num = Random.Next(1, 9999);

            if (IsDefault)
                return new RowItem() { ID = Num };

            else
                return new RowItem() { ID = Num, Name = "Kent", NickName = "SevenDollar", Content = "Hello World!" };
        }

        #region Index
        public ActionResult Index()
        {
            HomeViewModel ViewModel = new HomeViewModel();

            ViewModel.RowList.Add(GetRowItem());
           
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel ViewModel)
        {
            TempData["Message"] = "Done";

            return View(ViewModel);
        }
        #endregion




        #region _DynamicTablePartialView
        public ActionResult _DynamicTablePartial(List<RowItem> RowList)
        {
            HomeViewModel ViewModel = new HomeViewModel();

            ViewModel.RowList = RowList;

            return PartialView(ViewModel);
        }

        public ActionResult AddRow(List<RowItem> RowList)
        {
            if (RowList == null)
                RowList = new List<RowItem>();

            HomeViewModel ViewModel = new HomeViewModel();


            RowList.Add(GetRowItem(true));

            ViewModel.RowList = RowList;

            return PartialView("_DynamicTablePartial", ViewModel);
        }

        public ActionResult DeleteRow(List<RowItem> RowList, int ID)
        {

            HomeViewModel ViewModel = new HomeViewModel();

            RowList.Remove(RowList.Find(x => x.ID == ID));
            ViewModel.RowList = RowList;

            return PartialView("_DynamicTablePartial", ViewModel);
        }

        #endregion
    }
}