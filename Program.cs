using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using B64.Services;
using Terminal.Gui;
using B64.Models;
using System.Security.Cryptography.X509Certificates;

namespace B64
{
    class Program
    {
        //public ListView _listView;
        static async Task Main(string[] args)
        {
            //Initialize Gui.cs
            Application.Init();

            ConvertDXF _convert = new ConvertDXF();                   

            //create primary window
            var win = new Window("Convert DXF")
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(50f),
                Height = Dim.Fill()
            };

            //Create secondary window
            var win2 = new Window()
            {
                X = Pos.Right(win),
                Y = 0,
                Width = Dim.Percent(50f),
                Height = Dim.Fill()
            };

            //Change terminal colors
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);

            //grab the top level application container
            var top = Application.Top;

            //Add our window objects to the top level containe r
            top.Add(win, win2);
            
            //As the user cycles through available buttons the NextButton function tracks the next value from the "Buttons" list
            //This list contains context for user on button functionality
            var Buttons = new List<string>() {  "Convert DXF to B64 string", 
                "Close the application"};

            //track the current position of the cursor in the application
            int currentPosition = 0;

            //function to update currentPosition variable
            //maintains a valid index inside of the Buttons list
            string NextButton(string direction)
            {
                switch (direction)
                {
                    //i.e. keyboard down/tab/right 
                    case "Down":
                        if (currentPosition == Buttons.Count - 1)
                        {
                            currentPosition = 0;
                        }
                        else
                        {
                            currentPosition += 1;
                        }
                        break;
                    //i.e. keyboard up/backtab/left
                    case "Up":
                        if (currentPosition == 0)
                        {
                            currentPosition = Buttons.Count - 1;
                        }
                        else
                        {
                            currentPosition -= 1;
                        }
                        break;
                }
                return Buttons[currentPosition];
            };            

            //label object gives context to what the user is performing in the application
            var ButtonDescription = new TextView()
            { 
                X = 2, 
                Y = 2, 
                Width = Dim.Percent(90f),
                Height = Dim.Fill(),
                WordWrap = true,
                ReadOnly = true,
                Text = Buttons[currentPosition],
                ColorScheme = Colors.Menu
            };

            //interprets keyboard inputs to track cursor position 
            void KeyDownPressUp(KeyEvent keyEvent, string updown)
            {
                //List of strings
                List<string> stringSplit = new List<string>();
                //split the name of the key stroke on the '-' character
                stringSplit.AddRange(updown.Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)); 
                //switch on the string in the last index
                switch (stringSplit[stringSplit.Count - 1])
                {
                    case "CursorDown":
                        ButtonDescription.Text = NextButton("Down");
                        break;
                    case "CursorRight":
                        ButtonDescription.Text = NextButton("Down");
                        break;
                    case "Tab":
                        ButtonDescription.Text = NextButton("Down");
                        break;
                    case "CursorUp":
                        ButtonDescription.Text = NextButton("Up");
                        break;
                    case "CursorLeft":
                        ButtonDescription.Text = NextButton("Up");
                        break;                    
                    case "BackTab":
                        ButtonDescription.Text = NextButton("Up");
                        break;
                }
            }            

            #region Convert DXF to B64 string
            //button object
            var ConvertDXF = new Button("Convert DXF")
            {
                X = 3,
                Y = 2
            };
            
            ConvertDXF.Clicked += () =>
            {
                ScreenWipe(ButtonDescription);

                //Update description
                ButtonDescription.Text = "Processing, please wait.";
                //refresh application required to see text updated
                Application.Refresh();
                //call API service to get all ship addresses
                string dxfPath = "C:\\users\\lhotchkiss\\downloads\\DXF Test.dxf";
                string pngPath = "c:\\users\\lhotchkiss\\downloads\\temp\\output.png";
                //_convert.EncodeDxfToBase64("");
                //Update description again when call is finished

                if (_convert.ConvertDXFToPNG(dxfPath, pngPath))
                {
                    _convert.EncodeToBase64(pngPath);
                    //for ()
                    ButtonDescription.Text = _convert.EncodeToBase64(dxfPath);
                    Application.Refresh();
                }
                //update current position required in case mouse click was used to trigger event
                currentPosition = Buttons.IndexOf("Convert DXF to B64 string");
            };
            #endregion                    

            //button object 
            var ExitApplicationButton = new Button("Exit")
            {
                X = 3,
                Y = 13
            };
            //exit button click event (stop application)
            ExitApplicationButton.Clicked += () => Application.RequestStop();

            //add top level buttons to main window
            win.Add(
                ConvertDXF,
                ExitApplicationButton
                );

            //add "description" to secondary window
            win2.Add(
                ButtonDescription
                );

            static void ScreenWipe(TextView view, string wipeChar = "█", int delayMs = 10)
            {
                // Get dimensions
                int width = view.Bounds.Width;
                int height = view.Bounds.Height;

                // Build wipe text line by line
                for (int x = 0; x < width; x++)
                {
                    string wipeFrame = "";
                    for (int y = 0; y < height; y++)
                    {
                        // Add wipeChar for filled columns, space for the rest
                        wipeFrame += new string(wipeChar[0], x + 1).PadRight(width) + "\n";
                    }
                     
                    // Update view.Text on UI thread
                    Application.MainLoop.Invoke(() =>
                    {
                        view.Text = wipeFrame.TrimEnd();
                        Application.Refresh();
                    });

                    System.Threading.Thread.Sleep(delayMs);
                }
            }

            //when key is pressed trigger keydownpressup function
            win.KeyDown += (e) => KeyDownPressUp(e.KeyEvent, e.KeyEvent.ToString());
            
            //Run application
            Application.Run();
        }
    }
}

