/*Skapa en konsollapplikation som tar en textsträng (string) som argument till Main eller uppmanar användaren mata in en sträng i konsollen.
Textsträngen ska sedan sökas igenom efter alla delsträngar som är tal som börjar
och slutar på samma siffra, utan att start/slutsiffran, eller något annat tecken än
siffror förekommer där emellan.
ex. 3463 är ett korrekt sådant tal, men 34363 är det inte eftersom det finns
ytterligare en 3:a i talet, förutom start och slutsiffran. Strängar med bokstäver i
t.ex 95a9 är inte heller ett korrekt tal.

    Skriv ut och markera varje korrekt delsträng

För varje sådan delsträng som matchar kriteriet ovan ska programmet skriva ut en
rad med hela strängen, men där delsträngen är markerad i en annan färg.
Exempel output för input ”29535123p48723487597645723645”.

Addera ihop alla tal och skriv ut totalen

Programmet ska också addera ihop alla tal den hittat enligt ovan och skriva ut det
sist i programmet. Gör gärna en tom rad emellan för att skilja från output ovan.
Exempel output för input ”29535123p48723487597645723645”:
Total = 5836428677242*/

var sum = 0L;
var indexOfFirstNumOfSubStr = 0;
var indexOfLastNumOfSubStr = 0;
var lengthOfSubstring = 0;

//Be användaren skriva in en sträng:
Console.WriteLine("Hej! Skriv in en sträng:");
string input = Console.ReadLine();




//Hitta delsträngar som börjar och slutar på samma tal och är minst 3 tecken långa.
for (int i = 0; i < input.Length; i++)
{
	//Endast siffror avses, om annat tecken hittas, fortsätt till nästa.
	if (int.TryParse(input[i]+"", out int currentNum))
	{
        //      Spara platsen i strängen där delsträngen börjar.

        if (indexOfFirstNumOfSubStr == 0) { indexOfFirstNumOfSubStr = i; }

		for (int j = i+1; j < input.Length; j++)
		{
			//		Om man hittar annat tecken än siffra innan dublett, kolla nästa istället.
			if (int.TryParse(input[j]+"", out int notUsed) == false)
			{
				lengthOfSubstring = 0;
				indexOfFirstNumOfSubStr = 0;
				break; 
			}

            //      Spara platsen i strängen där delsträngen slutar.
            else if ( int.Parse(input[j]+"") == currentNum)
            {
				indexOfLastNumOfSubStr = j;
				lengthOfSubstring = j - indexOfFirstNumOfSubStr + 1;
				break;
            }

			//om ingen match hittades, kolla nästa.
			else if (j == input.Length - 1)
			{
                lengthOfSubstring = 0;
                indexOfFirstNumOfSubStr = 0;
                break;
            }


        }

        //För varje hittad delsträng:
        if (lengthOfSubstring >= 3 )
		{
            //      Spara ner värdet av varje delsträng och lägg till i en variabel
            sum += long.Parse(input.Substring(indexOfFirstNumOfSubStr, lengthOfSubstring));

            //      Skriv ut hela strängen med delsträngen markerad i annan färg.
            Console.Write(input.Substring(0, indexOfFirstNumOfSubStr));

			Console.ForegroundColor = ConsoleColor.Red;

			Console.Write(input.Substring(indexOfFirstNumOfSubStr,lengthOfSubstring));

			Console.ResetColor();

			Console.Write(input.Substring(indexOfLastNumOfSubStr + 1) + "\n");

			indexOfFirstNumOfSubStr = 0;
			indexOfLastNumOfSubStr = 0;

        }
	}
}
//skriv ut summan av värdet av alla hittade delsträngar.

Console.WriteLine($"Det totala värdet av alla delsträngar är: {sum}");