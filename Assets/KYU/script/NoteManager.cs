using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    List<NoteInfo> list;
    float currentTime;
    int flowIndex;
    bool isMakeNote;
    public GameObject[] spawns;
    public float setOffset = 2.5f;
    public GameObject[] noteFactory;
    public GameObject longnoteFactoryA;
    public GameObject longnoteFactoryB;
    public AudioClip bgm;
    public Transform noteMove;

    // Start is called before the first frame update
    void Start()
    {
        list = Loader();
        //for (int i = 0; i < list.Count; i++)
        //{
        //    list[i].Show();
        //}
        isMakeNote = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMakeNote == false)
        {
            return;
        }

        if (setOffset > 0)
        {
            setOffset -= Time.deltaTime;
            if (setOffset <= 0)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = bgm;
                audioSource.Play();
            }
        }

        // 시간이 흐르다가
        currentTime += Time.deltaTime;
        if (flowIndex < 0 || flowIndex >= list.Count)
        {
            // list의 범위를 벗어났으면 여기서 함수 종료
            return;
        }
        NoteInfo info = list[flowIndex];
        // 현재시간이 노트를 만들 시간되었으면
        if (currentTime >= info.time)
        {
            MakeNote(info);
        }
    }

    void MakeNote(NoteInfo info)
    {
        // 노트를 타입에 맞게 만들고
        int noteType = info.noteType;
        GameObject note = Instantiate(noteFactory[noteType]);
        print(noteFactory[noteType]);
        note.transform.position = spawns[info.noteIndex].transform.position;
        // 나의 부모 = 너
        note.transform.parent = noteMove;
        // 다음 노트 만들시간을 목표로 가게 하고싶다.
        flowIndex++;
        // 만약 더이상 만들 노트가 없으면 멈추고싶다. 
        if (flowIndex >= list.Count)
        {
            // 스톱!
            isMakeNote = false;
        }
        else
        {
            // 노트가 있는데
            NoteInfo nextInfo = list[flowIndex];
            // 만약 방금 만든 노트와 같은시간에 만들어야한다면 ?
            if (info.time == nextInfo.time)
            {
                // 재귀호출
                MakeNote(nextInfo);
            }
        }
    }

    public TextAsset noteText;
    List<NoteInfo> Loader()
    {
        List<NoteInfo> result = new List<NoteInfo>();
        string textss = noteText.text.Replace("\r", ""); // 보험
        string[] strings = textss.Split('\n'); // 줄바꿈으로 다음 줄 불러오기
        for (int i = 0; i < strings.Length; i++) //0부터 전체 길이까지 한 줄씩 불러온다.
        {
            NoteInfo noteInfo = new NoteInfo();
            noteInfo.Parse(strings[i]);
            result.Add(noteInfo);
        }

        return result;
    }//배열 1 라인번호, 배열 2 시간

}

public class NoteInfo
{
    public int noteIndex;
    public float time;
    public int noteType;
    public int noteLeagth;

    string info;

    public void Parse(string info) // parse = 문자열을 숫자로 변환시키기 위함
    {
        this.info = info;
        string[] s = info.Split(','); // ','로 구별
        int.TryParse(s[0], out noteIndex); // 결과값을 noteIndex에 저장하라

        if (noteIndex == 42) noteIndex = 0;
        else if (noteIndex == 64) noteIndex = 0;
        else if (noteIndex == 128) noteIndex = 1;
        else if (noteIndex == 192) noteIndex = 2;
        else if (noteIndex == 213) noteIndex = 2;
        else if (noteIndex == 320) noteIndex = 3;
        else if (noteIndex == 298) noteIndex = 3;
        else if (noteIndex == 384) noteIndex = 4;
        else if (noteIndex == 469) noteIndex = 5;
        else if (noteIndex == 448) noteIndex = 5;
        else if (noteIndex == 100) noteIndex = 6;
        else if (noteIndex == 200) noteIndex = 7;


        float.TryParse(s[2], out time);
        time /= 1000f;
        int.TryParse(s[3], out noteType);
        if (noteType == 1) noteType = 0;//싱글노트
        else if (noteType == 128) noteType = 1;//4박자 롱노트
        else if (noteType == 129) noteType = 2;//16박자 롱노트
        else if (noteType == 130) noteType = 3;//3줄노트
    }
}