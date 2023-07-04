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
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.MapLayer = new DevExpress.XtraMap.ImageLayer();
            this.wmsDataProvider1 = new DevExpress.XtraMap.WmsDataProvider();
            this.heatMapLayer = new DevExpress.XtraMap.ImageLayer();
            this.heatmapProvider1 = new DevExpress.XtraMap.HeatmapProvider();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(50D, 11D);
            this.mapControl1.Layers.Add(this.MapLayer);
            this.mapControl1.Layers.Add(this.heatMapLayer);
            this.mapControl1.Location = new System.Drawing.Point(240, -1);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(593, 533);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.ZoomLevel = 5D;
            this.MapLayer.DataProvider = this.wmsDataProvider1;
            this.MapLayer.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            this.MapLayer.Name = "WmsMap";
            this.wmsDataProvider1.ActiveLayerName = "TOPO-OSM-WMS";
            this.wmsDataProvider1.ServerUri = "http://ows.mundialis.de/services/service?";
            this.heatMapLayer.DataProvider = this.heatmapProvider1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 660);
            this.Controls.Add(this.mapControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl mapControl1;
        private DevExpress.XtraMap.ImageLayer MapLayer;
        private DevExpress.XtraMap.WmsDataProvider wmsDataProvider1;
        private DevExpress.XtraMap.ImageLayer heatMapLayer;
        private DevExpress.XtraMap.HeatmapProvider heatmapProvider1;
    }
}

