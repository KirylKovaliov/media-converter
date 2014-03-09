Easy way to convert video/audio with .net framework and avconv.exe or ffmpeg.exe

.NET wrapper around avconv.exe or ffmpeg.exe to convert audio/video to format accepted by HTML5 and most of the mordenest browsers.

Usage
-----

Decode video using H254 codec
```csharp

var options = AvOptions.H254Video(@"movie.mp4", string.Format(@"{0}\result.mp4", OutputDir));
MediaConvertor converter = new MediaConvertor();
Task task = converter.Convert(options);

Task.WaitAll(task);
```

Decode video to ogv format using Theora and Vorbis codecs
```csharp
var options = AvOptions.OggVideo(@"movie.mp4", string.Format(@"{0}\result.ogv", OutputDir));
MediaConvertor converter = new MediaConvertor();
Task task = converter.Convert(options);

Task.WaitAll(task);
```

Decode video webm format using VP8 codec
```csharp
var options = AvOptions.WebmVideo(@"Data\movie.mp4", string.Format(@"{0}\result.webm", OutputDir));
MediaConvertor converter = new MediaConvertor();
Task task = converter.Convert(options);

Task.WaitAll(task);
```

The same list of options are available for audio convertation

Extract preview from video file
-----
```csharp
string output = string.Format(@"{0}\preview.png", OutputDir);

MediaConvertor converter = new MediaConvertor();
Task task = converter.ExtractPreview(@"Data\movie.mp4", output);

Task.WaitAll(task);
```

See more examples in project Unit tests

