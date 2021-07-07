using System;
using System.Threading;

namespace Rent_A_Car
{
    class Program
    {
        static void Main(string[] args)
        {
        start: // instrukcja skokowa
            Console.WriteLine("Witaj w naszej wyporzyczalni Rent A Car");
            Thread.Sleep(2000); //metoda czekania o wartośći 2000 milisekund w celu uzyskania lepszego efektu
            Console.WriteLine("Wybierz auto które będzie dopasowane do twoich potrzeb");
            Thread.Sleep(2000);
            Console.WriteLine("Wybierz na klawiaturze numerycznej odpowiedni numer przypisany do auta i zatwierdź <ENTER>");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("1 - Fiat Tipo");
            Console.WriteLine("2 - Ford Mustang");
            Console.WriteLine("3 - Ford Ranger");
            Console.Write("#");
            int wybor = int.Parse(Console.ReadLine());
            Console.Clear(); // czyszczenie konsoli
            switch (wybor) // instrukcja wyboru switch wybiera pojedynczą sekcje przełącznika
            {
                case (1):
                    {
                        Car car = new Car(); // instancja obiektu
                        Console.WriteLine("Wybrałeś niezawodnego Fiata Tipo z {0} roku o wartości {1} złoty", car.Data_Prod.Ticks, car.Value);
                        Console.WriteLine("Podaj swoje imie i nazwisko w celu sfinalizowania transakcji");
                        Console.Write("#");
                        car.Name = Console.ReadLine();
                        Console.Clear();
                    skok: //instrukcja skokowa
                        Console.WriteLine("Podaj okres wypożyczenia samochodu");
                        Console.Write("Dzień:");
                        int dzienwyp = int.Parse(Console.ReadLine());
                        Console.Write("Miesiąc:");
                        int mscwyp = int.Parse(Console.ReadLine());
                        Console.Write("Rok:");
                        int rokwyp = int.Parse(Console.ReadLine());

                        car.DataWyp = new DateTime(rokwyp, mscwyp, dzienwyp);
                        Console.Clear();
                        Console.WriteLine("Termin wypożyczenia: {0}", String.Format("{0:d}", car.DataWyp)); // wyświetlnie odpowiedniego formatu daty
                        Console.WriteLine("Podaj okres zakończenia wypożyczenia samochodu");
                        Console.Write("Dzień:");
                        int dzienzak = int.Parse(Console.ReadLine());
                        Console.Write("Miesiąc:");
                        int msczak = int.Parse(Console.ReadLine());
                        Console.Write("Rok:");
                        int rokzak = int.Parse(Console.ReadLine());
                        car.DataWyp = new DateTime(rokzak, msczak, dzienzak);
                        var roz_pandemii = new DateTime(2020, 3, 1); // przypisanie odpowiedniej daty do zmiennej roz_pandemii
                        var zak_pandemii = new DateTime(2021, 6, 26);

                        if (car.DataWyp > roz_pandemii && car.DataWyp < zak_pandemii)
                        {
                            //- 25% w okresie pandemi
                            car.Term = car.DataWyp.Day - car.DataZwr.Day;

                            if (car.Term < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Liczba dni do wyporzyczenia musi być większa niż 1");
                                Thread.Sleep(4000);
                                Console.ResetColor();
                                Console.Clear();
                                goto skok;
                            }
                            else
                            {
                                car.Amortyzacja = (car.Value * 0.10) / 365;
                                car.Balance = (car.Term * 109) + car.Amortyzacja;
                                car.Balance *= 0.25;

                                Console.WriteLine("{0}, twoja łączna opłata za wynajem jest równa {1}", car.Name, String.Format("{0:0.00}", car.Balance));
                            }


                        }
                        else
                        {
                            car.Term = car.DataWyp.Day - car.DataZwr.Day;

                            if (car.Term < 1)
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Liczba dni do wyporzyczenia musi być większa niż 1");
                                Thread.Sleep(4000);
                                Console.ResetColor();
                                Console.Clear();
                                goto skok;
                            }
                            else
                            {
                                car.Amortyzacja = (car.Value * 0.10) / 365;
                                car.Balance = car.Term * 109;
                                Console.WriteLine("{0}, twoja łączna opłata za wynajem jest równa {1}", car.Name, String.Format("{0:0.00}", car.Balance));
                            }
                        }
                        break;
                    }
                case (2):
                    {
                        Muscle_Car muscle_Car = new Muscle_Car();
                        Console.WriteLine("Wybrałeś sportowego Forda Mustanga z {0} roku o wartości {1} złoty", muscle_Car.Data_Prod.Ticks, muscle_Car.Value);
                        Console.WriteLine("Podaj swoje imie i nazwisko w celu sfinalizowania transakcji");
                        Console.Write("#");
                        muscle_Car.Name = Console.ReadLine();
                        Console.Clear();
                    skok:
                        Console.WriteLine("Podaj okres wypożyczenia samochodu");
                        Console.Write("Dzień:");
                        int dzienwyp = int.Parse(Console.ReadLine());
                        Console.Write("Miesiąc:");
                        int mscwyp = int.Parse(Console.ReadLine());
                        Console.Write("Rok:");
                        int rokwyp = int.Parse(Console.ReadLine());

                        muscle_Car.DataWyp = new DateTime(rokwyp, mscwyp, dzienwyp);
                        Console.Clear();
                        Console.WriteLine("Termin wypożyczenia: {0}", String.Format("{0:d}", muscle_Car.DataWyp));
                        Console.WriteLine("Podaj okres zakończenia wypożyczenia samochodu");
                        Console.Write("Dzień:");
                        int dzienzak = int.Parse(Console.ReadLine());
                        Console.Write("Miesiąc:");
                        int msczak = int.Parse(Console.ReadLine());
                        Console.Write("Rok:");
                        int rokzak = int.Parse(Console.ReadLine());
                        muscle_Car.DataWyp = new DateTime(rokzak, msczak, dzienzak);
                        var roz_pandemii = new DateTime(2020, 3, 1);
                        var zak_pandemii = new DateTime(2021, 6, 26);

                        if (muscle_Car.DataWyp > roz_pandemii && muscle_Car.DataWyp < zak_pandemii)
                        {
                            //- 25% w okresie pandemi
                            muscle_Car.Term = muscle_Car.DataWyp.Day - muscle_Car.DataZwr.Day;

                            if (muscle_Car.Term < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red; // zmiana koloru tekstu
                                Console.WriteLine("Liczba dni do wyporzyczenia musi być większa niż 1");
                                Thread.Sleep(4000);
                                Console.ResetColor(); //reset koloru
                                Console.Clear();
                                goto skok;
                            }
                            else
                            {
                                muscle_Car.Amortyzacja = (muscle_Car.Value * 0.10) / 365;
                                muscle_Car.Balance = (muscle_Car.Term * 750) + muscle_Car.Amortyzacja;
                                muscle_Car.Balance *= 0.25;

                                Console.WriteLine("{0}, twoja łączna opłata za wynajem jest równa {1}", muscle_Car.Name, String.Format("{0:0.00}", muscle_Car.Balance));
                            }


                        }
                        else
                        {
                            muscle_Car.Term = muscle_Car.DataWyp.Day - muscle_Car.DataZwr.Day; // obliczenie ilości dni 

                            if (muscle_Car.Term < 1) // instrukcja warunkowa if
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Liczba dni do wyporzyczenia musi być większa niż 1");
                                Thread.Sleep(4000);
                                Console.ResetColor();
                                Console.Clear();
                                goto skok;
                            }
                            else
                            {
                                muscle_Car.Amortyzacja = (muscle_Car.Value * 0.10) / 365; //doliczenie do kosztów wypożycznia auta kosztów amortyzacji
                                muscle_Car.Balance = muscle_Car.Term * 750; // oblicznie kosztów wypożycznia auta
                                Console.WriteLine("{0}, twoja łączna opłata za wynajem jest równa {1}", muscle_Car.Name, String.Format("{0:0.00}", muscle_Car.Balance));
                            }
                        }
                        break;
                    }
                case (3):
                    {
                        Truck truck = new Truck(); //instancja klasy
                        Console.WriteLine("Wybrałeś terenowego Forda Rangeraz {0} roku o wartości {1} złoty", truck.Data_Prod.Ticks, truck.Value);
                        Console.WriteLine("Podaj swoje imie i nazwisko w celu sfinalizowania transakcji");
                        truck.Name = Console.ReadLine();
                        Console.Clear();
                    skok:
                        Console.WriteLine("Podaj okres wypożyczenia samochodu");
                        Console.Write("Dzień:");
                        int dzienwyp = int.Parse(Console.ReadLine());
                        Console.Write("Miesiąc:");
                        int mscwyp = int.Parse(Console.ReadLine());
                        Console.Write("Rok:");
                        int rokwyp = int.Parse(Console.ReadLine());

                        truck.DataWyp = new DateTime(rokwyp, mscwyp, dzienwyp);
                        Console.Clear();
                        Console.WriteLine("Termin wypożyczenia: {0}", String.Format("{0:d}", truck.DataWyp));
                        Console.WriteLine("Podaj okres zakończenia wypożyczenia samochodu");
                        Console.Write("Dzień:");
                        int dzienzak = int.Parse(Console.ReadLine());
                        Console.Write("Miesiąc:");
                        int msczak = int.Parse(Console.ReadLine());
                        Console.Write("Rok:");
                        int rokzak = int.Parse(Console.ReadLine());
                        truck.DataWyp = new DateTime(rokzak, msczak, dzienzak);
                        var roz_pandemii = new DateTime(2020, 3, 1);
                        var zak_pandemii = new DateTime(2021, 6, 26);

                        if (truck.DataWyp > roz_pandemii && truck.DataWyp < zak_pandemii) // instruckcja warunkowa sprawdzająca czy termin wypożycznia był objęty niżką
                        {
                            //- 25% w okresie pandemi
                            truck.Term = truck.DataWyp.Day - truck.DataZwr.Day;

                            if (truck.Term < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Liczba dni do wyporzyczenia musi być większa niż 1");
                                Thread.Sleep(4000);
                                Console.ResetColor();
                                Console.Clear();
                                goto skok;
                            }
                            else
                            {
                                truck.Amortyzacja = (truck.Value * 0.10) / 365;
                                truck.Balance = (truck.Term * 250) + truck.Amortyzacja;
                                truck.Balance *= 0.25; // odlicznie zniżki

                                Console.WriteLine("{0}, twoja łączna opłata za wynajem jest równa {1}", truck.Name, String.Format("{0:0.00}", truck.Balance));
                            }


                        }
                        else
                        {
                            truck.Term = truck.DataWyp.Day - truck.DataZwr.Day;

                            if (truck.Term < 1)
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Liczba dni do wyporzyczenia musi być większa niż 1");
                                Thread.Sleep(4000);
                                Console.ResetColor();
                                Console.Clear();
                                goto skok;
                            }
                            else
                            {
                                truck.Amortyzacja = (truck.Value * 0.10) / 365;
                                truck.Balance = truck.Term * 250;
                                Console.WriteLine("{0}, twoja łączna opłata za wynajem jest równa {1}", truck.Name, String.Format("{0:0.00}", truck.Balance));
                            }
                        }
                        break;
                    }
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podana przez ciebie wartość jest nieprawidłowa spróbuj ponownie");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                    goto start;
            }
        }
    }
    public class Car : Vehicle //Pochodna klasa Car
    {
        public Car() //konstruktor klasy
        {
            Name = string.Empty;
            Marka = "Fiat";
            Model = "Tipo";
            Data_Prod = new DateTime(2019);
            Value = 62900;
            Odometer = 19300;
        }
    }
    public class Muscle_Car : Vehicle //pochodna klasa Muscle_Car
    {
        public Muscle_Car() //konstruktor klasy
        {
            Name = string.Empty;
            Marka = "Ford";
            Model = "Mustang";
            Data_Prod = new DateTime(2020);
            Value = 180000;
            Odometer = 15000;
        }
    }
    public class Truck : Vehicle // klasa pochodna 
    {
        public Truck() // konstruktor klasy
        {
            Name = string.Empty;
            Marka = "Ford";
            Model = "Ranger";
            Data_Prod = new DateTime(2021);
            Value = 161300;
            Odometer = 3000;
        }
    }
    public class Vehicle // klasa Vehicle bazowa
    {
        public string Name { get; set; } // imie i nazwisko klienta
        public double Balance { get; set; } // saldo klienta – ile kosztowało wypożyczenie
        public int Term { get; set; } //okres wypożyczenia – liczba dni
        public DateTime DataWyp { get; set; } //data wyporzyczeia
        public DateTime DataZwr { get; set; } //data zwrotu
        public string Marka { get; set; } //marka pojazdu
        public string Model { get; set; } //model pojazdu
        public DateTime Data_Prod { get; set; }// data produkcji pojazdu
        public double Value { get; set; } //wartość pojazdu
        public double Amortyzacja { get; set; } //koszty amortyzacji samochodu – 10% wartości r/r
        public double Odometer { get; set; } //licznik – przebieg samochodu
    }
}





