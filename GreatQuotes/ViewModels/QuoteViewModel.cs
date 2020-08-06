using System;
using System.Threading.Tasks;
using GreatQuotes.Data;
using GreatQuotes.Infrastructure;
using Sharpnado.Presentation.Forms;

namespace GreatQuotes.ViewModels
{
    public class QuoteViewModel : SimpleViewModel
    {
        public TaskLoaderNotifier QuoteDetailsLoaderNotifier { get; }

        readonly GreatQuote quote;

        private bool _isToggled;
        public bool IsToggled
        {
            get { return _isToggled; }
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get { return quote.FirstName; }
            set
            {
                if (quote.FirstName != value)
                {
                    quote.FirstName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(() => Author);
                }
            }
        }

        public string LastName
        {
            get { return quote.LastName; }
            set
            {
                if (quote.LastName != value)
                {
                    quote.LastName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(() => Author);
                }
            }
        }

        public string Author
        {
            get { return quote.FirstName + " " + quote.LastName; }
        }

        public Gender Gender
        {
            get { return quote.Gender; }
            set
            {
                if (quote.Gender != value)
                {
                    quote.Gender = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string QuoteText
        {
            get { return quote.QuoteText; }
            set
            {
                if (quote.QuoteText != value)
                {
                    quote.QuoteText = value;
                    RaisePropertyChanged();
                }
            }
        }

        public QuoteViewModel(GreatQuote quote)
        {
            this.quote = quote;

            this.QuoteDetailsLoaderNotifier = new TaskLoaderNotifier();
        }

        public void Load()
        {
            QuoteDetailsLoaderNotifier.Load(InitializationTask);
        }

        private async Task InitializationTask()
        {
            await Task.Delay(1500);
        }
    }
}