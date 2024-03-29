﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintProductList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                getProductListResultBindingSource.DataSource = db.getProductList().ToList();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<getProductList_Result> list = getProductListResultBindingSource.DataSource as List<getProductList_Result>;
            if (list != null)
            {
                using(Form2 frm=new Form2(list))
                {
                    frm.ShowDialog();
                }
            }
        }
    }
}
