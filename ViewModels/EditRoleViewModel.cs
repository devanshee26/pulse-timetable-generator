using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.ViewModels
{
    public class EditRoleViewModel
    {
        
        public EditRoleViewModel()
        {
            UsersUnderThisRole = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required!")]
        public string RoleName { get; set; }

        //this is the user id of the user
        public List<string> UsersUnderThisRole { get; set; }

    }
}
