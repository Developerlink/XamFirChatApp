using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamFirChatApp.Model;

namespace XamFirChatApp.ViewModel.Helpers
{
    public interface IFirestore
    {
        bool InsertSubscription(Subscription subscription);
        Task<bool> DeleteSubscription(Subscription subscription);
        Task<bool> UpdateSubscription(Subscription subscription);   
        Task<IList<Subscription>> GetSubscriptionsAsync();
        
        
    }

    public class FirestoreHelper
    {
        //private static IFirestore _firestore = DependencyService.Get<IFirestore>();

        //public static Task<bool> DeleteSubscription(Subscription subscription)
        //{
        //    return _firestore.DeleteSubscription(subscription);
        //}

        //public static Task<IList<Subscription>> GetSubscriptionsAsync()
        //{
        //    return _firestore.GetSubscriptionsAsync();
        //}

        //public static bool InsertSubscription(Subscription subscription)
        //{
        //    return _firestore.InsertSubscription(subscription);
        //}

        //public static Task<bool> UpdateSubscription(Subscription subscription)
        //{
        //    return _firestore.UpdateSubscription(subscription);
        //} 
    }
}
