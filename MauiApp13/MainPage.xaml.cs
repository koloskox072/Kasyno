namespace MauiApp13
{
    class Karta
    {
        public string karta;
        public int value;
        public Karta(string karta, string Value)
        {
            this.karta = karta;
            if (Value == "0")
                value = 10;
            else if (Value == "j")
                value = 10;
            else if (Value == "q")
                value = 10;
            else if (Value == "k")
                value = 10;
            else if (Value == "a")
                value = 11;
            else
                value = int.Parse(Value);
        }
    }
    public partial class MainPage : ContentPage
    {
        int countDealer = 0;
        int countGracz = 0;
        Random rng = new Random();
        List<Karta> karty = new List<Karta>();
        List<Karta> dealer = new List<Karta>();
        List<Karta> gracz = new List<Karta>();
        public MainPage()
        {
            InitializeComponent();
            initializeCards();
        }
        public void initializeCards()
        {
            string color = "cdhs";
            string value = "234567890jqka";
            foreach(char c in color)
            {
                foreach(char v in value)
                {
                    karty.Add(new Karta(c.ToString() + v.ToString() + "", v.ToString()));
                }
            }
        }
        public void newGame()
        {
            countDealer = 0;
            countGracz = 0;
            int a = rng.Next(0, karty.Count);
            dealer1.Source = karty[a].karta + ".png";
            countDealer = countDealer + karty[a].value;
            dealer.Add(karty[a]);
            a = rng.Next(0, karty.Count);
            countDealer = countDealer + karty[a].value;
            dealer.Add(karty[a]);
            a = rng.Next(0, karty.Count);
            gracz1.Source = karty[a].karta + ".png";
            countGracz = countGracz + karty[a].value;
            gracz.Add(karty[a]);
            a = rng.Next(0, karty.Count);
            gracz2.Source = karty[a].karta + ".png";
            countGracz = countGracz + karty[a].value;
            gracz.Add(karty[a]);
        }
        public void nowaGra(object sender, EventArgs e)
        {
            Image gracz1 = new Image();
            int a = rng.Next(0, karty.Count);
            gracz1.Source = karty[a].karta + ".png";
            Image gracz2 = new Image();
            a = rng.Next(0, karty.Count);
            gracz2.Source = karty[a].karta + ".png";
            dealer2.Source = "blank.png";
            kartyGracza.Clear();
            kartyGracza.Add(gracz1);
            kartyGracza.Add(gracz2);
            newGame();
            btn1.IsVisible = false;
            btn2.IsVisible = true;
            btn3.IsVisible = true;
        }
        public void stay(object sender, EventArgs e)
        {

        }
        public void hit(object sender, EventArgs e)
        {
            Image img = new Image();
            int a = rng.Next(0, karty.Count);
            img.Source = karty[a].karta + ".png";
            kartyGracza.Add(img);
            countGracz = countGracz + karty[a].value;
            gracz.Add(karty[a]);
            if (countGracz > 21)
            {
                dealer2.Source = dealer[1].karta + ".png";
                btn1.IsVisible = true;
                btn2.IsVisible = false;
                btn3.IsVisible = false;
            }
        }
    }
}
