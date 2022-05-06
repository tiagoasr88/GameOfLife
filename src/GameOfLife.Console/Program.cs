// See https://aka.ms/new-console-template for more information
using GameOfLife.Console;

Console.CursorVisible = false;

var game = new Game();

game.CriarGridVazio(45);
game.CriarPopulacao(220);

for (int i = 0; i < 720; i++)
{
    game.Grid = game.Evoluir();

    Thread.Sleep(200);

    // escrever grid
    Console.SetCursorPosition(0, 0);
    Console.CursorVisible = false;
    for (int x = 1; x < game.Grid.GetLength(0) - 1; x++)
    {
        Console.Write("|");

        for (int y = 1; y < game.Grid.GetLength(1) - 1; y++)
        {
            Console.Write($"{(game.Grid[x, y].Vivo ? "@" : " ")}|");
        }
        Console.WriteLine();
    }
}