using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;

namespace ProyectoDeVerdad
{
    public partial class Game : Window
    {
        
        private DateTime startTime;
        private DispatcherTimer clock;

        public Game()
        {
            InitializeComponent();
            Turn = this.FindControl<Label>("Turn");
            Result = this.FindControl<Label>("Result");
            TimerLabel = this.Find<Label>("TimerLabel");
            MyAcrylicMaterial = this.FindControl<ExperimentalAcrylicBorder>("MyAcrylicMaterial");
        }
        
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            // First Row
            this.FindControl<Button>("Btn1");
            this.FindControl<Button>("Btn2");
            this.FindControl<Button>("Btn3");

            // Second Row
            this.FindControl<Button>("Btn4");
            this.FindControl<Button>("Btn5");
            this.FindControl<Button>("Btn6");

            // Third Row
            this.FindControl<Button>("Btn7");
            this.FindControl<Button>("Btn8");
            this.FindControl<Button>("Btn9");
        }

        public int Turno = 1;
        public int[] Estado = new int[9];
        
        

        private bool HasWon()
        {
            for (int i = 0; i < 3; i++)
            {
                // Check rows
                if (Estado[i * 3] == Estado[i * 3 + 1] && Estado[i * 3 + 1] == Estado[i * 3 + 2] && Estado[i * 3] != 0)
                {
                    return true;
                }

                // Check columns
                if (Estado[i] == Estado[i + 3] && Estado[i + 3] == Estado[i + 6] && Estado[i] != 0)
                {
                    return true;
                }
            }

            // Check diagonals
            if (Estado[0] == Estado[4] && Estado[4] == Estado[8] && Estado[0] != 0)
            {
                return true;
            }

            if (Estado[2] == Estado[4] && Estado[4] == Estado[6] && Estado[2] != 0)
            {
                return true;
            }

            return false;
        }
        
        private void UpdateButtonBackground(string buttonName)
        {
            Button button = this.FindControl<Button>(buttonName);

            if (button != null)
            {
                if (button.Content == "")
                {
                    if (Turno % 2 == 0)
                    {
                        Turn.Content = "Turno del jugador 1";
                        button.Background = Brushes.OrangeRed; 
                        MyAcrylicMaterial.Material.TintColor = Colors.DarkRed; 
                        button.Content = "X";
                
                    }
                    else
                    {
                        Turn.Content = "Turno del jugador 2";
                        button.Background = Brushes.Aqua;
                        MyAcrylicMaterial.Material.TintColor = Colors.DarkCyan; 
                        button.Content = "O";
                    }

                    Turno++;
                    
                    if (HasWon() == true)
                    {
                        Result.Content = $"El jugador {(Turno % 2 == 0 ? "1" : "2")} ha ganado";
                        Turn.Content = "";
                    }
                    else
                    {
                        int count = 0;
                        for (int i = 0; i < Estado.Length; i++)
                        {
                            count += Estado[i];
                            if (count == 14)
                            {
                                Result.Content = "Empate";
                                MyAcrylicMaterial.Material.TintColor = Colors.Black;
                                Turn.Content = "";
                            }
                        }
                    }
                }
            }
        }
        
        private void OnBtn1Clicked(object? sender, RoutedEventArgs e)
        {
            if (Estado[0] == 0)
            {
                if (HasWon() == false)
                {
                    if (Turno % 2 == 0)
                    {
                        Estado[0] = 1;
                    }
                    else
                    {
                        Estado[0] = 2;
                    }
                    UpdateButtonBackground("Btn1");
                }
            }
        }
        private void OnBtn2Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[1] = 1;
                }
                else
                {
                    Estado[1] = 2;
                }
                UpdateButtonBackground("Btn2");
            }
        }
        private void OnBtn3Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[2] = 1;
                }
                else
                {
                    Estado[2] = 2;
                }
                UpdateButtonBackground("Btn3");
            }
        }
        private void OnBtn4Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[3] = 1;
                }
                else
                {
                    Estado[3] = 2;
                }
                UpdateButtonBackground("Btn4");
            }
        }
        private void OnBtn5Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[4] = 1;
                }
                else
                {
                    Estado[4] = 2;
                }
                UpdateButtonBackground("Btn5");
            }
        }
        private void OnBtn6Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[5] = 1;
                }
                else
                {
                    Estado[5] = 2;
                }
                UpdateButtonBackground("Btn6");
            }
        }
        private void OnBtn7Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[6] = 1;
                }
                else
                {
                    Estado[6] = 2;
                }
                UpdateButtonBackground("Btn7");
            }
        }
        private void OnBtn8Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[7] = 1;
                }
                else
                {
                    Estado[7] = 2;
                }
                UpdateButtonBackground("Btn8");
            }
        }
        private void OnBtn9Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Turno % 2 == 0)
                {
                    Estado[8] = 1;
                }
                else
                {
                    Estado[8] = 2;
                }
                UpdateButtonBackground("Btn9");
            }
        }

        private void Reset_OnClick(object? sender, RoutedEventArgs e)
        {
            var secondWindow = new Game();
            secondWindow.Show();
            Close();
        }
    }
}
