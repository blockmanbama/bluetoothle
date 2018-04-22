﻿using System;
using System.Reflection;
using Acr.UserDialogs;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xunit.Runners.UI;


namespace Plugin.BluetoothLE.Android.Tests
{
    [Activity(
        Label = "BLE Plugin Tests",
        MainLauncher = true
    )]
    public class MainActivity : RunnerActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //GattConnectionConfig.DefaultConfiguration.AndroidAutoConnect = false;

            this.RequestPermissions(new[]
            {
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.BluetoothPrivileged
            }, 0);

            UserDialogs.Init(() => (Activity)Forms.Context);
            this.AddTestAssembly(typeof(BluetoothLE.Tests.DeviceTests).Assembly);
            this.AddTestAssembly(Assembly.GetExecutingAssembly());

            //CrossBleAdapter.AndroidUseNewScanner = false;
            CrossBleAdapter.AndroidOperationPause = TimeSpan.FromMilliseconds(100);
            //CrossBleAdapter.AndroidMaxAutoReconnectAttempts = 2;
            //CrossBleAdapter.AndroidPerformActionsOnMainThread = false;

            this.AutoStart = false;
            this.TerminateAfterExecution = false;
            //this.Writer =

            base.OnCreate(bundle);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
        }
    }
}

