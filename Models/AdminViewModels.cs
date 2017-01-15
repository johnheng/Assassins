using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assassins.Models
{
    public class AdminViewModels
    {
    }

    public class PlayerViewModel
    {
        [Display(Name = "name")]
        public string name { get; set; }
        [Display(Name = "id")]
        public string id { get; set; }
        [Display(Name = "family")]
        public string family { get; set; }
    }

    public class PlayerTargetViewModel
    {
        [Display(Name = "user")]
        public PlayerViewModel user { get; set; }
        [Display(Name = "target")]
        public PlayerViewModel target { get; set; }
    }

    public class PlayerShuffleViewModel
    {
        [Display(Name = "playerShuffle")]
        public List<PlayerTargetViewModel> playerShuffle { get; set; }
    }
}