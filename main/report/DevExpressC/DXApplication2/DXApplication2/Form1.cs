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
using DevExpress.Map.Kml.Model;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils.DPI;
using DevExpress.Utils.Text;
using DevExpress.CodeParser;

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
            provider.Algorithm = new HeatmapDensityBasedAlgorithm { PointRadius = 7 };

            ImageLayer heatmapLayer = new ImageLayer();
            heatmapLayer.DataProvider = provider;
            mapControl1.Layers.Add(heatmapLayer);


            ChoroplethColorizer colorizer = new ChoroplethColorizer();
            colorizer.RangeStops.Clear();
            colorizer.RangeStops.AddRange(new double[] { 0.1, 67, 100, 200, 300 });
            colorizer.ColorItems.Clear();
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Green));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.YellowGreen));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Yellow));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Orange));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Red));
            colorizer.ApproximateColors = true;

            provider.Colorizer = colorizer;
        }

        private List<MainSource> MainJobDataSource = new List<MainSource>();
        private List<PLZMainSource> MainPLZSource = new List<PLZMainSource>();

        private List<PLZMainSource> MainPLZSourceBaWu = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceBayern = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceBerlin = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceBrandenburg = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceBremen = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceHamburg = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceHessen = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceMCPom = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceNiedersachsen = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceNRW = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceRLP = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceSaarland = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceSachsen = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceSachsenAn = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceSchlieHol = new List<PLZMainSource>();
        private List<PLZMainSource> MainPLZSourceThueringen = new List<PLZMainSource>();

        List<string> PLZListBaWu = new List<string> { };
        List<string> PLZListBayern = new List<string> { };
        List<string> PLZListBerlin = new List<string> { };
        List<string> PLZListBrandenburg = new List<string> { };
        List<string> PLZListBremen = new List<string> { };
        List<string> PLZListHamburg = new List<string> { };
        List<string> PLZListHessen = new List<string> { };
        List<string> PLZListMCPom = new List<string> { };
        List<string> PLZListNiedersachsen = new List<string> { };
        List<string> PLZListNRW = new List<string> { };
        List<string> PLZListRLP = new List<string> { };
        List<string> PLZListSaarland = new List<string> { };
        List<string> PLZListSachsen = new List<string> { };
        List<string> PLZListSachsenAn = new List<string> { };
        List<string> PLZListSchlieHol = new List<string> { };
        List<string> PLZListThueringen = new List<string> { };


        private List<ChartData> ListGroupedJobs = new List<ChartData>();
        private List<ChartData> ListGroupedArbeitgeber = new List<ChartData>();
        private List<ChartData> ListGoupedBundesland = new List<ChartData>();


        private void Form1_Load(object sender, EventArgs e)
        {
            MainJobDataSource = LoadData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\TestJason.json");
            MainPLZSource = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahl.json");

            MainPLZSourceBaWu = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlBaWu.json");
            MainPLZSourceBayern = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlBayern.json");
            MainPLZSourceBerlin = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlBerlin.json");
            MainPLZSourceBrandenburg = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlBrandenburg.json");
            MainPLZSourceBremen = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlBremen.json");
            MainPLZSourceHamburg = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlHamburg.json");
            MainPLZSourceHessen = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlHessen.json");
            MainPLZSourceMCPom = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlMCPom.json");
            MainPLZSourceNiedersachsen = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlNiedersachsen.json");
            MainPLZSourceNRW = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlNRW.json");
            MainPLZSourceRLP = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlRLP.json");
            MainPLZSourceSaarland = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlSaarland.json");
            MainPLZSourceSachsen = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlSachsen.json");
            MainPLZSourceSachsenAn = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlSachsenAnh.json");
            MainPLZSourceSchlieHol = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlSchlieHol.json");
            MainPLZSourceThueringen = LoadPLZData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\georef-germany-postleitzahlThueringen.json");

            PLZListBaWu = MainPLZSourceBaWu.Select(s => s.plz_code).ToList();
            PLZListBayern = MainPLZSourceBayern.Select(s => s.plz_code).ToList();
            PLZListBerlin = MainPLZSourceBerlin.Select(s => s.plz_code).ToList();
            PLZListBrandenburg = MainPLZSourceBrandenburg.Select(s => s.plz_code).ToList();
            PLZListBremen = MainPLZSourceBremen.Select(s => s.plz_code).ToList();
            PLZListHamburg = MainPLZSourceHamburg.Select(s => s.plz_code).ToList();
            PLZListHessen = MainPLZSourceHessen.Select(s => s.plz_code).ToList();
            PLZListMCPom = MainPLZSourceMCPom.Select(s => s.plz_code).ToList();
            PLZListNiedersachsen = MainPLZSourceNiedersachsen.Select(s => s.plz_code).ToList();
            PLZListNRW = MainPLZSourceNRW.Select(s => s.plz_code).ToList();
            PLZListRLP = MainPLZSourceRLP.Select(s => s.plz_code).ToList();
            PLZListSaarland = MainPLZSourceSaarland.Select(s => s.plz_code).ToList();
            PLZListSachsen = MainPLZSourceSachsen.Select(s => s.plz_code).ToList();
            PLZListSachsenAn = MainPLZSourceSachsenAn.Select(s => s.plz_code).ToList();
            PLZListSchlieHol = MainPLZSourceSchlieHol.Select(s => s.plz_code).ToList();
            PLZListThueringen = MainPLZSourceThueringen.Select(s => s.plz_code).ToList();

            var JoinedPLZMainSource = MainJobDataSource.Join(MainPLZSource, a => a.PLZ, b => b.name, (a, b) => new { a.beruf, a.arbeitgeber, a.lat, a.lon, a.PLZ, b.lan_name }).ToList(); ;
            adapter.DataSource = MainJobDataSource;

            ListGroupedArbeitgeber = MainJobDataSource.GroupBy(g => g.arbeitgeber).OrderByDescending(
                o => o.Count()).Take(25).Select(s => new ChartData()
                {
                    XValue = s.Key,
                    YValue = s.Count()
                }).ToList();

            ListGroupedJobs = MainJobDataSource.GroupBy(g => g.beruf).OrderByDescending(
                o => o.Count()).Take(25).Select(s => new ChartData()
                {
                    XValue = s.Key,
                    YValue = s.Count()
                }).ToList();

            ListGoupedBundesland = JoinedPLZMainSource.GroupBy(g => g.lan_name).OrderByDescending(
                o => o.Count()).Take(16).Select(s => new ChartData()
                {
                    XValue = s.Key,
                    YValue = s.Count()
                }).ToList();



            ChartBundeslaender.DataSource = ListGoupedBundesland;
            ChartGroessteArbeitgeber.DataSource = ListGroupedArbeitgeber;
            var DiagramArbeitgeber = ChartGroessteArbeitgeber.Diagram as XYDiagram;
            DiagramArbeitgeber.AxisX.VisualRange.MinValue = ListGroupedArbeitgeber[0].XValue;
            DiagramArbeitgeber.AxisX.VisualRange.MaxValue = ListGroupedArbeitgeber[4].XValue;
            DiagramArbeitgeber.AxisX.WholeRange.MinValue = ListGroupedArbeitgeber[0].XValue;
            DiagramArbeitgeber.AxisX.WholeRange.MaxValue = ListGroupedArbeitgeber.Last().XValue;


            ChartMeisgesuchteJobs.DataSource = ListGroupedJobs;
            var DiagramJobs = ChartMeisgesuchteJobs.Diagram as XYDiagram;
            DiagramJobs.AxisX.VisualRange.MinValue = ListGroupedArbeitgeber[0].XValue;
            DiagramJobs.AxisX.VisualRange.MaxValue = ListGroupedArbeitgeber[4].XValue;
            DiagramJobs.AxisX.WholeRange.MinValue = ListGroupedArbeitgeber[0].XValue;
            DiagramJobs.AxisX.WholeRange.MaxValue = ListGroupedArbeitgeber.Last().XValue;
        }

        public class ChartData
        {
            public string XValue { get; set; }
            public int YValue { get; set; }

            public int XYValue { get; set; }
        }
        List<MainSource> LoadData(string filepath)
        {
            string json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<MainSource>>(json);
        }

        List<PLZMainSource> LoadPLZData(string filepath)
        {
            string json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<PLZMainSource>>(json);
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


        public class Geometry
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
            public Properties properties { get; set; }
            public List<List<List<double>>> coordinates { get; set; }
        }

        public class GeoPoint2d
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Properties
        {
        }

        public class PLZMainSource
        {
            public string name { get; set; }
            public string plz_name { get; set; }
            public string plz_name_long { get; set; }
            public Geometry geometry { get; set; }
            public string plz_code { get; set; }
            public string krs_code { get; set; }
            public string lan_name { get; set; }
            public string lan_code { get; set; }
            public string krs_name { get; set; }
            public GeoPoint2d geo_point_2d { get; set; }
        }


        private void FilterHeatmapToArbeitgeber(string filter)
        {
            var filteredList = MainJobDataSource.Where(s => s.arbeitgeber == filter).ToList();
            var densityAlg = provider.Algorithm as HeatmapDensityBasedAlgorithm;
            densityAlg.PointRadius = 10;

            var colorizer = provider.Colorizer as ChoroplethColorizer;
            colorizer.RangeStops.Clear();
            colorizer.RangeStops.AddRange(new double[] { 0.1, 2, 5, 8, 15 });
            colorizer.ColorItems.Clear();
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Green));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.YellowGreen));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Yellow));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Orange));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Red));
            colorizer.ApproximateColors = true;

            provider.Colorizer = colorizer;
            adapter.DataSource = filteredList;
        }
        private void FilterHeatmapToJobs(string filter)
        {
            var filteredList = MainJobDataSource.Where(s => s.beruf == filter).ToList();
            var densityAlg = provider.Algorithm as HeatmapDensityBasedAlgorithm;
            densityAlg.PointRadius = 10;

            var colorizer = provider.Colorizer as ChoroplethColorizer;
            colorizer.RangeStops.Clear();
            colorizer.RangeStops.AddRange(new double[] { 0.1, 2, 5, 20, 30 });
            colorizer.ColorItems.Clear();
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Green));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.YellowGreen));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Yellow));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Orange));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Red));
            colorizer.ApproximateColors = true;

            provider.Colorizer = colorizer;
            adapter.DataSource = filteredList;
        }
        private void FilterArbeitgeberChart(string filter)
        {
            var FilteredGroupedArbeitgeber = MainJobDataSource.Where(s => s.beruf == filter).GroupBy(g => g.arbeitgeber).OrderByDescending(
                o => o.Count()).Take(10).Select(s => new ChartData()
                {
                    XValue = s.Key,
                    YValue = s.Count()
                }).ToList();

            ChartGroessteArbeitgeber.DataSource = FilteredGroupedArbeitgeber;
        }

        private void FilterJobsChart(string filter)
        {
            var FilteredGroupedJobs = MainJobDataSource.Where(s => s.arbeitgeber == filter).GroupBy(g => g.beruf).OrderByDescending(
            o => o.Count()).Take(10).Select(s => new ChartData()
            {
                XValue = s.Key,
                YValue = s.Count()
            }).ToList();

            ChartMeisgesuchteJobs.DataSource = FilteredGroupedJobs;
        }
        private void FilterJobsToBundesland(List<MainSource> source)
        {
            var filteredMainData = source.GroupBy(g => g.beruf).OrderByDescending(
                o => o.Count()).Take(10).Select(s => new ChartData()
                {
                    XValue = s.Key,
                    YValue = s.Count()
                }).ToList();
            ChartMeisgesuchteJobs.DataSource = filteredMainData;
        }
        private void FilterArbeitgeberToBundesland(List<MainSource> source)
        {
            var filteredMainData = source.GroupBy(g => g.arbeitgeber).OrderByDescending(
                o => o.Count()).Take(10).Select(s => new ChartData()
                {
                    XValue = s.Key,
                    YValue = s.Count()
                }).ToList();
            ChartGroessteArbeitgeber.DataSource = filteredMainData;
        }

        private Dictionary<string, List<MainSource>> cachedPLZSources = new Dictionary<string, List<MainSource>>();
        private List<MainSource> GetPLZFilteredSource(string filter)
        {
            List<MainSource> filteredMainData = new List<MainSource>();

            if (cachedPLZSources.ContainsKey(filter))
            {
                return cachedPLZSources[filter];
            }

            if (filter == "Baden-W\u00fcrttemberg")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListBaWu.Contains(s.PLZ)).ToList();
            }
            if (filter == "Bayern")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListBayern.Contains(s.PLZ)).ToList();
            }
            if (filter == "Berlin")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListBerlin.Contains(s.PLZ)).ToList();
            }
            if (filter == "Brandenburg")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListBrandenburg.Contains(s.PLZ)).ToList();
            }
            if (filter == "Bremen")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListBremen.Contains(s.PLZ)).ToList();
            }
            if (filter == "Hamburg")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListHamburg.Contains(s.PLZ)).ToList();
            }
            if (filter == "Hessen")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListHessen.Contains(s.PLZ)).ToList();
            }
            if (filter == "Mecklenburg-Vorpommern")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListMCPom.Contains(s.PLZ)).ToList();
            }
            if (filter == "Niedersachsen")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListNiedersachsen.Contains(s.PLZ)).ToList();
            }
            if (filter == "Nordrhein-Westfalen")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListNRW.Contains(s.PLZ)).ToList();
            }
            if (filter == "Rheinland-Pfalz")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListRLP.Contains(s.PLZ)).ToList();
            }
            if (filter == "Saarland")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListSaarland.Contains(s.PLZ)).ToList();
            }
            if (filter == "Sachsen")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListSachsen.Contains(s.PLZ)).ToList();
            }
            if (filter == "Sachsen-Anhalt")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListSachsenAn.Contains(s.PLZ)).ToList();
            }
            if (filter == "Schleswig-Holstein")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListSchlieHol.Contains(s.PLZ)).ToList();
            }
            if (filter == "Th\u00fcringen")
            {
                filteredMainData = MainJobDataSource.Where(s => PLZListThueringen.Contains(s.PLZ)).ToList();
            }

            cachedPLZSources.Add(filter, filteredMainData);

            return filteredMainData;
        }

        private void FilterHeatmapToBundesland(List<MainSource> filteredMainData)
        {
            var densityAlg = provider.Algorithm as HeatmapDensityBasedAlgorithm;
            densityAlg.PointRadius = 7;
            adapter.DataSource = filteredMainData;
            var colorizer = provider.Colorizer as ChoroplethColorizer;

            // colorizer.RangeStops.AddRange(new double[] { 0.1, 2, 5, 8, 15 });
            colorizer.RangeStops.Clear();
            colorizer.RangeStops.AddRange(new double[] { 0.1, 67, 100, 200, 300 });
            colorizer.ColorItems.Clear();
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Green));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.YellowGreen));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Yellow));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Orange));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Red));
            colorizer.ApproximateColors = true;

            provider.Colorizer = colorizer;
        }
        private void btnFilterTxt_Click(object sender, EventArgs e)
        {
            string filter = txtBoxFilter.Text;
            FilterHeatmapToArbeitgeber(filter);
        }

        private void ChartGroessteArbeitgeber_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            if (e.HitInfo.SeriesPoint != null)
            {
                FilterHeatmapToArbeitgeber(e.HitInfo.SeriesPoint.Argument);
                FilterJobsChart(e.HitInfo.SeriesPoint.Argument);
            }
        }
        private void ChartMeisgesuchteJobs_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            if (e.HitInfo.SeriesPoint != null)
            {
                FilterHeatmapToJobs(e.HitInfo.SeriesPoint.Argument);
                FilterArbeitgeberChart(e.HitInfo.SeriesPoint.Argument);
            }
        }
        private void ChartBundeslaender_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            if (e.HitInfo.SeriesPoint != null)
            {
                var filteredSource = GetPLZFilteredSource(e.HitInfo.SeriesPoint.Argument);
                FilterHeatmapToBundesland(filteredSource);
                FilterArbeitgeberToBundesland(filteredSource);
                FilterJobsToBundesland(filteredSource);
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            ResetAllFilter();
        }
        private void ResetAllFilter()
        {
            adapter.DataSource = MainJobDataSource;
            ChartGroessteArbeitgeber.DataSource = ListGroupedArbeitgeber;
            ChartMeisgesuchteJobs.DataSource = ListGroupedJobs;
            var densityAlg = provider.Algorithm as HeatmapDensityBasedAlgorithm;
            densityAlg.PointRadius = 7;
            var colorizer = provider.Colorizer as ChoroplethColorizer;

           // colorizer.RangeStops.AddRange(new double[] { 0.1, 2, 5, 8, 15 });
            colorizer.RangeStops.Clear();
            colorizer.RangeStops.AddRange(new double[] { 0.1, 67, 100, 200, 300 });
            colorizer.ColorItems.Clear();
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Green));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.YellowGreen));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Yellow));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Orange));
            colorizer.ColorItems.Add(new ColorizerColorItem(Color.Red));
            colorizer.ApproximateColors = true;

            provider.Colorizer = colorizer;

        }

        private void ChartGroessteArbeitgeber_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            e.LabelText = e.SeriesPoint.Argument;
        }
    }
}
