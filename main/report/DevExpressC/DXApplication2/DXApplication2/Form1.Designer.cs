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
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.MapLayer = new DevExpress.XtraMap.ImageLayer();
            this.wmsDataProvider1 = new DevExpress.XtraMap.WmsDataProvider();
            this.heatMapLayer = new DevExpress.XtraMap.ImageLayer();
            this.heatmapProvider1 = new DevExpress.XtraMap.HeatmapProvider();
            this.btnFilterTxt = new System.Windows.Forms.Button();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.btnResetFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(50.5D, 10D);
            this.mapControl1.Layers.Add(this.MapLayer);
            this.mapControl1.Layers.Add(this.heatMapLayer);
            this.mapControl1.Location = new System.Drawing.Point(12, -1);
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
            this.btnFilterTxt.Location = new System.Drawing.Point(985, 517);
            this.btnFilterTxt.Name = "btnFilterTxt";
            this.btnFilterTxt.Size = new System.Drawing.Size(75, 23);
            this.btnFilterTxt.TabIndex = 1;
            this.btnFilterTxt.Text = "Filter";
            this.btnFilterTxt.UseVisualStyleBackColor = true;
            this.btnFilterTxt.Click += new System.EventHandler(this.btnFilterTxt_Click);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.Location = new System.Drawing.Point(881, 478);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(312, 23);
            this.txtBoxFilter.TabIndex = 2;
            // 
            // chartControl1
            // 
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram3;
            this.chartControl1.Legend.LegendID = -1;
            this.chartControl1.Location = new System.Drawing.Point(753, -1);
            this.chartControl1.Name = "chartControl1";
            series5.ArgumentDataMember = "XValue";
            series5.Name = "Series 1";
            series5.SeriesID = 0;
            series5.ValueDataMembersSerializable = "YValue";
            series6.ArgumentDataMember = "XValue";
            series6.Name = "Series 2";
            series6.SeriesID = 1;
            series6.ValueDataMembersSerializable = "XYValue";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series5,
        series6};
            this.chartControl1.Size = new System.Drawing.Size(649, 445);
            this.chartControl1.TabIndex = 3;
            this.chartControl1.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.chartControl1_ObjectSelected);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(1108, 517);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(120, 23);
            this.btnResetFilter.TabIndex = 4;
            this.btnResetFilter.Text = "Reset Filter";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 1040);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.txtBoxFilter);
            this.Controls.Add(this.btnFilterTxt);
            this.Controls.Add(this.mapControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
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
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Button btnResetFilter;
    }
}

