using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework.Media;
using System.Windows.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Devices;
using System.Windows.Resources;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Map.Resources;

namespace Map
{
    public partial class MusicPage : PhoneApplicationPage
    {
        #region MemberVariables

        Song _playingSong;                          // The song that is currently playing or will play when the user presses the Play button.
        //const String _playSongKey = "playSong";     // Key for MediaHistoryItem key-value pair.

        #endregion MemberVariables


        // Constructor
        /// <summary>
        /// Initializes member variables and sets up a DispatcherTimer 
        /// to run XNA internals because MediaPlayer is from XNA.
        /// </summary>

        public MusicPage()
        {
            _playingSong = null;
            InitializeComponent();
            BuildApplicationBar();
            MediaPlayer.ActiveSongChanged += MediaPlayer_ActiveSongChanged;
            // Timer to run the XNA internals (MediaPlayer is from XNA)
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(33);
            dt.Tick += delegate { try { FrameworkDispatcher.Update(); } catch { } };
            dt.Start();
            // Event handler to manage button states based on whether or not a song in playing.
            MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaPlayer_MediaStateChanged);
        }

        void MediaPlayer_ActiveSongChanged(object sender, EventArgs e)
        {
            _playingSong = MediaPlayer.Queue.ActiveSong;
            PopulateSongMetadata();
            AddToHistory();
        }


        #region EventHandlers

        /// <summary>
        /// Sets the _playingSong member variable based on how the app was started.
        /// If a song was already playing in the media player, set _playingSong to the currently active song.
        /// If the app was started from a history item, set _playingSong using the data from the history token.
        /// If no song was playing, find a random song in the media library and set _playingSong to that song.
        /// </summary>
        /// 
        List<Song> songList = new List<Song>();
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            SetInitialButtonStates();
            PopulateSongMetadata();
            MediaLibrary library = new MediaLibrary();
            try
            {

                foreach (Song song in library.Songs)
                {
                    //SongDetail a = new SongDetail(song);
                    songList.Add(song);
                }
                ll.ItemsSource = songList;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            if (MediaPlayer.State == MediaState.Playing)
            {
                // A song was already playing when we started.
                _playingSong = MediaPlayer.Queue.ActiveSong;
            }
            else
            {



                // Song library is empty. 
                if (library.Songs.Count == 0)
                {
                    SongName.Text = AppResources.NoSongMsg;
                    PlayButton.IsEnabled = false;
                }

            }
            base.OnNavigatedTo(e);
        }
        void PlayPauseButtonChangeTo(string type)
        {
            if (type == "Play")
            {
                ApplicationBarIconButton bt = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                bt.IconUri = new Uri("Assets/AppBar/play.png", UriKind.Relative);
            }
            if (type == "Pause")
            {
                ApplicationBarIconButton bt = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                bt.IconUri = new Uri("Assets/AppBar/pause.png", UriKind.Relative);
            }
        }
        /// <summary>
        /// Called once the UI has finished loading. Now it is safe to 
        /// initialize the UI elements and to start playing a song, if 
        /// we were launched from a history item.
        /// </summary>
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the album art and song name.
            PopulateSongMetadata();

            // Set the IsEnabled state of the buttons.

        }



        /// <summary>
        /// Sets the state of the Play and Stop buttons based on the state of the MediaPlayer.
        /// </summary>
        void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            switch (MediaPlayer.State)
            {
                case MediaState.Playing:
                    PlayPauseButtonChangeTo("Pause");
                    PopulateSongMetadata();
                    break;

                case MediaState.Stopped:
                    PlayPauseButtonChangeTo("Play");

                    // Song library is empty. 
                    SongName.Text = AppResources.NoSongMsg;
                    PlayButton.IsEnabled = false;
                    break;
                case MediaState.Paused:
                    PlayPauseButtonChangeTo("Play");
                    break;
            }
        }

        #endregion EventHandlers


        #region MediaPlayer

        /// <summary>
        /// Starts playing the song and sets the button states 
        /// to allow the user to stop playing the song.
        /// </summary>
        private void PlaySong()
        {
            if (_playingSong != null)
            {
                MediaPlayer.Play(_playingSong);
            }
        }

        #endregion MediaPlayer


        /// <summary>
        /// Sets the album art and song name in the corresponding UI elements.
        /// </summary>
        private void PopulateSongMetadata()
        {
            if (_playingSong != null)
            {

                // Initialize the SongName TextBlock found in the XAML file.
                SongName.Text = _playingSong.Name;
                Artist.Text = _playingSong.Artist.Name;
                Album.Text = _playingSong.Album.Name;
                int _timeCount = (int)_playingSong.Duration.TotalSeconds;
                if (_timeCount / 3600 != 0)
                    Duration.Text = string.Format("{0}:{1:00}:{2:00}", _timeCount / 3600, (_timeCount / 60) % 60, _timeCount % 60);
                else
                    Duration.Text = string.Format("{0}:{1:00}", (_timeCount / 60) % 60, _timeCount % 60);
                // Try to get the album art.
                // NOTE! You cannot debug this application while the Zune software 
                // is running because the media database is locked by Zune. You will
                // get an InvalidOperationException here if the Zune software is running.
                Stream albumArtStream = _playingSong.Album.GetAlbumArt();

                if (albumArtStream == null)
                {
                    // No album art found, use a generic place holder image.
                    StreamResourceInfo albumArtPlaceholder = Application.GetResourceStream(new Uri("Assets/JustRunLogo.png", UriKind.Relative));
                    albumArtStream = albumArtPlaceholder.Stream;
                }

                // Initialize the Image element named 
                // SongAblbumArtImage in the XAML file.
                BitmapImage albumArtImage = new BitmapImage();
                albumArtImage.SetSource(albumArtStream);
                SongAlbumArtImage.Source = albumArtImage;
            }
            
        }

        /// <summary>
        /// Sets the initial state of the Play and Stop buttons.
        /// </summary>
        private void SetInitialButtonStates()
        {
            // Initialize buttons because the MediaStateChanged 
            // event will not occur if we are already playing.
            UpdateRepeatButtonApprearance();
            UpdateShuffleButtonApprearance();
            switch (MediaPlayer.State)
            {
                case MediaState.Playing:
                    PlayPauseButtonChangeTo("Pause");
                    break;

                case MediaState.Stopped:
                    PlayPauseButtonChangeTo("Play");
                    break;

                case MediaState.Paused:
                    PlayPauseButtonChangeTo("Play");
                    break;
            }
        }

        /// <summary>
        /// Creates a MediaHistoryItem for the song we are playing and 
        /// adds it to the history area of the Music + Videos Hub.
        /// </summary>
        private void AddToHistory()
        {
            if (_playingSong != null)
            {
                MediaHistoryItem historyItem = new MediaHistoryItem();
                historyItem.Title = _playingSong.Name;
                historyItem.Source = "";

                // TODO: Use a more unique image here that better identifies 
                // the history item as having come from this app.
                historyItem.ImageStream = _playingSong.Album.GetThumbnail();

                if (historyItem.ImageStream == null)
                {
                    // No album art found, use a generic place holder image.
                    StreamResourceInfo sri = Application.GetResourceStream(new Uri("Assets/JustRunLogo.png", UriKind.Relative));
                    historyItem.ImageStream = sri.Stream;
                }

                //// If we get activated by the MediaHistoryItem we're creating here, 
                //// our NavigationContext will have a key-value pair ("playSong", "<Song Name>")
                //// where <Song Name> is the Name property of the _playingSong object.
                //historyItem.PlayerContext["play"] = _playingSong.Name;

                // Add our item to the MediaHistory area of the Music + Videos Hub.
                MediaHistory mediaHistory = MediaHistory.Instance;
                mediaHistory.WriteRecentPlay(historyItem);
            }
        }
        Grid grid = null;

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                if (grid != null)
                {

                    TextBlock tb1 = (TextBlock)grid.FindName("tbSongTitle");
                    tb1.Foreground = new SolidColorBrush(Colors.White);
                }
                grid = (Grid)sender;
                TextBlock tb = (TextBlock)grid.FindName("tbSongTitle");
                tb.Foreground = myAnimatedBrush;
                myStoryboard.Begin();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ApplicationBarIconButton PlayButton;
        private void BuildApplicationBar()
        {

            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            try
            {
                ApplicationBar = new ApplicationBar();
                ApplicationBar.Opacity = 0.6;

                ApplicationBar.BackgroundColor = System.Windows.Media.Color.FromArgb(255, 10, 50, 91);
                // Create a new button and set the text value to the localized string from AppResources.

                ApplicationBarIconButton btPrev = new ApplicationBarIconButton(new Uri("/Assets/AppBar/prev.png", UriKind.Relative));
                btPrev.Text = AppResources.Prev;
                btPrev.Click += btPrev_Click;
                ApplicationBar.Buttons.Add(btPrev);

                PlayButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/play.png", UriKind.Relative));
                PlayButton.Text = AppResources.Play;
                PlayButton.Click += PlayButton_Click;
                ApplicationBar.Buttons.Add(PlayButton);

                ApplicationBarIconButton btNext = new ApplicationBarIconButton(new Uri("/Assets/AppBar/next.png", UriKind.Relative));
                btNext.Text = AppResources.Next;
                btNext.Click += btNext_Click;
                ApplicationBar.Buttons.Add(btNext);



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        void StopHighlightingItem()
        {
            myStoryboard.Stop();
            myAnimatedBrush.Color = Colors.White;

        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            StopHighlightingItem();
            MediaPlayer.MovePrevious();
        }

        void btNext_Click(object sender, EventArgs e)
        {
            StopHighlightingItem();
            MediaPlayer.MoveNext();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {

            if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }
            else
                if (MediaPlayer.State != MediaState.Playing)
                {
                    StopHighlightingItem();
                    MediaLibrary a = new MediaLibrary();
                    MediaPlayer.Play(a.Songs);

                    //PlaySong();

                }
                else
                {
                    MediaPlayer.Pause();
                }
        }


        private void ll_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int selectedIndex = ll.ItemsSource.IndexOf(ll.SelectedItem as Song);
                MediaLibrary library = new MediaLibrary();

                MediaPlayer.Play(library.Songs, selectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btRepeat_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.IsRepeating = !MediaPlayer.IsRepeating;
            UpdateRepeatButtonApprearance();
            var newSettings = (AppSettings)System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings["AppSettings"];
            newSettings._Repeating = MediaPlayer.IsRepeating;
            System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings.Save();
        }

        private void btShuffle_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.IsShuffled = !MediaPlayer.IsShuffled;
            UpdateShuffleButtonApprearance();
            var newSettings = (AppSettings)System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings["AppSettings"];
            newSettings._Shuffled = MediaPlayer.IsShuffled;
            System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings.Save();
        }

        void UpdateShuffleButtonApprearance()
        {
            var Settings = (AppSettings)System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings["AppSettings"];
            bool enabled = Settings._Shuffled;
            Stream stream;
            if (enabled)
                stream = Application.GetResourceStream(new Uri("Assets/shuffleEnabled.png", UriKind.Relative)).Stream;
            else
                stream = Application.GetResourceStream(new Uri("Assets/shuffleDisabled.png", UriKind.Relative)).Stream;

            ImageBrush img = new ImageBrush();
            BitmapImage bit = new BitmapImage();
            bit.SetSource(stream);
            img.ImageSource = bit;
            btShuffle.Background = img;
        }

        void UpdateRepeatButtonApprearance()
        {
            var Settings = (AppSettings)System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings["AppSettings"];
            bool enabled = Settings._Repeating;
            Stream stream;
            if (enabled)
                stream = Application.GetResourceStream(new Uri("Assets/repeatEnabled.png", UriKind.Relative)).Stream;
            else
                stream = Application.GetResourceStream(new Uri("Assets/repeatDisabled.png", UriKind.Relative)).Stream;

            ImageBrush img = new ImageBrush();
            BitmapImage bit = new BitmapImage();
            bit.SetSource(stream);
            img.ImageSource = bit;
            btRepeat.Background = img;
        }
    }
}