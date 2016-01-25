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
using Game.Contracts;
using Game.Models.Items;
using Game.UI;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IRenderer renderer = new Renderer(Canvas);
            Chest chest = new Chest(200, 100, 100);
            var image = new Image();
            image.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Images/chest.png"));

            renderer.Render(chest);
        }
    }
}
