
using ProductManager.Models;
using ProductManager.Models.Helpers;

public class Program
{
    static void Main(string[] args)
    {
        var p1 = new Product("Fasola", Category.Warzywo, 20.12m, 10m);
        var p2 = new Product("Banan", Category.Warzywo, 20.99m, 20m);


        decimal priceSum = Sum(p1, p2);

        var user1 = new User("Framek", "Kączak", Role.User,
            new Product[3] { p1, p2, new Product("Kiwi", Category.Owoc, 123, 10) }
    );


        decimal sumaCenyProduktówDlaUsera = LiczSumeProduktówZKoszyka(user1);
        decimal sumaCenyProduktówDlaUsera1 = LiczSumeProduktówZKoszyka(user1, true, 200, true, 123, true);
        decimal sumaCenyProduktówDlaUsera2 = LiczSumeProduktówZKoszyka(user1, true, 200, true, 123, false);
    }

    private static decimal LiczSumeProduktówZKoszyka(User user, bool czyDoliczyćDodatkoweKoszty = false, int DodatkoweKoszty = 0,
            bool czyDoliczyćMarże = false, int Marża = 0, bool czyWagaProduktówMaZnaczenieNaCene = true)
    {
        if (user != null)
        {
            if (user.Products[0] == null)
                return 0;



            decimal priceSum = user.Products[0].Price;

            if (user.Products[1] != null)
                priceSum = Sum(user.Products[0], user.Products[1]);
            if (user.Products[1] != null)
                priceSum += Sum(user.Products[1], user.Products[2]);

            if ((user.Products[0].Price - priceSum) < decimal.One / decimal.MaxValue)
                priceSum = decimal.One / decimal.MaxValue;

            Console.WriteLine("Cena produktów #1 " + priceSum);

            // zniżki 
            if
                (priceSum > 5000) priceSum = (decimal)(0.7m * priceSum); // dla wiekszych od 5000 30%
            else
            if (priceSum > 1000)
                priceSum = (decimal)(0.8m * priceSum); // dla wiekszych od 5000 20%
            else
            if (priceSum > 500)
                priceSum = (decimal)(0.85m * priceSum); // dla wiekszych od 5000 15%
            else
            if (priceSum > 100)
                priceSum = (decimal)(0.9m * priceSum); // dla wiekszych od 5000 10%

            Console.WriteLine("Cena produktów #2 " + priceSum);

            if ((user.Role == Role.Admin) || (user.Role == Role.Admin)) // dodatkowa zniżka dla adminów lub VIP
                priceSum = (int)(0.9m * priceSum);

            Console.WriteLine("Cena produktów #3 " + priceSum);

            decimal WagaSuma = user.Products[0].Weight;
            if (user.Products[1] != null)
                WagaSuma += user.Products[1].Weight;
            if (user.Products[1] != null)
                WagaSuma += user.Products[2].Weight;

            Console.WriteLine("Cena produktów #4 " + priceSum);

            if (czyWagaProduktówMaZnaczenieNaCene)
            {
                // Dodatkowe cany dla większej wagi jeżeli tru dla znaczenie ceny na wagę
                if ((WagaSuma > 1000)
                    && (user.Products[0].Category == Category.Owoc)
                    && (user.Products[1] == null || (user.Products[1] != null
                                                     && (user.Products[0].Category == Category.Owoc))
                        && (user.Products[2] == null || (user.Products[2] != null && user.Products[2].Category == Category.Owoc)))
                   )
                    priceSum += 45; // jeżeli to są tylko owoce to 45 dodatkowo,
                else
                if ((WagaSuma > 1000)
                    && (user.Products[0].Category == Category.Warzywo)
                    && (user.Products[1] == null || (user.Products[1] != null && user.Products[1].Category == Category.Owoc))
                    && (user.Products[2] == null || (user.Products[2] != null && user.Products[2].Category == Category.Owoc))
                   )
                    priceSum += 35; // jeżeli to są tylko warzywa to 35 dodatkowo,
                else
                if (WagaSuma > 1000)
                    priceSum += 25; // jeżeli to są tylko warzywa to 20 dodatkowo,
                else
                if (WagaSuma > 500)
                    priceSum += 15;
                else
                if (WagaSuma > 100)
                    priceSum += 10;
                else
                if (WagaSuma > 50)
                    priceSum += 5;
                else
                if (WagaSuma > 15)
                    priceSum += 2;

                Console.WriteLine("Cena produktów #5 " + priceSum);
            }

            if (czyDoliczyćDodatkoweKoszty)
            {
                priceSum += DodatkoweKoszty;
            }
            Console.WriteLine("Cena produktów #6 " + priceSum);

            if (czyDoliczyćMarże)
            {
                priceSum += Marża;
                if (Marża > 100)
                    Console.WriteLine("Brawo, podwyżka się należy!");
            }
            Console.WriteLine("Cena produktów #7 " + priceSum);

            return priceSum;
        }

        return 0;
    }

    private static decimal Sum(Product p, Product p2)
    {
        return p.Price + p2.Price;
    }
}