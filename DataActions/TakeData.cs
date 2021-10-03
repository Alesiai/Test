using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;
using System.Windows;
using System;

using Colors = TestForAtomicus.Model.Colors;

namespace TestForAtomicus.DataActions
{
    static class TakeData
    {
        static string Path = "Color.dat";

        public static void SendColorsToBinary(ObservableCollection<Colors> ColorsList)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(Path)))
            {
                foreach (Colors colors in ColorsList)
                {
                    writer.Write(colors.ColorName.R);
                    writer.Write(colors.ColorName.G);
                    writer.Write(colors.ColorName.B);
                }
            }
        }


        public static ObservableCollection<Colors> TakeColorsFromBinary()
        {
            ObservableCollection<Colors> ListOfColors = new ObservableCollection<Colors>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        Colors color = new Colors();

                        byte R = reader.ReadByte();
                        byte G = reader.ReadByte();
                        byte B = reader.ReadByte();

                        color.ColorName = Color.FromRgb(R, G, B);
                        ListOfColors.Add(color);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return ListOfColors;
        }
    }
}
