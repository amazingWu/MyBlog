using DemoLogin.Controllers.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoLogin.Models;

namespace DemoLogin.Controllers
{
    public class TitleController : BaseController
    {

        private DemoLoginBLL.ModelBll.TitcleBLL titlebll = new DemoLoginBLL.ModelBll.TitcleBLL();
        private DemoLoginBLL.ModelBll.TagBll tagbll = new DemoLoginBLL.ModelBll.TagBll();
        public const  int num = 6;
        public const int manage_num = 20;
        //
        // GET: /Title/
        public ActionResult Index()
        {
            int index=0;
            if (string.IsNullOrEmpty(Request.QueryString["index"]))
            {
                index = 1;
            }
            else
            {
                index = Convert.ToInt32(Request.QueryString["index"]);
            }
            List<DemoLoginBean.Models.Title> titles = titlebll.GetListByPageAiticle("", "", (index-1)*num+1, index*num);
            foreach (DemoLoginBean.Models.Title _title in titles)
            {
                _title.tContent = Tools.NoHTML(HttpUtility.HtmlDecode(_title.tContent));
                if (_title.tContent.Length > 300)
                {
                    _title.tContent = _title.tContent.Substring(0, 300) + "...";
                }
            }
            ViewBag.list = titles;
            NowPage nowpage = new NowPage();
            nowpage.MaxNum = titlebll.GetRecordCount("") / num + 1;
            nowpage.NowNum = index;
            ViewData["nowpage"] = nowpage;

            return View();
        }

        // GET: /Title/Create
        [AuthAttribute(Code = 2)]//2代表普通用户，普通用户即可发布文章
        
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [AuthAttribute(Code = 2)]//2代表普通用户，普通用户即可发布文章
        public ActionResult Create(DemoLoginBean.Models.Title title)
        {
            if (!string.IsNullOrEmpty(title.tContent) && !string.IsNullOrEmpty(title.tName))
            {
                title.tContent = HttpUtility.HtmlEncode(title.tContent);
                title.tUserID = CheckLogin.Instance.GetUser().ID;
                title.tTime = DateTime.Now;
                int id=titlebll.Add(title);
                title.tag.TitleID = id;
                tagbll.Add(title.tag);
                return RedirectToAction("Index");
            }

            return View(title);
        }


        /// <summary>
        /// 管理界面
        /// </summary>
        /// <returns></returns>
        [AuthAttribute(Code = 2)]//2代表普通用户
        public ActionResult Manage()
        {
            int index = 0;
            if (string.IsNullOrEmpty(Request.QueryString["index"]))
            {
                index = 1;
            }
            else
            {
                index = Convert.ToInt32(Request.QueryString["index"]);
            }
            List<DemoLoginBean.Models.Title> titles = titlebll.GetListByPageAiticle("", "", (index - 1) * manage_num + 1, index * manage_num);
            ViewBag.list = titles;
            NowPage nowpage = new NowPage();
            nowpage.MaxNum = titlebll.GetRecordCount("") / manage_num + 1;
            nowpage.NowNum = index;
            ViewData["nowpage"] = nowpage;

            return View();
        }
        /// <summary>
        /// 查看详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            DemoLoginBean.Models.Title title= titlebll.GetModel(id);
            title.tContent = HttpUtility.HtmlDecode(title.tContent);//解析回带有html标记的文本
            title.tag = tagbll.GetModel(id);
            ViewData["titleDetail"] = title;
            return View(title);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [AuthAttribute(Code = 2)]//2代表普通用户
        public ActionResult Delete()
        {
            string titleList = "";
            if (string.IsNullOrEmpty(Request.QueryString["titlelist"]))
            {
                //什么都不做，直接返回界面
            }
            else
            {
                titleList = Request.QueryString["titlelist"].ToString();
                tagbll.DeleteList(titleList);//删除标签，必须先删除标签，因为titles表中有tag表的外键约束
                titlebll.DeleteList(titleList);//删除文章
                
            }
            return RedirectToAction("Manage", "Title");
        }
        /// <summary>
        /// 删除单个
        /// </summary>
        /// <returns></returns>
        [AuthAttribute(Code = 2)]//2代表普通用户
        public ActionResult DeleteSingle()
        {
            int id = 0;
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //什么都不做，直接返回界面
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                tagbll.Delete(id);//删除标签，必须先删除标签，因为titles表中有tag表的外键约束
                titlebll.Delete(id);//删除文章

            }
            return RedirectToAction("Manage", "Title");
        }
        [AuthAttribute(Code = 2)]//2代表普通用户
        public ActionResult Edit(int id)
        {
            DemoLoginBean.Models.Title title = titlebll.GetModel(id);
            title.tContent = HttpUtility.HtmlDecode(title.tContent);//解析回带有html标记的文本
            title.tag = tagbll.GetModel(id);
            ViewData["titleDetail"] = title;
            return View(title);
        }
        [HttpPost]
        [ValidateInput(false)]
        [AuthAttribute(Code = 2)]//2代表普通用户
        public ActionResult Edit(DemoLoginBean.Models.Title title)
        {
            if (!string.IsNullOrEmpty(title.tContent) && !string.IsNullOrEmpty(title.tName))
            {
                title.tContent = HttpUtility.HtmlEncode(title.tContent);
                title.tTime = DateTime.Now;
                titlebll.Update(title);
                title.tag.TitleID = title.ID;
                tagbll.Update(title.tag);
                
                return RedirectToAction("Index");
            }
            return View(title);
        }
    }
}
