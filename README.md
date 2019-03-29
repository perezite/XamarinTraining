Hallo vom Michi :)
Hallo


Links:
https://github.com/ppedvAG/190326_Xamarin_DUS
http://fakeupdate.net/
https://blog.xamarin.com/xamarin-forms-4-0-feature-preview-an-entirely-new-point-of-collectionview/
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/
https://www.nuget.org/packages/Xam.Plugin.Iconize/
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell?tabs=android
https://github.com/xamarin/Xamarin.Forms/wiki/Feature-Roadmap
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/styles/css/index
https://blog.xamarin.com/adaptive-mobile-designs-with-flexlayout/
https://github.com/Fody/PropertyChanged
https://docs.microsoft.com/en-us/xamarin/essentials/
https://xamarinhelp.com/accommodate-on-screen-keyboard-xamarin-forms/



Bilder:
http://placekitten.com/g/500/800
https://baconmockup.com/500/500/
http://www.placecage.com/g/200/300
https://www.stevensegallery.com/200/300
http://www.fillmurray.com/g/200/300




    <!-- Horizontal/VerticalOptions: 
    Center -> Container selbst
    ...andExpand -> innerhalb des Containers -->
    <StackLayout BackgroundColor="DarkSlateBlue"
                 Spacing="0">
        <Button Text="Button 1"/>
        <Button Text="Button 2"/>
        <Button Text="Button 3"/>
        <Button Text="Button 4"/>
        <BoxView BackgroundColor="NavajoWhite"
                 VerticalOptions="FillAndExpand"/>

        <StackLayout Orientation="Horizontal">
            <Button Text="Ok"/>
            <Button Text="Abbrechen" HorizontalOptions="FillAndExpand"/>
        </StackLayout>
        
        
    </StackLayout>
    
        <Grid BackgroundColor="MediumSeaGreen"
          RowSpacing="20"
          ColumnSpacing="20">

        <BoxView Grid.Row="0" Grid.ColumnSpan="2" BackgroundColor="LightSalmon"/>
        <BoxView Grid.Row="3" BackgroundColor="DarkCyan"/>
        <BoxView Grid.Row="1"
                 Grid.RowSpan="3"
                 Grid.Column="1" BackgroundColor="MediumPurple"/>

    </Grid>
    
        <!-- Margin: Aussenabstand
         Padding: Innenabstand
         "links,oben,rechts,unten"
         "linksOben,RechtsUnten"
         "alleSeiten"
        -->
    <Grid BackgroundColor="LightPink" Padding="20">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>
        
        
        <Entry Grid.Row="0" Grid.Column="0" Placeholder="Suchtext:"/>
        <Button Grid.Row="0" Grid.Column="1" Text="Suchen !"/>
        <ListView Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="2" BackgroundColor="YellowGreen"/>
    </Grid>
    
    
        <!-- AbsoluteLayout.LayoutBounds="X,Y,Width,Height" -->
    <!-- AbsoluteLayout.LayoutFlags="None"   => Proportional zwischen 0 und 1-->

    <AbsoluteLayout BackgroundColor="Linen">
        <BoxView BackgroundColor="PaleGreen"
                 AbsoluteLayout.LayoutBounds="0,0,1,0.3"
                 AbsoluteLayout.LayoutFlags="SizeProportional"/>
        
        <BoxView BackgroundColor="DarkMagenta"
                 AbsoluteLayout.LayoutBounds="0,1,1,0.7"
                 AbsoluteLayout.LayoutFlags="All"/>
        
        <BoxView BackgroundColor="DarkSalmon"
                 AbsoluteLayout.LayoutBounds="50,50,100,100"/>

        <BoxView BackgroundColor="Blue"
                 AbsoluteLayout.LayoutBounds="80,80,100,100"/>
    </AbsoluteLayout>
    
        <RelativeLayout BackgroundColor="Navy">

        <BoxView x:Name="boxViewHeader" BackgroundColor="BlueViolet"
                 RelativeLayout.HeightConstraint="{ConstraintExpression
                 Type=RelativeToParent,
                 Property=Height,
                 Factor=0.333}"
                 RelativeLayout.WidthConstraint="{ConstraintExpression
                 Type=RelativeToParent,
                 Property=Width}"/>

        <BoxView BackgroundColor="HotPink" HeightRequest="100" WidthRequest="100"
                 RelativeLayout.YConstraint="{ConstraintExpression
                 Type=RelativeToView,
                 ElementName=boxViewHeader,
                 Property=Height,
                 Factor=1,Constant=-50}"
                 RelativeLayout.XConstraint="{ConstraintExpression
                 Type=RelativeToView,
                 ElementName=boxViewHeader,
                 Property=Width,
                 Factor=0.5,Constant=-50}"/>

    </RelativeLayout>
    
    
    class MulticastService
    {
        public MulticastService()
        {
            client = new UdpClient();
            client.ExclusiveAddressUse = false;
            localEp = new IPEndPoint(IPAddress.Any, 1234);

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;

            client.Client.Bind(localEp);

            IPAddress multicastaddress = IPAddress.Parse("224.0.0.99");
            client.JoinMulticastGroup(multicastaddress);
            remoteep = new IPEndPoint(multicastaddress, 1234);

            cts = new CancellationTokenSource();
        }
        private CancellationTokenSource cts;
        private Task listener;

        private UdpClient client;
        private IPEndPoint localEp;
        private IPEndPoint remoteep;

        public bool IsRunning { get; set; }

        public void StartService()
        {
            if (IsRunning)
                return;
            listener = Task.Run(new Action(Listen));
            IsRunning = true;
        }
        public void StoppService()
        {
            if (IsRunning)
            {
                cts.Cancel();
                IsRunning = false;
            }
        }
        public void SendJSON(string json)
        {
            if (IsRunning)
            {
                var data = Encoding.Default.GetBytes(json);
                client.Send(data, data.Length, remoteep);
            }
        }
        private void Listen()
        {
            while (true)
            {
                if (cts.Token.IsCancellationRequested)
                    break;

                byte[] data = client.Receive(ref localEp);
                string json = Encoding.Default.GetString(data, 0, data.Length);
                MulticastMessage msg = JsonConvert.DeserializeObject<MulticastMessage>(json);
                MessagingCenter.Send(this, msg.Type.ToString(), msg);
            }
        }
    }
 
    // --------------------------
    
        class ShakeViewModel
    {
        public ShakeViewModel()
        {
            service = new MulticastService();
            service.StartService();
            Accelerometer.ShakeDetected += ShakeDetected;

            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
            else
                Accelerometer.Start(SensorSpeed.UI);
        }
        private readonly MulticastService service;
        private void ShakeDetected(object sender, EventArgs e)
        {
            service.SendMessage("vibrate");
        }
    }
    
    // ---------------------------------
    
        <ContentPage.BindingContext>
        <vm:ShakeViewModel/>
    </ContentPage.BindingContext>
    
        <StackLayout>
            <Label Text="pls Shake for fun :)"
                VerticalOptions="CenterAndExpand" 
                HorizontalOptions="CenterAndExpand" />
        </StackLayout>
