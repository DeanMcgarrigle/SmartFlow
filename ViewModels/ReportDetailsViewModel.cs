using System;
using System.Collections.Generic;
using SmartFlow.Entity;

namespace SmartFlow.ViewModels
{
    public class ReportDetailsViewModel
    {
        public string ClientMac { get; set; }
        public string Floor { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<ReportDetailsResult> Results { get; set; }
        public string ImagePath { get; set; }
        public decimal Y { get; set; }
        public decimal X { get; set; }
        public List<AccessPointConfig> AccessPoints { get; set; }
        public int ChartWidth { get; set; }
        public int ChartHeight { get; set; }
        public int MinimumRssi { get; set; }
        public int MaximumUnc { get; set; }

        public ReportDetailsViewModel()
        {
            FromDate = DateTime.Now.Date.ToString();
            ToDate = DateTime.Now.ToString();
            MaximumUnc = 1000;
            ChartWidth = 1170;
            ChartHeight = 600;
            Results = new List<ReportDetailsResult>();
            AccessPoints = new List<AccessPointConfig>();
        }
    }
}