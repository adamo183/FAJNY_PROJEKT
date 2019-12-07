﻿using System;
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
using System.Windows.Shapes;

namespace Project_management
{
    /// <summary>
    /// Logika interakcji dla klasy SML_Subject.xaml
    /// </summary>
    public partial class SML_Subject : Window
    {
        public SML_Subject()
        {
            InitializeComponent();
        }

        /// To potem wyedytować bo SML_Sub_EditButton przenosi tam gdzie SML_Sub_AddSubjectButton
        private void SML_Sub_EditButton(object sender, RoutedEventArgs e)
        {
            SML_Sub_AddEdit SML_Sub_AddEdit_window = new SML_Sub_AddEdit();
            this.Visibility = Visibility.Hidden;
            SML_Sub_AddEdit_window.Show();
        }
        private void SML_Sub_AddSubjectButton(object sender, RoutedEventArgs e) 
        {
            SML_Sub_AddEdit SML_Sub_AddEdit_window = new SML_Sub_AddEdit();
            this.Visibility = Visibility.Hidden;
            SML_Sub_AddEdit_window.Show();
        }
    }
}
