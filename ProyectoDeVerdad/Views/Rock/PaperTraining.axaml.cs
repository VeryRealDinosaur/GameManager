using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ProyectoDeVerdad.Views.Rock;

public partial class PaperTraining : Window
{
    
    double[][][] randomModel = MainWindow.RandomModelSingleton.Instance.GetRandomModel();

    
    string playerChoice;
    string computerChoice;
    string[] Options = { "R", "P", "S", "P", "S", "R" };
    Random random = new Random();
    int computerScore;
    int playerScore;
    string draw;
    
    public PaperTraining()
    {
        InitializeComponent();
    }

        private void MakeChoiceEvent()
        {
            int i = random.Next(0, Options.Length);
            computerChoice = Options[i];

            PlayerChoice.Text = "Player is: " + UpdateTextandImagePlayer(playerChoice);
            AIChoice.Text = "Computer is: " + UpdateTextandImageAI(computerChoice);
            CheckGame();

        }

        private string UpdateTextandImagePlayer(string text)
        {
            string word = null;

            switch (text)
            {
                case "R":
                    word = "Rock";
                    
                    ImagePlayerRock.ZIndex = 1;
                    ImagePlayerPaper.ZIndex = 0;
                    ImagePlayerScissors.ZIndex = 0;
                    
                    break;
                case "P":
                    word = "Paper";
                    
                    ImagePlayerRock.ZIndex = 0;
                    ImagePlayerPaper.ZIndex = 1;
                    ImagePlayerScissors.ZIndex = 0;
                    
                    break;
                case "S":
                    word = "Scissors";
                    
                    ImagePlayerRock.ZIndex = 0;
                    ImagePlayerPaper.ZIndex = 0;
                    ImagePlayerScissors.ZIndex = 1;
                    
                    break;
            }

            return word;
        }
        private string UpdateTextandImageAI(string text)
        {
            string word = null;

            switch (text)
            {
                case "R":
                    word = "Rock";
                    
                    ImageAIRock.Opacity = 1;
                    ImageAIPaper.Opacity = 0;
                    ImageAIScissors.Opacity = 0;
                    
                    break;
                case "P":
                    word = "Paper";
                    
                    ImageAIRock.Opacity = 0;
                    ImageAIPaper.Opacity = 1;
                    ImageAIScissors.Opacity = 0;
                    
                    break;
                case "S":
                    word = "Scissors";
                    
                    ImageAIRock.Opacity = 0;
                    ImageAIPaper.Opacity = 0;
                    ImageAIScissors.Opacity = 1;
                    
                    break;
            }

            return word;
        }


        private void CheckGame()
        {
            if (computerChoice == playerChoice)
            {
                draw = " Draw!";
            }
            else if (playerChoice == "R" && computerChoice == "P" || playerChoice == "S" && computerChoice == "R" || playerChoice == "P" && computerChoice == "S")
            {
                computerScore++;
                draw = null;
            }
            else
            {
                playerScore++;
                draw = null;
            }
            
            Score.Content = "Computer Score: " + computerScore + Environment.NewLine + draw + "Player Score: " + playerScore + Environment.NewLine + draw;

        }

        private void ROCK_OnClick(object? sender, RoutedEventArgs e)
        {
            playerChoice = "R";
            MakeChoiceEvent();
        }
        
        private void PAPER_OnClick(object? sender, RoutedEventArgs e)
        {
            playerChoice = "P";
            MakeChoiceEvent();
        }
        
        private void SCISSORS_OnClick(object? sender, RoutedEventArgs e)
        {
            playerChoice = "S";
            MakeChoiceEvent();
        }
}