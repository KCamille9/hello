using MVVMExample.Model;
using MVVMExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMExample
{


    //Data Binding is gonna happen through here

    public class MainViewModel : ViewModelBase
    {
        //Person's properties val
        private Person person_ = null;
        private int aidi_ = 0;
        private String name_ = null;
        private int age_ = 0;
        private String profession_ = null;
        public String searchBoxText_ = null;

        private List<String> myList_ = null;
        private List<String> usual_ = null;



        //Person list
        public ObservableCollection<Person> personList_ = new ObservableCollection<Person>();
        public ObservableCollection<String> peopleFound_ = new ObservableCollection<String>();

        //Selected Person
        public Person SelectedPerson { get; set; } 

        //Person properties binded in XAML<------------------>
        public String NameX
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
                OnPropertyChanged("NameX");
            }
        }

        public int AgeX
        {
            get
            {
                return age_;
            }
            set
            {
                age_ = value;
                OnPropertyChanged("AgeX");
            }
        }

        public String ProfessionX
        {
            get
            {
                return profession_;
            }
            set
            {
                profession_ = value;
                OnPropertyChanged("ProfessionX");
            }
        }

        public ObservableCollection<Person> PersonList
        {
            get
            {
                return personList_;
            }
        }

        public ObservableCollection<String> PeopleFound
        {
            get {
                return peopleFound_ ;
            }
        }

        //Search textbox
        public String SearchBoxText
        {
            get
            {
                return searchBoxText_;
            }
            set
            {
                profession_ = value;
                OnPropertyChanged("SearchBoxText");
            }
        }

        //NamesList
        public List<String> MyList
        {
            get
            {
                return myList_;
            }
            set
            {
                myList_ = value;
                OnPropertyChanged("MyList");
            }
        }

        //Usual item, in searchbox
        public List<String> Usuals
        {
            get
            {
                return usual_;
            }
            set
            {
                usual_ = value;
                OnPropertyChanged("Usuals");
            }
        }


        //Command to display name to the screen
        public ICommand AddButtonClicked
        {
            get
            {
                return new DelegateCommand(DisplayName);
            }
        }

        public void DisplayName()
        {
            person_ = new Person(aidi_, NameX, AgeX, ProfessionX);
            String personStr = person_.Sentence;
            personList_.Add(person_);
            peopleFound_.Add(personStr);


            aidi_++;

            //Resseting values
            NameX = "";
            AgeX = 0;
            ProfessionX = "";

        }

        
        //Command to delete a person
        public ICommand DeleteButtonClicked
        {

            get
            {
                return new DelegateCommand(DeletePerson);
            }
        }

        public void DeletePerson()
        {

            if (SelectedPerson != null)
            {
                PersonList.Remove(SelectedPerson);
                personList_.Remove(SelectedPerson);
            }
        }

        //Command to edit a customer
        public ICommand EditButtonClicked
        {
            get
            {
                return new DelegateCommand(EditPerson);
            }
        }

        public void EditPerson()
        {
            if (SelectedPerson != null)
            {
                NameX = SelectedPerson.Name;
                AgeX = SelectedPerson.Age;
                ProfessionX = SelectedPerson.Proffesions;

            }
        }

        //Command to update a customer
        public ICommand SaveButtonClicked
        {
            get
            {
                return new DelegateCommand(UpdatePerson);
            }
        }

        public void UpdatePerson()
        {
            int oldID = SelectedPerson.ID;

            if (SelectedPerson != null)
            {
                personList_.Remove(SelectedPerson);

            }

            person_ = new Person(oldID, NameX, AgeX, ProfessionX);
            personList_.Add(person_);
            aidi_++;

            //Resseting values
            NameX = "";
            AgeX = 0;
            ProfessionX = "";
        }

        //Command to update a customer
        public ICommand SearchButtonClicked
        {
            get
            {
                return new DelegateCommand(SearchPerson);
            }
        }



       
        public void SearchPerson()
        {
           /* String userText = SearchBoxText;

            foreach (String item in PeopleFound)
            {
                String[] sentence = item.Split('\n', ' ');

                foreach (String word in sentence)
                {
                    if (word.ToLower().Equals(userText))
                    {
                        peopleFound_.Add(item);
                    }
                }
            }** 
            /*
            String[] result = null;
            result = peopleFound_.Where(x => x.Contains(SearchBoxText)).ToArray();
           
            for (var i = 0; i < result.Length; i++)
            {
                PeopleFound.Add(result[i]);
            }
            */
            
        }
       
    }
}
