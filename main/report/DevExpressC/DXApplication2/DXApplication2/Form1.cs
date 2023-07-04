using DevExpress.XtraMap;
using System;
using Newtonsoft;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using System.Diagnostics;

namespace DXApplication2
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        HeatmapDataSourceAdapter adapter;
        HeatmapProvider provider;
        public Form1()
        {
            InitializeComponent();
            adapter = new HeatmapDataSourceAdapter();
            adapter.Mappings.XCoordinate = "lon"; //lon
            adapter.Mappings.YCoordinate = "lat"; //lat

            provider = new HeatmapProvider();
            provider.PointSource = adapter;
            provider.Algorithm = new HeatmapDensityBasedAlgorithm { PointRadius = 3 };

            ImageLayer heatmapLayer = new ImageLayer();
            heatmapLayer.DataProvider = provider;
            mapControl1.Layers.Add(heatmapLayer);


            ChoroplethColorizer colorizer = new ChoroplethColorizer();
            colorizer.RangeStops.AddRange(new double[] { 0.1, 0.3, 0.5, 0.7, 1 });
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Green));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.YellowGreen));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Yellow));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Orange));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Red));
            colorizer.ApproximateColors = true;

            provider.Colorizer = colorizer;
        }

        private List<MainSource> MainJobDataSource = new List<MainSource>();
        private void Form1_Load(object sender, EventArgs e)
        {
            MainJobDataSource = LoadData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\TestJason.json");
            adapter.DataSource = MainJobDataSource;

            var grouped = MainJobDataSource.GroupBy(g => g.arbeitgeber).OrderByDescending(
                o => o.Count()).Take(5).Select(s => new ChartData()
                {
                    XValue = s.Key,
                    YValue = s.Count()
                }).ToList();

            chartControl1.DataSource = grouped;
        }

        public class ChartData
        {
            public string XValue { get; set; }
            public int YValue { get; set; }

            public int XYValue { get; set; }
        }

        private void btnFilterTxt_Click(object sender, EventArgs e)
        {
            string filter = txtBoxFilter.Text;
            FilterHeatmap(filter);
        }

        private void FilterHeatmap(string filter)
        {
            var filteredList = MainJobDataSource.Where(s => s.arbeitgeber == filter).ToList();
            var densityAlg = provider.Algorithm as HeatmapDensityBasedAlgorithm;
            densityAlg.PointRadius = 10;
            adapter.DataSource = filteredList;
        }

        List<MainSource> LoadData(string filepath)
        {
            string json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<MainSource>>(json);
        }

        public class MainSource
        {
            public string beruf;
            public string titel;
            public string refnr;
            public string arbeitgeber;
            public DateTime eintrittsdatum;
            public string entfernung;
            public string PLZ;
            public double lat { get; set; }
            public double lon { get; set; }

            public double Value => 1;
        }

        private void chartControl1_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            if (e.HitInfo.SeriesPoint != null)
            {
                FilterHeatmap(e.HitInfo.SeriesPoint.Argument);
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            adapter.DataSource = MainJobDataSource;
        }
    }
}
