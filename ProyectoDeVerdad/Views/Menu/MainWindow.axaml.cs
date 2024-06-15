using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Styling;
using ProyectoDeVerdad.Views.Rock;
using Risk.Views;

namespace ProyectoDeVerdad.Views
{
    public partial class MainWindow : Window
    {
        private bool _mouseDownForWindowMoving = false;
        private Point _originalPoint;
        private bool _isMouseOverImage = false;

        private List<Button> buttons;
        private int currentStartIndex = 0;
        
         public class RandomModelSingleton
{
    private static RandomModelSingleton instance;
    private double[][][] randomModel;

    private RandomModelSingleton()
    {
        randomModel = BuildRandomModel();
    }

    public static RandomModelSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RandomModelSingleton();
            }
            return instance;
        }
    }

    private double[][][] BuildRandomModel()
    {
        int numGames = 100;
        int numTurns = 100; // Ensure this is the minimum number of turns you want per game
        double[][][] randomModel = new double[numTurns][][]; // First dimension is now 'numTurns'

        // Initialize random model
        for (int turn = 0; turn < numTurns; turn++)
        {
            randomModel[turn] = new double[3][]; // Three actions: Recargar, Escudo, Disparar
            for (int action = 0; action < 3; action++)
            {
                randomModel[turn][action] = new double[3]; // Probability of each action at each turn
            }
        }

        // Define a jagged array to store game patterns
        List<int>[] gamePatterns = new List<int>[numGames];

        // Initialize each game's pattern
        for (int j = 0; j < numGames; j++)
        {
            gamePatterns[j] = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < numTurns; i++)
            {
                int action = rand.Next(1, 4); // Generating a random action: 1 (Recargar), 2 (Escudo), or 3 (Disparar)
                gamePatterns[j].Add(action);
            }
        }

        // Count occurrences of each action at each turn position
        for (int turn = 0; turn < numTurns; turn++)
        {
            int[] actionOccurrences = new int[3]; // Count of each action
            for (int game = 0; game < numGames; game++)
            {
                int action = gamePatterns[game][turn] - 1; // Adjust for 0-based index
                actionOccurrences[action]++;
            }

            // Calculate probabilities
            for (int action = 0; action < 3; action++)
            {
                for (int otherAction = 0; otherAction < 3; otherAction++)
                {
                    randomModel[turn][action][otherAction] = (double)actionOccurrences[otherAction] / numGames;
                }
            }
        }

        return randomModel;
    }

    public double[][][] GetRandomModel()
    {
        return randomModel;
    }
}
        
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

            var horizontalOffset = scrollViewer.Offset.X;
            var viewportWidth = scrollViewer.Viewport.Width;
            var extentWidth = scrollViewer.Extent.Width;

            if (horizontalOffset <= 0)
            {
                ScrollLeft();
            }
            else if (horizontalOffset >= extentWidth - viewportWidth)
            {
                ScrollRight();
            }
        }

        private void ScrollLeft()
        {
            if (currentStartIndex <= 0) return;

            currentStartIndex--;

            var grid = (Grid)ScrollViewer.Content;

            if (grid.Children.Count > 4)
            {
                // Remove the second last item (not right buffer)
                grid.Children.RemoveAt(grid.Children.Count - 2);
            }

            // Insert new item at the second position (after left buffer)
            if (currentStartIndex >= 0 && currentStartIndex < buttons.Count)
            {
                grid.Children.Insert(1, buttons[currentStartIndex]);
            }

            // Adjust scroll offset
            ScrollViewer.Offset = new Avalonia.Vector(buttons[currentStartIndex].Width, ScrollViewer.Offset.Y);
        }

        private void ScrollRight()
        {
            var grid = (Grid)ScrollViewer.Content;

            if (currentStartIndex + 3 >= buttons.Count) return;

            currentStartIndex++;

            if (grid.Children.Count > 4)
            {
                // Remove the first item (not left buffer)
                grid.Children.RemoveAt(1);
            }

            // Insert new item at the second last position (before right buffer)
            if (currentStartIndex + 3 < buttons.Count)
            {
                grid.Children.Insert(grid.Children.Count - 1, buttons[currentStartIndex + 2]);
            }

            // Adjust scroll offset
            ScrollViewer.Offset = new Avalonia.Vector(ScrollViewer.Offset.X - buttons[currentStartIndex].Width, ScrollViewer.Offset.Y);
        }
        
        private void Right_OnClick(object? sender, RoutedEventArgs e)
        {
            double scrollAmount = 300; // Amount to scroll each click
            double newHorizontalOffset = ScrollViewer.Offset.X + scrollAmount;

            // Animate the vertical scrolling
            var animation = new Animation
            {
                Duration = TimeSpan.FromMilliseconds(300), // Adjust the duration as needed
                Easing = new SineEaseInOut()
            };

            var keyFrame = new KeyFrame
            {
                Cue = new Cue(1d),
                Setters =
                {
                    new Setter(ScrollViewer.OffsetProperty, new Avalonia.Vector(newHorizontalOffset, ScrollViewer.Offset.Y))
                }
            };

            animation.Children.Add(keyFrame);

            animation.RunAsync(ScrollViewer);
        }
        
        private void Left_OnClick(object? sender, RoutedEventArgs e)
        {
            double scrollAmount = -300; // Amount to scroll each click
            double newHorizontalOffset = ScrollViewer.Offset.X + scrollAmount;

            // Animate the vertical scrolling
            var animation = new Animation
            {
                Duration = TimeSpan.FromMilliseconds(300), // Adjust the duration as needed
                Easing = new SineEaseInOut()
            };

            var keyFrame = new KeyFrame
            {
                Cue = new Cue(1d),
                Setters =
                {
                    new Setter(ScrollViewer.OffsetProperty, new Avalonia.Vector(newHorizontalOffset, ScrollViewer.Offset.Y))
                }
            };

            animation.Children.Add(keyFrame);

            animation.RunAsync(ScrollViewer);
        }

        private async void RiskButton_OnClick(object? sender, RoutedEventArgs e)
        {
            await Task.Delay(700);
            var risk = new RiskGame();
            risk.Show();
        }

        private async void PPoTButton_OnClick(object? sender, RoutedEventArgs e)
        {
            await Task.Delay(700);
            var rock = new PaperTraining();
            rock.Show();
        }
    }
}