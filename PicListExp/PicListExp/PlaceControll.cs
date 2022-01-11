﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PicListExp
{

    internal class PlaceControll
    {
        CancellationTokenSource cts;

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }

        public delegate void LocationHandler(LocationResult result);
        public event LocationHandler OnLocation;

        public bool SaveData()
        {
            // сохранить данные в БД
            return false;
        }
        public async Task<LocationResult> GetLocationAsync()
        {
            GeolocationRequest request = new GeolocationRequest();
            request.Timeout = TimeSpan.FromSeconds(60);
            request.DesiredAccuracy = GeolocationAccuracy.Best;
            cts = new CancellationTokenSource();
            LocationResult result = new LocationResult();

            try
            {
                Location location = await Geolocation.GetLocationAsync(request, cts.Token);
                
                if (location != null)
                {
                    result.isError = false;
                    result.Location = location;
                    result.Message = "Success";
                    OnLocation?.Invoke(result);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                result.isError = true;
                result.Location = null;
                result.Message = "Device is not supported";

            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                result.isError = true;
                result.Location = null;
                result.Message = fneEx.Message;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                result.isError = true;
                result.Location = null;
                result.Message = pEx.Message;
            }
            catch (Exception ex)
            {
                // Unable to get location
                result.isError = true;
                result.Location = null;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ImageSource> SetImage(bool isFoto)
        {
            FileResult capture;
            if (isFoto)
            {
                capture = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions());
            }
            else
            {
                capture = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Landmark picture" });
            }
               
            if (capture == null)
            {
                return null;
            }
            var stream = await capture.OpenReadAsync();
            return ImageSource.FromStream(() => stream);
        }

        public void Destroy()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
        }
        
    }
    public struct LocationResult
        {
            public bool isError { get; set; }
            public string Message { get; set; }
            public Location Location { get; set; }
        }
}