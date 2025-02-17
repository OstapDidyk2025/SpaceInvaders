using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class UIController
    {
        public event EventHandler OnAPressed;
        public event EventHandler OnDPressed;
        public event EventHandler OnSpacePressed;
        public event EventHandler OnEscapePressed;
        public event EventHandler OnEnterPressed;
        public event EventHandler OnPPressed;

        public void StartListining()
        {
            while (true)
            { 
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key.Equals(ConsoleKey.A))
                {
                    OnAPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.D))
                {
                    OnDPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.Spacebar))
                {
                    OnSpacePressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.P))
                {
                    OnPPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.Enter))
                {
                    OnEnterPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.Escape))
                {
                    OnEscapePressed?.Invoke(this, new EventArgs());
                }
                else 
                {
                    ;
                }



            }
        }

    }
}
