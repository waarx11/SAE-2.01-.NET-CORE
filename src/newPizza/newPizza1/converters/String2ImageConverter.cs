﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace newPizza1.converters
{
    class String2ImageConverter : IValueConverter
    {
        public static string ImagesPath { get; private set; }


        static String2ImageConverter()
        {
            ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\img\\");
        }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;

            if (string.IsNullOrWhiteSpace(imageName)) return new Uri("..\\img\\default\\noImg.png", UriKind.RelativeOrAbsolute);

            string imagePath = Path.Combine(ImagesPath, imageName);

            return new Uri(imagePath, UriKind.RelativeOrAbsolute);

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }

}
