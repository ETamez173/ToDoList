using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models.ViewModels
{
    public class ToDoItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int ToDoStatusId { get; set; }
        public List<SelectListItem> ToDoStatusOptions { get; set; }
    }
}
