using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class EmployeeModel
    {
        public long EmployeeId { get; set; }
        [Required(ErrorMessage ="Employee Name field required")]
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age field required")]
        [Range(1,100,ErrorMessage = "Age must be enter between 1 and 100.")]
        public int Age { get; set; }
    }
}
