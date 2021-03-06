﻿using System;
using System.Windows.Forms;
using MissionPlanner.Controls;
using GMap.NET.WindowsForms;
using MissionPlanner.GCSViews;

namespace MissionPlanner
{
    public partial class Form1 : Form
    {

        GMapOverlay drawnpolygonsoverlay = new GMapOverlay("drawnpolygons");


        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

            int i, k;
            double o;
            o = MainV2.instance.FlightPlanner.drawnpolygon.Points[0].Lat;
            k = FlightPlanner.k;
            dataGridView1.RowCount = k + 1;
            string h = "50";
            InputBox.Show("海拔", "海拔", ref h);
            for (i = 0; i < k; i++)
            {
                MainV2.instance.FlightPlanner.polygongridmode = false;
                MainV2.instance.FlightPlanner.AddWPToMap(MainV2.instance.FlightPlanner.drawnpolygon.Points[i].Lat, MainV2.instance.FlightPlanner.drawnpolygon.Points[i].Lng, Int32.Parse(h));
                MainV2.instance.FlightPlanner.setfromMap(MainV2.instance.FlightPlanner.drawnpolygon.Points[i].Lat, MainV2.instance.FlightPlanner.drawnpolygon.Points[i].Lng, Int32.Parse(h));
            }
            MainV2.instance.FlightPlanner.AddWPToMap(MainV2.instance.FlightPlanner.drawnpolygon.Points[0].Lat, MainV2.instance.FlightPlanner.drawnpolygon.Points[0].Lng, Int32.Parse(h));
            MainV2.instance.FlightPlanner.setfromMap(MainV2.instance.FlightPlanner.drawnpolygon.Points[0].Lat, MainV2.instance.FlightPlanner.drawnpolygon.Points[0].Lng, Int32.Parse(h));
            for (i = 0; i < k; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = MainV2.instance.FlightPlanner.drawnpolygon.Points[i].Lng;
                dataGridView1.Rows[i].Cells[2].Value = MainV2.instance.FlightPlanner.drawnpolygon.Points[i].Lat;
            }
            dataGridView1.Rows[k].Cells[0].Value = k + 1;
            dataGridView1.Rows[k].Cells[1].Value = MainV2.instance.FlightPlanner.drawnpolygon.Points[0].Lng;
            dataGridView1.Rows[k].Cells[2].Value = MainV2.instance.FlightPlanner.drawnpolygon.Points[0].Lat;
            Show();
            MainV2.instance.FlightPlanner.drawnpolygon.Points.Clear();
            MainV2.instance.FlightPlanner.MainMap.Invalidate();

            MainV2.instance.FlightPlanner.writeKML();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

