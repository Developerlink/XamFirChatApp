using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamFirChatApp.Model;
using XamFirChatApp.ViewModel.Helpers;
using Firebase;

[assembly: Dependency(typeof(XamFirChatApp.Droid.Dependencies.Firestore))]
namespace XamFirChatApp.Droid.Dependencies
{
    public class Firestore //: IFirestore
    {
        //public Task<bool> DeleteSubscription(Subscription subscription)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IList<Subscription>> GetSubscriptionsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool InsertSubscription(Subscription subscription)
        //{
        //    try
        //    {
        //        var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("");
        //        var subscriptionDocument = new Dictionary<string, Java.Lang.Object>
        //    {
        //        { "author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
        //        { "name", subscription.Name },
        //        { "isActive", subscription.IsActive },
        //        { "subscriptionDate", DateTimeToNativeDate(subscription.SupscriptionDate) }
        //    };
        //        collection.Add(subscriptionDocument);

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public Task<bool> UpdateSubscription(Subscription subscription)
        //{
        //    throw new NotImplementedException();
        //}

        //private static Date DateTimeToNativeDate(DateTime date)
        //{
        //    long dateTimeUtcAsMilliseconds = (long)date.ToUniversalTime()
        //        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
        //        .TotalMilliseconds;
        //    return new Date(dateTimeUtcAsMilliseconds);
        //}
    }
}