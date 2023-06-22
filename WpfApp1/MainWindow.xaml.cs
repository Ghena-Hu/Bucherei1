using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bibliotheksverwaltung
{
    public partial class MainWindow : Window
    {
        private List<Buch> buchListe = new List<Buch>(); // da ist für Liste von Büchern

        public MainWindow()
        {
            InitializeComponent();  // Benutzeroberfläche  
            buchListView.ItemsSource = buchListe; // Bücherliste anzeigen
        }

        private void neuesBuch_Click(object sender, RoutedEventArgs e) // da ist für Neues Buch hinzufügen
        {
            // Neues Buch erstellen und neue Eingaben hinzufügen
            Buch buch = new Buch(); //  neues Buch erstelen
            buch.Titel = titelTextBox.Text; // Titel von Buch
            buch.Autor = autorTextBox.Text; // Autor von Buch
            buch.Verlag = verlagTextBox.Text; // Verlag von Buch
            buch.Erscheinungsjahr = int.Parse(erscheinungsjahrTextBox.Text); // da ist für die Erscheinungsjahr 

            //  neues Buch zur Liste hinzufügen
            buchListe.Add(buch);

            // Die ListAnzeigeaktualisieren
            buchListView.Items.Refresh();
        }

        private void buchBearbeiten_Click(object sender, RoutedEventArgs e) // da ist für Bearbeiten
        {
            //  ausgewählte Buch aus der Listanzeige zeigen
            Buch buch = (Buch)buchListView.SelectedItem;

            // Überprüfen, ob ein Buch ausgewählt wurde
            if (buch != null)
            {
                // Die Eigenschaften von Buch mit den neuen Werten aktualisieren
                buch.Titel = titelTextBox.Text;
                buch.Autor = autorTextBox.Text;
                buch.Verlag = verlagTextBox.Text;
                buch.Erscheinungsjahr = int.Parse(erscheinungsjahrTextBox.Text);

                // Die ListAnzeige aktualisieren
                buchListView.Items.Refresh();
            }
        }

        private void buchEntfernen_Click(object sender, RoutedEventArgs e) // da ist für Entfernen
        {
            // ausgewählte Buch aus der ListView abrufen
            Buch buch = (Buch)buchListView.SelectedItem;

            // Überprüfen, ob ein Buch ausgewählt wurde
            if (buch != null)
            {
                // Das Buch aus der Liste entfernen
                buchListe.Remove(buch);

                // Die ListView aktualisieren
                buchListView.Items.Refresh();
            }
        }
    }
    public class Buch // da ist die Klasse für ein Buch
    {
        public string Titel { get; set; } 
        public string Autor { get; set; } 
        public string Verlag { get; set; } 
        public int Erscheinungsjahr { get; set; } 
    }
}
