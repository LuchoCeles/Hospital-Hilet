﻿using MaquetaParaFinal.Clases;
using MaquetaParaFinal.View.Agregar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaquetaParaFinal.View
{
    public partial class Pacientes : Page
    {
        Conectar conectar = new Conectar();
        private void DataGridPacientes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
        private void DataGridPacientes_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridPacientes.ItemsSource = conectar.DescargaTablaPaciente().DefaultView;
        }
       
        private void CargarSeleccion(int num = 0)
        {
            if (DataGridPacientes.SelectedItem != null && DataGridPacientes.Items.Count >= num)
            {
                DataGridPacientes.SelectedIndex = num;
                DataRowView row = (DataRowView)DataGridPacientes.SelectedItem;
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtDni.Text = row["Dni"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtFecha_De_Nacimiento.Text = row["Fecha De Nacimiento"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCalle.Text = row["Calle"].ToString();
                txtNro.Text = row["Numero"].ToString();
                txtLocalidad.Text = row["Localidad"].ToString();
                txtCodPostas.Text = row["Codigo Postal"].ToString();
                txtPiso.Text = row["Piso"].ToString();
            }
        }

        private void DataGridPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)DataGridPacientes.SelectedItem;
            CargarSeleccion(int.Parse(row["ID"].ToString()) - 1); //-1 Porque el Datagrid comienza en 0 y el id en 1 (ya le dije al ale que inicie en 0)
        }
        private void ClickBuscar(object sender, RoutedEventArgs e) => Buscar(txtBuscar.Text);
        private void EnterBuscar(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) Buscar(txtBuscar.Text);
        }
        private void Buscar(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return;
            }

            foreach (DataRowView columna in DataGridPacientes.ItemsSource)
            {
                int mostrarFila = -1;

                for (int i = 0; i < columna.Row.ItemArray.Length; i++)
                {
                    if (columna.Row.ItemArray[i] is string valorCelda)
                    { // "StringComparison.OrdinalIgnoreCase" es para que compare pero ignorando las diferencias de mayusculas y minusculas
                        if (valorCelda.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0) // Aca compara el valor de la celda con lo buscando
                        {
                            mostrarFila = int.Parse(columna.Row["ID"].ToString())-1;
                            break;
                        }
                    }
                }
                if (mostrarFila != -1) 
                {
                    DataGridPacientes.SelectedIndex = mostrarFila;
                    CargarSeleccion(mostrarFila);
                }
            }
        }
        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPaciente agregarPaciente = new AgregarPaciente();
            agregarPaciente.Show();
        }
    }
}
