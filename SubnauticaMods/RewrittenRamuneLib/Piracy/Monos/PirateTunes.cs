

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Monos
        {
            public class MyData
            {
                public string[] URLs { get; set; }
            }


            public class PirateTunes : MonoBehaviour
            {
                public static List<AudioClip> clips = new();
                public static AudioSource source;
                public static int clipIndex = 0;


                public void Update()
                {
                    if(!GameInput.AnyKeyDown())
                        return;

                    if(Cursor.visible)
                        return;

                    if(GameInput.GetKeyDown(KeyCode.Period))
                        source.Stop();
                }


                public void Start()
                {
                    var go = new GameObject("PirateTunes");
                    go.transform.parent = gameObject.transform;

                    source = go.EnsureComponent<AudioSource>();
                    source.volume = 0.095f;
                    source.loop = false;

                    CoroutineHost.StartCoroutine(GetAudioClips());
                }


                public IEnumerator LoopSongs()
                {
                    LoggerUtils.LogSubtitle($"PIRATE TUNES: Thanks for choosing Pirate Tunes as your preferred music player", 4);

                    while (true)
                    {
                        for(int i = 0; i < clips.Count; i++)
                        {
                            var clip = clips[i];

                            if(source is null)
                                yield break;

                            if(clip is null)
                            {
                                clips.Remove(clip);
                                continue;
                            }

                            while(source.isPlaying)
                                yield return null;

                            source.clip = clip;
                            source.Play();

                            var length = TimeSpan.FromSeconds(clip.length);
                            LoggerUtils.LogSubtitle($"PIRATE TUNES: Playing {clip.name}, length: {string.Format("{0:00}:{1:00}", (int)length.TotalMinutes, length.Seconds)} ({i + 1}/{clips.Count})", 5);
                        }
                    }
                }


                public IEnumerator GetAudioClips()
                {
                    var request = UnityWebRequest.Get("https://raw.githubusercontent.com/RamuneNeptune/SubnauticaMods.Nautilus/main/Mystery/URLs.json");
                    yield return request.SendWebRequest();

                    if(request.isNetworkError || request.isHttpError)
                    {
                        LoggerUtils.LogError("PirateTunes.GetAudioClips: " + request.error);
                        yield break;
                    }

                    var rawText = request.downloadHandler.text;

                    if(rawText is null)
                        yield break;

                    var data = JsonConvert.DeserializeObject<MyData>(rawText);
                    var list = data.URLs.ToList();
                    list.RemoveAll(url => url is null);

                    float urls = list.Count;
                    float currentValue = 0f;

                    foreach(string url in list)
                    {
                        using var _ = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
                        yield return _.SendWebRequest();

                        if(_.isNetworkError || _.isHttpError)
                        {
                            LoggerUtils.LogError("PirateTunes.GetAudioClips: " + _.error);
                            yield break;
                        }

                        yield return new WaitUntil(() => Player.main);
                        var clip = DownloadHandlerAudioClip.GetContent(_);

                        if(clip != null)
                        {
                            clip.name = Path.GetFileName(url);
                            clips.Add(clip);
                        }

                        currentValue++;
                        float progressPercentage = (currentValue / urls) * 100f;
                        string formattedPercentage = progressPercentage.ToString("F1");

                        LoggerUtils.LogSubtitle($"PIRATE TUNES: Processing {formattedPercentage}% complete..", 1);
                    }

                    clips.Shuffle();
                    CoroutineHost.StartCoroutine(LoopSongs());
                }
            }
        }
    }
}