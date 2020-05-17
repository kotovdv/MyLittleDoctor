using MyLittleDoctor.Controller;

namespace MyLittleDoctor
{
    public class Game
    {
        public static readonly Game Instance = new Game();

        public readonly TimeController TimeController = new TimeController();
    }
}