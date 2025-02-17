
using System.Threading;

namespace Space_Invaders
{
    internal class Program
    {
        static GameSettings settings;

        static GameEngine gameEmgine;

        static UIController uicontroller;

        static MusicContoler musicContoler;

        static void Main(string[] args)
        {
            Initialization();

            gameEmgine.Run(settings);
        }

        static void Initialization()
        { 
            settings = new GameSettings();

            gameEmgine = GameEngine.GetGameEngine(settings);

            uicontroller = new UIController();

            uicontroller.OnAPressed -= (obj, arg) => gameEmgine.ClalculatePlayerMoveLeft();
            uicontroller.OnDPressed -= (obj, arg) => gameEmgine.ClalculatePlayerMoveRight();
            uicontroller.OnSpacePressed -= (obj, arg) => gameEmgine.Shot();
            uicontroller.OnEscapePressed -= (obj, arg) => gameEmgine.ExitGame();
            uicontroller.OnPPressed -= (obj, arg) => gameEmgine.PauseGame();
            uicontroller.OnEnterPressed -= (obj, arg) => gameEmgine.RestartGame();

            uicontroller.OnAPressed += (obj, arg) => gameEmgine.ClalculatePlayerMoveLeft();
            uicontroller.OnDPressed += (obj, arg) => gameEmgine.ClalculatePlayerMoveRight();
            uicontroller.OnSpacePressed += (obj, arg) => gameEmgine.Shot();
            uicontroller.OnEscapePressed += (obj, arg) => gameEmgine.ExitGame();
            uicontroller.OnPPressed += (obj, arg) => gameEmgine.PauseGame();
            uicontroller.OnEnterPressed += (obj, arg) => gameEmgine.RestartGame();

            Thread uIControler = new Thread(uicontroller.StartListining);

            musicContoler = new MusicContoler();
            Thread musicContolerThread = new Thread(musicContoler.PlayMusic);

            uIControler.Start();
            musicContolerThread.Start();
        }
    }
}
