<img src="./marketing/Icon.png" width="128" height="128" />

# OpenTDB.Net
[![NuGet](https://img.shields.io/nuget/vpre/OpenTDB.Net.svg?maxAge=2592000?style=plastic)](https://www.nuget.org/packages/OpenTDB.Net)

An API wrapper for [OpenTDB](https://opentdb.com/), written in C#.

# Usage
This API uses a disposable class called `TdbClient`. This client stores all unique methods that can be called. You can request the count of a trivia category, request session tokens, questions, and global question counts.

## Example
This is an example that uses the `TdbClient` to request questions.

```cs
public async Task MethodAsync()
{
  using (TdbClient client = new TdbClient())
  {
    List<TriviaQuestion> questions = await client.GetQuestionsAsync(10);
  }
}
```

It is recommended that you use a single instance of a `TdbClient` class, although quick disposable usage is supported.
