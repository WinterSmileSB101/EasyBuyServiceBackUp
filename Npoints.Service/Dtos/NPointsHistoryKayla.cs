using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
    [RestService("/npointkayla")]
    [RestService("/npointkayla?AccountName={AccountName}")]
    public class NPointsHistoryKayla
    {
        public string AccountName { get; set; }
        public bool State { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }
        public DateTime InDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
        public DateTime? LastEditDate { get; set; }
    }
}
