using HepsiBuradaRover.ConsoleApp.Enum;

namespace HepsiBuradaRover.ConsoleApp.Services.Abstract
{
    public interface IRover
    {
        void Move(IPlateau plateau);
        void PreMove(IPlateau plateau);
        Coordinates Position { get; }
        Direction Direction { get; }
    }
}
