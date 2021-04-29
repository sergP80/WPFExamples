using System.Globalization;
using System.Windows.Input;

namespace SharedResources
{

    public class LangItemViewModel: AbstractObservableViewModel
    {
        private CultureInfo culture;

        public LangItemViewModel(string langCode, ICommand command) : this(false, langCode, command) { }

        public LangItemViewModel(bool active, string langCode, ICommand commad)
        {
            Active  = active;
            culture = new CultureInfo(langCode);
            Command  = commad;
        }

        private bool active;
        public bool Active {
            get
            {
                return active;
            }
            set
            {
                if (active != value)
                {
                    active = value;
                    OnPropertyChanged();
                }
            } 
        }

        private ICommand command;

        public ICommand Command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
                OnPropertyChanged();
            }
        }

        public string CountryCode
        {
            get
            {
                return culture.IetfLanguageTag.Split(new char[] { '-'})[1];
            }
            
        }

        public string NativeLanguageName
        {
            get
            {
                return culture.NativeName;
            }

        }

        public string Name
        {
            get
            {
                return culture.Name;
            }

        }
    }
}
