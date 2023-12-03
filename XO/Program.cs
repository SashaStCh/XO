char[] xo = new char[9];
int v = 0;

// игра
while (true)
{
    xo = new char[9] { '*', '*', '*', '*', '*', '*', '*', '*', '*' };
    for (int i = 0; i < 9; i++)
    {
        if (i % 2 == 0)
        {
            do
            {
                WriteBoard();
                Console.WriteLine("Ходит X:");
                ReadMove();
            }
            while (!IsAvaliable(v));
            xo[v - 1] = 'X';
            if (IsWinCombination())
            {
                WriteBoard();
                Console.WriteLine("Кажется X подебил");
                break;
            }
        }
        else
        {
            do
            {
                WriteBoard();
                Console.WriteLine("Ходит O:");
                ReadMove();
            }

            while (!IsAvaliable(v));
            xo[v - 1] = 'O';
            if (IsWinCombination())
            {
                WriteBoard();
                Console.WriteLine("Кажется O подебил");
                break;
            }
        }
    }
    if (!IsWinCombination())
    {
        WriteBoard();
        Console.WriteLine("Кажется никто не подебил");
    }
    Console.Write("Еще? Сделай тык --->");
    Console.ReadKey();
}

bool IsAvaliable(int a)
{
    if (((a < 1) || (a > 9)) || (xo[a - 1] != '*')) return false;
    return true;
}

void WriteBoard()
{
    Console.Clear();
    Console.WriteLine("Подсказка:");
    for (int i = 1; i <= 9; i++)
    {
        Console.Write(i + "\t");
        if ((i) % 3 == 0) Console.WriteLine("\n");
    }
    Console.WriteLine("=================\n");
    for (int i = 0; i < 9; i++)
    {
        Console.Write(xo[i] + "\t");
        if ((i + 1) % 3 == 0) Console.WriteLine("\n");
    }
}

void ReadMove()
{
    try
    {
        v = Convert.ToInt32(Console.ReadLine());
        if (!IsAvaliable(v)) { throw new Exception(); }
    }
    catch
    {
        Console.WriteLine("Ты чо твариш?\nНажми любую клавишу...");
        Console.ReadKey();
    };
}

bool IsWinCombination()
{
    if (
        (((xo[4] == 'X') && (((xo[3] == 'X')&&(xo[5] == 'X')) || ((xo[1] == 'X')&&(xo[7] == 'X')) || ((xo[0] == 'X')&&(xo[8] == 'X')) || ((xo[2] == 'X')&&(xo[6] == 'X'))))
        ||
        ((xo[0] == 'X') && (((xo[1] == 'X') && (xo[2] == 'X')) || ((xo[3] == 'X') && (xo[6] == 'X'))))
        ||
        ((xo[8] == 'X') && (((xo[6] == 'X') && (xo[7] == 'X')) || ((xo[2] == 'X') && (xo[5] == 'X')))))
        ||
        (((xo[4] == 'O') && (((xo[3] == 'O') && (xo[5] == 'O')) || ((xo[1] == 'O') && (xo[7] == 'O')) || ((xo[0] == 'O') && (xo[8] == 'O')) || ((xo[2] == 'O') && (xo[6] == 'O'))))
        ||
        ((xo[0] == 'O') && (((xo[1] == 'O') && (xo[2] == 'O')) || ((xo[3] == 'O') && (xo[6] == 'O'))))
        ||
        ((xo[8] == 'O') && (((xo[6] == 'O') && (xo[7] == 'O')) || ((xo[2] == 'O') && (xo[5] == 'O')))))
        )
        return true;
    return false;
}