using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerializeDemo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public Pokemon Pokemon { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _pokemonName;
        public string PokemonName
        {
            get => _pokemonName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _pokemonName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _pokemonImage;
        public string PokemonImage
        {
            get => _pokemonImage;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _pokemonImage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _pokemonHeight;
        public int PokemonHeight
        {
            get => _pokemonHeight;
            set
            {
                _pokemonHeight = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand SearchPokemonCommand => new Command(async () => await SearchPokemon());

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task SearchPokemon()
        {
            var foundPokemon = await PokemonService.GetPokeMon(Name);
            Pokemon = JsonConvert.DeserializeObject<Pokemon>(foundPokemon);

            PokemonName = Pokemon.name;
            PokemonHeight = Pokemon.height;
            PokemonImage = Pokemon.sprites.front_default;
        }
    }
}
