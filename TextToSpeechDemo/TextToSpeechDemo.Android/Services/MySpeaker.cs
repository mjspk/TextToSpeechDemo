using System;
using System.Linq;
using Android.Speech.Tts;
using Java.Interop;
using TextToSpeechDemo.Droid.Services;
using Xamarin.Forms;


namespace TextToSpeechDemo.Droid.Services
{
    public class MySpeaker : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
       
        public MySpeaker()
        {
            if (speaker == null)
            {
                speaker = new TextToSpeech(Forms.Context, this, "com.google.android.tts");
              
            }
        }
        public void Speak(string text)
        {
            if (speaker != null)
            {
              
                speaker.Speak(text, QueueMode.Flush, null);
            }
            
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            speaker.SetLanguage(new Java.Util.Locale("ar"));
        }
        #endregion

       

        public void SetJniIdentityHashCode(int value)
        {
        }

        public void SetPeerReference(JniObjectReference reference)
        {
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
        }

        public void UnregisterFromRuntime()
        {
        }

        public void DisposeUnlessReferenced()
        {
        }

        public void Disposed()
        {
        }

        public void Finalized()
        {
        }

        public void Dispose()
        {
        }

     
    }
}