using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Com.Airwatch.Gateway.UI;
using Com.Airwatch.Sdk;
using Android.Support.V7.App;

namespace XamarinAndroidSampleApp.Information
{
    [Activity(Label = "Information")]
    public class GeneralInfoActivity : GatewayBaseActivity
    {

        ListView listView;
        List<ItemType> listItems = new List<ItemType>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            listView = FindViewById<ListView>(Resource.Id.listview);

            // Below call returns instanlty as SDKManager is already initialised as part of login flow
            var sdkmanager = SDKManager.Init(this);
            listItems.Add(new HeaderItem() { Heading = "Device Information" });
            listItems.Add(new ListItem() { Setting = "Device UID", Value = sdkmanager.DeviceUid });
            listItems.Add(new ListItem() { Setting = "Compliance Status", Value = sdkmanager.IsCompliant.ToString() });
            listItems.Add(new ListItem() { Setting = "Compromised Status", Value = sdkmanager.IsCompromised.ToString() });
            listItems.Add(new ListItem() { Setting = "Is Device Enterprise", Value = sdkmanager.IsEnterprise.ToString() });
            listItems.Add(new ListItem() { Setting = "Has API Permission/Is Whitelisted", Value = sdkmanager.HasAPIPermission.ToString() });
            listItems.Add(new HeaderItem() { Heading = "User Information" });
            listItems.Add(new ListItem() { Setting = "Username", Value = sdkmanager.EnrollmentUsername });
            listItems.Add(new ListItem() { Setting = "Group ID", Value = sdkmanager.GroupId });
            listItems.Add(new ListItem() { Setting = "Emrollment Status", Value = sdkmanager.IsEnrolled.ToString() });
            listItems.Add(new HeaderItem() { Heading = "Server Information" });
            listItems.Add(new ListItem() { Setting = "Server", Value = sdkmanager.ServerName });
            listItems.Add(new ListItem() { Setting = "Console Version", Value = sdkmanager.ConsoleVersion.ToString() });
            listItems.Add(new ListItem() { Setting = "Server Port", Value = sdkmanager.ServerPort.ToString() });
            
            listView.Adapter = new InfoAdapter(this, listItems);
        }
    }
}