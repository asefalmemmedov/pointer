using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pointer.Models.ViewModels
{
    public class HomeIndexVM
    {
        public Headers Header { get; set; }
        public About About { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<TeamSlider> TeamSliders { get; set; }
        public TeamSlider TeamSlider { get; set; }
        public IEnumerable<Blog>  Blog { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<Testimonials> Testimonials  { get; set; }
        public IEnumerable<Services> Services{ get; set; }
        public IEnumerable<OurApproach> OurApproach { get; set; }


    }
}