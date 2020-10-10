# CouchBot - Submit A Command!

Want to create a command that may become a part of CouchBot? This is where you can do just that!

1. Fork / Clone the repository.
2. Open in Visual Studio [Community Edition is Free](https://visualstudio.microsoft.com/downloads/)
3. Open Modules/UserCommands.cs
4. Copy / Paste the code block provided.

```csharp
[Command("commandName", RunMode = RunMode.Async)]
[Alias("alias1", "alias2", "etc")]
[Summary("Description of the command")]
public Task CommandAsync()
{
    return ReplyAsync("Your Return Text!");
}
```

5. Create your command.
6. Create a PR, making sure to explain what the command does, and show proof of functionality (screenshot)

Thanks for contributing towards CouchBot! 