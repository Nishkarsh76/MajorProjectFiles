using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Project.Models;

namespace Mini_Project
{
    public class MultiTable
    {
        public IEnumerable<Sport_tournamentlist>
            reg1
        { get; set; }

        public IEnumerable<Cultural_eventlist>
           reg2
        { get; set; }
    }
}