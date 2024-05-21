using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace ProyectoDeVerdad
{
    public partial class AutoGame : Window
    {
        public AutoGame()
        {
            InitializeComponent();
            Turn = this.FindControl<Label>("Turn");
            Result = this.FindControl<Label>("Result");
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
        public int cont = 0;

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

        private void DisplayMsg()
        {
            if (HasWon() == true)
            {
                Result.Content = $"El jugador {(Turno % 2 == 0 ? "X" : "O")} ha ganado";
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
                        Turn.Content = "";
                    }
                }
            }
        }

        private void UpdateButtonBackground(string buttonName)
        {
            Button button = this.FindControl<Button>(buttonName);

            if (button != null)
            {
                if (button.Content == "")
                {
                    button.Background = Brushes.OrangeRed;
                    button.Content = "X";
                }
            }
            
            Turno++;
        }

        private void Machine()
        {
            cont++;
            if (HasWon()) return;
            int index = GetRandomMove();
            if (Estado[index] == 0)
            {
                Button button = this.FindControl<Button>($"Btn{index + 1}");
                button.Background = Brushes.Aqua;
                button.Content = "O";
                Estado[index] = 1;
                Turno++;
            }
            else
            {
                if (cont < 82)
                {
                    Machine(); 
                }
            }
        }

        private int GetRandomMove()
        {
            return new Random().Next(9);
        }
        
        private void OnBtn1Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[0] == 0)
                {
                    UpdateButtonBackground("Btn1");
                    Estado[0] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
            
        }
        private void OnBtn2Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[1] == 0)
                {
                    UpdateButtonBackground("Btn2");
                    Estado[1] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }
        private void OnBtn3Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[2] == 0)
                {
                    UpdateButtonBackground("Btn3");
                    Estado[2] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }
        private void OnBtn4Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[3] == 0)
                {
                    UpdateButtonBackground("Btn4");
                    Estado[3] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }
        private void OnBtn5Clicked(object? sender, RoutedEventArgs e)
        {
            if (!HasWon())
            {
                if (Estado[4] == 0)
                {
                    UpdateButtonBackground("Btn5");
                    Estado[4] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }
        private void OnBtn6Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[5] == 0)
                {
                    UpdateButtonBackground("Btn6");
                    Estado[5] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }
        private void OnBtn7Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[6] == 0)
                {
                    UpdateButtonBackground("Btn7");
                    Estado[6] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }
        private void OnBtn8Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[7] == 0)
                {
                    UpdateButtonBackground("Btn8");
                    Estado[7] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }
        private void OnBtn9Clicked(object? sender, RoutedEventArgs e)
        {
            if (HasWon() == false)
            {
                if (Estado[8] == 0)
                {
                    UpdateButtonBackground("Btn9");
                    Estado[8] = 2;
                    Machine();
                    DisplayMsg();
                }
            }
        }

        private void Reset_OnClick(object? sender, RoutedEventArgs e)
        {
            var thirdWindow = new AutoGame();
            thirdWindow.Show();
            Close();
        }
    }
}
