using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;


public class Notification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var notifc = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notifc);

        var notification = new AndroidNotification();
        notification.Title = "Farmbili";
        notification.Text = "Thank you for supporting";
        notification.FireTime = System.DateTime.Now.AddMinutes(5);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
