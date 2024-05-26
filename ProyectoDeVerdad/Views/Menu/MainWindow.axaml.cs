using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

namespace ProyectoDeVerdad.Views
{
    public partial class MainWindow : Window
    {
        private bool _mouseDownForWindowMoving = false;
        private Point _originalPoint;
        private bool _isMouseOverImage = false;
        
        private List<Button> buttons;
        private int currentStartIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            AttachWindowMoveEvents();
            buttons = new List<Button> { GatoButton, PPoTButton, RiskButton };
            StackPanel = this.FindControl<StackPanel>("StackPanel");
        }

        private void AttachWindowMoveEvents()
        {
            // Suscribirse al evento PointerPressed del control TopPanel (que es una imagen)
            var topPanel = this.FindControl<Image>("TopPanel");
            topPanel.PointerPressed += (sender, e) =>
            {
                if (e.GetCurrentPoint(topPanel).Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
                {
                    _mouseDownForWindowMoving = true;
                    _originalPoint = e.GetPosition(this);
                }
            };

            // Suscribirse al evento PointerMoved de la ventana
            this.PointerMoved += (sender, e) =>
            {
                if (_mouseDownForWindowMoving)
                {
                    var currentPoint = e.GetPosition(this);
                    var delta = currentPoint - _originalPoint;

                    // Mover la ventana según el desplazamiento del mouse
                    Position = new PixelPoint(Position.X + (int)delta.X, Position.Y + (int)delta.Y);
                }
            };

            // Suscribirse al evento PointerReleased de la ventana
            this.PointerReleased += (sender, e) =>
            {
                if (e.GetCurrentPoint(this).Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonReleased)
                {
                    _mouseDownForWindowMoving = false;
                }
            };
        }

        private async void GatoButton_OnClick(object? sender, RoutedEventArgs e)
        { 
            await Task.Delay(700);
            var gato1V1 = new Game();
            gato1V1.Show();        
        }

        private void ScrollViewer_OnScrollChanged(object? sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer == null) return;

            var verticalOffset = scrollViewer.Offset.Y;
            var viewportHeight = scrollViewer.Viewport.Height;
            var extentHeight = scrollViewer.Extent.Height;

            if (verticalOffset <= 0)
            {
                ScrollUp();
            }
            else if (verticalOffset >= extentHeight - viewportHeight)
            {
                ScrollDown();
            }
        }
        
        
        
        private void ScrollUp()
        {
            if (currentStartIndex <= 0) return;

            currentStartIndex--;

            StackPanel.Children.RemoveAt(StackPanel.Children.Count - 2); // Remove second last item (not bottom buffer)
            StackPanel.Children.Insert(1, buttons[currentStartIndex]); // Add new item at the top (after top buffer)
            
            ScrollViewer.Offset = new Avalonia.Vector(ScrollViewer.Offset.X, buttons[currentStartIndex].Height); // Adjust scroll offset
        }

        private void ScrollDown()
        {
            if (currentStartIndex + StackPanel.Children.Count - 3 >= buttons.Count) return; // -3 for top/bottom buffer

            currentStartIndex++;

            StackPanel.Children.RemoveAt(1); // Remove first item (not top buffer)
            StackPanel.Children.Insert(StackPanel.Children.Count - 1, buttons[currentStartIndex + StackPanel.Children.Count - 3]); // Add new item at the bottom (before bottom buffer)
            
            ScrollViewer.Offset = new Avalonia.Vector(ScrollViewer.Offset.X, ScrollViewer.Offset.Y - buttons[currentStartIndex].Height); // Adjust scroll offset
        }
    }
}