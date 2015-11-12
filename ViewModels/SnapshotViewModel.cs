using System;
using System.Collections.Generic;

namespace SmartFlow.ViewModels
{
    public class SnapshotViewModel
    {
        public List<string> Floors { get; set; }
        public string Floor { get; set; }
        public string SelectedDate { get; set; }
        public List<SnapshotListResult> Results { get; set; }
        public string ImagePath { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public int ChartWidth { get; set; }
        public int ChartHeight { get; set; }

        public SnapshotViewModel()
        {
            ChartWidth = 1170;
            ChartHeight = 600;
            SelectedDate = DateTime.Now.ToString(@"dd/MM/yyyy HH:mm");
            Floors = new List<string>();
            Results = new List<SnapshotListResult>();
        }
    }
}