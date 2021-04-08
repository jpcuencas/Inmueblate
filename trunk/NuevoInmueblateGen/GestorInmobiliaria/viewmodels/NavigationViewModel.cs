using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;
using CommonMvvm;
using GestorInmobiliaria.views;
using GestorInmobiliaria.viewmodels;


namespace GestorInmobiliaria.viewmodels
{
    public sealed class NavigationViewModel : ObservableObject
    {
        Frame currentFrame;
        Frame currentFrameNav;
        Page currentPage;
        Page currentPageNav;
        int image;
        int otherUser;
        int comment;
        Stack<Page> back;
        Stack<Page> forward;
        String imagePath;
        String icon;

        String cabecera;
        String breadcrumbs;
   
        
        static readonly NavigationViewModel instance = new NavigationViewModel();
        private volatile object locker = new object();

        static NavigationViewModel()
        {
            
            instance.currentPage = new views.Anuncio.Anuncios();
            instance.currentPage.DataContext = new AnunciosViewModel();
            instance.currentPageNav = new MenuLateral();
            instance.currentPageNav.DataContext = new MenuLateralViewModel();
         
            instance.Back = new Stack<Page>();
            instance.Forward = new Stack<Page>();
            //Instance.Icon = "/PetstoreGen_WPF;images/petstore.png";
        }

        private NavigationViewModel() { }

        public static NavigationViewModel Instance
        {
            get
            {
                return instance;
            }
        }

        public Frame CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Frame CurrentFrameNav
        {
            get { return currentFrameNav; }
            set { currentFrameNav = value; }
        }

        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    currentPage.ShowsNavigationUI = false;
                    RaisePropertyChanged("CurrentPage");
                }
            }
        }

        public Page CurrentPageNav
        {
            get { return currentPageNav; }
            set
            {
                if (currentPageNav != value)
                {
                    currentPageNav = value;
                    RaisePropertyChanged("CurrentPageNav");
                }
            }
        }

        public int Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    RaisePropertyChanged("Image");
                }
            }
        }

        public int OtherUser
        {
            get { return otherUser; }
            set
            {
                if (otherUser != value)
                {
                    otherUser = value;
                    RaisePropertyChanged("OtherUser");
                }
            }
        }

        public int Comment
        {
            get { return comment; }
            set
            {
                if (comment != value)
                {
                    comment = value;
                    RaisePropertyChanged("Comment");
                }
            }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    RaisePropertyChanged("ImagePath");
                }
            }
        }

        public string Icon
        {
            get { return icon; }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    RaisePropertyChanged("Icon");
                }
            }
        }



        public Stack<Page> Back
        {
            get { return back; }
            set
            {
                if (back != value)
                {
                    back = value;
                    RaisePropertyChanged("Back");
                }
            }
        }

        public Stack<Page> Forward
        {
            get { return forward; }
            set
            {
                if (forward != value)
                {
                    forward = value;
                    RaisePropertyChanged("Forward");
                }
            }
        }

        public string Cabecera
        {
            get { return cabecera; }
            set { cabecera = value; RaisePropertyChanged("Cabecera"); }
        }

        public string Breadcrumbs
        {
            get { return breadcrumbs; }
            set { breadcrumbs = value; RaisePropertyChanged("Breadcrumbs"); }
        }
        #region Methods

        public void pushBackStack()
        {
            Instance.Back.Push(Instance.CurrentPage);
        }

        public void pushForwardStack()
        {
            Instance.Forward.Push(Instance.CurrentPage);
        }

        public void popBackStack()
        {
            if (Instance.Back.Count > 0)
            {
                Instance.CurrentPage = Instance.Back.Pop();
                Breadcrumbs = Breadcrumbs.Substring(0, Breadcrumbs.LastIndexOf('>'));
            }
        }

        public void popForwardStack()
        {

            Instance.currentPage = Instance.Forward.Pop();
        }

        public void cleanBack()
        {
            Instance.Back.Clear();
            Breadcrumbs = "";
        }

        public void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = Application.Current.MainWindow.Width;
            double windowHeight = Application.Current.MainWindow.Height;
            Application.Current.MainWindow.Left = (screenWidth / 2) - (windowWidth / 2);
            Application.Current.MainWindow.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        public RelayCommand VolverCommand { get { return new RelayCommand(popBackStack); } }

        #endregion
    }
}
