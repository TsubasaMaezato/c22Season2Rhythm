using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class noteGeneratorScript : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();
    public AudioSource seAS;
    public AudioSource bgmAS;
    public AudioClip beatSE;
    AudioClip musicMP3;
    float beat = 0;
    int oldBeat = 0;
    bool onPlay = false;
    float musicCounbter = 0;
    public GameObject notesIcon;

    int noteCount = 1;
    void Awake()
    {
        Application.targetFrameRate = 60;
        csvFile = Resources.Load("Csvs/asatogotsu") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }

    void Start()
    {
        //beat = float.Parse(csvDatas[0][4]);//beat開始ディレイ
        musicMP3 = Resources.Load("Sounds/" + csvDatas[0][0]) as AudioClip;//曲データ
        Debug.Log(csvDatas[0][3]);//bpm
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) onPlay = true;

        if (onPlay)
        {
            if (musicCounbter == 0) Invoke("MusicStart", float.Parse(csvDatas[0][4]));


            musicCounbter += Time.deltaTime;
            beat = musicCounbter / (60 / float.Parse(csvDatas[0][3]));
            //Debug.Log(beat);

            // csvDatas[noteCount][0] noteCount行に入っているnBeat
            // csvDatas[noteCount][1] 1 n.0  2 n.25  3 n.5  4 1.75
            float noteBeat;
            switch ((int)float.Parse(csvDatas[noteCount][1]))
            {
                case 1:
                    noteBeat = float.Parse(csvDatas[noteCount][0] + ".0");
                    break;
                case 2:
                    noteBeat = float.Parse(csvDatas[noteCount][0] + ".25");
                    break;
                case 3:
                    noteBeat = float.Parse(csvDatas[noteCount][0] + ".5");
                    break;
                case 4:
                    noteBeat = float.Parse(csvDatas[noteCount][0] + ".75");
                    break;
                default:
                    noteBeat = float.Parse(csvDatas[noteCount][0] + ".0");
                    break;
            }

            Debug.Log(beat + " : " + noteBeat);
            if (beat >= noteBeat)
            {
                Instantiate(
            notesIcon, new Vector3(0, 5, 0), Quaternion.identity);
                noteCount++;//行数のカウント
            }


            /// /2 /4 /8 beat

            if ((int)beat != oldBeat)
            {
                seAS.PlayOneShot(beatSE);
            }
            oldBeat = (int)beat;
        }
    }

    void MusicStart()
    {

        bgmAS.PlayOneShot(musicMP3);
    }






}
