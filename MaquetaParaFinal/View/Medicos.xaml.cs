﻿using MaquetaParaFinal.View.Agregar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaquetaParaFinal.View
{
    public partial class Medicos : Page
    {
        public Medicos()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarMedico agregarMedico = new AgregarMedico();
            agregarMedico.ShowDialog();
            try
            {
                DataGridMedicos.ItemsSource = conectar.DescargaTablaProfesinales().DefaultView;
            }
            catch { }
        }
    }
}
