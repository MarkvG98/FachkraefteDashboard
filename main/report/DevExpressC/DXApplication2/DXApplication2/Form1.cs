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

namespace DXApplication2
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            HeatmapDataSourceAdapter adapter = new HeatmapDataSourceAdapter();
            adapter.Mappings.XCoordinate = "lon"; //The data souce field name that provides x-coordinate
            adapter.Mappings.YCoordinate = "lat"; //The data sou"rce field name that provides y-coordinate
            adapter.DataSource = LoadData("C:\\projects\\dashboard\\FachkraefteDashboard\\main\\dump\\TestJason.json");

            HeatmapProvider provider = new HeatmapProvider();
            provider.PointSource = adapter;
            provider.Algorithm = new HeatmapDensityBasedAlgorithm { PointRadius = 3 };

            ImageLayer heatmapLayer = new ImageLayer();
            heatmapLayer.DataProvider = provider;
            mapControl1.Layers.Add(heatmapLayer);
        }

        DataTable LoadData(string filepath)
        {
            string json = File.ReadAllText(filepath);
            return (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
        }
    }
}
