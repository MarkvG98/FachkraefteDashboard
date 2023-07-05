namespace DXApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange1 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange2 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange3 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.MapLayer = new DevExpress.XtraMap.ImageLayer();
            this.wmsDataProvider1 = new DevExpress.XtraMap.WmsDataProvider();
            this.heatMapLayer = new DevExpress.XtraMap.ImageLayer();
            this.heatmapProvider1 = new DevExpress.XtraMap.HeatmapProvider();
            this.btnFilterTxt = new System.Windows.Forms.Button();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.ChartGroessteArbeitgeber = new DevExpress.XtraCharts.ChartControl();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.entityServerModeSource1 = new DevExpress.Data.Linq.EntityServerModeSource();
            this.ChartMeisgesuchteJobs = new DevExpress.XtraCharts.ChartControl();
            this.ChartBundeslaender = new DevExpress.XtraCharts.ChartControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.circularGauge1 = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleSpindleCapComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGroessteArbeitgeber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMeisgesuchteJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBundeslaender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(50.5D, 10D);
            this.mapControl1.Layers.Add(this.MapLayer);
            this.mapControl1.Layers.Add(this.heatMapLayer);
            this.mapControl1.Location = new System.Drawing.Point(2, 12);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(735, 649);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.ZoomLevel = 5.8D;
            this.MapLayer.DataProvider = this.wmsDataProvider1;
            this.MapLayer.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            this.MapLayer.Name = "WmsMap";
            this.wmsDataProvider1.ActiveLayerName = "OSM-WMS";
            this.wmsDataProvider1.ServerUri = "http://ows.mundialis.de/services/service?";
            this.heatMapLayer.DataProvider = this.heatmapProvider1;
            // 
            // btnFilterTxt
            // 
            this.btnFilterTxt.Location = new System.Drawing.Point(545, 667);
            this.btnFilterTxt.Name = "btnFilterTxt";
            this.btnFilterTxt.Size = new System.Drawing.Size(192, 44);
            this.btnFilterTxt.TabIndex = 1;
            this.btnFilterTxt.Text = "Filter";
            this.btnFilterTxt.UseVisualStyleBackColor = true;
            this.btnFilterTxt.Click += new System.EventHandler(this.btnFilterTxt_Click);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.Location = new System.Drawing.Point(200, 667);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(339, 23);
            this.txtBoxFilter.TabIndex = 2;
            // 
            // ChartGroessteArbeitgeber
            // 
            this.ChartGroessteArbeitgeber.AutoLayout = false;
            xyDiagram1.AxisX.Label.Alignment = DevExpress.XtraCharts.AxisLabelAlignment.Center;
            xyDiagram1.AxisX.Label.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 6F);
            xyDiagram1.AxisX.LabelPosition = DevExpress.XtraCharts.AxisLabelPosition.Inside;
            xyDiagram1.AxisX.MinorCount = 5;
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "9";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.WholeRange.Auto = false;
            xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "9";
            xyDiagram1.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.EnableAxisXScrolling = true;
            this.ChartGroessteArbeitgeber.Diagram = xyDiagram1;
            this.ChartGroessteArbeitgeber.Legend.LegendID = -1;
            this.ChartGroessteArbeitgeber.Location = new System.Drawing.Point(747, 15);
            this.ChartGroessteArbeitgeber.Name = "ChartGroessteArbeitgeber";
            series1.ArgumentDataMember = "XValue";
            sideBySideBarSeriesLabel1.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Anzahl Stellen";
            series1.SeriesID = 0;
            series1.ValueDataMembersSerializable = "YValue";
            this.ChartGroessteArbeitgeber.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ChartGroessteArbeitgeber.Size = new System.Drawing.Size(1167, 454);
            this.ChartGroessteArbeitgeber.TabIndex = 3;
            this.ChartGroessteArbeitgeber.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.ChartGroessteArbeitgeber_ObjectSelected);
            this.ChartGroessteArbeitgeber.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ChartGroessteArbeitgeber_CustomDrawSeriesPoint);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(2, 664);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(192, 44);
            this.btnResetFilter.TabIndex = 4;
            this.btnResetFilter.Text = "Reset Filter";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // ChartMeisgesuchteJobs
            // 
            xyDiagram2.AxisX.Label.Alignment = DevExpress.XtraCharts.AxisLabelAlignment.Center;
            xyDiagram2.AxisX.Label.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 6F);
            xyDiagram2.AxisX.LabelPosition = DevExpress.XtraCharts.AxisLabelPosition.Inside;
            xyDiagram2.AxisX.MinorCount = 5;
            xyDiagram2.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisX.VisualRange.Auto = false;
            xyDiagram2.AxisX.VisualRange.MaxValueSerializable = "9";
            xyDiagram2.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram2.AxisX.WholeRange.Auto = false;
            xyDiagram2.AxisX.WholeRange.MaxValueSerializable = "9";
            xyDiagram2.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.EnableAxisXScrolling = true;
            this.ChartMeisgesuchteJobs.Diagram = xyDiagram2;
            this.ChartMeisgesuchteJobs.Legend.LegendID = -1;
            this.ChartMeisgesuchteJobs.Location = new System.Drawing.Point(747, 480);
            this.ChartMeisgesuchteJobs.Name = "ChartMeisgesuchteJobs";
            series2.ArgumentDataMember = "XValue";
            sideBySideBarSeriesLabel2.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop;
            series2.Label = sideBySideBarSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Anzahl Jobs Gesamt";
            series2.SeriesID = 0;
            series2.ValueDataMembersSerializable = "YValue";
            this.ChartMeisgesuchteJobs.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.ChartMeisgesuchteJobs.Size = new System.Drawing.Size(1167, 553);
            this.ChartMeisgesuchteJobs.TabIndex = 5;
            this.ChartMeisgesuchteJobs.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.ChartMeisgesuchteJobs_ObjectSelected);
            this.ChartMeisgesuchteJobs.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ChartGroessteArbeitgeber_CustomDrawSeriesPoint);
            // 
            // ChartBundeslaender
            // 
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            this.ChartBundeslaender.Diagram = xyDiagram3;
            this.ChartBundeslaender.Legend.LegendID = -1;
            this.ChartBundeslaender.Location = new System.Drawing.Point(2, 714);
            this.ChartBundeslaender.Name = "ChartBundeslaender";
            series3.ArgumentDataMember = "XValue";
            series3.Name = "Jobs nach Orten";
            series3.SeriesID = 0;
            series3.ValueDataMembersSerializable = "YValue";
            this.ChartBundeslaender.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.ChartBundeslaender.Size = new System.Drawing.Size(477, 314);
            this.ChartBundeslaender.TabIndex = 6;
            this.ChartBundeslaender.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.ChartBundeslaender_ObjectSelected);
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(485, 726);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(252, 287);
            this.gaugeControl1.TabIndex = 7;
            // 
            // circularGauge1
            // 
            this.circularGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.circularGauge1.Bounds = new System.Drawing.Rectangle(3, 2, 244, 284);
            this.circularGauge1.Name = "circularGauge1";
            this.circularGauge1.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
            this.circularGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleComponent1});
            this.circularGauge1.SpindleCaps.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent[] {
            this.arcScaleSpindleCapComponent1});
            // 
            // arcScaleComponent1
            // 
            this.arcScaleComponent1.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent1.AppearanceTickmarkText.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.arcScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.arcScaleComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 140F);
            this.arcScaleComponent1.EndAngle = 45F;
            this.arcScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.arcScaleComponent1.MajorTickmark.ShapeOffset = -13F;
            this.arcScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1;
            this.arcScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleComponent1.MaxValue = 100F;
            this.arcScaleComponent1.MinorTickCount = 4;
            this.arcScaleComponent1.MinorTickmark.ShapeOffset = -9F;
            this.arcScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2;
            this.arcScaleComponent1.Name = "scale1";
            arcScaleRange1.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#9EC968");
            arcScaleRange1.EndThickness = 14F;
            arcScaleRange1.EndValue = 33F;
            arcScaleRange1.Name = "Range0";
            arcScaleRange1.ShapeOffset = 0F;
            arcScaleRange1.StartThickness = 14F;
            arcScaleRange2.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#FED96D");
            arcScaleRange2.EndThickness = 14F;
            arcScaleRange2.EndValue = 66F;
            arcScaleRange2.Name = "Range1";
            arcScaleRange2.ShapeOffset = 0F;
            arcScaleRange2.StartThickness = 14F;
            arcScaleRange2.StartValue = 33F;
            arcScaleRange3.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#EF8C75");
            arcScaleRange3.EndThickness = 14F;
            arcScaleRange3.EndValue = 100F;
            arcScaleRange3.Name = "Range2";
            arcScaleRange3.ShapeOffset = 0F;
            arcScaleRange3.StartThickness = 14F;
            arcScaleRange3.StartValue = 66F;
            this.arcScaleComponent1.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange1,
            arcScaleRange2,
            arcScaleRange3});
            this.arcScaleComponent1.StartAngle = -225F;
            // 
            // arcScaleBackgroundLayerComponent1
            // 
            this.arcScaleBackgroundLayerComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleBackgroundLayerComponent1.Name = "bg1";
            this.arcScaleBackgroundLayerComponent1.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.56F);
            this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularThreeFourth_Style16;
            this.arcScaleBackgroundLayerComponent1.Size = new System.Drawing.SizeF(250F, 224F);
            this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // arcScaleNeedleComponent1
            // 
            this.arcScaleNeedleComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleNeedleComponent1.EndOffset = 5F;
            this.arcScaleNeedleComponent1.Name = "needle1";
            this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style16;
            this.arcScaleNeedleComponent1.ZOrder = -50;
            // 
            // arcScaleSpindleCapComponent1
            // 
            this.arcScaleSpindleCapComponent1.ArcScale = this.arcScaleComponent1;
            this.arcScaleSpindleCapComponent1.Name = "cap1";
            this.arcScaleSpindleCapComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.SpindleCapShapeType.CircularFull_Style16;
            this.arcScaleSpindleCapComponent1.Size = new System.Drawing.SizeF(25F, 25F);
            this.arcScaleSpindleCapComponent1.ZOrder = -100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 1040);
            this.Controls.Add(this.gaugeControl1);
            this.Controls.Add(this.ChartBundeslaender);
            this.Controls.Add(this.ChartMeisgesuchteJobs);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.ChartGroessteArbeitgeber);
            this.Controls.Add(this.txtBoxFilter);
            this.Controls.Add(this.btnFilterTxt);
            this.Controls.Add(this.mapControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGroessteArbeitgeber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMeisgesuchteJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBundeslaender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraMap.MapControl mapControl1;
        private DevExpress.XtraMap.ImageLayer MapLayer;
        private DevExpress.XtraMap.WmsDataProvider wmsDataProvider1;
        private DevExpress.XtraMap.ImageLayer heatMapLayer;
        private DevExpress.XtraMap.HeatmapProvider heatmapProvider1;
        private System.Windows.Forms.Button btnFilterTxt;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private DevExpress.XtraCharts.ChartControl ChartGroessteArbeitgeber;
        private System.Windows.Forms.Button btnResetFilter;
        private DevExpress.Data.Linq.EntityServerModeSource entityServerModeSource1;
        private DevExpress.XtraCharts.ChartControl ChartMeisgesuchteJobs;
        private DevExpress.XtraCharts.ChartControl ChartBundeslaender;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent1;
    }
}
