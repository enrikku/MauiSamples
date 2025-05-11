using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Widget;
using System;
using Android.App;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSamples.Platforms.Android
{
    public class SpeechRecognizerHelper : Java.Lang.Object, IRecognitionListener
    {
        private readonly SpeechRecognizer _speechRecognizer;
        private readonly Intent _speechIntent;
        private readonly Action<string> _onResult;
        private readonly Context context = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;

        public SpeechRecognizerHelper(Action<string> onResult)
        {
            _onResult = onResult;

            _speechRecognizer = SpeechRecognizer.CreateSpeechRecognizer(context);
            _speechRecognizer.SetRecognitionListener(this);

            _speechIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            _speechIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            _speechIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
        }

        public void StartListening()
        {
            _speechRecognizer.StartListening(_speechIntent);
            Toast.MakeText(context, "Listening...", ToastLength.Short).Show();
        }

        public void StopListening() => _speechRecognizer.StopListening();

        public void OnResults(Bundle results)
        {
            var matches = results.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
            string text = matches.Count > 0 ? matches[0] : string.Empty;
            _onResult.Invoke(text);
        }

        public void OnReadyForSpeech(Bundle @params)
        { }

        public void OnBeginningOfSpeech()
        { }

        public void OnRmsChanged(float rmsdB)
        { }

        public void OnBufferReceived(byte[] buffer)
        { }

        public void OnEndOfSpeech()
        { }

        public void OnError([GeneratedEnum] SpeechRecognizerError error) =>
            Toast.MakeText(context, $"Error: {error}", ToastLength.Short).Show();

        public void OnPartialResults(Bundle partialResults)
        { }

        public void OnEvent(int eventType, Bundle @params)
        { }
    }
}