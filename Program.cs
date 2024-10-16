using System.Diagnostics;

string path = "C:\\Users\\msette\\Desktop\\Rubrica.csv";

string contacts = File.ReadAllText(path);
string[] arrayContacts = contacts.Split('\n');


Program();

void Program()
{


    //tempo   
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    BubbleSort(arrayContacts);
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    



    Console.WriteLine("Tempo del Bubble Sort: " + stopWatch);



    //Selection sort

    stopWatch.Restart();
    SelectionSort(arrayContacts);
    stopWatch.Stop();
    ts = stopWatch.Elapsed;

    Console.WriteLine("Tempo del Selection Sort " + stopWatch);


    //Insertion Sort

    stopWatch.Restart();
    InsertionSort(arrayContacts);
    stopWatch.Stop();
    ts = stopWatch.Elapsed;


    Console.WriteLine("Tempo del Insertion Sort " + stopWatch);


    //Merge Sort
    stopWatch.Start();
    MergeSort(arrayContacts, 0, arrayContacts.Length - 1);
    stopWatch.Stop();
    ts = stopWatch.Elapsed;

    Console.WriteLine("Tempo del Merge Sort " + stopWatch);

    //stampa elementi ordinati

    Console.WriteLine("\nArray ordinato:");
    Console.WriteLine(arrayContacts.ToString());

    foreach (var item in arrayContacts)
    {
        Console.WriteLine(item);
    }

}





//Bubbble sort
void BubbleSort(string[] array)
{
    int n = array.Length;
    bool changed;

    for (int i = 0; i < n - 1; i++)
    {
        changed = false;

        for (int j = 0; j < n - 1 - i; j++)
        {

            if (string.Compare(array[j], array[j + 1]) > 0)
            {
                string temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;

                changed = true;
            }
        }
        if (!changed)
            break;
    }
}


//selection sort
static void SelectionSort(string[] array)
{
    int n = array.Length;

    for (int i = 0; i < n - 1; i++)
    {

        int indiceMinimo = i;
        for (int j = i + 1; j < n; j++)
        {

            if (string.Compare(array[j], array[indiceMinimo]) < 0)
            {
                indiceMinimo = j;
            }
        }


        if (indiceMinimo != i)
        {
            string temp = array[i];
            array[i] = array[indiceMinimo];
            array[indiceMinimo] = temp;
        }
    }
}


//insertion sort
static void InsertionSort(string[] array)
{
    int n = array.Length;

    for (int i = 1; i < n; i++)
    {
        string chiave = array[i];
        int j = i - 1;

        // Sposta gli elementi di array[0..i-1] che sono maggiori della chiave
        // a una posizione avanti rispetto alla loro posizione attuale
        while (j >= 0 && string.Compare(array[j], chiave) > 0)
        {
            array[j + 1] = array[j];
            j--;
        }

        // Inserisci la chiave nella sua posizione corretta
        array[j + 1] = chiave;
    }
}


//Merge sort

static void MergeSort(string[] array, int inizio, int fine)
{
    if (inizio < fine)
    {
        // Trova il punto medio
        int mezzo = (inizio + fine) / 2;

        // Ordina la prima metà
        MergeSort(array, inizio, mezzo);
        // Ordina la seconda metà
        MergeSort(array, mezzo + 1, fine);
        // Unisci le due metà
        Merge(array, inizio, mezzo, fine);
    }
}


static void Merge(string[] array, int inizio, int mezzo, int fine)
{
    // Dimensione delle sottosezioni
    int n1 = mezzo - inizio + 1;
    int n2 = fine - mezzo;

    // Creazione degli array temporanei
    string[] sinistra = new string[n1];
    string[] destra = new string[n2];

    // Copia i dati negli array temporanei
    Array.Copy(array, inizio, sinistra, 0, n1);
    Array.Copy(array, mezzo + 1, destra, 0, n2);

    // Indici per scorrere gli array temporanei
    int i = 0, j = 0, k = inizio;

    // Unisci gli array temporanei nell'array originale
    while (i < n1 && j < n2)
    {
        if (string.Compare(sinistra[i], destra[j]) <= 0)
        {
            array[k] = sinistra[i];
            i++;
        }
        else
        {
            array[k] = destra[j];
            j++;
        }
        k++;
    }

    // Copia gli elementi rimanenti, se ce ne sono
    while (i < n1)
    {
        array[k] = sinistra[i];
        i++;
        k++;
    }

    while (j < n2)
    {
        array[k] = destra[j];
        j++;
        k++;
    }
}
