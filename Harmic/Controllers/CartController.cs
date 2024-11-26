using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Harmic.Models;
using Microsoft.AspNetCore.Http;

namespace MyFinalProject.Controllers
{
    public class CartController : Controller
    {
        private readonly HarmicContext _context;

        public CartController(HarmicContext context)
        {
            _context = context;
        }

     
        
    }
}