﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureSqlXamarinDbDemo.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddModifyItemDialog : ContentView
    {
        public AddModifyItemDialog()
        {
            InitializeComponent();
        }
    }
}