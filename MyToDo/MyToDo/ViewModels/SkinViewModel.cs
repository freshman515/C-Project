using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors.ColorManipulation;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Media;

namespace MyToDo.ViewModels {
    public class SkinViewModel :BindableBase{
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
        public DelegateCommand<Object> ChangeHueCommand { get; private set; }

        private bool _isDarkTheme;
        public bool IsDarkTheme {
            get => _isDarkTheme;
            set {
                if (SetProperty(ref _isDarkTheme, value)) {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
            }
        }
        private readonly PaletteHelper paletteHelper = new();

        public SkinViewModel() {
            ChangeHueCommand = new DelegateCommand<Object>(ChangeHue);
            IsDarkTheme = true;
        }

        private void ChangeHue(object obj) {
            var hue = (System.Windows.Media.Color)obj!;

            Theme theme = paletteHelper.GetTheme();

            theme.PrimaryLight = new ColorPair(hue.Lighten());
            theme.PrimaryMid = new ColorPair(hue);
            theme.PrimaryDark = new ColorPair(hue.Darken());

            paletteHelper.SetTheme(theme);

        }
        private static void ModifyTheme(Action<Theme> modificationAction) {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }

    }
}
