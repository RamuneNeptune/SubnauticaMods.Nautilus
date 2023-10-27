

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static class Monos
        {
            public class MyData
            {
                public string[] URLs { get; set; }
            }


            public class PirateTunes : MonoBehaviour
            {
                public List<AudioClip> clips = new();
                public AudioSource source;


                public void Start()
                {
                    source = gameObject.EnsureComponent<AudioSource>();
                    source.volume = 0.4f;
                    source.loop = false;

                    CoroutineHost.StartCoroutine(GetAudioClips());

                    LoggerUtils.LogFatal(">> PirateTunes should be starting");
                }


                public IEnumerator GetAudioClips()
                {
                    var request = UnityWebRequest.Get("https://raw.githubusercontent.com/RamuneNeptune/SubnauticaMods.Nautilus/main/Mystery/URLs.json");
                    yield return request.SendWebRequest();

                    if(request.isNetworkError || request.isHttpError)
                    {
                        LoggerUtils.LogError("Error: " + request.error);
                    }
                    else
                    {
                        var rawText = request.downloadHandler.text;

                        if(rawText is null)
                            yield break;

                        var data = JsonConvert.DeserializeObject<MyData>(rawText);

                        if (data.URLs.Length == 0)
                            yield break;

                        foreach (var url in data.URLs)
                        {
                            if (url is null)
                                yield break;

                            using var request_ = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
                            yield return request_.SendWebRequest();

                            if(request_.isNetworkError || request_.isHttpError)
                            {
                                LoggerUtils.LogError(request_.error);
                            }
                            else
                            {
                                yield return new WaitUntil(() => Player.main);

                                var clip = DownloadHandlerAudioClip.GetContent(request_);

                                if(clip is not null)
                                    clips.Add(clip);
                            }
                        }
                    }

                    CoroutineHost.StartCoroutine(LoopSongs());
                }


                public IEnumerator LoopSongs()
                {
                    clips.Shuffle();

                    while (true)
                    {
                        foreach (var clip in clips)
                        {
                            if (clip is null)
                                yield break;

                            if (source is null)
                                yield break;

                            if (source.isPlaying)
                            {
                                while (source.isPlaying)
                                    yield return null;
                            }

                            source.clip = clip;
                            source.Play(1);


                            var length = TimeSpan.FromSeconds(clip.length);
                            LoggerUtils.LogSubtitle($"Playing next track, length: {string.Format("{0:00}:{1:00}", (int)length.TotalMinutes, (int)length.Seconds)}");
                        }
                    }
                }
            }
        }
    }
}