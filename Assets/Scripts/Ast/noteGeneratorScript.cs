using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class noteGeneratorScript : MonoBehaviour
{
    TextAsset csvFile;
    float beat = 0;
    public List<string[]> csvDatas = new List<string[]>();
    public AudioSource AS;
    public AudioClip beatSE;

    void Awake()
    {
        csvFile = Resources.Load("Csvs/asatogotsu") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
        Debug.Log(csvDatas[0][3]);//bpm
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
