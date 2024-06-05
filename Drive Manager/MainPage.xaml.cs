using CommunityToolkit.Mvvm.Input;
using Drive_Manager.Models;
using Microcharts;
using SkiaSharp;

namespace Drive_Manager
{
    public partial class MainPage : ContentPage
    {

        private List<ChartEntry> entries;
        private List<Drive> drives;
        private string[] graphColors = new string[]
        {
            "#1abc9c", "#2ecc71", "#3498db", "#9b59b6", "#f1c40f", "#e67e22", "#e74c3c",
            "#16a085", "#27ae60", "#2980b9", "#8e44ad", "#f39c12", "#d35400", "#c0392b",
            "#34495e", "#ecf0f1", "#2c3e50", "#bdc3c7"
        };

        public MainPage()
        {
            InitializeComponent();
            GetDrives();
            collectionView.ItemsSource = this.drives;
            
            float totalFreeSpace = 0.0f;
            if (this.drives != null)
            {
                this.entries = new List<ChartEntry>();
                for (int i = 0; i < this.drives.Count; i++)
                {
                    string label = this.drives[i].Letter.ToString() + ":";
                    float value = this.drives[i].SpaceUsed;
                    totalFreeSpace += drives[i].SpaceAvailable;
                    this.entries.Add(new ChartEntry(value)
                    {
                        Label = label,
                        Color = SKColor.Parse(graphColors[i])
                    });
                }

                ChartEntry newEntry = new ChartEntry(totalFreeSpace)
                {
                    Label = "Free",
                    Color = SKColor.Parse("#6F6F6F")
                };
               

                this.entries.Add(newEntry);


                chartView.Chart = new DonutChart
                {
                    BackgroundColor = SKColor.Parse("#1c1c1c"),
                    Entries = this.entries,
                    HoleRadius = 0.85f,
                    LabelTextSize = 15,
                    AnimationDuration = TimeSpan.FromSeconds(0)

                };

            }
            if(this.drives == null) this.drives = new List<Drive>();
            if(this.entries == null) this.entries = new List<ChartEntry>();
        }

        void GetDrives()
        {
            this.drives = new List<Drive>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach(DriveInfo d in allDrives)
            {
                this.drives.Add(new Drive(d));
            }
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync(nameof(DetailPage));
        }

        private void detailedViewButtonClicked(char driveLetter)
        {
            int index = 0;
            for(int i = 0; i < this.drives.Count; i++)
            {
                if (driveLetter == this.drives[i].Letter)
                {
                    index = i;
                }
            }
            Navigation.PushModalAsync(new DetailPage());
            
        }
    }
}