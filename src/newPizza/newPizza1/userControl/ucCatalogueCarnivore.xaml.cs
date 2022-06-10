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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele;

namespace newPizza1
{
    /// <summary>
    /// Logique d'interaction pour ucCatalogueCarnivore.xaml
    /// </summary>
    public partial class ucCatalogueCarnivore : UserControl
    {
        public Manager Mgr => ((App)App.Current).LeManager;
        public ucCatalogueCarnivore()
        {
            DataContext = Mgr;
            InitializeComponent();
        }

        public event RoutedEventHandler? CLICKCARNIVORE;
        private void MenuBouton_Click(object sender, RoutedEventArgs e)
        {
            if (CLICKCARNIVORE != null)
            {
                CLICKCARNIVORE(this, e);
            }
        }


    }
}