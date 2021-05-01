namespace HepsiBuradaRover.ConsoleApp.Services.Abstract
{
    public interface IPlateau
    {
        Coordinates Size { get; }
        void Move(IRover rover, Coordinates destination);
        void PreMove(IRover rover);
    }
}
