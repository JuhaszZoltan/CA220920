using CA220920;

List<Kuldetes> kuldetesek = new();

//beolvasas
using StreamReader sr = new(@"..\..\..\res\kuldetesek.csv");
while (!sr.EndOfStream)
    kuldetesek.Add(new Kuldetes(sr.ReadLine()));

//f3
Console.WriteLine(
    "3.feladat:\n\t" +
    $"Összesen {kuldetesek.Count} alkalommal indítiottak űrhajót.");

//f4
int uszo = kuldetesek.Sum(x => x.UtasokSzama);
Console.WriteLine(
    $"4.feladat:\n\t" +
    $"{uszo} utas indult az űrbe összesen");

//f5
int k5u = kuldetesek.Count(x => x.UtasokSzama < 5);
Console.WriteLine($"5. feladat:\n\t" +
    $"Összese {k5u} alkalommal küldtek kevesebb, mint 5 embert az űrbe.");

//f6
int cuuusz = kuldetesek
    .Where(x => x.SikloNeve == "Columbia")
    .OrderByDescending(x => x.KilovesNapja)
    .First().UtasokSzama;
Console.WriteLine($"6. feladat:\n\t" +
    $"{cuuusz} asztronauta volt a Columbia feldélzetén annak utolsó útján.");

//f7
Kuldetes litf = kuldetesek
    .OrderByDescending(x => x.KuldetesHossza)
    .First();
Console.WriteLine($"7. feladat:\n\t" +
    $"A leghosszabb ideig a {litf.SikloNeve} volt az űrben\n" +
    $"\ta {litf.Kod} küldetés során.\n" +
    $"\tÖsszesen {litf.KuldetesHossza} órát töltött távol a Földtől.");

//f8
Console.Write("8. feladat:\n\t" +
    "Évszám: ");
int evszam = int.Parse(Console.ReadLine());
int kszae = kuldetesek.Count(x => x.KilovesNapja.Year == evszam);
Console.WriteLine($"\tEbben az évben {kszae} küldetés volt.");

//f9
int kszku = kuldetesek
    .Where(x => x.ErkezesHelye == "Kennedy")
    .Count();
Console.WriteLine($"9. feladat:\n\t" +
    $"A küldetésk {kszku/(float)kuldetesek.Count * 100:0.00}%-a " +
    $"fejeződött be a Kennedy űrközpontban.");

//f10
var spn = kuldetesek.GroupBy(x => x.SikloNeve);

using StreamWriter sw = new(@"..\..\..\res\ursiklok.txt");
foreach (var grp in spn)
{
    sw.WriteLine($"{grp.Key}\t{grp.Sum(x => x.KuldetesHossza) / 24f:0.00}");
}