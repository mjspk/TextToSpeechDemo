using System;
using System.Collections.Generic;
using System.Text;

namespace TextToSpeechDemo
{
    public interface  ITextToSpeech
    {
        void Speak(string text);
    }
}
