using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class noteGeneratorScript : MonoBehaviour
{
    TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();
    public AudioSource AS;
    public AudioClip beatSE;
    AudioClip musicMP3;
    int beat = 0;
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
        if (Input.GetButtonDown("Jump")) onPlay = true;

        if (onPlay)
        {
            if (musicCounbter == 0) Invoke("MusicStart", float.Parse(csvDatas[0][4]));


            musicCounbter += Time.deltaTime;
            beat = (int)(musicCounbter / (60 / float.Parse(csvDatas[0][3])));
            Debug.Log(beat);

            if (beat + "" == csvDatas[noteCount][0])
            {
                Instantiate(
            notesIcon, new Vector3(0, 5, 0), Quaternion.identity);
            noteCount++;
            }




            if (beat != oldBeat)
            {
                AS.PlayOneShot(beatSE);
            }
            oldBeat = beat;
        }

    }

    void MusicStart()
    {

        AS.PlayOneShot(musicMP3);
    }






}
