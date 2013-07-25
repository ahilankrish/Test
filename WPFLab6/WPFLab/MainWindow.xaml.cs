using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFLab6
{
    
    public partial class MainWindow : Window
    {
        private int diameter = 8;
        private Brush brushColor = Brushes.Black;
        private bool shouldErase = false;
        private bool shouldpaint = false;

        private enum Sizes
        {
            SMALL = 4, MEDIUM = 8, LARGE = 10
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void paintCircle(Brush circleColor, Point position)
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = circleColor;
            newEllipse.Width = diameter;
            newEllipse.Height = diameter;
            Canvas.SetTop(newEllipse, position.Y);
            Canvas.SetLeft(newEllipse, position.X);
            paintCanvas.Children.Add(newEllipse);
        }


        private void paintCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (shouldpaint)
            {
                Point mousePosition = e.GetPosition(paintCanvas);
                paintCircle(brushColor, mousePosition);

            }
            else if (shouldErase)
            {
                Point mousePosition = e.GetPosition(paintCanvas);
                paintCircle(paintCanvas.Background, mousePosition);
            }

        }

        private void redRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Red;
        }

        private void blueRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Blue;

        }

        private void greenRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Green;

        }

        private void blackRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Black;
        }

        private void smallRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.SMALL;
        }

        private void mediumRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.MEDIUM;
        }

        private void largeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.LARGE;
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            int count = paintCanvas.Children.Count;
            if (count > 0)
                paintCanvas.Children.RemoveAt(count - 1);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            paintCanvas.Children.Clear();
        }

        private void paintCanvas_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            shouldpaint = true;
        }

        private void paintCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            shouldpaint = false;
        }

        private void paintCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            shouldpaint = true;
        }

        private void paintCanvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            shouldpaint = false;
        }



    }
}
