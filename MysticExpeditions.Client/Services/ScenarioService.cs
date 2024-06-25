namespace MysticExpeditions.Client.Services
{
    public class ScenarioService
    {
        private readonly List<string> _scenarios = new List<string>
        {
            "You enter a dark forest.",
            "You find a hidden cave.",
            "You encounter a wandering merchant.",
            "You stumble upon an ancient ruin."
        };

        public string GetRandomScenario()
        {
            var rand = new Random();
            int index = rand.Next(_scenarios.Count);
            return _scenarios[index];
        }
    }
}