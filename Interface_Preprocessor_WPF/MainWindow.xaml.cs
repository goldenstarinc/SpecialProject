﻿using Microsoft.Win32;
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
using DataProcessor;

namespace Interface_Preprocessor_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExcelFile ExcelFile;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ExcelFile = new ExcelFile(openFileDialog.FileName);

                    Window1 ViewWindow = new Window1(openFileDialog.FileName, ExcelFile);
                    ViewWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox($"Ошибка: {ex.Message}");
                    customMessageBox.ShowDialog();
                }
            } 
        }
    }
}
