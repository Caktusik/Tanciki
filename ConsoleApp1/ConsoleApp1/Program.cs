using Tanciki;

ConsoleRender consoleRender = new ConsoleRender();

Input input = new Input();
Player player = new Player();
int startplayerHP = 3;
lvlsManager();

while (true)
{
    while (GameData.GetInstance().IsGameGo)
    {
        clener();
        Console.Clear();
        input.ChekKeyInfo();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Map.GetInstance().MainMap[i, j] == 4)
                {
                    Map.GetInstance().MainMap[i, j] = 0;
                }
            }
        }
        foreach (Bullet bullet in GameData.GetInstance().AllBulets)
        {
            bullet.update();
        }
        player.update();
        foreach (Enemy enemy in GameData.GetInstance().enemyList)
        {
            enemy.update();
        }
        consoleRender.render();
        Console.ForegroundColor = ConsoleColor.Black;
        if (IsHaveOneEnemyOrMore())
        {
            GameData.GetInstance().IsGameGo = false;
            GameData.GetInstance().sms = 1;
        }
        Thread.Sleep(200);
    }
    while (!GameData.GetInstance().IsGameGo)
    {
        if (GameData.GetInstance().sms == 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Проигрышь");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        if (GameData.GetInstance().sms == 1)
        {
            GameData.GetInstance().lvl++;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Переход на следуюший уровень, номер-" + (GameData.GetInstance().lvl));
            GameData.GetInstance().AllBulets.Clear();
            lvlsManager();
            GameData.GetInstance().IsGameGo = true;
            Thread.Sleep(2000);
        }
    }
}
void lvlsManager()
{
    switch (GameData.GetInstance().lvl)
    {
        case 0:
            LvlMapChange(5, 8, Map.GetInstance().MapStart, new List<Enemy>() { new Enemy(player, 6, 1) });
            break;
        case 1:
            LvlMapChange(1, 9, Map.GetInstance().MapLabirint, new List<Enemy>() { new Enemy(player, 8, 6) });
            break;
        case 2:
            LvlMapChange(5, 9, Map.GetInstance().MapBitva, new List<Enemy>() { new Enemy(player, 4, 1), new Enemy(player, 7, 1) });
            break;
        case 3:
            LvlMapChange(1, 5, Map.GetInstance().MapPiramid, new List<Enemy>() { new Enemy(player, 4, 1), new Enemy(player, 8, 4), new Enemy(player, 5, 8) });
            break;
        case 4:
            LvlMapChange(2, 7, Map.GetInstance().MapTurma, new List<Enemy>() { new Enemy(player, 1, 4), new Enemy(player, 7, 1), new Enemy(player, 6, 8) });
            break;
        case 5:
            LvlMapChange(2, 7, Map.GetInstance().MapOnluyWool, new List<Enemy>() { new Enemy(player, 1, 4), new Enemy(player, 2, 5), new Enemy(player, 6, 8) });
            break;
        case 6:
            LvlMapChange(1, 9, Map.GetInstance().MapLabirint, new List<Enemy>() { new Enemy(player, 8, 1), new Enemy(player, 8, 6) });
            break;
        case 7:
            LvlMapChange(2, 9, Map.GetInstance().MapBitva, new List<Enemy>() { new Enemy(player, 4, 1), new Enemy(player, 7, 1), new Enemy(player, 2, 2) });
            break;
        case 8:
            LvlMapChange(1, 5, Map.GetInstance().MapPiramid, new List<Enemy>() { new Enemy(player, 4, 1), new Enemy(player, 8, 4), new Enemy(player, 5, 8) });
            break;
        case 9:
            LvlMapChange(5, 8, Map.GetInstance().MapStart, new List<Enemy>() { new Enemy(player, 6, 1), new Enemy(player, 3, 3), new Enemy(player, 5, 2), new Enemy(player, 8, 8) });
            break;
    }
}
void LvlMapChange(int PlayerX, int PlayerY, int[,] Lvl, List<Enemy> enemyPos)
{
    GameData.GetInstance().enemyList = enemyPos;
    player.X = PlayerX;
    player.Y = PlayerY;
    GameData.GetInstance().HpPlayer = startplayerHP;
    Map.GetInstance().MainMap = Lvl;
}
void clener()
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (Map.GetInstance().MainMap[i, j] == 4)
            {
                Map.GetInstance().MainMap[i, j] = 0;
            }
        }
    }
}
bool IsHaveOneEnemyOrMore()
{
    return GameData.GetInstance().enemyList.Count == 0 ? true : false;
}