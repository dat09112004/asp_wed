﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.ViewComponents
{
    public class TheLoaiViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiViewComponent (ApplicationDbContext db)
        {
            _db = db;
        }
       public IViewComponentResult Invoke()
        {
            var theloai = _db.TheLoai.ToList();
            return View(theloai);
        }
    }

}
