using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class MusicContoler
    {

        public void PlayMusic()
        { 
            while (true) 
            {
                int tempo = 200; 

                Console.Beep(384, tempo); 
                Console.Beep(480, tempo); 
                Console.Beep(588, tempo); 
                Console.Beep(384, tempo); 
                Thread.Sleep(tempo / 2);

                Console.Beep(588, tempo); 
                Console.Beep(647, tempo); 
                Console.Beep(480, tempo); 
                Console.Beep(384, tempo); 
                Thread.Sleep(tempo / 2);

                Console.Beep(384, tempo); 
                Console.Beep(588, tempo); 
                Console.Beep(480, tempo); 
                Console.Beep(384, tempo); 
                Thread.Sleep(tempo / 2);

                Console.Beep(298, tempo); 
                Console.Beep(384, tempo); 
                Console.Beep(480, tempo); 
                Console.Beep(588, tempo); 
                Thread.Sleep(tempo);

                Console.Beep(647, tempo * 2); 
                Thread.Sleep(tempo);

                Thread.Sleep(tempo * 2);
            }
        }
    }
}
