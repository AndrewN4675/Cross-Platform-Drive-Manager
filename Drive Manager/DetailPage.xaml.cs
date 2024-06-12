using Drive_Manager.DriveUtil;
using Microcharts;
using SkiaSharp;

namespace Drive_Manager;

public partial class DetailPage : ContentPage
{
    private char DriveLetter {  get; }
    private readonly string[] GraphColors =
           {
                "#1abc9c", "#2ecc71", "#3498db", "#9b59b6", "#f1c40f", "#e67e22", "#e74c3c",
                "#16a085", "#27ae60", "#2980b9", "#8e44ad", "#f39c12", "#d35400", "#c0392b",
                "#34495e", "#ecf0f1", "#2c3e50", "#bdc3c7"
            };

    public DetailPage(Drive drive)
    {
        InitializeComponent();
        setTextFields(drive);
        GenerateStorageChart(drive);
        this.DriveLetter = drive.Letter;
    }

    private void setTextFields(Drive drive)
    {
        driveLetter.Text = drive.Letter.ToString();
        driveLabel.Text = drive.Label;
        driveType.Text = drive.Type;
        driveFormat.Text = drive.Format;
        usedStorage.Text = drive.SpaceUsed.ToString("#,##0.##") + " GB";
        availStorage.Text = drive.SpaceAvailable.ToString("#,##0.##") + " GB";
        totalStorage.Text = drive.TotalSize.ToString("#,##0.##") + " GB";
    }

    private void GenerateStorageChart(Drive drive)
    {
        ChartEntry[] entries = {
            new ChartEntry(drive.SpaceUsed)
            {
                Color = SKColor.Parse("#1abc9c"),
                Label = "Used"
            },
            new ChartEntry(drive.SpaceAvailable)
            {
                Color = SKColor.Parse("#6F6F6F"),
                Label = "Free"
            }
        };

        chartView.Chart = new DonutChart{
           BackgroundColor = SKColor.Parse("#1c1c1c"),
           Entries = entries,
           HoleRadius = 0.85f,
           LabelTextSize = 15,
           AnimationDuration = TimeSpan.FromSeconds(0)
        
        };
    }

    private void StorageDetailButtonClicked(object sender, EventArgs e)//recreates the storage chart with the size of the main folders found in the root directory of the drive
    {
        string directory = this.DriveLetter.ToString() + ":/";
    }

    protected override void OnDisappearing()
    {
        Navigation.PopAsync();
        base.OnDisappearing();
    }
    
}