namespace Drive_Manager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 1050;
            const int newHeight = 550;
           
            window.MaximumWidth = newWidth + 100;
            window.MaximumHeight = newHeight + 100;
            window.MinimumWidth = newWidth;
            window.MinimumHeight = newHeight;
            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
