
using ProductManager.Managers.Concrete;
using ProductManager.Models.Helpers;

namespace ProductManager;

public class Program
{
    static List<(string, string, Role)> _identities = new()
    {
        ("Rafał", "Kieś", Role.User),
        ("Pucybut", "Kędzierzawy", Role.VIP),
        ("Geralt", "Zrivii", Role.Admin),
    };
    private static void Main(string[] args)
    {
        var userManager = new UserManager(new Managers.Concrete.ProductManager(), new PriceManager());

        foreach (var identity in _identities)
        {
            var user = userManager.SetupUser(identity.Item1, identity.Item2, identity.Item3);

            Console.WriteLine($"Starting calculations for user: {identity.Item1} {identity.Item2}, role: {identity.Item3}");
            userManager.ManageUser(user);

            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}