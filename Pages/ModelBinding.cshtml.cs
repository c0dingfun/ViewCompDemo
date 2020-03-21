using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ViewCompDemo.Pages
{
    // [BindProperties]
    public class ModelBindingModel : PageModel
    {
        public void OnGet(int id)
        {
            ViewData["id"] = id;

        }

        // Request.Form way
        // public void OnPost()
        // {
        //     var name = Request.Form["Name"];
        //     var email = Request.Form["Email"];

        //     ViewData["confirmation"] = 
        //         $"{name}, info will be sent to {email}";
        // }

        // // ModelBinding way - Binding to PageModel handler's parameters
        // public void OnPost(string name, string email)
        // {
        //     ViewData["confirmation"] = 
        //         $"{name}, info will be sent to {email}";
        // }

        // ModelBinding way - Binding to PageModel public properties
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public void OnPost()
        {
            ViewData["confirmation"] = 
                $"{Name}, info will be sent to {Email}";
        }

        // NOTE:
        // Model binding itself is not case sensitive. 
        // It performs case-insensitive matches between the names of 
        // incoming values and the names or parameters or properties 
        // that it attempts to bind the values to. 
    }

}
