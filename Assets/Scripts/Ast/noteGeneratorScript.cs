using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class noteGeneratorScript : MonoBehaviour
{
    TextAsset csvFile;
    float beat;
    public List<string[]> csvDatas = new List<string[]>();
    public AudioSource AS;
    public AudioClip beatSE;
    AudioClip musicMP3;
    void Awake()
    {
        csvFile = Resources.Load("Csvs/asatogotsu") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
        beat = float.Parse(csvDatas[0][4]);//beat開始ディレイ
        musicMP3 = Resources.Load("Sounds/"+csvDatas[0][0]) as AudioClip;//曲データ
        Debug.Log(csvDatas[0][3]);//bpm
    }

    void Start() {
        AS.PlayOneShot(musicMP3);
    }


    void Update()
    {
        beat += Time.deltaTime;
        if (beat >= 60 / float.Parse(csvDatas[0][3]))
        {
            beat = 0;
            AS.PlayOneShot(beatSE);
        };
        Debug.Log(beat);

    }








}
