using System;
using Android.Speech.Tts;
using Java.Interop;
using TextToSpeechDemo.Droid.Services;
using Xamarin.Forms;
[assembly: Dependency(typeof(TextToSpeechImplementation))]

namespace TextToSpeechDemo.Droid.Services
{
    public class TextToSpeechImplementation : Java.Lang.Object, TextToSpeech.IOnInitListener,ITextToSpeech
    {
        TextToSpeech speaker;
        public IntPtr Handle => throw new NotImplementedException();

        public int JniIdentityHashCode => throw new NotImplementedException();

        public JniObjectReference PeerReference => throw new NotImplementedException();

        public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        public void Speak(string text)
        {
            if (speaker == null)
            {
                speaker = new TextToSpeech(Forms.Context, this, "com.google.android.tts");
                var lang = "ar";
                var locale = new Java.Util.Locale(lang);
                speaker.SetLanguage(locale);
                speaker.Speak(text, QueueMode.Flush, null);
            }
            else
            {
                speaker.Speak(text, QueueMode.Flush,null );
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
        }
        #endregion

       

        public void SetJniIdentityHashCode(int value)
        {
            throw new NotImplementedException();
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            throw new NotImplementedException();
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            throw new NotImplementedException();
        }

        public void UnregisterFromRuntime()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnlessReferenced()
        {
            throw new NotImplementedException();
        }

        public void Disposed()
        {
            throw new NotImplementedException();
        }

        public void Finalized()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

     
    }
}