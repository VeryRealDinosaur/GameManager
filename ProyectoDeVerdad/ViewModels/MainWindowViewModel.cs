using System.Drawing;
using System.Reactive;
using System.Reflection.Metadata;
using System.Xml;
using ProyectoDeVerdad.Views;
using ProyectoDeVerdad.Views.Rock;
using ReactiveUI;
using Risk.Views;

namespace ProyectoDeVerdad.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
 public ReactiveCommand<Unit, Unit> OptionMenu { get; }
 public ReactiveCommand<Unit, Unit> ExitMainMenu { get; }
 public ReactiveCommand<Unit, Unit> PlayGato1V1 { get; }
 public ReactiveCommand<Unit, Unit> PlayGatoVsAi { get; }
 public ReactiveCommand<Unit, Unit> DeleteGato { get; }
 public ReactiveCommand<Unit, Unit> TrainPPoT { get; }
 public ReactiveCommand<Unit, Unit> PlayPPoT { get; }
 public ReactiveCommand<Unit, Unit> DeletePPoT { get; }
 public ReactiveCommand<Unit, Unit> PlayRisk { get; }
 public ReactiveCommand<Unit, Unit> DeleteRisk { get; }

        public MainWindowViewModel()
        {
            OptionMenu = ReactiveCommand.Create(ExecuteOptionMenu);
            ExitMainMenu = ReactiveCommand.Create(ExecuteExitMainMenu);
            PlayGato1V1 = ReactiveCommand.Create(ExecutePlayGato1V1);
            PlayGatoVsAi = ReactiveCommand.Create(ExecutePlayGatoVsAi);
            DeleteGato = ReactiveCommand.Create(ExecuteDeleteGato);
            TrainPPoT = ReactiveCommand.Create(ExecuteTrainPPoT);
            PlayPPoT = ReactiveCommand.Create(ExecutePlayPPoT);
            DeletePPoT = ReactiveCommand.Create(ExecuteDeletePPoT);
            PlayRisk = ReactiveCommand.Create(ExecutePlayRisk);
            DeleteRisk = ReactiveCommand.Create(ExecuteDeleteRisk);
        }
        
        private void ExecuteOptionMenu()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        
        private void ExecuteExitMainMenu()
        {
        }
        private void ExecutePlayGato1V1()
        {
            var gato1V1 = new Game();
            gato1V1.Show();
        }
        private void ExecutePlayGatoVsAi()
        {
            var gatoVsAi = new AutoGame();
            gatoVsAi.Show();
        }
        private void ExecuteDeleteGato()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecuteTrainPPoT()
        {
            var trainTHOMAS = new PaperTraining();
            trainTHOMAS.Show();
        }
        private void ExecutePlayPPoT()
        {
            var rock = new Rock();
            rock.Show();
        }
        private void ExecuteDeletePPoT()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        private void ExecutePlayRisk()
        {
            var risk = new RiskGame();
            risk.Show();
        }
        private void ExecuteDeleteRisk()
        {
            var optionMenu = new MenuOpciones();
            optionMenu.Show();
        }
        
    }