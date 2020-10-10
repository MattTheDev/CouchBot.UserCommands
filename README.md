![.NET Core](https://github.com/MattTheDev/CouchBot.UserCommands/workflows/.NET%20Core/badge.svg?branch=main)
<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-1-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->

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

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/FarshanAhamed"><img src="https://avatars0.githubusercontent.com/u/15251751?v=4" width="100px;" alt=""/><br /><sub><b>Farshan Ahamed</b></sub></a><br /><a href="https://github.com/MattTheDev/CouchBot.UserCommands/commits?author=FarshanAhamed" title="Code">💻</a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!