﻿using UnityEngine;
using System.Collections;

public class ShoutInput : MonoBehaviour  {
     
        public static float MicLoudness;

		public static bool ShoutActive;
		public static float SmoothedLoudness;
		public static float SmoothedSqLoudness;

		public static int ShoutPower;
		public static float ShoutPowerf;

		public float boost = 1;

		[Range(0,1)]
		public float Loudness;
		[Range(0,1)]
		public float SqLoudness;

		[Range(0,1)]
		public float[] Threshes;
		public int Power;
		public bool Active;
		public float decay;
 
        private string _device;

        float since = 0;
     
        //mic initialization
        void InitMic(){
            if(_device == null) _device = Microphone.devices[0];
            _clipRecord = Microphone.Start(_device, true, 999, 44100);
        }
     
        void StopMicrophone()
        {
            Microphone.End(_device);
        }
     
 
        AudioClip _clipRecord = new AudioClip();
        int _sampleWindow = 128;
     
        //get data from microphone into audioclip
        float  LevelMax()
        {
            float levelMax = 0;
            float[] waveData = new float[_sampleWindow];
            int micPosition = Microphone.GetPosition(null)-(_sampleWindow+1); // null means the first microphone
            if (micPosition < 0) return 0;
            _clipRecord.GetData(waveData, micPosition);
            // Getting a peak on the last 128 samples
            for (int i = 0; i < _sampleWindow; i++) {
                float wavePeak = Mathf.Abs(waveData[i]);// * waveData[i];
				//wavePeak *= 10;
                if (levelMax < wavePeak) {
                    levelMax = wavePeak;
                }
            }
            return levelMax;
        }
     
     
     
        void Update()
        {
            // levelMax equals to the highest normalized value power 2, a small number because < 1
            // pass the value to a static var so we can access it from anywhere
            MicLoudness = LevelMax ();
			Loudness = Mathf.Max(Loudness-decay*Time.deltaTime, MicLoudness*boost);
			SqLoudness = Loudness*Loudness;
			SmoothedLoudness = Loudness;
			SmoothedSqLoudness = SqLoudness;
			Active = Loudness>Threshes[0];
			Power = 0;
			if (Active){
				foreach (float Thresh in Threshes){
					if (Loudness>Thresh)
						Power++;
				}
			}
			ShoutPower = Power;
			ShoutPowerf = Mathf.Max(ShoutPowerf-decay*Time.deltaTime,Power);
			ShoutActive = Active;
            if (Active){
                since = 0;
            }
            since+=Time.deltaTime;
            if (since>30){
                gameObject.AddComponent<ResetEverything>().seconds=0;
            }
        }
     
        bool _isInitialized;
        // start mic when scene starts
        void OnEnable()
        {
            InitMic();
            _isInitialized=true;
        }
     
        //stop mic when loading a new level or quit application
        void OnDisable()
        {
            StopMicrophone();
        }
     
        void OnDestroy()
        {
            StopMicrophone();
        }
     
     
        // make sure the mic gets started & stopped when application gets focused
        void OnApplicationFocus(bool focus) {
            if (focus)
            {
                //Debug.Log("Focus");
             
                if(!_isInitialized){
                    //Debug.Log("Init Mic");
                    InitMic();
                    _isInitialized=true;
                }
            }      
            if (!focus)
            {
                //Debug.Log("Pause");
                StopMicrophone();
                //Debug.Log("Stop Mic");
                _isInitialized=false;
             
            }
        }
    }
