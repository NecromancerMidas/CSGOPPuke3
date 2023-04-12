
namespace CSGOPPuke3
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var ms = 1000;
            var ctTeam = new CounterTerroristTeam();
            var terroristTeam = new TerroristTeam();

            while (!terroristTeam.BombIsPlanted)
            {
                terroristTeam.TerroristAction(ctTeam);
                Thread.Sleep(ms);
                ctTeam.CounterTerroristAction(terroristTeam);
                Thread.Sleep(ms);
            }

            for (int countDown = 15; countDown >= 0; countDown--)
            {
                Console.WriteLine(@$"Bomb explodes in {countDown} seconds
");
                Thread.Sleep(ms);
                if (countDown == 0) TerroristTeam.BombExplodes();
                terroristTeam.TerroristAction(ctTeam);
                Thread.Sleep(ms);
                ctTeam.CounterTerroristAction(terroristTeam);
                Thread.Sleep(ms);

            }
        }
    }
}
