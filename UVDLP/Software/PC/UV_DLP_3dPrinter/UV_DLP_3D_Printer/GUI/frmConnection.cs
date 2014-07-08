﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmConnection : Form
    {
        ConnectionConfig m_config;
        public frmConnection(ref ConnectionConfig config)
        {
            m_config = config;
            InitializeComponent();
            SetData();
        }

        private bool GetData() 
        {
            try
            {
                m_config.comname = cmbPorts.SelectedItem.ToString();
                m_config.speed = int.Parse(cmbSpeed.SelectedItem.ToString());
                m_config.databits = int.Parse(txtDataBits.Text);
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
                return false;
            }
        }

        private void SetData() 
        {
            ConnectionConfig cc = m_config;
            cmbPorts.Items.Clear();
            //set all available port names
            foreach (String s in SerialPort.GetPortNames()) 
            {
                cmbPorts.Items.Add(s);
            }
            cmbPorts.SelectedItem = cc.comname;
            cmbSpeed.SelectedItem = cc.speed.ToString();
            txtDataBits.Text = cc.databits.ToString();

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GetData()) 
            {
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdrefresh_Click(object sender, EventArgs e)
        {
            SetData();
        }

    }
}
