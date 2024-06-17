using Drive_Manager.DriveUtil;
using Microcharts;
using SkiaSharp;

namespace Drive_Manager
{
    public partial class MainPage : ContentPage
    {

        private List<ChartEntry> ?Entries;
        private List<Drive> ?Drives;
        private readonly string[] GraphColors = 
            {
                "#1abc9c", "#2ecc71", "#3498db", "#9b59b6", "#f1c40f", "#e67e22", "#e74c3c",
                "#16a085", "#27ae60", "#2980b9", "#8e44ad", "#f39c12", "#d35400", "#c0392b",
                "#34495e", "#ecf0f1", "#2c3e50", "#bdc3c7"
            };

        public MainPage()
        {
            InitializeComponent();
            RetrieveDrives();
            collectionView.ItemsSource = this.Drives;
            GenerateChart();

        }

        ~MainPage() {
            if(this.Drives != null)
            {
                this.Drives.Clear();
                this.Drives = null;
            }   
            if(this.Entries != null)
            {
                this.Entries.Clear();
                this.Entries = null;
            }
        
        }


        private void RetrieveDrives()
        {
            this.Drives = new List<Drive>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach(DriveInfo d in allDrives)
            {
                this.Drives.Add(new Drive(d));
            }
        }

        private void GenerateChart()//Creates a donut chart to visualize total usage and free space of all connected drives combined
        {
            float totalFreeSpace = 0.0f;
            if (this.Drives != null)
            {
                this.Entries = new List<ChartEntry>();
                for (int i = 0; i < this.Drives.Count; i++)
                {
                    string label = this.Drives[i].Letter.ToString() + ":";
                    float value = this.Drives[i].SpaceUsed;
                    totalFreeSpace += Drives[i].SpaceAvailable;
                    this.Entries.Add(new ChartEntry(value)
                    {
                        Label = label,
                        Color = SKColor.Parse(GraphColors[i])
                    });
                }

                ChartEntry newEntry = new ChartEntry(totalFreeSpace)
                {
                    Label = "Free",
                    Color = SKColor.Parse("#6F6F6F")
                };

                this.Entries.Add(newEntry);

                chartView.Chart = new DonutChart
                {
                    BackgroundColor = SKColor.Parse("#1c1c1c"),
                    Entries = this.Entries,
                    HoleRadius = 0.85f,
                    LabelTextSize = 15,
                    AnimationDuration = TimeSpan.FromSeconds(0)

                };

            }
        }

        private async void DetailedViewButtonClicked(object sender, EventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                await Navigation.PushAsync(new DetailPage((Drive)button.CommandParameter), true);
            }
        }
    }
}