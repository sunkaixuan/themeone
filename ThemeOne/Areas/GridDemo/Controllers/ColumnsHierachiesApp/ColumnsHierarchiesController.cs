﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQWidgetsSugar;
using ThemeOne.Infrastructure;
using SqlSugar;
using ThemeOne.Entities;

namespace ThemeOne.Areas.GridDemo.Controllers.ColumnsHierachiesApp
{
    /// <summary>
    /// 多表头
    /// </summary>
    public class ColumnsHierarchiesController : Controller
    {
        ListService ls;
        public ColumnsHierarchiesController(ListService ls)
        {
            this.ls = ls;
        }

        public ActionResult Index()
        {
            ViewBag.Grid = JQXGrid.BindGrid("#grid", ColHieModel.GetDataAdapterSource(), ColHieModel.GetGridConfig());
            return View();
        }
        public JsonResult GetListSource(GridSearchParams pars)
        {

            if (pars.sortdatafield == null)
            { //默认按id降序
                pars.sortdatafield = "id";
                pars.sortorder = "desc";
            }
            Sqlable sable = ls.GetListSqlable();
            var model = JQXGrid.GetWidgetsSource<list>(sable, pars, "*");//根据grid的参数自动查询
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
