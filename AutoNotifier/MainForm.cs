﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;

namespace AutoNotifier
{
    public partial class MainForm : Form
    {
        CancellationTokenSource cancelTokenSource;

        // Notification Events
        List<NotificationEvent> events = new List<NotificationEvent>();
        List<int> triggeredEvents = new List<int>();

        public class NotificationEvent
        {
            public int id { get; set; }
            public string headerText { get; set; }
            public string bottomText { get; set; }
            public string[] eventHours { get; set; }
        }

        // Declare the ContextMenuStrip control.
        private ContextMenuStrip trayContextMenuStrip;

        // Declare sub forms
        private AddEventForm addEventForm;

        public MainForm()
        {
            InitializeComponent();

            // Init sub forms
            addEventForm = new AddEventForm();
            addEventForm.mainForm = this;

            bool hideWindow = false;

            // Load events from JSON
            string jsonString = File.ReadAllText("events.json");
            if (jsonString.Length > 3)
            {
                events = JsonSerializer.Deserialize<List<NotificationEvent>>(jsonString);
                hideWindow = true;
            }

            // Create a cancellation token and start looping through events
            cancelTokenSource = new CancellationTokenSource();
            LoopNotifications(cancelTokenSource.Token);

            // Create a new ContextMenuStrip control.
            trayContextMenuStrip = new ContextMenuStrip();

            // Attach an event handler for the 
            // ContextMenuStrip control's Opening event.
            trayContextMenuStrip.Opening += new CancelEventHandler(cms_Opening);

            notifyIcon1.ContextMenuStrip = trayContextMenuStrip;

            // Hide the window if there are events
            // Otherwise show it so the user can more easily add events
            if (hideWindow) HideControl();

            // Send notification telling the program started
            TriggerNotification(new NotificationEvent
            {
                headerText = "AutoNotifier Started",
                bottomText = "You're a cunt."
            });
        }

        #region Callbacks
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowControl();
        }

        private void bt_addEvent_Click(object sender, EventArgs e)
        {
            addEventForm.Show();
        }

        private void bt_clearevents_Click(object sender, EventArgs e)
        {
            ClearEventsAndFocus();
        }

        private void bt_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e) { }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            // If the window is minimized, hide it to the tray
            if (WindowState == FormWindowState.Minimized)
            {
                Console.WriteLine("Deactivating...");
                HideControl();
            }
        }

        #endregion

        void LoopNotifications(CancellationToken cancelToken)
        {
            if (events == null || events.Count == 0)
            {
                Console.WriteLine("No events to trigger.");
                return;
            }

            Task.Run(async () =>
            {
                while (!cancelToken.IsCancellationRequested)
                {
                    double minutes = 0;
                    string triggerHour = "";
                    NotificationEvent nextEvent = null;
                    bool checkTomorrow = false;

                    // Run twice if the next event starts in the next day
                    Console.WriteLine("Searching for next event...");
                    for (int i = 0; i < 2; i++)
                    {
                        // Iterate through all the events
                        foreach (NotificationEvent ne in events)
                        {
                            Console.WriteLine("Checking event " + ne.id.ToString());
                            // Check if the event is already triggered
                            //if (triggeredEvents.Contains(ne.id)) continue;

                            // Find which event should be triggered next
                            foreach (string s in ne.eventHours)
                            {
                                DateTime hour = DateTime.Parse(s);
                                if (checkTomorrow) hour = hour.AddDays(1);
                                Console.WriteLine("Checking hour: " + hour.ToString());

                                int result = DateTime.Compare(DateTime.Now, hour);
                                Console.WriteLine("Result: " + result.ToString());
                                double totalMinutes = hour.Subtract(DateTime.Now).TotalMinutes;

                                Console.WriteLine("result == -1 : " + (result == -1).ToString());
                                Console.WriteLine("minutes == 0 : " + (minutes == 0).ToString());
                                Console.WriteLine("totalMinutes < minutes : " + (totalMinutes < minutes).ToString());
                                if (result == -1 && (minutes == 0 || totalMinutes < minutes))
                                {
                                    minutes = totalMinutes;
                                    triggerHour = s;
                                    nextEvent = ne;
                                    Console.WriteLine("Found potential next event!");
                                }
                            }
                        }

                        // If there are no events left for today,
                        // search again but look for events in the next day
                        if (minutes == 0)
                        {
                            checkTomorrow = true;
                            triggeredEvents.Clear();
                        }
                        else break;
                    }

                    // Wait to trigger event
                    Console.WriteLine(string.Format("Next notification in {0} minutes.", minutes.ToString()));
                    await Task.Delay(TimeSpan.FromMinutes(minutes), cancelToken);

                    // Trigger event and all the other events that should be triggered at the same time
                    // Add events to triggered list so they're not triggered again
                    TriggerNotification(nextEvent);
                    triggeredEvents.Add(nextEvent.id);
                    foreach (NotificationEvent ne in events)
                    {
                        if (triggeredEvents.Contains(ne.id)) continue;

                        foreach (string s in ne.eventHours)
                        {
                            if (s == triggerHour && !triggeredEvents.Contains(ne.id))
                            {
                                TriggerNotification(ne);
                                triggeredEvents.Add(ne.id);
                            }
                        }
                    }
                }
            }, cancelToken);
        }

        void TriggerNotification(NotificationEvent notification)
        {
            Console.WriteLine(string.Format("{0} ({1})", notification.headerText, DateTime.Now.TimeOfDay.ToString().Substring(0, 8)));

            new ToastContentBuilder()
                .AddArgument("conversationId", 9813)
                .AddText(notification.headerText)
                .AddText(notification.bottomText)
                .AddAppLogoOverride(new Uri("C:/Users/eemel/Desktop/kekw.ico"))
                .SetToastScenario(ToastScenario.Reminder)
                .Show();
        }

        // Utility
        void HideControl()
        {
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        void ShowControl()
        {
            ShowInTaskbar = true;
            Show();
            WindowState = FormWindowState.Normal;
            Focus();
        }

        // This event handler is invoked when the ContextMenuStrip
        // control's Opening event is raised. It demonstrates
        // dynamic item addition and dynamic SourceControl 
        // determination with reuse.
        void cms_Opening(object sender, CancelEventArgs e)
        {
            // Acquire references to the owning control and item.
            Control c = trayContextMenuStrip.SourceControl;
            ToolStripDropDownItem tsi = trayContextMenuStrip.OwnerItem as ToolStripDropDownItem;

            // Clear the ContextMenuStrip control's Items collection.
            trayContextMenuStrip.Items.Clear();

            // Check the source control first.
            if (c != null)
            {
                // Add custom item (Form)
                trayContextMenuStrip.Items.Add("Source: " + c.GetType().ToString());
            }
            else if (tsi != null)
            {
                // Add custom item (ToolStripDropDownButton or ToolStripMenuItem)
                trayContextMenuStrip.Items.Add("Source: " + tsi.GetType().ToString());
            }

            // Populate the ContextMenuStrip control with its default items.
            trayContextMenuStrip.Items.Add("Open", null, (sender, e) => ShowControl());
            trayContextMenuStrip.Items.Add("Clear Events", null, (sender, e) => ClearEventsAndFocus());
            trayContextMenuStrip.Items.Add("Quit", null, (sender, e) => Application.Exit());

            // Set Cancel to false. 
            // It is optimized to true based on empty entry.
            e.Cancel = false;
        }

        public void AddEventAndRestart(string header, string bottom, CheckedListBox.CheckedItemCollection eventTriggerHours)
        {
            // Generate an array of event trigger hours
            string[] eHours = new string[eventTriggerHours.Count];
            for (int i = 0; i < eventTriggerHours.Count; i++)
            {
                eHours[i] = eventTriggerHours[i].ToString();
            }

            // Add event to list
            events.Add(new NotificationEvent
            {
                id = events.Count,
                headerText = header,
                bottomText = bottom,
                eventHours = eHours
            });

            // Save events in a JSON
            SaveJSON();

            LoopNotifications(cancelTokenSource.Token);
        }

        void ClearEventsAndFocus()
        {
            events.Clear();
            ShowControl();
        }

        void SaveJSON()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(events, options);
            File.WriteAllText("events.json", jsonString);
            Console.WriteLine("Events saved in events.json");
        }
    }
}
